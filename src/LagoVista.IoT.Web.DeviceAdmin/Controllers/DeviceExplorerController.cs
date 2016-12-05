using LagoVista.Core.PlatformSupport;
using LagoVista.UserManagement.Models.Account;
using LagoVista.IoI.Web.Common.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LagoVista.IoT.Web.DeviceAdmin.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class DeviceExplorerController : LagoVistaBaseController
    {

        public DeviceExplorerController(UserManager<AppUser> userManager, ILogger logger) : base(userManager, logger)
        {
        }
    }
}
