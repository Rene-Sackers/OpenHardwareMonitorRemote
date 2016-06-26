using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Messaging;
using OpenHardwareMonitorRemote.UWP.Models.Messages;

namespace OpenHardwareMonitorRemote.UWP.Views
{
    public sealed partial class EditConnectionPage
    {
        public EditConnectionPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Messenger.Default.Send(new NavigatedFromPageMessage {PageNavigatedFrom = this});
            base.OnNavigatedFrom(e);
        }
    }
}
