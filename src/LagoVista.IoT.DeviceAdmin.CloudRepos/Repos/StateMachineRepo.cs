using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{
    public class StateMachineRepo : DocumentDBRepoBase<StateMachine>, IStateMachineRepo
    {
        public StateMachineRepo(IDeviceRepoSettings repoSettings, ILogger logger) : base(repoSettings.DeviceDocDbStorage.Uri, repoSettings.DeviceDocDbStorage.AccessKey, repoSettings.DeviceDocDbStorage.ResourceName, logger)
        {

        }

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

        public async Task<IEnumerable<StateMachineSummary>> GetStateMachinesForOrgAsync(string orgId)
        {
            var items = await base.QueryAsync(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId);

            return from item in items
                   select item.CreateSummary();
        }
    }
}
