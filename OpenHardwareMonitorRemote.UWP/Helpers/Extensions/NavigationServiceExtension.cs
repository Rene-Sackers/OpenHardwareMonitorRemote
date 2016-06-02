using System;
using GalaSoft.MvvmLight.Views;

namespace OpenHardwareMonitorRemote.UWP.Helpers.Extensions
{
    public static class NavigationServiceExtension
    {
        public static void NavigateTo(this INavigationService navigationService, Type pageType, object parameter = null)
        {
            if (parameter == null) navigationService.NavigateTo(pageType.FullName);
            else navigationService.NavigateTo(pageType.FullName, parameter);
        }

        public static void Configure(this NavigationService navigationService, Type pageType)
        {
            navigationService.Configure(pageType.FullName, pageType);
        }
    }
}
