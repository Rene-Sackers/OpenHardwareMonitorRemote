using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using OpenHardwareMonitorRemote.UWP.Models;
using OpenHardwareMonitorRemote.UWP.Services.Interfaces;

namespace OpenHardwareMonitorRemote.UWP.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<Connection> Connections { get; }

        public MainPageViewModel(IDataProvider dataProvider)
        {
            Connections = new ObservableCollection<Connection>(dataProvider.GetStoredApplicationData().Connections);
        }
    }
}
