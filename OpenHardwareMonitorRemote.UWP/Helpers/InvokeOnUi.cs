using System;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace OpenHardwareMonitorRemote.UWP.Helpers
{
    public static class InvokeOnUi
    {
        private static async Task Invoke(DispatchedHandler action)
        {
            await App.UiDispatcher.RunAsync(CoreDispatcherPriority.Normal, action);
        }
    }
}
