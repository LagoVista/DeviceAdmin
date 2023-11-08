using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IDeviceWorkflowRepo
    {
        Task AddDeviceWorkflowAsync(DeviceWorkflow workflow);
        Task<DeviceWorkflow> GetDeviceWorkflowAsync(string id);
        Task<ListResponse<DeviceWorkflowSummary>> GetDeviceWorkflowsForOrgAsync(string orgId, ListRequest listRequest);
        Task UpdateDeviceWorkflowAsync(DeviceWorkflow workflow);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
        Task DeleteDeviceWorkflowAsync(string id);
    }
}
