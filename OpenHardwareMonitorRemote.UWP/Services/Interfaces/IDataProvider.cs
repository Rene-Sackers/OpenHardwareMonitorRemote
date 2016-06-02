using System.Collections.Generic;
using OpenHardwareMonitorRemote.UWP.Models;

namespace OpenHardwareMonitorRemote.UWP.Services.Interfaces
{
    public interface IDataProvider
    {
        IEnumerable<Connection> GetConnections();
    }
}