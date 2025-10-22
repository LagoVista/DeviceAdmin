// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 5a926b2fc426f126857a5ee9e424c1ce2264ae33cce1692a2c7ed7caa51fa56f
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Logging.Loggers;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{
    public class StateSetRepo : DocumentDBRepoBase<StateSet>, IStateSetRepo
    {
        private bool _shouldConsolidateCollections;

        public StateSetRepo(IDeviceRepoSettings settings, IAdminLogger logger, ICacheProvider cacheProvider, IDependencyManager dependencyMgr) 
            : base(settings.DeviceDocDbStorage.Uri, settings.DeviceDocDbStorage.AccessKey, settings.DeviceDocDbStorage.ResourceName, logger, cacheProvider, dependencyMgr)
        {
            _shouldConsolidateCollections = settings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections { get { return _shouldConsolidateCollections; } }

        public Task AddStateSetAsync(StateSet unitSet)
        {
            return CreateDocumentAsync(unitSet);
        }

        public Task UpdateStateSetAsync(StateSet unitSet)
        {
            return UpsertDocumentAsync(unitSet);
        }

        public Task<StateSet> GetStateSetAsync(string unitSetId)
        {
            return GetDocumentAsync(unitSetId);
        }

        public async Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            var items = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true) && attr.Key == key);
            return items.Any();
        }

        public Task<ListResponse<StateSetSummary>> GetStateSetsForOrgAsync(string orgId, ListRequest listRequest)
        {
            return base.QuerySummaryAsync<StateSetSummary, StateSet>(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId, itm=>itm.Name, listRequest);
        }

        public Task DeleteStateSetAsync(string stateSetId)
        {
            return DeleteDocumentAsync(stateSetId);
        }
    }
}
