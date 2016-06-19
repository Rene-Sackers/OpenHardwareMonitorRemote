using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Core;
using GalaSoft.MvvmLight;
using OpenHardwareMonitorRemote.UWP.Models;

namespace OpenHardwareMonitorRemote.UWP.ViewModels
{
    public class LiveViewPageViewModel : ViewModelBase
    {
        public ObservableCollection<ChartItem> ChartItems { get; set; } = new ObservableCollection<ChartItem>();

        public LiveViewPageViewModel()
        {
            var random = new Random();
            
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    await Task.Delay(100);
                    
                    await InvokeOnUi(() =>
                    {
                        ChartItems.Add(new ChartItem
                        {
                            Date = DateTime.Now,
                            Value = random.Next(0, 101)
                        });
                    });
                }
            });
        }

        private static async Task InvokeOnUi(DispatchedHandler action)
        {
            await App.UiDispatcher.RunAsync(CoreDispatcherPriority.Normal, action);
        }
    }
}
