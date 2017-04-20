using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LagoVista.IoT.Web.Common.Controllers;
using LagoVista.Core.Validation;
using LagoVista.UserAdmin.Models.Account;
using LagoVista.Core.Models;

namespace LagoVista.IoT.DeviceAdmin.Rest.Controllers
{

    [Authorize]
    public class DeviceAdminController : LagoVistaBaseController
    {
        IDeviceAdminManager _deviceAdminManager;

        public DeviceAdminController(UserManager<AppUser> userManager, ILogger logger, IDeviceAdminManager attrManager) : base(userManager, logger)
        {
            _deviceAdminManager = attrManager;
        }

        #region Unit Set
        /// <summary>
        /// Unit Set - Key in Use
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/unitset/keyinuse/{key}")]
        public Task<bool> UnitSetKeyInUse(String key)
        {
            return _deviceAdminManager.QueryAttributeUnitSetKeyInUseAsync(key, CurrentOrgId);
        }

        /// <summary>
        /// Unit Set - Add New
        /// </summary>
        /// <param name="unitSet"></param>
        /// <returns></returns>
        [HttpPost("/api/deviceadmin/unitset")]
        public Task<InvokeResult> AddUnitSet([FromBody] UnitSet unitSet)
        {
            return _deviceAdminManager.AddUnitSetAsync(unitSet, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Unit Set - Update
        /// </summary>
        /// <param name="unitSet"></param>
        /// <returns></returns>
        [HttpPut("/api/deviceadmin/unitset")]
        public Task<InvokeResult> UpdateUnitSet([FromBody] UnitSet unitSet)
        {
            SetUpdatedProperties(unitSet);
            return _deviceAdminManager.UpdateUnitSetAsync(unitSet, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// UnitSet - Check In Use
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/unitset/{id}/inuse")]
        public Task<DependentObjectCheckResult> CheckUnitSetInUseAsync(string id)
        {
            return _deviceAdminManager.CheckInUseUnitSetAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Unit Set - Get for Org
        /// </summary>
        /// <param name="orgId">Organization Id</param>
        /// <returns></returns>
        [HttpGet("/api/orgs/{orgid}/deviceadmin/unitsets")]
        public async Task<ListResponse<UnitSetSummary>> GetUnitSetsForOrgAsync(String orgId)
        {
            var unitSets = await _deviceAdminManager.GetUnitSetsForOrgAsync(orgId, UserEntityHeader);
            var response = ListResponse<UnitSetSummary>.Create(unitSets);

            return response;
        }

        /// <summary>
        /// Unit Set - Get Detail
        /// </summary>
        /// <param name="unitsetid"></param>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/unitset/{unitsetid}")]
        public async Task<DetailResponse<UnitSet>> GetUnitSetAsync(String unitsetid)
        {
            var unitSet = await _deviceAdminManager.GetUnitSetAsync(unitsetid, OrgEntityHeader, UserEntityHeader);

            var response = DetailResponse<UnitSet>.Create(unitSet);

            return response;
        }

        /// <summary>
        /// Unit Set - Delete
        /// </summary>
        /// <param name="unitsetid"></param>
        /// <returns></returns>
        [HttpDelete("/api/deviceadmin/unitset/{unitsetid}")]
        public Task<InvokeResult> DeleteUnitSetAsync(String unitsetid)
        {
            return _deviceAdminManager.DeleteUnitSetAsync(unitsetid, OrgEntityHeader, UserEntityHeader);
        }
        #endregion

        #region Device Workflow
        /// <summary>
        /// Device Workflow - Add New
        /// </summary>
        /// <param name="deviceWorkflow"></param>
        /// <returns></returns>
        [HttpPost("/api/deviceadmin/deviceworkflow")]
        public Task<InvokeResult> AddDeviceWorkflowAsync([FromBody] DeviceWorkflow deviceWorkflow)
        {
            return _deviceAdminManager.AddDeviceWorkflowAsync(deviceWorkflow, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Device Workflow - Update Config
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        [HttpPut("/api/deviceadmin/deviceworkflow")]
        public Task<InvokeResult> UpdateDeviceWorkflowAsync([FromBody] DeviceWorkflow workflow)
        {
            SetUpdatedProperties(workflow);
            return _deviceAdminManager.UpdateDeviceWorkflowAsync(workflow, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Device Workflow - Get Device Workflows for Org
        /// </summary>
        /// <param name="orgId">Organization Id</param>
        /// <returns></returns>
        [HttpGet("/api/orgs/{orgid}/deviceadmin/deviceworkflows")]
        public async Task<ListResponse<DeviceWorkflowSummary>> GetDeviceWorkflowsForOrgAsync(String orgId)
        {
            var deviceWorkflows = await _deviceAdminManager.GetDeviceWorkflowsForOrgsAsync(orgId, UserEntityHeader);
            return ListResponse<DeviceWorkflowSummary>.Create(deviceWorkflows);
        }

        /// <summary>
        /// Device Workflow - Get A Device Workflow
        /// </summary>
        /// <param name="deviceWorkflowId"></param>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/deviceworkflow/{deviceWorkflowId}")]
        public async Task<DetailResponse<DeviceWorkflow>> GetDeviceWorkflowAsync(String deviceWorkflowId)
        {
            var deviceWorkflow = await _deviceAdminManager.GetDeviceWorkflowAsync(deviceWorkflowId, OrgEntityHeader, UserEntityHeader);
            return DetailResponse<DeviceWorkflow>.Create(deviceWorkflow);
        }

        /// <summary>
        /// Device Workflow - Key In Use
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/deviceworkflows/keyinuse/{key}")]
        public Task<bool> DeviceWorkflowsKeyInUse(String key)
        {
            return _deviceAdminManager.QueryDeviceWorkflowKeyInUseAsync(key, CurrentOrgId);
        }


        /// <summary>
        /// UnitSet - Check In Use
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/deviceworkflows/{id}/inuse")]
        public Task<DependentObjectCheckResult> CheckDeviceWorkflowInUseAsync(string id)
        {
            return _deviceAdminManager.CheckInUseDeviceWorkflowAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Device Workflow - Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/deviceadmin/deviceworkflows/{id}")]
        public Task<InvokeResult> DeleteDeviceWorkflowAsync(String id)
        {
            return _deviceAdminManager.DeleteDeviceWorkflowAsync(id, OrgEntityHeader, UserEntityHeader);
        }
        #endregion
    }
}
