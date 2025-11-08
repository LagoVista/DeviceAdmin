// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: a25fbae53285a2489a3a1ed66acb30ebf0f8c7920631c9854e5cc7954fe6ef5a
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.CloudStorage.DocumentDB;
using System.Threading.Tasks;
using System.Linq;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Interfaces;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{
    public class UnitSetRepo : DocumentDBRepoBase<UnitSet>, IUnitSetRepo
    {
        private bool _shouldConsolidateCollections;

        public UnitSetRepo(IDeviceRepoSettings settings, IAdminLogger logger, ICacheProvider cacheProvider, IDependencyManager dependencyMgr) 
            : base(settings.DeviceDocDbStorage.Uri, settings.DeviceDocDbStorage.AccessKey, settings.DeviceDocDbStorage.ResourceName, logger, cacheProvider, dependencyMgr)
        {
            _shouldConsolidateCollections = settings.ShouldConsolidateCollections;
        }
        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public Task AddUnitSetAsync(UnitSet unitSet)
        {
            return CreateDocumentAsync(unitSet);
        }

        public Task UpdateUnitSetAsync(UnitSet unitSet)
        {
            return UpsertDocumentAsync(unitSet);
        }

        public Task<UnitSet> GetUnitSetAsync(string unitSetId)
        {
            return GetDocumentAsync(unitSetId);
        }

        public async Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            var items = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true) && attr.Key == key);
            return items.Any();
        }

        public Task<ListResponse<UnitSetSummary>> GetUnitSetsForOrgAsync(string orgId, ListRequest listRequest)
        {
            return base.QuerySummaryAsync<UnitSetSummary, UnitSet>(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId, itm => itm.Name, listRequest);
        }

        public Task DeleteUnitSetAsync(string unitSetId)
        {
            return DeleteDocumentAsync(unitSetId);
        }
    }
}
