using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.IoT.Web.Common.Controllers;
using LagoVista.UserAdmin.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using LagoVista.Core;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LagoVista.Core.Validation;
using LagoVista.Core.Models;

namespace LagoVista.IoT.DeviceAdmin.Rest.Controllers
{
    [Authorize]
    public class EquipmentController : LagoVistaBaseController
    {
        IEquipmentManager _mgr;

        public EquipmentController(UserManager<AppUser> userManager, IAdminLogger logger, IEquipmentManager mgr) : base(userManager, logger)
        {
            _mgr = mgr;
        }

        /// <summary>
        /// Equipment - Add
        /// </summary>
        /// <param name="equipment"></param>
        [HttpPost("/api/equipment")]
        public Task<InvokeResult> AddEquipmentAsync([FromBody] Equipment equipment)
        {
            return _mgr.AddEquipmentAsync(equipment, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Equipment - Update
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns></returns>
        [HttpPut("/api/equipment")]
        public Task<InvokeResult> UpdateEquipment([FromBody] Equipment equipment)
        {
            SetUpdatedProperties(equipment);
            return _mgr.UpdateEquipmentAsync(equipment, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Equipment - Get for Current Org
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/equipmentitems")]
        public Task<ListResponse<EquipmentSummary>> GetEquomentForOrg()
        {
            return _mgr.GetEquipmentSummaryAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Equipment - In Use
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/equipment/{id}/inuse")]
        public Task<DependentObjectCheckResult> InUseCheck(String id)
        {
            return _mgr.CheckInUseAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Equipment - Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/equipment/{id}")]
        public async Task<DetailResponse<Equipment>> GetEquipmentAsync(String id)
        {
            var equipment = await _mgr.GetEquipmentAsync(id, OrgEntityHeader, UserEntityHeader);
            return DetailResponse<Equipment>.Create(equipment);
        }

        /// <summary>
        /// Equipment - Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/equipment/{id}/detail")]
        public Task<Equipment> GetEquipmentDetailAsync(String id)
        {
            return _mgr.GetEquipmentAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Equipment - Key In Use
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/equipment/{key}/keyinuse")]
        public Task<bool> GetEquipmentKeyInUseAsync(String key)
        {
            return _mgr.QueryKeyInUseAsync(key, CurrentOrgId);
        }

        /// <summary>
        /// Equipment - Delete
        /// </summary>
        /// <returns></returns>
        [HttpDelete("/api/equipment/{id}")]
        public Task<InvokeResult> DeleteEquipmentAsync(string id)
        {
            return _mgr.DeleteEquipmentAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        ///  Equipment - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/equipment/factory")]
        public DetailResponse<Equipment> CreateNew()
        {
            var response = DetailResponse<Equipment>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
            return response;
        }
    }
}
