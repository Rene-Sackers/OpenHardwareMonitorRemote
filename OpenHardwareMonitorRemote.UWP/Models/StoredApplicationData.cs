using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenHardwareMonitorRemote.UWP.Models
{
    [DataContract]
    public class StoredApplicationData
    {
        [DataMember]
        public ICollection<Connection> Connections { get; set; } = new Connection[0];
    }
}
