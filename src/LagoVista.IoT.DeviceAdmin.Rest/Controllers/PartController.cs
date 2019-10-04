using LagoVista.Core.Models;
using LagoVista.Core;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.IoT.Web.Common.Controllers;
using LagoVista.UserAdmin.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Rest.Controllers
{

    [Authorize]
    public class PartController : LagoVistaBaseController
    {
        IPartManager _mgr;

        public PartController(UserManager<AppUser> userManager, IAdminLogger logger, IPartManager mgr) : base(userManager, logger)
        {
            _mgr = mgr;
        }

        /// <summary>
        /// Part - Add
        /// </summary>
        /// <param name="part"></param>
        [HttpPost("/api/part")]
        public Task<InvokeResult> AddPartAsync([FromBody] Part part)
        {
            return _mgr.AddPartAsync(part, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Part - Update
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        [HttpPut("/api/part")]
        public Task<InvokeResult> UpdatePart([FromBody] Part part)
        {
            SetUpdatedProperties(part);
            return _mgr.UpdatePartAsync(part, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Part - Get for Current Org
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/parts")]
        public Task<ListResponse<PartSummary>> GetEquomentForOrg()
        {
            return _mgr.GetPartsSummaryAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Part - In Use
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/part/{id}/inuse")]
        public Task<DependentObjectCheckResult> InUseCheck(String id)
        {
            return _mgr.CheckInUseAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Part - Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/part/{id}")]
        public async Task<DetailResponse<Part>> GetPartAsync(String id)
        {
            var part = await _mgr.GetPartAsync(id, OrgEntityHeader, UserEntityHeader);
            return DetailResponse<Part>.Create(part);
        }

        /// <summary>
        /// Part - Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/part/{id}/detail")]
        public Task<Part> GetPartDetailAsync(String id)
        {
            return _mgr.GetPartAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Part - Get with part number
        /// </summary>
        /// <param name="partnumber"></param>
        /// <returns></returns>
        [HttpGet("/api/part")]
        public async Task<DetailResponse<Part>> GetPartWithPartNumberAsync(string partnumber, string sku)
        {

            if (String.IsNullOrEmpty(partnumber))
            {
                var part = await _mgr.GetPartByPartNumberAsync(partnumber, OrgEntityHeader, UserEntityHeader);
                return DetailResponse<Part>.Create(part);
            }
            else if(String.IsNullOrEmpty(sku))
            {
                var part = await _mgr.GetPartBySKUAsync(sku, OrgEntityHeader, UserEntityHeader);
                return DetailResponse<Part>.Create(part);
            }

            throw new InvalidOperationException("Must pass either part number or sku on query string.");
        }

        /// <summary>
        /// Part - Get with part number
        /// </summary>
        /// <param name="partnumber"></param>
        /// <returns></returns>
        [HttpGet("/api/part/detail")]
        public Task<Part> GetPartDetailWithPartNUmberAsync(string partnumber, string sku)
        {
            if(String.IsNullOrEmpty(partnumber))
                return _mgr.GetPartByPartNumberAsync(partnumber, OrgEntityHeader, UserEntityHeader);
            else if(string.IsNullOrEmpty(sku))
                return _mgr.GetPartByPartNumberAsync(sku, OrgEntityHeader, UserEntityHeader);

            throw new InvalidOperationException("Must pass either part number or sku on query string.");
        }

        /// <summary>
        /// Part - Delete
        /// </summary>
        /// <returns></returns>
        [HttpDelete("/api/part/{id}")]
        public Task<InvokeResult> DeletePartAsync(string id)
        {
            return _mgr.DeletePartAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        ///  Part - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/part/factory")]
        public DetailResponse<Part> CreateNew()
        {
            var response = DetailResponse<Part>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
            return response;
        }
    }
}
