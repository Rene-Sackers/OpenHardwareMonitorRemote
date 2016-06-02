using System;
using System.Collections.Generic;
using OpenHardwareMonitorRemote.UWP.Models;
using OpenHardwareMonitorRemote.UWP.Services.Interfaces;

namespace OpenHardwareMonitorRemote.UWP.Services
{
    public class DataProvider : IDataProvider
    {
        public IEnumerable<Connection> GetConnections()
        {
            throw new NotImplementedException();
        }
    }
}
