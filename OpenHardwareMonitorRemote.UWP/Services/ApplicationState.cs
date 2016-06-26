using System.ComponentModel;
using System.Runtime.CompilerServices;
using OpenHardwareMonitorRemote.UWP.Annotations;
using OpenHardwareMonitorRemote.UWP.Models;
using OpenHardwareMonitorRemote.UWP.Services.Interfaces;
using PropertyChanged;

namespace OpenHardwareMonitorRemote.UWP.Services
{
    [ImplementPropertyChanged]
    public class ApplicationState : IApplicationState
    {
        public Connection ActiveConnection { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
