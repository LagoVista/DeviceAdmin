using System.Collections.Generic;
using System.Threading.Tasks;
using LagoVista.IoT.DeviceAdmin.Models;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IDeviceConfigurationRepo
    {
        Task AddDeviceConfigurationAsync(DeviceConfiguration sharedAction);
        Task<DeviceConfiguration> GetDeviceConfigurationAsync(string id);
        Task<IEnumerable<DeviceConfigurationSummary>> GetDeviceConfigurationsForOrgAsync(string orgId);
        Task UpdateDeviceConfigurationAsync(DeviceConfiguration sharedAction);
    }
}