﻿using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using OpenHardwareMonitorRemote.UWP.Models;
using OpenHardwareMonitorRemote.UWP.Helpers.Extensions;
using OpenHardwareMonitorRemote.UWP.Models.Messages;
using OpenHardwareMonitorRemote.UWP.Views;

namespace OpenHardwareMonitorRemote.UWP.ViewModels
{
    public class EditConnectionPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private TaskCompletionSource<bool> _modalTaskCompletionSource;

        private Connection _connection = new Connection();

        public Connection Connection
        {
            get { return _connection; }
            set
            {
                if (Connection == value) return;

                _connection = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand OkCommand { get; }

        public RelayCommand CancelCommand { get; }

        public EditConnectionPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            OkCommand = new RelayCommand(() => SetModalResultAndNavigateBack(true));
            CancelCommand = new RelayCommand(() => SetModalResultAndNavigateBack(false));

            Messenger.Default.Register<NavigatedFromPageMessage>(this, NavigatedFromPage);
        }

        private void SetModalResultAndNavigateBack(bool result)
        {
            _modalTaskCompletionSource?.TrySetResult(result);

            _navigationService.GoBack();
        }

        private void NavigatedFromPage(NavigatedFromPageMessage navigatedFromPageMessage)
        {
            if (navigatedFromPageMessage.PageNavigatedFrom.GetType() != typeof(EditConnectionPage)) return;

            _modalTaskCompletionSource?.TrySetResult(false);
        }

        public Task<bool> ShowAsModal()
        {
            _modalTaskCompletionSource = new TaskCompletionSource<bool>();

            _navigationService.NavigateTo(typeof(EditConnectionPage));

            return _modalTaskCompletionSource.Task;
        }
    }
}