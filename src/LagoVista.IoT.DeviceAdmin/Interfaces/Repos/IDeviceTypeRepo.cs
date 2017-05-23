using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IDeviceTypeRepo
    {
        Task AddDeviceTypeAsync(DeviceType deviceType);
        Task<DeviceType> GetDeviceTypeAsync(String deviceTypeId);
        Task UpdateDeviceTypeAsync(DeviceType deviceType);
        Task<IEnumerable<DeviceTypeSummary>> GetDeviceTypesForOrgAsync(string orgId);
        Task<bool> QueryKeyInUseAsync(String key, String orgId);
        Task DeleteDeviceTypeSetAsync(string deviceTypeId);
    }
}
