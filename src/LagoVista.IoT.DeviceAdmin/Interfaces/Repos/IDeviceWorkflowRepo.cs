// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 6d53a8a373a6a1cb13da9dcc15b0fea899b6e97c3ed87f28b61272c790d6c3e0
// IndexVersion: 2
// --- END CODE INDEX META ---
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
