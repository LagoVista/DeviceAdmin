// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 41ca0341cf23a6f3b41f520cde47e9c9c7f63b4da04fb488b34d5a039cc4d94f
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.CloudStorage;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.CloudStorage.Interfaces;
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

        public EquipmentRepo(IDeviceRepoSettings repoSettings, IDocumentCloudCachedServices services    )
            : base(repoSettings.DeviceDocDbStorage.Uri, repoSettings.DeviceDocDbStorage.AccessKey, repoSettings.DeviceDocDbStorage.ResourceName, services)
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
            return await base.QuerySummaryAsync<EquipmentSummary, Equipment>(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId, qry => qry.Name, listRequest);
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
