// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 9fbd46792f4e1d100afbdb2d9d8bc99d08a714221223d5cc32645f18b8c6944d
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
    public interface IStateSetRepo
    {
        Task AddStateSetAsync(StateSet stateSet);
        Task<StateSet> GetStateSetAsync(String stateSetId);
        Task UpdateStateSetAsync(StateSet stateSet);
        Task<ListResponse<StateSetSummary>> GetStateSetsForOrgAsync(string orgId, ListRequest listRequest);
        Task<bool> QueryKeyInUseAsync(String key, String orgId);
        Task DeleteStateSetAsync(string stateSetId);
    }

}
