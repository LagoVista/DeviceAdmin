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
        [HttpGet("attributeunitset")]
        public DetailResponse<UnitSet> CreateAttributeUnitSet()
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
        /// Shared Action - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("devicecommand")]
        public DetailResponse<DeviceCommand> CreateDeviceCommand()
        {
            var response = DetailResponse<DeviceCommand>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);           
            return response;
        }

        /// <summary>
        /// Shared Action - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("sensor")]
        public DetailResponse<Sensor> CreateSensor()
        {
            var response = DetailResponse<Sensor>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
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
            response.Model.Actions = new List<IoT.DeviceAdmin.Models.Action>();
            response.Model.Attributes = new List<IoT.DeviceAdmin.Models.Attribute>();
            response.Model.StateMachines = new List<StateMachine>();
            response.Model.CustomFields = new List<CustomField>();
            response.Model.Sensors = new List<Sensor>();
            response.Model.DeviceCommands = new List<DeviceCommand>();
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
            response.Model.DiagramLocation = new Point();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
            return response;
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
            response.Model.DiagramLocation = new Point();

            SetOwnedProperties(response.Model);
            SetAuditProperties(response.Model);
            return response;
        }


        /// <summary>
        ///  Attribute Unit - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("attributeunit")]
        public DetailResponse<Unit> CreatAttributeUnit()
        {
            var response = DetailResponse<Unit>.Create();
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
