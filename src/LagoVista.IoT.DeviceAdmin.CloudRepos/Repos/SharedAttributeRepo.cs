using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{
    public class SharedAttributeRepo : DocumentDBRepoBase<SharedAttribute>, ISharedAtributeRepo
    {
        public SharedAttributeRepo(IDeviceRepoSettings repoSettings, ILogger logger) : base(repoSettings.DeviceDocDbStorage.Uri, repoSettings.DeviceDocDbStorage.AccessKey, repoSettings.DeviceDocDbStorage.ResourceName, logger)
        {

        }

        public Task AddSharedAttributeAsync(SharedAttribute sharedAttribute)
        {
            return base.CreateDocumentAsync(sharedAttribute);
        }

        public Task UpdateSharedAttributeAsync(SharedAttribute sharedAttribute)
        {
            return base.UpsertDocumentAsync(sharedAttribute);
        }

        public Task<SharedAttribute> GetSharedAttributeAsync(String id)
        {
            return GetDocumentAsync(id);
        }

        public async Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            var items = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true) && attr.Key == key);
            return items.Any();
        }

        public async Task<IEnumerable<SharedAttributeSummary>> GetSharedAttributesForOrgAsync(string orgId)
        {
            var items = await base.QueryAsync(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId);

            return from item in items
                   select item.CreateSummary();
        }

    }
}
