using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IUnitSetRepo
    {
        Task AddUnitSetAsync(UnitSet unitSet);
        Task<UnitSet> GetUnitSetAsync(String unitSetId);
        Task UpdateUnitSetAsync(UnitSet unitSet);
        Task<IEnumerable<UnitSetSummary>> GetUnitSetsForOrgAsync(string orgId);
        Task<bool> QueryKeyInUseAsync(String key, String orgId);
        Task DeleteUnitSetAsync(string unitSetId);
    }
}
