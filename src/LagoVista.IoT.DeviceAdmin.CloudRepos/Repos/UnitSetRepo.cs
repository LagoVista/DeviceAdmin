using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.CloudStorage.DocumentDB;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using System;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.CloudStorage;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{
    public class UnitSetRepo : DocumentDBRepoBase<UnitSet>, IUnitSetRepo
    {
        private bool _shouldConsolidateCollections;

        public UnitSetRepo(IDeviceRepoSettings settings, IAdminLogger logger, ICacheProvider cacheProvider) 
            : base(settings.DeviceDocDbStorage.Uri, settings.DeviceDocDbStorage.AccessKey, settings.DeviceDocDbStorage.ResourceName, logger, cacheProvider)
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

        public async Task<IEnumerable<UnitSetSummary>> GetUnitSetsForOrgAsync(string orgId)
        {
            var items = await base.QueryAsync(qry => qry.IsPublic == true ||  qry.OwnerOrganization.Id == orgId);

            return from item in items.OrderBy(itm => itm.Name)
                   select item.CreateUnitSetSummary();
        }

        public Task DeleteUnitSetAsync(string unitSetId)
        {
            return DeleteDocumentAsync(unitSetId);
        }
    }
}
