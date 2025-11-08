// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: ce71e977fbeec42067974c5f8d83756fdd5c86dd7e70815ef1f12a995ff8f89e
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IEquipmentRepo
    {
        Task AddEquipmentAsync(Equipment equipment);
        Task UpdateEquipmentAsync(Equipment equipment);
        Task DeleteEquipmentAsync(string id);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
        Task<Equipment> GetEquipmentAsync(string id);
        Task<ListResponse<EquipmentSummary>> GetToolSummariesForOrgAsync(string orgId, ListRequest listRequest);
    }
}
