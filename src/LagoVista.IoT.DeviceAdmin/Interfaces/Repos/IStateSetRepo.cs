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
        Task<IEnumerable<StateSetSummary>> GetStateSetsForOrgAsync(string orgId);
        Task<bool> QueryKeyInUseAsync(String key, String orgId);
    }

}
