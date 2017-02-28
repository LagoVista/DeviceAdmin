using LagoVista.Core.Interfaces;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Web.Common.Controllers;
using LagoVista.UserManagement.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using LagoVista.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LagoVista.IoT.Web.DeviceAdmin.Controllers
{
    [Authorize]
    [Route("api/deviceadmin/factory")]
    public class DeviceAdminFactory : LagoVistaBaseController
    {
        public DeviceAdminFactory(UserManager<AppUser> userManager, ILogger logger) : base(userManager, logger)
        {

        }

        private void SetAuditProperties(IAuditableEntity entity)
        {
            var createDate = DateTime.Now.ToJSONString();

            entity.CreationDate = createDate;
            entity.LastUpdatedDate = createDate;
            entity.CreatedBy = UserEntityHeader;
            entity.LastUpdatedBy = UserEntityHeader;
        }

        private void SetOwnedProperties(IOwnedEntity entity)
        {
            entity.OwnerOrganization = OrgEntityHeader;
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
        /// Shared Attribute - Create New
        /// </summary>
        /// <returns>Instance of Unit Set that can be populated.</returns>
        [HttpGet("sharedattribute")]
        public DetailResponse<SharedAttribute> CreateSharedAttribute()
        {
            var response = DetailResponse<SharedAttribute>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
            return response;
        }


        /// <summary>
        /// Shared Action - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("sharedaction")]
        public DetailResponse<SharedAction> CreateSharedAction()
        {
            var response = DetailResponse<SharedAction>.Create();
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
        ///  Workflow Config - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("deviceworkflow")]
        public DetailResponse<DeviceWorkflow> CreateWorkflowConfigurartion()
        {
            var response = DetailResponse<DeviceWorkflow>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            response.Model.InputCommands = new List<IoT.DeviceAdmin.Models.InputCommand>();
            response.Model.Attributes = new List<IoT.DeviceAdmin.Models.Attribute>();
            response.Model.StateMachines = new List<StateMachine>();
            response.Model.Inputs = new List<WorkflowInput>();
            response.Model.OutputCommands = new List<OutputCommand>();
            response.Model.Environment = LagoVista.IoT.DeviceAdmin.Models.Environment.GetDefault().ToEntityHeader();
            response.Model.ConfigurationVersion = 0.1;

            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);

            return response;
        }

        /// <summary>
        ///  Device Config - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("deviceconfiguration")]
        public DetailResponse<DeviceConfiguration> CreateDeviceConfigurartion()
        {
            var response = DetailResponse<DeviceConfiguration>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            response.Model.Environment = LagoVista.IoT.DeviceAdmin.Models.Environment.GetDefault().ToEntityHeader();
            response.Model.ConfigurationVersion = 0.1;

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
            var parameter = DetailResponse<IoT.DeviceAdmin.Models.Parameter>.Create();
            return parameter;
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
            response.Model.AttributeType = new Core.Models.EntityHeader() { Id = "-1" };
    
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
            var response = DetailResponse<Unit>.Create();
            response.Model.IsDefault = true;
            response.Model.ConversionType = new Core.Models.EntityHeader()
            {
                Text = "Factor",
                Id = "factor"
            };
            response.Model.ConversionFactor = 1.0;

            return response;
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
