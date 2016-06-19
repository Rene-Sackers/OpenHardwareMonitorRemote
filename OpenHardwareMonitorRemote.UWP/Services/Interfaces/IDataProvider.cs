using OpenHardwareMonitorRemote.UWP.Models;

namespace OpenHardwareMonitorRemote.UWP.Services.Interfaces
{
    public interface IDataProvider
    {
        StoredApplicationData GetStoredApplicationData();

        void SaveStoredApplicationData(StoredApplicationData storedApplicationData);
    }
}