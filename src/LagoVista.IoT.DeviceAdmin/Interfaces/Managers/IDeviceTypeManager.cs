using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Managers
{
    public interface IDeviceTypeManager
    {
        Task<InvokeResult> AddDeviceTypeAsync(DeviceType deviceType, EntityHeader org, EntityHeader user);
        Task<DeviceType> GetDeviceTypeAsync(string id, EntityHeader org, EntityHeader user);

        Task<DependentObjectCheckResult> CheckDeviceTypeInUseAsync(string id, EntityHeader org, EntityHeader user);

        Task<IEnumerable<DeviceTypeSummary>> GetDeviceTypesForOrgsAsync(string orgId, EntityHeader user);
        Task<InvokeResult> UpdateDeviceTypeAsync(DeviceType deviceType, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteDeviceTypeAsync(string id, EntityHeader org, EntityHeader user);
        Task<bool> QueryDeviceTypeKeyInUseAsync(string key, string orgId);
    }
}
