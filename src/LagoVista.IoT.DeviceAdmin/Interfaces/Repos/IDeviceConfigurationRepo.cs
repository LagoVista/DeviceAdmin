using System.Collections.Generic;
using System.Threading.Tasks;
using LagoVista.IoT.DeviceAdmin.Models;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IDeviceConfigurationRepo
    {
        Task AddDeviceConfigurationAsync(DeviceConfiguration deviceConfiguration);
        Task<DeviceConfiguration> GetDeviceConfigurationAsync(string id);
        Task<IEnumerable<DeviceConfigurationSummary>> GetDeviceConfigurationsForOrgAsync(string orgId);
        Task UpdateDeviceConfigurationAsync(DeviceConfiguration deviceConfiguration);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}