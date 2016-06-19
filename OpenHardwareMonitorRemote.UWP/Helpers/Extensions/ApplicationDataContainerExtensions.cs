using Windows.Storage;
using Newtonsoft.Json;

namespace OpenHardwareMonitorRemote.UWP.Helpers.Extensions
{
    public static class ApplicationDataContainerExtensions
    {
        public static T GetStoredObject<T>(this ApplicationDataContainer applicationDataContainer, string key, T @default = default(T))
        {
            if (!applicationDataContainer.Values.ContainsKey(key)) return @default;

            var serializedObject = (string)applicationDataContainer.Values[key];

            return JsonConvert.DeserializeObject<T>(serializedObject);
        }

        public static void StoreObject<T>(this ApplicationDataContainer applicationDataContainer, string key, T @object)
        {
            var serializedObject = JsonConvert.SerializeObject(@object);

            applicationDataContainer.Values[key] = serializedObject;
        }
    }
}
