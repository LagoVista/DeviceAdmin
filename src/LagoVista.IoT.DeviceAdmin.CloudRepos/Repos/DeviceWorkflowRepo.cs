using LagoVista.CloudStorage.DocumentDB;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Interfaces;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{
    public class DeviceWorkflowRepo : DocumentDBRepoBase<DeviceWorkflow>, IDeviceWorkflowRepo
    {
        private bool _shouldConsolidateCollections;
        public DeviceWorkflowRepo(IDeviceRepoSettings repoSettings, ICacheProvider cacheProvider, IAdminLogger logger, IDependencyManager dependencyMgr)
            : base(repoSettings.DeviceDocDbStorage.Uri, repoSettings.DeviceDocDbStorage.AccessKey, repoSettings.DeviceDocDbStorage.ResourceName, logger, cacheProvider, dependencyManager: dependencyMgr)
        {
            _shouldConsolidateCollections = repoSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public Task AddDeviceWorkflowAsync(DeviceWorkflow workflow)
        {
            return base.CreateDocumentAsync(workflow);
        }

        public Task UpdateDeviceWorkflowAsync(DeviceWorkflow workflow)
        {
            return base.UpsertDocumentAsync(workflow);
        }

        public Task<DeviceWorkflow> GetDeviceWorkflowAsync(String id)
        {
            return GetDocumentAsync(id);
        }

        public Task<ListResponse<DeviceWorkflowSummary>> GetDeviceWorkflowsForOrgAsync(string orgId, ListRequest listRequest)
        {
            return base.QuerySummaryAsync<DeviceWorkflowSummary, DeviceWorkflow>(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId, qry=>qry.Name, listRequest);
        }

        public async Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            var items = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true) && attr.Key == key);
            return items.Any();
        }

        public Task DeleteDeviceWorkflowAsync(string id)
        {
            return DeleteDocumentAsync(id);
        }
    }
}
