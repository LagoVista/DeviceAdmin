// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: f9f515f8c54e71484d835d9abbfa33f1f9f9c96e26ed553b15be42052b7b7867
// IndexVersion: 0
// --- END CODE INDEX META ---
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
        Task<DeviceType> GetDeviceTypeForKeyAsync(string orgId, string key);
        Task<ListResponse<DeviceTypeSummary>> GetDeviceTypesForOrgAsync(string orgId, ListRequest listRequest);
        Task<bool> QueryKeyInUseAsync(String key, String orgId);
        Task DeleteDeviceTypeSetAsync(string deviceTypeId);
    }
}
