using Syncfusion.UI.Xaml.Charts;

namespace OpenHardwareMonitorRemote.UWP.Views
{
    public sealed partial class LiveViewPage
    {
        public LiveViewPage()
        {
            InitializeComponent();
        }

        private void ChartAxis_OnActualRangeChanged(object sender, ActualRangeChangedEventArgs e)
        {
            if (e.IsScrolling || e.ActualMaximum == null) return;

            e.VisibleMinimum = (double)e.ActualMaximum - 50d;
        }
    }
}
