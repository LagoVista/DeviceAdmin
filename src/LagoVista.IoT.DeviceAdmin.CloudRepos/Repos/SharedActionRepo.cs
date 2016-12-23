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
    public class SharedActionRepo : DocumentDBRepoBase<SharedAction>, ISharedActionRepo
    {
        public SharedActionRepo(IDeviceRepoSettings repoSettings, ILogger logger) : base(repoSettings.DeviceDocDbStorage.Uri, repoSettings.DeviceDocDbStorage.AccessKey, repoSettings.DeviceDocDbStorage.ResourceName, logger)
        {

        }

        public Task AddSharedActionAsync(SharedAction sharedAction)
        {
            return base.CreateDocumentAsync(sharedAction);
        }

        public Task UpdateSharedActionAsync(SharedAction sharedAction)
        {
            return base.UpsertDocumentAsync(sharedAction);
        }

        public Task<SharedAction> GetSharedActionAsync(String id)
        {
            return GetDocumentAsync(id);
        }

        public async Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            var items = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true) && attr.Key == key);
            return items.Any();
        }

        public async Task<IEnumerable<SharedActionSummary>> GetSharedActionsForOrgAsync(string orgId)
        {
            var items = await base.QueryAsync(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId);

            return from item in items
                   select item.CreateSummary();
        }
    }
}
