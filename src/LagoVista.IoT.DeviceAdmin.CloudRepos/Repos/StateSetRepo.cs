using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{
    public class StateSetRepo : DocumentDBRepoBase<StateSet>, IStateSetRepo
    {
        private bool _shouldConsolidateCollections;

        public StateSetRepo(IDeviceRepoSettings settings, ILogger logger) : base(settings.DeviceDocDbStorage.Uri, settings.DeviceDocDbStorage.AccessKey, settings.DeviceDocDbStorage.ResourceName, logger)
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
            return CreateDocumentAsync(unitSet);
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

        public async Task<IEnumerable<StateSetSummary>> GetStateSetsForOrgAsync(string orgId)
        {
            var items = await base.QueryAsync(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId);

            return from item in items
                   select item.CreateStateSetSummary();
        }
    }
}
