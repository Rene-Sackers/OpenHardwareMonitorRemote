using System;
using Windows.Storage;

namespace OpenHardwareMonitorRemote.UWP.Helpers.Extensions
{
    public static class ApplicationDataContainerExtensions
    {
        public static T GetStoredObject<T>(this ApplicationDataContainer applicationDataContainer, string key, T @default = default(T))
        {
            return applicationDataContainer.Values.ContainsKey(key) ? (T)applicationDataContainer.Values[key] : @default;
        }
    }
}
