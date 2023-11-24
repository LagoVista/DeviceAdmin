using LagoVista.CloudStorage;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Logging.Loggers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{
    public class EquipmentRepo : DocumentDBRepoBase<Equipment>, IEquipmentRepo
    {
        private bool _shouldConsolidateCollections;

        public EquipmentRepo(IDeviceRepoSettings repoSettings, IAdminLogger logger, ICacheProvider cacheProvider, IDependencyManager dependencyMgr)
            : base(repoSettings.DeviceDocDbStorage.Uri, repoSettings.DeviceDocDbStorage.AccessKey, repoSettings.DeviceDocDbStorage.ResourceName, logger, cacheProvider, dependencyMgr)
        {
            _shouldConsolidateCollections = repoSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public Task AddEquipmentAsync(Equipment equipment)
        {
            return CreateDocumentAsync(equipment);
        }

        public Task DeleteEquipmentAsync(string id)
        {
            return DeleteDocumentAsync(id);
        }

        public Task<Equipment> GetEquipmentAsync(string id)
        {
            return GetDocumentAsync(id);
        }

        public async Task<ListResponse<EquipmentSummary>> GetToolSummariesForOrgAsync(string orgId, ListRequest listRequest)
        {
            var response = await base.QueryAsync(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId, qry => qry.Name, listRequest);
            return response.Create(response.Model.Select(mod => mod.CreateSummary()));
        }

        public async Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            var items = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true) && attr.Key == key);
            return items.Any();
        }

        public Task UpdateEquipmentAsync(Equipment equipment)
        {
            return UpsertDocumentAsync(equipment);
        }
    }
}
