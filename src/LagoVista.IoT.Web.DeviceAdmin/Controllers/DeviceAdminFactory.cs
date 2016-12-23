using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Web.Common.Controllers;
using LagoVista.UserManagement.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.Web.DeviceAdmin.Controllers
{
    [Authorize]
    [Route("api/deviceadmin/factory")]
    public class DeviceAdminFactory : LagoVistaBaseController
    {
        public DeviceAdminFactory(UserManager<AppUser> userManager, ILogger logger) : base(userManager, logger)
        {

        }

        /// <summary>
        /// Unit Set - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("attributeunitset")]
        public DetailResponse<AttributeUnitSet> CreateAttributeSet()
        {
            var response = DetailResponse<AttributeUnitSet>.Create();

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
            return response;
        }


        /// <summary>
        ///  Action Parameter- Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("actionparameter")]
        public DetailResponse<ActionParameter> CreateActionParameter()
        {
            var response = DetailResponse<ActionParameter>.Create();
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
            return response;
        }


        /// <summary>
        ///  Attribute Unit - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("attributeunit")]
        public DetailResponse<AttributeUnit> CreatAttributeUnit()
        {
            var response = DetailResponse<AttributeUnit>.Create();
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
            return response;
        }
    }
}
