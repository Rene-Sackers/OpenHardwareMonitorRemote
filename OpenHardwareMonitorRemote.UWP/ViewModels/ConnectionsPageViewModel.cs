using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Xaml.Interactions.Core;
using OpenHardwareMonitorRemote.UWP.Models;
using OpenHardwareMonitorRemote.UWP.Models.Messages;
using OpenHardwareMonitorRemote.UWP.Services.Interfaces;
using OpenHardwareMonitorRemote.UWP.Views;

namespace OpenHardwareMonitorRemote.UWP.ViewModels
{
    public class ConnectionsPageViewModel : ViewModelBase
    {
        private readonly IDataProvider _dataProvider;
        private readonly IApplicationState _applicationState;
        private readonly EditConnectionPageViewModel _editConnectionPageViewModel;

        public ObservableCollection<Connection> Connections { get; }

        private Connection _selectedConnection;

        public Connection SelectedConnection
        {
            get { return _selectedConnection; }
            set
            {
                if (SelectedConnection == value) return;

                _selectedConnection = value;
                RaisePropertyChanged();

                ConnectToSelectedSelectedConnectionCommand.RaiseCanExecuteChanged();
                EditSelectedConnectionCommand.RaiseCanExecuteChanged();
                DeleteSelectedConnectionCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand AddConnectionCommand { get; set; }

        public RelayCommand ConnectToSelectedSelectedConnectionCommand { get; set; }

        public RelayCommand EditSelectedConnectionCommand { get; set; }

        public RelayCommand DeleteSelectedConnectionCommand { get; set; }

        public ConnectionsPageViewModel(IDataProvider dataProvider, IApplicationState applicationState, EditConnectionPageViewModel editConnectionPageViewModel)
        {
            _dataProvider = dataProvider;
            _applicationState = applicationState;
            _editConnectionPageViewModel = editConnectionPageViewModel;

            Connections = new ObservableCollection<Connection>(dataProvider.GetStoredApplicationData().Connections);

            AddConnectionCommand = new RelayCommand(AddConnection);
            ConnectToSelectedSelectedConnectionCommand = new RelayCommand(ConnectToSelectedConnection, () => SelectedConnection != null);
            EditSelectedConnectionCommand = new RelayCommand(EditSelectedConnection, () => SelectedConnection != null);
            DeleteSelectedConnectionCommand = new RelayCommand(DeleteSelectedConnection, () => SelectedConnection != null);
        }

        private async void AddConnection()
        {
            _editConnectionPageViewModel.Connection = new Connection();

            var modalResult = await _editConnectionPageViewModel.ShowAsModal();
            if (!modalResult) return;

            Connections.Add(_editConnectionPageViewModel.Connection);

            var storedData = _dataProvider.GetStoredApplicationData();
            storedData.Connections = Connections;
            _dataProvider.SaveStoredApplicationData(storedData);
        }

        private async void ConnectToSelectedConnection()
        {
            if (SelectedConnection == null)
            {
                await new MessageDialog("No connection selected.").ShowAsync();
                return;
            }

            _applicationState.ActiveConnection = SelectedConnection;
        }

        private async void EditSelectedConnection()
        {
            var currentOject = SelectedConnection.Clone();

            _editConnectionPageViewModel.Connection = SelectedConnection;
            var modalResult = await _editConnectionPageViewModel.ShowAsModal();
            if (!modalResult)
            {
                SelectedConnection.Title = currentOject.Title;
                SelectedConnection.Ip = currentOject.Ip;
                SelectedConnection.Port = currentOject.Port;
                return;
            }

            var storedData = _dataProvider.GetStoredApplicationData();
            storedData.Connections = Connections;
            _dataProvider.SaveStoredApplicationData(storedData);
        }

        private async void DeleteSelectedConnection()
        {
            var messageDialog =
                new MessageDialog($"Are you sure you want to delete the connection \"{SelectedConnection.Title}\"?", "Delete connection");

            var yesCommand = new UICommand("Yes");
            var noCommand = new UICommand("No");

            messageDialog.Commands.Add(yesCommand);
            messageDialog.Commands.Add(noCommand);

            var pressedCommand = await messageDialog.ShowAsync();

            if (pressedCommand != yesCommand) return;

            Connections.Remove(SelectedConnection);

            var storedData = _dataProvider.GetStoredApplicationData();
            storedData.Connections = Connections;
            _dataProvider.SaveStoredApplicationData(storedData);
        }
    }
}
