using PropertyChanged;

namespace OpenHardwareMonitorRemote.UWP.Models
{
    [ImplementPropertyChanged]
    public class PageDesign
    {
        public string Title { get; set; }

        public int SensorId { get; set; }

        public PageDesignType PageDesignType { get; set; }
    }
}