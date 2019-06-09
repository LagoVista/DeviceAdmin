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
