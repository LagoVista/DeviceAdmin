// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 19835cf63687fc3a8bc245aa0334f7fd9effcbbed3e9bd5af00f7c8bea505234
// IndexVersion: 2
// --- END CODE INDEX META ---
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
using LagoVista.IoT.Logging.Loggers;
using LagoVista.UserAdmin.Models.Users;
using LagoVista.IoT.DeviceAdmin.Resources;
using LagoVista.IoT.DeviceAdmin.Models.Resources;

namespace LagoVista.IoT.DeviceAdmin.Rest.Controllers
{
    [Authorize]
    public class DeviceAdminFactory : LagoVistaBaseController
    {
        public DeviceAdminFactory(UserManager<AppUser> userManager, IAdminLogger logger) : base(userManager, logger)
        {

        }

        /// <summary>
        /// Unit Set - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/factory/unitset")]
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
        [HttpGet("/api/deviceadmin/factory/outputcommand")]
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
        [HttpGet("/api/deviceadmin/factory/input")]
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
        [HttpGet("/api/deviceadmin/factory/inputcommand")]
        public DetailResponse<InputCommand> CreateInputCommand()
        {
            var response = DetailResponse<InputCommand>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
            return response;
        }

        /// <summary>
        /// Parameter - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/factory/parameter")]
        public DetailResponse<Parameter> CreateParameter()
        {
            return DetailResponse<Parameter>.Create();
        }


        /// <summary>
        /// Input Command Parameter - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/factory/inputcommand/parameter")]
        public DetailResponse<Parameter> CreateInputCommandParameter()
        {
            var response = DetailResponse<Parameter>.Create();
            return response;
        }

        /// <summary>
        /// Output Command Parameter - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/factory/outputcommand/parameter")]
        public DetailResponse<Parameter> CreateOutputCommandParameter()
        {
            var response = DetailResponse<Parameter>.Create();
            return response;
        }

        /// <summary>
        ///  Device Workflow - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/factory/deviceworkflow")]
        public DetailResponse<DeviceWorkflow> CreateDeviceWorkflow()
        {
            var response = DetailResponse<DeviceWorkflow>.Create();
            response.Model.Pages.Add(
                new Page()
                {
                    PageNumber = 1,
                    Name = DeviceLibraryResources.Common_PageNumberOne
                });

            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
            return response;
        }

        /// <summary>
        ///  Device Workflow - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/factory/page")]
        public DetailResponse<Page> CreatePage()
        {
            return DetailResponse<Page>.Create();
        }

        /// <summary>
        ///  Action - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/factory/action")]
        public DetailResponse<IoT.DeviceAdmin.Models.Action> CreateAction()
        {
            var response = DetailResponse<IoT.DeviceAdmin.Models.Action>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
            return response;
        }        

        /// <summary>
        ///  Action Parameter- Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/factory/actionparameter")]
        public DetailResponse<ActionParameter> CreateActionParameter()
        {
            var response = DetailResponse<ActionParameter>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            return response;
        }

        /// <summary>
        ///  Admin Note - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/factory/adminnote")]
        public DetailResponse<AdminNote> CreateAdminNote()
        {
            var response = DetailResponse<AdminNote>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            return response;
        }

        /// <summary>
        ///  Admin Note - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/factory/devicebusinessrule")]
        public DetailResponse<BusinessRule> CreateBusinessRule()
        {
            var response = DetailResponse<BusinessRule>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            return response;
        }

        /// <summary>
        ///  Attribute - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/factory/attribute")]
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
        [HttpGet("/api/deviceadmin/factory/unit")]
        public DetailResponse<Unit> CreatUnit()
        {
            return DetailResponse<Unit>.Create();
        }

        /// <summary>
        ///  Custom Field - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/deviceadmin/factory/customfield")]
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
        [HttpGet("/api/deviceadmin/factory/customfieldcollection")]
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
