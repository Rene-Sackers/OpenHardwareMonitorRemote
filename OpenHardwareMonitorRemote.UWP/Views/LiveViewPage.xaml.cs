using System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using OpenHardwareMonitorRemote.UWP.Helpers.Extensions;
using OpenHardwareMonitorRemote.UWP.Services.Interfaces;
using Syncfusion.UI.Xaml.Charts;

namespace OpenHardwareMonitorRemote.UWP.Views
{
    public sealed partial class LiveViewPage
    {
        private readonly IApplicationState _applicationState;
        private readonly INavigationService _navigationService;

        public LiveViewPage()
        {
            _applicationState = SimpleIoc.Default.GetInstance<IApplicationState>();
            _navigationService = SimpleIoc.Default.GetInstance<INavigationService>();

            InitializeComponent();
        }

        private void ChartAxis_OnActualRangeChanged(object sender, ActualRangeChangedEventArgs e)
        {
            if (e.IsScrolling || e.ActualMaximum == null) return;

            e.VisibleMinimum = (double)e.ActualMaximum - 50d;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (_applicationState.ActiveConnection == null)
            {
                await new MessageDialog("No connection selected.").ShowAsync();
                _navigationService.NavigateTo(typeof(ConnectionsPage));
            }
        }
    }
}
