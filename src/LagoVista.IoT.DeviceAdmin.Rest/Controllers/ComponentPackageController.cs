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
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Rest.Controllers
{
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



    }
}
