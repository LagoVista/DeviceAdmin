using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using System;
using System.Linq;
using System.Collections.Generic;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Threading.Tasks;
using LagoVista.Core.PlatformSupport;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.IoT.Logging.Loggers;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{
    public class DeviceTypeRepo : DocumentDBRepoBase<DeviceType>, IDeviceTypeRepo
    {
        private bool _shouldConsolidateCollections;
        public DeviceTypeRepo(IDeviceRepoSettings repoSettings, IAdminLogger logger) 
            : base(repoSettings.DeviceDocDbStorage.Uri, repoSettings.DeviceDocDbStorage.AccessKey, repoSettings.DeviceDocDbStorage.ResourceName, logger)
        {
            _shouldConsolidateCollections = repoSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public Task AddDeviceTypeAsync(DeviceType deviceType)
        {
            return CreateDocumentAsync(deviceType);
        }

        public Task DeleteDeviceTypeSetAsync(string deviceTypeId)
        {
            return DeleteDocumentAsync(deviceTypeId);
        }

        public Task<DeviceType> GetDeviceTypeAsync(string deviceTypeId)
        {
            return GetDocumentAsync(deviceTypeId);
        }

        public async Task<IEnumerable<DeviceTypeSummary>> GetDeviceTypesForOrgAsync(string orgId)
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

        public Task UpdateDeviceTypeAsync(DeviceType deviceType)
        {
            return UpsertDocumentAsync(deviceType);
        }
    }
}
