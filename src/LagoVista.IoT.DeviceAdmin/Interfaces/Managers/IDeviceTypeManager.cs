using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static LagoVista.IoT.DeviceAdmin.Managers.DeviceTypeManager;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Managers
{
    public interface IDeviceTypeManager
    {
        Task<InvokeResult> AddDeviceTypeAsync(DeviceType deviceType, EntityHeader org, EntityHeader user);
        Task<DeviceType> GetDeviceTypeAsync(string id, EntityHeader org, EntityHeader user);
        Task<DependentObjectCheckResult> CheckDeviceTypeInUseAsync(string id, EntityHeader org, EntityHeader user);
        Task<ListResponse<DeviceTypeSummary>> GetDeviceTypesForDeviceConfigOrgAsync(string deviceConfigId, ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<ListResponse<DeviceTypeSummary>> GetDeviceTypesForOrgsAsync(ListRequest listRequest, string orgId, EntityHeader user);
        Task<InvokeResult> UpdateDeviceTypeAsync(DeviceType deviceType, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteDeviceTypeAsync(string id, EntityHeader org, EntityHeader user);
        Task<bool> QueryDeviceTypeKeyInUseAsync(string key, string orgId);

        Task<InvokeResult<EntityHeader<string>>> UploadAngularFileAsync(string deviceTypeId, AngularTypeType fileType, Stream file, EntityHeader org, EntityHeader user);
    }
}
