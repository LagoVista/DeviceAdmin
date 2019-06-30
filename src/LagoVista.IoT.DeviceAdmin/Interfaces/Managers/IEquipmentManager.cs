using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Managers
{
    public interface IEquipmentManager
    {
        Task<InvokeResult> AddEquipmentAsync(Equipment equipment, EntityHeader org, EntityHeader user);
        Task<InvokeResult> UpdateEquipmentAsync(Equipment equipment, EntityHeader org, EntityHeader user);
        Task<ListResponse<EquipmentSummary>> GetEquipmentSummaryAsync(ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<DependentObjectCheckResult> CheckInUseAsync(string id, EntityHeader org, EntityHeader user);
        Task<Equipment> GetEquipmentAsync(string id, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteEquipmentAsync(string id, EntityHeader org, EntityHeader user);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}
