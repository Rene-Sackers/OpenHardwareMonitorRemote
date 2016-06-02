using GalaSoft.MvvmLight.Ioc;
using OpenHardwareMonitorRemote.UWP.Services;
using OpenHardwareMonitorRemote.UWP.Services.Interfaces;

namespace OpenHardwareMonitorRemote.UWP.ViewModels
{
    public class ViewModelLocator
    {
        private static bool _isInitialized;

        public MainPageViewModel MainPageViewModel => SimpleIoc.Default.GetInstance<MainPageViewModel>();

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
            SimpleIoc.Default.Register<MainPageViewModel>();
        }

        private static void RegisterRuntimeServices()
        {
            SimpleIoc.Default.Register<IDataProvider, DataProvider>();
        }

        private static void RegisterDesignServices()
        {
            SimpleIoc.Default.Register<IDataProvider, Services.Design.DataProvider>();
        }
    }
}
