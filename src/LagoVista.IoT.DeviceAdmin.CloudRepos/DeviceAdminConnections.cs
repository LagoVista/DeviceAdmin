
using LagoVista.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos
{
    public class DeviceAdminConnections : IDeviceRepoSettings
    {
        public IConnectionSettings DeviceDocDbStorage { get; }
        public IConnectionSettings DeviceTableStorage { get; }
    
        public DeviceAdminConnections(IConfiguration configRoot)
        {
            DeviceDocDbStorage = configRoot.CreateDefaultDBStorageSettings();
            DeviceTableStorage = configRoot.CreateDefaultTableStorageSettings();
        }
    }
}


