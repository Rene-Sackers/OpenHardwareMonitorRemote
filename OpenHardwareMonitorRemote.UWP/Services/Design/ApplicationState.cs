using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using OpenHardwareMonitorRemote.UWP.Models;
using OpenHardwareMonitorRemote.UWP.Services.Interfaces;

namespace OpenHardwareMonitorRemote.UWP.Services.Design
{
    public class ApplicationState : IApplicationState
    {
        public Connection ActiveConnection { get; set; } = new Connection
        {
            Title = "Design Time Connection",
            Ip = "http://localhost/",
            Port = 80,
            PageDesigns = new ObservableCollection<PageDesign>(new []
            {
                new PageDesign
                {
                    Title = "Example page 1",
                    PageDesignType = PageDesignType.Graph,
                    SensorId = 1
                }
            })
        };

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            throw new NotImplementedException();
        }
    }
}
