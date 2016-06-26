using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using OpenHardwareMonitorRemote.UWP.Services.Interfaces;

namespace OpenHardwareMonitorRemote.UWP.ViewModels
{
    public class LiveViewPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public RelayCommand AddPageCommand { get; }

        public IApplicationState ApplicationState { get; set; }

        public LiveViewPageViewModel(IApplicationState applicationState, INavigationService navigationService)
        {
            _navigationService = navigationService;
            ApplicationState = applicationState;
            //ApplicationState.PropertyChanged += ApplicationStateOnPropertyChanged;
            
            AddPageCommand = new RelayCommand(AddView);
        }

        //private void ApplicationStateOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        //{
        //    if (propertyChangedEventArgs.PropertyName != nameof(IApplicationState.ActiveConnection)) return;


        //}

        private void AddView()
        {
            
        }
    }
}
