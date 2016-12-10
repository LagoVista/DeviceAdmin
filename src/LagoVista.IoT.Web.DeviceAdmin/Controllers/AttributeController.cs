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

namespace LagoVista.IoT.Web.DeviceAdmin.Controllers
{

    [Authorize]
    [Route("api/attributes")]
    public class AttributeController : LagoVistaBaseController
    {
        IAttributeManager _attrManager;

        public AttributeController(UserManager<AppUser> userManager, ILogger logger, IAttributeManager attrManager) : base(userManager, logger)
        {
            _attrManager = attrManager;
        }

        /// <summary>
        /// Unit Set - Get View Model
        /// </summary>
        /// <returns>Instance of Unit Set that can be populated.</returns>
        [HttpGet("attributeunitset/new")]
        public DetailResponse<AttributeUnitSet> CreateAttributeSet()
        {
            var response = DetailResponse<AttributeUnitSet>.Create();

            return response;
        }

        /// <summary>
        /// Unit Set - Get View Model
        /// </summary>
        /// <returns>Instance of Unit Set that can be populated.</returns>
        [HttpGet("attributeunitset/keyinuse/{key}")]
        public async Task<bool> KeyInUse(String key)
        {
            return await _attrManager.QueryUnitKeyInUseAsync(key, CurrentOrgId);
        }

        /// <summary>
        /// Unit Set - Create New
        /// </summary>
        /// <param name="unitSet"></param>
        /// <returns></returns>
        [HttpPost("attributeunitset")]
        public Task AddAttributeSet(AttributeUnitSet unitSet)
        {
            return _attrManager.AddUnitSetAsync(unitSet, UserEntityHeader, OrgEntityHeader);
        }

        /// <summary>
        /// Unit Set - Apply Update
        /// </summary>
        /// <param name="unitSet"></param>
        /// <returns></returns>
        [HttpPut("attributeunitset")]
        public Task UpdateAttributeSet(AttributeUnitSet unitSet)
        {
            return _attrManager.UpdateUnitSetAsync(unitSet, UserEntityHeader);
        }

        /// <summary>
        /// Unit Set - Get for Organization
        /// </summary>
        /// <param name="orgId">Organization Id</param>
        /// <returns></returns>
        [HttpGet("attributeunitsets/{orgid}")]
        public async Task<ListResponse<AttributeUnitSetSummary>> GetAttributeUnitSets(String orgId)
        {
            var unitSets = await _attrManager.GetUnitSetsForOrgAsync(orgId);
            var response = ListResponse<AttributeUnitSetSummary>.Create(unitSets);

            return response;
        }

        /// <summary>
        /// Unit Set - Get Details
        /// </summary>
        /// <param name="unitsetid"></param>
        /// <returns></returns>

        [HttpGet("attributeunitset/{unitsetid}")]
        public async Task<DetailResponse<AttributeUnitSet>> GetAttributeSet(String unitsetid)
        {
            var unitSet = await _attrManager.GetUnitSetAsync(unitsetid);

            var response = DetailResponse<AttributeUnitSet>.Create(unitSet);

            return response;
        }

    }
}
