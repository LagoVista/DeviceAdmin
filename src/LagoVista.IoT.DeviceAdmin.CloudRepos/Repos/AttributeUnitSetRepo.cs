using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.CloudStorage.DocumentDB;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{
    public class AttributeUnitSetRepo : DocumentDBRepoBase<AttributeUnitSet>, IAttributeUnitSetRepo
    {
        public AttributeUnitSetRepo(IDeviceRepoSettings settings, ILogger logger) : base(settings.DeviceDocDbStorage.Uri, settings.DeviceDocDbStorage.AccessKey, settings.DeviceDocDbStorage.ResourceName, logger)
        {

        }

        public Task AddUnitSetAsync(AttributeUnitSet unitSet)
        {
            return CreateDocumentAsync(unitSet);
        }

        public Task UpdateUnitSetAsync(AttributeUnitSet unitSet)
        {
            return CreateDocumentAsync(unitSet);
        }

        public Task<AttributeUnitSet> GetUnitSetAsync(string unitSetId)
        {
            return GetDocumentAsync(unitSetId);
        }

        public async Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            var items = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true) && attr.Key == key);
            return items.Any();
        }

        public async Task<IEnumerable<AttributeUnitSetSummary>> GetUnitSetsForOrg(string orgId)
        {
            var items = await base.QueryAsync(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId);

            return from item in items
                   select item.CreateUnitSetSummary();
        }
    }
}
