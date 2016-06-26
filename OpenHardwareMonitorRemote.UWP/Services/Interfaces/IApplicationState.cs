using System.ComponentModel;
using OpenHardwareMonitorRemote.UWP.Models;

namespace OpenHardwareMonitorRemote.UWP.Services.Interfaces
{
    public interface IApplicationState : INotifyPropertyChanged
    {
        Connection ActiveConnection { get; set; } 
    }
}