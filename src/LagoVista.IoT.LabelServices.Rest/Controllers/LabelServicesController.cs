using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.IoT.Web.Common.Controllers;
using LagoVista.UserAdmin.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LagoVista.IoT.LabelServices.Rest.Controllers
{
    [Authorize]
    public class LabelServicesController : LagoVistaBaseController
    {
        private readonly ILabelManager _labelManager;
        public LabelServicesController(UserManager<AppUser> userManager, IAdminLogger logger, ILabelManager labelManager) : base(userManager, logger)
        {
            _labelManager = labelManager ?? throw new ArgumentNullException(nameof(labelManager));
        }

        [HttpGet("/api/labelset")]
        public async Task<InvokeResult<LabelSet>> GetLabelSetAsync()
        {
            return  await _labelManager.GetLabelSetAsync(OrgEntityHeader, UserEntityHeader);
        }

        [HttpPost("/api/label")]
        public async Task<InvokeResult<LabelSet>> AddLabelAsync([FromBody] Label label)
        {
            return await _labelManager.AddLabelAsync(label, OrgEntityHeader, UserEntityHeader);
        }

        [HttpPut("/api/label")] 
        public async Task<InvokeResult<LabelSet>> UpdateLabelAsync([FromBody] Label label)
        {
            return await _labelManager.UpdateLabelAsync(label, OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/label/entities/{id}")]
        public async Task<ListResponse<ILabeledEntity>> UpdateLabelAsync(string labelId)
        {
            return await _labelManager.GetLabeledEntitiesAsync(labelId, GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }
    }
}
