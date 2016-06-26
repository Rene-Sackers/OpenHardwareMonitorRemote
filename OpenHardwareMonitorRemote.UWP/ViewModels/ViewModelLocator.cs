using Windows.UI.Notifications;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using OpenHardwareMonitorRemote.UWP.Helpers.Extensions;
using OpenHardwareMonitorRemote.UWP.Services;
using OpenHardwareMonitorRemote.UWP.Services.Interfaces;
using OpenHardwareMonitorRemote.UWP.Views;

namespace OpenHardwareMonitorRemote.UWP.ViewModels
{
    public class ViewModelLocator
    {
        private static bool _isInitialized;

        public ConnectionsPageViewModel ConnectionsPageViewModel => SimpleIoc.Default.GetInstance<ConnectionsPageViewModel>();

        public EditConnectionPageViewModel EditConnectionPagePageViewModel => SimpleIoc.Default.GetInstance<EditConnectionPageViewModel>();

        public LiveViewPageViewModel LiveViewPageViewModel => SimpleIoc.Default.GetInstance<LiveViewPageViewModel>();

        public ViewModelLocator()
        {
            if (_isInitialized) return;
            _isInitialized = true;

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            RegisterDefaultServices();

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled) RegisterDesignServices();
            else RegisterRuntimeServices();
        }

        private static void RegisterDefaultServices()
        {
            var navigationService = CreateNavigationService();
            SimpleIoc.Default.Register(() => navigationService);

            SimpleIoc.Default.Register<ConnectionsPageViewModel>();
            SimpleIoc.Default.Register<EditConnectionPageViewModel>();
            SimpleIoc.Default.Register<LiveViewPageViewModel>();
        }

        private static void RegisterRuntimeServices()
        {
            SimpleIoc.Default.Register<IDataProvider, DataProvider>();
            SimpleIoc.Default.Register<IApplicationState, ApplicationState>();
        }

        private static void RegisterDesignServices()
        {
            SimpleIoc.Default.Register<IDataProvider, Services.Design.DataProvider>();
            SimpleIoc.Default.Register<IApplicationState, Services.Design.ApplicationState>();
        }

        private static INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();

            navigationService.Configure(typeof(ConnectionsPage));
            navigationService.Configure(typeof(EditConnectionPage));
            navigationService.Configure(typeof(LiveViewPage));

            return navigationService;
        }
    }
}
