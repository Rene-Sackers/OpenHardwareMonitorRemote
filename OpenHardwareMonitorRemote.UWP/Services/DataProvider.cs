using Windows.Storage;
using OpenHardwareMonitorRemote.UWP.Helpers.Extensions;
using OpenHardwareMonitorRemote.UWP.Models;
using OpenHardwareMonitorRemote.UWP.Services.Interfaces;

namespace OpenHardwareMonitorRemote.UWP.Services
{
    public class DataProvider : IDataProvider
    {
        private const string StoredDataKey = "Data";

        private ApplicationDataContainer GetApplicationDataContainer()
        {
            return ApplicationData.Current.RoamingSettings;
        }

        public StoredApplicationData GetStoredApplicationData()
        {
            return GetApplicationDataContainer().GetStoredObject(StoredDataKey, new StoredApplicationData());
        }

        public void SaveStoredApplicationData(StoredApplicationData storedApplicationData)
        {
            GetApplicationDataContainer().StoreObject(StoredDataKey, storedApplicationData);
        }
    }
}
