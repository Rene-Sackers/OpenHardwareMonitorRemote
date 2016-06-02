using System;
using System.Collections.Generic;
using OpenHardwareMonitorRemote.UWP.Models;
using OpenHardwareMonitorRemote.UWP.Services.Interfaces;

namespace OpenHardwareMonitorRemote.UWP.Services.Design
{
    public class DataProvider : IDataProvider
    {
        public StoredApplicationData GetStoredApplicationData()
        {
            var storedApplicationData = new StoredApplicationData
            {
                Connections = new List<Connection>()
            };
            
            const int connectionCount = 10;
            for (var i = 1; i <= connectionCount; i++)
            {
                storedApplicationData.Connections.Add(new Connection
                {
                    Title = "Design connection " + i,
                    Ip = "http://localhost/",
                    Port = 80
                });
            }

            return storedApplicationData;
        }

        public void SaveStoredApplicationData(StoredApplicationData storedApplicationData)
        {
            throw new NotImplementedException();
        }
    }
}
