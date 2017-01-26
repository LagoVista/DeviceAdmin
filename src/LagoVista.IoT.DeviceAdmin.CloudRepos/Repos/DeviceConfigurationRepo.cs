using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{
    public class DeviceConfigurationRepo : DocumentDBRepoBase<DeviceConfiguration>, IDeviceConfigurationRepo
    {
        public DeviceConfigurationRepo(IDeviceRepoSettings repoSettings, ILogger logger) : base(repoSettings.DeviceDocDbStorage.Uri, repoSettings.DeviceDocDbStorage.AccessKey, repoSettings.DeviceDocDbStorage.ResourceName, logger)
        {

        }

        public Task AddDeviceConfigurationAsync(DeviceConfiguration sharedAction)
        {
            return base.CreateDocumentAsync(sharedAction);
        }

        public Task UpdateDeviceConfigurationAsync(DeviceConfiguration sharedAction)
        {
            return base.UpsertDocumentAsync(sharedAction);
        }

        public Task<DeviceConfiguration> GetDeviceConfigurationAsync(String id)
        {
            return GetDocumentAsync(id);
        }

        public async Task<IEnumerable<DeviceConfigurationSummary>> GetDeviceConfigurationsForOrgAsync(string orgId)
        {
            var items = await base.QueryAsync(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId);

            return from item in items
                   select item.CreateSummary();
        }

        public async Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            var items = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true) && attr.Key == key);
            return items.Any();
        }
    }
}
