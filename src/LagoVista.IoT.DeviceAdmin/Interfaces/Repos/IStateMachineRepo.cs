// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: f267b72c6df926863e8a4b1057ec312260e8ccdb83f24eb6f47b475d07928fb0
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Core.Models.UIMetaData;
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
        Task<ListResponse<StateMachineSummary>> GetStateMachinesForOrgAsync(string orgId, ListRequest listRequest);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
        Task UpdateStateMachineAsync(StateMachine sharedAttribute);
        Task DeleteStateMachineAsync(string stateMachineId);
    }
}
