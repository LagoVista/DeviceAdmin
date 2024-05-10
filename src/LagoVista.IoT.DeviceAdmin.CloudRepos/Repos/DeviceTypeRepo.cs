﻿using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using System.Linq;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Threading.Tasks;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Interfaces;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{
    public class DeviceTypeRepo : DocumentDBRepoBase<DeviceType>, IDeviceTypeRepo
    {
        private bool _shouldConsolidateCollections;
        public DeviceTypeRepo(IDeviceRepoSettings repoSettings, IAdminLogger logger, ICacheProvider cacheProvider, IDependencyManager dependencyMgr) 
            : base(repoSettings.DeviceDocDbStorage.Uri, repoSettings.DeviceDocDbStorage.AccessKey, repoSettings.DeviceDocDbStorage.ResourceName, logger, cacheProvider, dependencyManager: dependencyMgr)
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

        public Task<ListResponse<DeviceTypeSummary>> GetDeviceTypesForDeviceConfigOrgAsync(string deviceConfigId, string orgId, ListRequest listRequest)
        {
            return base.QuerySummaryAsync<DeviceTypeSummary, DeviceType>(qry => (qry.IsPublic == true || qry.OwnerOrganization.Id == orgId) 
            && (qry.DefaultDeviceConfiguration != null && qry.DefaultDeviceConfiguration.Id == deviceConfigId), qry=>qry.Name, listRequest);
        }

        public Task<ListResponse<DeviceTypeSummary>> GetDeviceTypesForOrgAsync(string orgId, ListRequest listRequest)
        {
            return base.QuerySummaryAsync<DeviceTypeSummary, DeviceType>(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId, qry=>qry.Name, listRequest);
        }

        public async Task<DeviceType> GetDeviceTypeForKeyAsync(string orgId, string key)
        {
            Verbose = true;
            var items = await base.QueryAsync(deviceType => (deviceType.OwnerOrganization.Id == orgId || deviceType.IsPublic == true) && deviceType.Key == key);
            return items.FirstOrDefault();
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
