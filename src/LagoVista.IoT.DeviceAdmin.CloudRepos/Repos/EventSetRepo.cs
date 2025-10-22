// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: a729ebd0a9757033a5acd186cb3d366c4454e43b8847a6bac213636f89f5ee9c
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
    public class EventSetRepo : DocumentDBRepoBase<EventSet>, IEventSetRepo
    {
        private bool _shouldConsolidateCollections;

        public EventSetRepo(IDeviceRepoSettings settings, IAdminLogger logger, ICacheProvider cacheProvider, IDependencyManager dependencyMgr) :
            base(settings.DeviceDocDbStorage.Uri, settings.DeviceDocDbStorage.AccessKey, settings.DeviceDocDbStorage.ResourceName, logger, cacheProvider, dependencyMgr)
        {
            _shouldConsolidateCollections = settings.ShouldConsolidateCollections;
        }
        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public Task AddEventSetAsync(EventSet eventSet)
        {
            return CreateDocumentAsync(eventSet);
        }

        public Task UpdateEventSetAsync(EventSet eventSet)
        {
            return CreateDocumentAsync(eventSet);
        }

        public Task<EventSet> GetEventSetAsync(string unitSetId)
        {
            return GetDocumentAsync(unitSetId);
        }

        public async Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            var items = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true) && attr.Key == key);
            return items.Any();
        }

        public Task<ListResponse<EventSetSummary>> GetEventSetsForOrgAsync(string orgId, ListRequest listRequest)
        {
            return base.QuerySummaryAsync<EventSetSummary, EventSet>(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId, itm=>itm.Name, listRequest);
        }

        public Task DeleteEventSetAsync(string eventSetId)
        {
            return DeleteDocumentAsync(eventSetId);
        }
    }
}
