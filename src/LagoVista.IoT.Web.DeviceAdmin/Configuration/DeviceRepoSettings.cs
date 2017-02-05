using Microsoft.Extensions.Configuration;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.CloudRepos;
using LagoVista.Core.Models;
using System;

namespace LagoVista.IoT.Web.DeviceAdmin
{
    public class DeviceRepoSettings : IDeviceRepoSettings
    {
        public DeviceRepoSettings(IConfigurationRoot configuration)
        {
            bool shouldConsolidate = true;
            bool.TryParse(configuration["ConsolidateCollections"], out shouldConsolidate);
            ShouldConsolidateCollections = shouldConsolidate;

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

        public bool ShouldConsolidateCollections
        {
            get; private set;
        }
    }
}