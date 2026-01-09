// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 896a1c8d1b122fa98e1d728ba501c13d1ca80184169f72eb0280ee1bff7958c7
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.CloudStorage;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Interfaces;
using LagoVista.CloudStorage.Interfaces;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{
    public class StateMachineRepo : DocumentDBRepoBase<StateMachine>, IStateMachineRepo
    {
        private bool _shouldConsolidateCollections;

        public StateMachineRepo(IDeviceRepoSettings repoSettings, IDocumentCloudCachedServices services) 
            : base(repoSettings.DeviceDocDbStorage.Uri, repoSettings.DeviceDocDbStorage.AccessKey, repoSettings.DeviceDocDbStorage.ResourceName, services)
        {
            _shouldConsolidateCollections = repoSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public Task AddStateMachineAsync(StateMachine stateMachine)
        {
            return base.CreateDocumentAsync(stateMachine);
        }

        public Task UpdateStateMachineAsync(StateMachine stateMachine)
        {
            return base.UpsertDocumentAsync(stateMachine);
        }

        public Task<StateMachine> GetStateMachineAsync(String id)
        {
            return GetDocumentAsync(id);
        }

        public async Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            var items = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true) && attr.Key == key);
            return items.Any();
        }

        public Task<ListResponse<StateMachineSummary>> GetStateMachinesForOrgAsync(string orgId, ListRequest listRequest)
        {
            return base.QuerySummaryAsync<StateMachineSummary, StateMachine>(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId, qry=>qry.Name, listRequest);
        }

        public Task DeleteStateMachineAsync(string stateMachineId)
        {
            return DeleteDocumentAsync(stateMachineId);
        }
    }
}
