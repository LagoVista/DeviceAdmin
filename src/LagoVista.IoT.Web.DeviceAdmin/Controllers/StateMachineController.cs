using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
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
    [Route("api/statemachineadmin")]
    public class StateMachineController : LagoVistaBaseController
    {
        IDeviceAdminManager _deviceAmdinManager;

        public StateMachineController(UserManager<AppUser> userManager, ILogger logger, IDeviceAdminManager deviceAdminManager) : base(userManager, logger)
        {
            _deviceAmdinManager = deviceAdminManager;
        }

        /// <summary>
        /// Unit Set - Get View Model
        /// </summary>
        /// <returns>Instance of Unit Set that can be populated.</returns>
        [HttpGet("new")]
        public DetailResponse<StateMachine> NewStateMachine()
        {
            return DetailResponse<StateMachine>.Create();
        }

        /// <summary>
        /// Unit Set - Get View Model
        /// </summary>
        /// <returns>Instance of Unit Set that can be populated.</returns>
        [HttpGet("keyinuse/{key}")]
        public async Task<bool> StateMachineKeyInUse(String key)
        {
            return await _deviceAmdinManager.QueryStateMachineKeyInUseAsync(key, CurrentOrgId);
        }

        /// <summary>
        /// Unit Set - Create New
        /// </summary>
        /// <param name="stateMachine"></param>
        /// <returns></returns>
        [HttpPost()]
        public Task AddStateMachine(StateMachine stateMachine)
        {
            return _deviceAmdinManager.AddStateMachineAsync(stateMachine, UserEntityHeader, OrgEntityHeader);
        }

        /// <summary>
        /// Unit Set - Apply Update
        /// </summary>
        /// <param name="stateMachine"></param>
        /// <returns></returns>
        [HttpPut()]
        public Task UpdateAttributeSet(StateMachine stateMachine)
        {
            return _deviceAmdinManager.UpdateStateMachineAsync(stateMachine, UserEntityHeader);
        }

        /// <summary>
        /// Unit Set - Get for Organization
        /// </summary>
        /// <param name="orgId">Organization Id</param>
        /// <returns></returns>
        [HttpGet("statemachines/{orgid}")]
        public async Task<ListResponse<StateMachineSummary>> GetStateMachinesForOrgAsync(String orgId)
        {
            var unitSets = await _deviceAmdinManager.GetStateMachinesForOrgAsync(orgId);
            var response = ListResponse<StateMachineSummary>.Create(unitSets);

            return response;
        }

        /// <summary>
        /// Unit Set - Get Details
        /// </summary>
        /// <param name="statemachineid"></param>
        /// <returns></returns>
        [HttpGet("attributeunitset/{statemachineid}")]
        public async Task<DetailResponse<StateMachine>> GetAttributeSet(String statemachineid)
        {
            var stateMachine = await _deviceAmdinManager.GetStateMachineAsync(statemachineid, OrgEntityHeader);

            var response = DetailResponse<StateMachine>.Create(stateMachine);

            return response;
        }
    }
}
