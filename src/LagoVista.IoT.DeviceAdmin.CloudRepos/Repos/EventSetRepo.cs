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
    public class EventSetRepo : DocumentDBRepoBase<EventSet>, IEventSetRepo
    {
        private bool _shouldConsolidateCollections;

        public EventSetRepo(IDeviceRepoSettings settings, ILogger logger) : base(settings.DeviceDocDbStorage.Uri, settings.DeviceDocDbStorage.AccessKey, settings.DeviceDocDbStorage.ResourceName, logger)
        {
            _shouldConsolidateCollections = settings.ShouldConsolidateCollections;
        }
        protected override bool ShouldConsolidateCollections { get { return _shouldConsolidateCollections; } }

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

        public async Task<IEnumerable<EventSetSummary>> GetEventSetsForOrgAsync(string orgId)
        {
            var items = await base.QueryAsync(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId);

            return from item in items
                   select item.CreateEventSetSummary();
        }
    }
}
