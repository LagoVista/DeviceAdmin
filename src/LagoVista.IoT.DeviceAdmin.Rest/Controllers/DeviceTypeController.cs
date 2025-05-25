using LagoVista.Core;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.IoT.Web.Common.Controllers;
using LagoVista.UserAdmin.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using static LagoVista.IoT.DeviceAdmin.Managers.DeviceTypeManager;

namespace LagoVista.IoT.DeviceAdmin.Rest.Controllers
{
    [Authorize]
    public class DeviceTypeController : LagoVistaBaseController
    {
        IDeviceTypeManager _deviceTypeManager;

        public DeviceTypeController(UserManager<AppUser> userManager, IAdminLogger logger, IDeviceTypeManager deviceTypeManager) : base(userManager, logger)
        {
            _deviceTypeManager = deviceTypeManager;
        }

        /// <summary>
        /// Device Type - Add
        /// </summary>
        /// <param name="deviceType"></param>
        [HttpPost("/api/devicetype")]
        public Task<InvokeResult> AddDeviceTypeAsync([FromBody] DeviceType deviceType)
        {
            return _deviceTypeManager.AddDeviceTypeAsync(deviceType, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Device Type - Update
        /// </summary>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        [HttpPut("/api/devicetype")]
        public Task<InvokeResult> UpdateDeviceTypeAsync([FromBody] DeviceType deviceType)
        {
            SetUpdatedProperties(deviceType);
            return _deviceTypeManager.UpdateDeviceTypeAsync(deviceType, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Device Type- Get for Current Org
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/devicetypes")]
        public async Task<ListResponse<DeviceTypeSummary>> GetDeviceTypesForOrg()
        {
           return await _deviceTypeManager.GetDeviceTypesForOrgsAsync(GetListRequestFromHeader(), OrgEntityHeader.Id, UserEntityHeader);
        }

        /// <summary>
        /// Device Type- Get device types that have been created for a specific device typeid
        /// </summary>
        /// <param name="deviceconfigid"></param>
        /// <returns></returns>
        [HttpGet("/api/deviceconfig/{deviceconfigid}/devicetypes")]
        public async Task<ListResponse<DeviceTypeSummary>> GetDeviceTypesForDeviceConfig(string deviceconfigid)
        {
            return await _deviceTypeManager.GetDeviceTypesForDeviceConfigOrgAsync(deviceconfigid, GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Device Type - In Use
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/devicetype/{id}/inuse")]
        public Task<DependentObjectCheckResult> InUseCheck(String id)
        {
            return _deviceTypeManager.CheckDeviceTypeInUseAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Device Type - Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/devicetype/{id}")]
        public async Task<DetailResponse<DeviceType>> GetDeviceType(String id)
        {
            var deviceType = await _deviceTypeManager.GetDeviceTypeAsync(id, OrgEntityHeader, UserEntityHeader);

            var response = DetailResponse<DeviceType>.Create(deviceType);
            response.View[nameof(DeviceType.WebAppJs).CamelCase()].UploadUrl = response.View[nameof(DeviceType.WebAppJs).CamelCase()].UploadUrl.Replace("{id}", response.Model.Id);
            response.View[nameof(DeviceType.WebAppStyles).CamelCase()].UploadUrl = response.View[nameof(DeviceType.WebAppStyles).CamelCase()].UploadUrl.Replace("{id}", response.Model.Id);
            response.View[nameof(DeviceType.PolyfillJs).CamelCase()].UploadUrl = response.View[nameof(DeviceType.PolyfillJs).CamelCase()].UploadUrl.Replace("{id}", response.Model.Id);
            return response;
        }

        [HttpPost("/api/deviceype/{devicetypeid}/{filetype}/upload")]
        public async Task<InvokeResult<EntityHeader<string>>> AddOtaFirmwareRevisionAsync(string devicetypeid, string filetype, IFormFile file)
        {
            if(Enum.TryParse<AngularTypeType>(filetype, out AngularTypeType angularFilteType))
            {
                using (var strm = file.OpenReadStream())
                {
                    return await _deviceTypeManager.UploadAngularFileAsync(devicetypeid, angularFilteType, strm, OrgEntityHeader, UserEntityHeader);
                }
            }
            else
            {
                throw new InvalidDataException($"Don't know how to upload {filetype}");
            }
        }

        /// <summary>
        /// Device Type - Key In Use
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/devicetype/{key}/keyinuse")]
        public Task<bool> GetDeviceTypeKeyInUseAsync(String key)
        {
            return _deviceTypeManager.QueryDeviceTypeKeyInUseAsync(key, CurrentOrgId);
        }

        /// <summary>
        /// Device Type - Delete
        /// </summary>
        /// <returns></returns>
        [HttpDelete("/api/devicetype/{id}")]
        public Task<InvokeResult> DeleteDeviceTypeAsync(string id)
        {
            return _deviceTypeManager.DeleteDeviceTypeAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        ///  Device Type - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/devicetype/factory")]
        public DetailResponse<DeviceType> CreateDeviceType()
        {
            var response = DetailResponse<DeviceType>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            response.View[nameof(DeviceType.WebAppJs).CamelCase()].UploadUrl = response.View[nameof(DeviceType.WebAppJs).CamelCase()].UploadUrl.Replace("{id}", response.Model.Id);
            response.View[nameof(DeviceType.WebAppStyles).CamelCase()].UploadUrl = response.View[nameof(DeviceType.WebAppStyles).CamelCase()].UploadUrl.Replace("{id}", response.Model.Id);
            response.View[nameof(DeviceType.PolyfillJs).CamelCase()].UploadUrl = response.View[nameof(DeviceType.PolyfillJs).CamelCase()].UploadUrl.Replace("{id}", response.Model.Id);
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
            return response;
        }

        /// <summary>
        ///  Device Type BOM Item - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/devicetype/bomitem/factory")]
        public DetailResponse<BOMItem> CreateBOMItem()
        {
            var response = DetailResponse<BOMItem>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            return response;
        }
    }
}
