using System.Collections.Generic;

namespace OpenHardwareMonitorRemote.UWP.Models
{
    public class StoredApplicationData
    {
        public ICollection<Connection> Connections { get; set; } = new Connection[0];
    }
}
