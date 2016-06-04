using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
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

        public ViewModelLocator()
        {
            if (_isInitialized) return;
            _isInitialized = true;

            RegisterDefaultServices();

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled) RegisterDesignServices();
            else RegisterRuntimeServices();
        }

        private static void RegisterDefaultServices()
        {
            SimpleIoc.Default.Register(CreateNavigationService);

            SimpleIoc.Default.Register<ConnectionsPageViewModel>();
            SimpleIoc.Default.Register<EditConnectionPageViewModel>();
        }

        private static void RegisterRuntimeServices()
        {
            SimpleIoc.Default.Register<IDataProvider, DataProvider>();
        }

        private static void RegisterDesignServices()
        {
            SimpleIoc.Default.Register<IDataProvider, Services.Design.DataProvider>();
        }

        private static INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();

            navigationService.Configure(typeof(ConnectionsPage));
            navigationService.Configure(typeof(EditConnectionPage));

            return navigationService;
        }
    }
}
