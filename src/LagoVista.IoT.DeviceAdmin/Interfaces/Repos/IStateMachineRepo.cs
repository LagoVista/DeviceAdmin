using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IStateMachineRepo
    {
        Task AddStateMachineAsync(StateMachine sharedAction);
        Task<StateMachine> GetStateMachineAsync(string id);
        Task<IEnumerable<StateMachineSummary>> GetStateMachinesForOrgAsync(string orgId);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
        Task UpdateStateMachineAsync(StateMachine sharedAttribute);
        Task DeleteStateMachineAsync(string stateMachineId);
    }
}
