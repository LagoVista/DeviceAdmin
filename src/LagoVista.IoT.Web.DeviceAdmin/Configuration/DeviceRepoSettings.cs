using Microsoft.Extensions.Configuration;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.CloudRepos;
using LagoVista.Core.Models;

namespace LagoVista.IoT.Web.DeviceAdmin
{
    public class DeviceRepoSettings : IDeviceRepoSettings
    {
        public DeviceRepoSettings(IConfigurationRoot configuration)
        {
            var deviceDocDbSection = configuration.GetSection("DeviceDocDbStorage");
            DeviceDocDbStorage = new ConnectionSettings()
            {
                AccessKey = deviceDocDbSection["AccessKey"],
                Uri = deviceDocDbSection["Endpoint"]  ,
                ResourceName = deviceDocDbSection["DbName"]
            };

            var tableStorageSection = configuration.GetSection("DeviceTableStorage");
            DeviceTableStorage = new ConnectionSettings()
            {
                AccountId = tableStorageSection["Name"],
                AccessKey = tableStorageSection["AccessKey"]                
            };
        }

        public IConnectionSettings DeviceDocDbStorage { get; set; }

        public IConnectionSettings DeviceTableStorage { get; set; }

    }
}