using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.PlatformSupport;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Web.Common.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using LagoVista.Core;
using System.Threading.Tasks;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.UserAdmin.Models.Users;

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
        public Task<InvokeResult> AddHostAsync([FromBody] DeviceType deviceType)
        { 
            return _deviceTypeManager.AddDeviceTypeAsync(deviceType, UserEntityHeader, OrgEntityHeader);
        }

        /// <summary>
        /// Device Type - Update
        /// </summary>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        [HttpPut("/api/devicetype")]
        public Task<InvokeResult> UpdateHostAsync([FromBody] DeviceType deviceType)
        {
            SetUpdatedProperties(deviceType);
            return _deviceTypeManager.UpdateDeviceTypeAsync(deviceType, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Device Type- Get for Org
        /// </summary>
        /// <param name="orgId">Organization Id</param>
        /// <returns></returns>
        [HttpGet("/api/org/{orgid}/devicetypes")]
        public async Task<ListResponse<DeviceTypeSummary>> GetDeviceTypesForOrg(String orgId)
        {
            var hostSummaries = await _deviceTypeManager.GetDeviceTypesForOrgsAsync(orgId, UserEntityHeader);
            return ListResponse<DeviceTypeSummary>.Create(hostSummaries);
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

            return DetailResponse<DeviceType>.Create(deviceType);
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
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
            return response;
        }
    }
}
