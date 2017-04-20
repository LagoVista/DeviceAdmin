using LagoVista.Core.Interfaces;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Web.Common.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using LagoVista.Core;
using System.Collections.Generic;
using LagoVista.IoT.DeviceAdmin.Resources;
using LagoVista.UserAdmin.Models.Account;

namespace LagoVista.IoT.DeviceAdmin.Rest.Controllers
{
    [Authorize]
    [Route("/api/deviceadmin/factory")]
    public class DeviceAdminFactory : LagoVistaBaseController
    {
        public DeviceAdminFactory(UserManager<AppUser> userManager, ILogger logger) : base(userManager, logger)
        {

        }

        /// <summary>
        /// Unit Set - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("unitset")]
        public DetailResponse<UnitSet> CreateUnitSet()
        {
            var response = DetailResponse<UnitSet>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
            return response;
        }


        /// <summary>
        /// Output Command - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("outputcommand")]
        public DetailResponse<OutputCommand> CreateOutputCommand()
        {
            var response = DetailResponse<OutputCommand>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);           
            return response;
        }

        /// <summary>
        /// Input - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("input")]
        public DetailResponse<WorkflowInput> CreateSensor()
        {
            var response = DetailResponse<WorkflowInput>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);            
            return response;
        }

        /// <summary>
        /// Input Command - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("inputcommand")]
        public DetailResponse<InputCommand> CreateInputCommand()
        {
            var response = DetailResponse<InputCommand>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
            return response;
        }

        /// <summary>
        ///  Device Workflow - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("deviceworkflow")]
        public DetailResponse<DeviceWorkflow> CreateDeviceWorkflow()
        {
            var response = DetailResponse<DeviceWorkflow>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
            return response;
        }

        /// <summary>
        ///  Action - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("action")]
        public DetailResponse<IoT.DeviceAdmin.Models.Action> CreateAction()
        {
            var response = DetailResponse<IoT.DeviceAdmin.Models.Action>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
            return response;
        }

        /// <summary>
        ///  Create New Parameter
        /// </summary>
        /// <returns></returns>
        [HttpGet("parameter")]
        public DetailResponse<IoT.DeviceAdmin.Models.Parameter> CreateInputParameter()
        {
            return  DetailResponse<IoT.DeviceAdmin.Models.Parameter>.Create();
        }

        /// <summary>
        ///  Action Parameter- Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("actionparameter/{id}")]
        public DetailResponse<ActionParameter> CreateActionParameter(String id)
        {
            var response = DetailResponse<ActionParameter>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            return response;
        }

        /// <summary>
        ///  Admin Note - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("adminnote")]
        public DetailResponse<AdminNote> CreateAdminNote()
        {
            var response = DetailResponse<AdminNote>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            return response;
        }

        /// <summary>
        ///  Attribute - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("attribute")]
        public DetailResponse<IoT.DeviceAdmin.Models.Attribute> CreateAttribute()
        {
            var response = DetailResponse<IoT.DeviceAdmin.Models.Attribute>.Create();
            response.Model.Id = Guid.NewGuid().ToId();        
            SetOwnedProperties(response.Model);
            SetAuditProperties(response.Model);
            return response;
        }

        /// <summary>
        ///  Unit - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("unit")]
        public DetailResponse<Unit> CreatUnit()
        {
            return DetailResponse<Unit>.Create();
        }

        /// <summary>
        ///  Custom Field - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("customfield")]
        public DetailResponse<CustomField> CreateCustomField()
        {
            var response = DetailResponse<CustomField>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            return response;
        }

        /// <summary>
        ///  Custom Field Collection - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("customfieldcollection")]
        public DetailResponse<CustomFieldCollection> CreateCustomFieldCollection()
        {
            var response = DetailResponse<CustomFieldCollection>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
            return response;
        }
    }
}
