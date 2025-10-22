// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: de25972b9b8ac6284a9a5cd2d8c4a11f485f33be8ab00230aa58ce6ccc202277
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
    public interface IUnitSetRepo
    {
        Task AddUnitSetAsync(UnitSet unitSet);
        Task<UnitSet> GetUnitSetAsync(String unitSetId);
        Task UpdateUnitSetAsync(UnitSet unitSet);
        Task<ListResponse<UnitSetSummary>> GetUnitSetsForOrgAsync(string orgId, ListRequest listRequest);
        Task<bool> QueryKeyInUseAsync(String key, String orgId);
        Task DeleteUnitSetAsync(string unitSetId);
    }
}
