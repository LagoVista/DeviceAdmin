using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.PlatformSupport;
using LagoVista.UserManagement.Models.Account;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LagoVista.IoT.Web.Common.Controllers;
using System.Collections.Generic;
using LagoVista.Core.Validation;

namespace LagoVista.IoT.Web.DeviceAdmin.Controllers
{

    [Authorize]
    [Route("api/deviceadmin")]
    public class DeviceAdminController : LagoVistaBaseController
    {
        IDeviceAdminManager _attrManager;

        public DeviceAdminController(UserManager<AppUser> userManager, ILogger logger, IDeviceAdminManager attrManager) : base(userManager, logger)
        {
            _attrManager = attrManager;
        }

        /// <summary>
        /// Unit Set - Key in Use
        /// </summary>
        /// <returns></returns>
        [HttpGet("attributeunitset/keyinuse/{key}")]
        public Task<bool> UnitSetKeyInUse(String key)
        {
            return _attrManager.QueryAttributeUnitSetKeyInUseAsync(key, CurrentOrgId);
        }

        /// <summary>
        /// Environment - Get List of Hosting Environments
        /// </summary>
        /// <returns>List of current environments for org</returns>
        [HttpGet("environments")]
        public InvokeResult<List<LagoVista.IoT.DeviceAdmin.Models.Environment>> GetEnvironmentList()
        {
            //TODO: Eventually we will add to this, for now we have dev/test/prod
            return new InvokeResult<List<IoT.DeviceAdmin.Models.Environment>>() { Result = LagoVista.IoT.DeviceAdmin.Models.Environment.GetStandardList() };
        }

        /// <summary>
        /// Unit Set - Add New
        /// </summary>
        /// <param name="unitSet"></param>
        /// <returns></returns>
        [HttpPost("unitset")]
        public Task<InvokeResult> AddUnitSet([FromBody] UnitSet unitSet)
        {
            return _attrManager.AddUnitSetAsync(unitSet, UserEntityHeader, OrgEntityHeader);
        }

        /// <summary>
        /// Unit Set - Update
        /// </summary>
        /// <param name="unitSet"></param>
        /// <returns></returns>
        [HttpPut("unitset")]
        public Task<InvokeResult> UpdateUnitSet([FromBody] UnitSet unitSet)
        {
            return _attrManager.UpdateUnitSetAsync(unitSet, UserEntityHeader);
        }

        /// <summary>
        /// Unit Set - Get for Org
        /// </summary>
        /// <param name="orgId">Organization Id</param>
        /// <returns></returns>
        [HttpGet("unitset/{orgid}")]
        public async Task<ListResponse<UnitSetSummary>> GetAttributeUnitSets(String orgId)
        {
            var unitSets = await _attrManager.GetUnitSetsForOrgAsync(orgId);
            var response = ListResponse<UnitSetSummary>.Create(unitSets);

            return response;
        }

        /// <summary>
        /// Unit Set - Get Detail
        /// </summary>
        /// <param name="unitsetid"></param>
        /// <returns></returns>
        [HttpGet("unitset/{unitsetid}")]
        public async Task<DetailResponse<UnitSet>> GetAttributeSet(String unitsetid)
        {
            var unitSet = await _attrManager.GetAttributeUnitSetAsync(unitsetid, OrgEntityHeader);

            var response = DetailResponse<UnitSet>.Create(unitSet);

            return response;
        }


        /// <summary>
        /// Shared Attribute - Key in use 
        /// </summary>
        /// <returns>.</returns>
        [HttpGet("sharedattribute/keyinuse/{key}")]
        public  Task<bool> SharedAttributeKeyInUse(String key)
        {
            return _attrManager.QuerySharedAttributeKeyInUseAsync(key, CurrentOrgId);
        }

        /// <summary>
        /// Shared Attribute - Add New
        /// </summary>
        /// <param name="sharedAttribute"></param>
        /// <returns></returns>
        [HttpPost("sharedattribute")]
        public Task<InvokeResult> AddSharedAttributeAsync([FromBody] SharedAttribute sharedAttribute)
        {
            return _attrManager.AddSharedAttributeAsync(sharedAttribute, UserEntityHeader, OrgEntityHeader);
        }

        /// <summary>
        /// Shared Attribute - Update
        /// </summary>
        /// <param name="sharedAttribute"></param>
        /// <returns></returns>
        [HttpPut("sharedattribute")]
        public Task<InvokeResult> UpdateSharedAttribute([FromBody] SharedAttribute sharedAttribute)
        {
            return _attrManager.UpdateSharedAttributeAsync(sharedAttribute, UserEntityHeader);
        }

        /// <summary>
        /// Shared Attributes - Get for Org
        /// </summary>
        /// <param name="orgId">Organization Id</param>
        /// <returns></returns>
        [HttpGet("sharedattributes/{orgid}")]
        public async Task<ListResponse<SharedAttributeSummary>> GetSharedAttributesForOrg(String orgId)
        {
            var sharedAttributes = await _attrManager.GetSharedAttributesForOrgAsync(orgId);
            var response = ListResponse<SharedAttributeSummary>.Create(sharedAttributes);

            return response;
        }

        /// <summary>
        /// Shared Attribute - Get Details
        /// </summary>
        /// <param name="sharedattributeid"></param>
        /// <returns></returns>
        [HttpGet("sharedattribute/{sharedattributeid}")]
        public async Task<DetailResponse<SharedAttribute>> GetSharedAttributeAsync(String sharedattributeid)
        {
            var sharedAttribute = await _attrManager.GetSharedAttributeAsync(sharedattributeid, OrgEntityHeader);

            var response = DetailResponse<SharedAttribute>.Create(sharedAttribute);

            return response;
        }


        /// <summary>
        /// Shared Action - Key In Use
        /// </summary>
        /// <returns></returns>
        [HttpGet("sharedaction/keyinuse/{key}")]
        public async Task<bool> SharedActionKeyInUse(String key)
        {
            return await _attrManager.QuerySharedActionKeyInUseAsync(key, CurrentOrgId);
        }

        /// <summary>
        /// Shared Action - Add New
        /// </summary>
        /// <param name="sharedAction"></param>
        /// <returns></returns>
        [HttpPost("sharedaction")]
        public Task<InvokeResult> AddSharedActionAsync([FromBody] SharedAction sharedAction)
        {
            return _attrManager.AddSharedActionAsync(sharedAction, UserEntityHeader, OrgEntityHeader);
        }

        /// <summary>
        /// Shared Action - Update
        /// </summary>
        /// <param name="sharedAction"></param>
        /// <returns></returns>
        [HttpPut("sharedaction")]
        public Task<InvokeResult> UpdateSharedAction([FromBody] SharedAction sharedAction)
        {
            return _attrManager.UpdateSharedActionAsync(sharedAction, UserEntityHeader);
        }

        /// <summary>
        /// Shared Action - Get for Org
        /// </summary>
        /// <param name="orgId">Organization Id</param>
        /// <returns></returns>
        [HttpGet("sharedactions/{orgid}")]
        public async Task<ListResponse<SharedActionSummary>> GetSharedActionsForOrg(String orgId)
        {
            var sharedAttributes = await _attrManager.GetSharedActionsForOrgAsync(orgId);
            var response = ListResponse<SharedActionSummary>.Create(sharedAttributes);

            return response;
        }

        /// <summary>
        /// Shared Action - Get
        /// </summary>
        /// <param name="sharedactionid"></param>
        /// <returns></returns>
        [HttpGet("sharedaction/{sharedactionid}")]
        public async Task<DetailResponse<SharedAction>> GetSharedActionAsync(String sharedactionid)
        {
            var sharedAttribute = await _attrManager.GetSharedActionAsync(sharedactionid, OrgEntityHeader);

            var response = DetailResponse<SharedAction>.Create(sharedAttribute);

            return response;
        }

        /// <summary>
        /// Device Config - Add New
        /// </summary>
        /// <param name="deviceConfiguration"></param>
        /// <returns></returns>
        [HttpPost("deviceconfiguration")]
        public Task<InvokeResult> AddDeviceConfigurationAsync(DeviceConfiguration deviceConfiguration)
        {
            return _attrManager.AddDeviceConfigurationAsync(deviceConfiguration, UserEntityHeader, OrgEntityHeader);
        }

        /// <summary>
        /// Device Config - Update Config
        /// </summary>
        /// <param name="deviceConfiguration"></param>
        /// <returns></returns>
        [HttpPut("deviceconfiguration")]
        public Task<InvokeResult> UpdateDeviceConfigurationAsync(DeviceConfiguration deviceConfiguration)
        {
            return _attrManager.UpdateDeviceConfigurationAsync(deviceConfiguration, UserEntityHeader);
        }

        /// <summary>
        /// Device Config - Get Configs for Org
        /// </summary>
        /// <param name="orgId">Organization Id</param>
        /// <returns></returns>
        [HttpGet("deviceconfigurations/{orgid}")]
        public async Task<ListResponse<DeviceConfigurationSummary>> GetDeviceConfigurationsForOrgAsync(String orgId)
        {
            var deviceConfiguration = await _attrManager.GetDeviceConfigurationsForOrgsAsync(orgId);
            var response = ListResponse<DeviceConfigurationSummary>.Create(deviceConfiguration);

            return response;
        }

        /// <summary>
        /// Device Config - Get A Configuration
        /// </summary>
        /// <param name="deviceconfigurationid"></param>
        /// <returns></returns>
        [HttpGet("deviceconfiguration/{deviceconfigurationid}")]
        public async Task<DetailResponse<DeviceConfiguration>> GetDeviceConfigurationAsync(String deviceconfigurationid)
        {
            var sharedAttribute = await _attrManager.GetDeviceConfigurationAsync(deviceconfigurationid, OrgEntityHeader);

            var response = DetailResponse<DeviceConfiguration>.Create(sharedAttribute);

            return response;
        }

        /// <summary>
        /// Device Config - Key In Use
        /// </summary>
        /// <returns></returns>
        [HttpGet("deviceconfiguration/keyinuse/{key}")]
        public Task<bool> DeviceConfigKeyInUse(String key)
        {
            return _attrManager.QueryAttributeUnitSetKeyInUseAsync(key, CurrentOrgId);
        }
    }
}
