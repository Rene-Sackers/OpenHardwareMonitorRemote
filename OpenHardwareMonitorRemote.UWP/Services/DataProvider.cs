using Windows.Storage;
using OpenHardwareMonitorRemote.UWP.Helpers.Extensions;
using OpenHardwareMonitorRemote.UWP.Models;
using OpenHardwareMonitorRemote.UWP.Services.Interfaces;

namespace OpenHardwareMonitorRemote.UWP.Services
{
    public class DataProvider : IDataProvider
    {
        private const string StoredDataKey = "Data";

        public StoredApplicationData GetStoredApplicationData()
        {
            return ApplicationData.Current.RoamingSettings.GetStoredObject(StoredDataKey, new StoredApplicationData());
        }

        public void SaveStoredApplicationData(StoredApplicationData storedApplicationData)
        {
            ApplicationData.Current.RoamingSettings.Values[StoredDataKey] = storedApplicationData;
        }
    }
}
