using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IAttributeUnitSetRepo
    {
        Task AddUnitSetAsync(AttributeUnitSet unitSet);
        Task<AttributeUnitSet> GetUnitSetAsync(String unitSetId);
        Task UpdateUnitSetAsync(AttributeUnitSet unitSet);
        Task<IEnumerable<AttributeUnitSetSummary>> GetUnitSetsForOrgAsync(string orgId);
        Task<bool> QueryKeyInUseAsync(String key, String orgId);
    }
}
