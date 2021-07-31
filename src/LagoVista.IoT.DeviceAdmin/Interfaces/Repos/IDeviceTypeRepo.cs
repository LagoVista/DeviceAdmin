using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IDeviceTypeRepo
    {
        Task<ListResponse<DeviceTypeSummary>> GetDeviceTypesForDeviceConfigOrgAsync(string deviceConfigId, string orgId, ListRequest listRequest);
        Task AddDeviceTypeAsync(DeviceType deviceType);
        Task<DeviceType> GetDeviceTypeAsync(String deviceTypeId);
        Task UpdateDeviceTypeAsync(DeviceType deviceType);
        Task<ListResponse<DeviceTypeSummary>> GetDeviceTypesForOrgAsync(string orgId, ListRequest listRequest);
        Task<bool> QueryKeyInUseAsync(String key, String orgId);
        Task DeleteDeviceTypeSetAsync(string deviceTypeId);
    }
}
