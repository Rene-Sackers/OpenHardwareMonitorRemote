using System.Collections.ObjectModel;
using PropertyChanged;

namespace OpenHardwareMonitorRemote.UWP.Models
{
    [ImplementPropertyChanged]
    public class Connection
    {
        public string Title { get; set; }
        
        public string Ip { get; set; }
        
        public ushort Port { get; set; }

        public ObservableCollection<PageDesign> PageDesigns { get; set; } = new ObservableCollection<PageDesign>();

        public Connection Clone()
        {
            return new Connection
            {
                Title = Title,
                Ip = Ip,
                Port = Port
            };
        }
    }
}
