using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.IoT.Web.Common.Attributes;
using LagoVista.IoT.Web.Common.Controllers;
using LagoVista.UserAdmin.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Rest.Controllers
{
    [ConfirmedUser]
    [Authorize]
    public class ComponentPackageController : LagoVistaBaseController
    {
        private readonly IComponentPackageManager _mgr;

        public ComponentPackageController(UserManager<AppUser> userManager, IAdminLogger logger, IComponentPackageManager mgr) : base(userManager, logger)
        {
            _mgr = mgr;
        }

        [HttpGet("/api/component/package/{id}")]
        public async Task<DetailResponse<ComponentPackage>> GetComponentPackage(string id)
        {
            return DetailResponse<ComponentPackage>.Create( await _mgr.GetComponentPackageAsync(id, OrgEntityHeader, UserEntityHeader));
        }

        [HttpGet("/api/component/package/factory")]
        public DetailResponse<ComponentPackage> CreateComponentPackage()
        {
            var form = DetailResponse<ComponentPackage>.Create();
            SetAuditProperties(form.Model);
            SetOwnedProperties(form.Model);
            return form;
        }

        [HttpDelete("/api/component/package/{id}")]
        public async Task<InvokeResult> DeleteComponentPackage(string id)
        {
            return await _mgr.DeleteCommponentPackageAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// ComponentPackage - Add
        /// </summary>
        /// <param name="ComponentPackage"></param>
        [HttpPost("/api/component/package")]
        public Task<InvokeResult> AddComponentPackageAsync([FromBody] ComponentPackage ComponentPackage)
        {
            return _mgr.AddComponentPackageAsync(ComponentPackage, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// ComponentPackage - Update
        /// </summary>
        /// <param name="ComponentPackage"></param>
        /// <returns></returns>
        [HttpPut("/api/component/package")]
        public Task<InvokeResult> UpdateComponentPackage([FromBody] ComponentPackage ComponentPackage)
        {
            SetUpdatedProperties(ComponentPackage);
            return _mgr.UpdateComponentPackageAsync(ComponentPackage, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// ComponentPackage - Get for Current Org
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/component/packages")]
        public Task<ListResponse<ComponentPackageSummary>> GetEquomentForOrg()
        {
            return _mgr.GetComponentPackagesSummariesAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

    }
}
