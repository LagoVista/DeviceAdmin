// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 959f8d21b69801f37ab568fdc3a7ea47d62bba94012c4f829dc585bb93affd0b
// IndexVersion: 0
// --- END CODE INDEX META ---
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

    public class ProductionQAController : LagoVistaBaseController
    {
        IProductionQAResultManager _productionQAResultManager;

        public ProductionQAController(IProductionQAResultManager productionQAResultManager, UserManager<AppUser> userManager, IAdminLogger logger, IDeviceAdminManager attrManager) : base(userManager, logger)
        {
            _productionQAResultManager = productionQAResultManager;
        }


        [HttpGet("/api/devicetype/{devicetypeid}/qa/completed")]
        public Task<InvokeResult<ProductionQAResult>> CompleteQAAsync(string devicetypeid)
        {
            return _productionQAResultManager.CompleteQAAsync(devicetypeid, OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/devicetype/{devicetypeid}/qa/results")]
        public Task<ListResponse<ProductionQAResult>> GetForDeviceType(string devicetypeid)
        {
            return _productionQAResultManager.GetForDeviceTypeAsync(devicetypeid, GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }


        [HttpGet("/api/qa/results/{serialnumber}")]
        public Task<InvokeResult<ProductionQAResult>> GetForSerialNumber(int serialnumber)
        {
            return _productionQAResultManager.GetForSerialNumberAsync(serialnumber);
        }
    }
}
