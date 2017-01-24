using LagoVista.Core.Interfaces;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Web.Common.Controllers;
using LagoVista.UserManagement.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LagoVista.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace LagoVista.IoT.Web.DeviceAdmin.Controllers
{
    [Authorize]
    [Route("api/statemachines")]
    public class StateMachineController : LagoVistaBaseController
    {
        IDeviceAdminManager _deviceAmdinManager;

        private void SetAuditProperties(IAuditableEntity entity)
        {
            var createDate = DateTime.Now.ToJSONString();

            entity.CreationDate = createDate;
            entity.LastUpdatedDate = createDate;
            entity.CreatedBy = UserEntityHeader;
            entity.LastUpdatedBy = UserEntityHeader;
        }

        private void SetOwnedProperties(IOwnedEntity entity)
        {
            entity.OwnerOrganization = OrgEntityHeader;
        }


        public StateMachineController(UserManager<AppUser> userManager, ILogger logger, IDeviceAdminManager deviceAdminManager) : base(userManager, logger)
        {
            _deviceAmdinManager = deviceAdminManager;
        }

        /// <summary>
        /// State Machine - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("factory")]
        public DetailResponse<StateMachine> NewStateMachine()
        {
            var stateMachine = DetailResponse<StateMachine>.Create();
            stateMachine.Model.Id = Guid.NewGuid().ToId();

            SetOwnedProperties(stateMachine.Model);
            SetAuditProperties(stateMachine.Model);

            stateMachine.Model.States = new ObservableCollection<State>();
            stateMachine.Model.Events = new ObservableCollection<StateMachineEvent>();
            stateMachine.Model.Variables = new ObservableCollection<CustomField>();
            stateMachine.Model.InitialActions = new ObservableCollection<Core.Models.EntityHeader>();

            return stateMachine;
        }

        /// <summary>
        /// State Machien - Key in use
        /// </summary>
        /// <returns>Instance of Unit Set that can be populated.</returns>
        [HttpGet("keyinuse/{key}")]
        public async Task<bool> StateMachineKeyInUse(String key)
        {
            return await _deviceAmdinManager.QueryStateMachineKeyInUseAsync(key, CurrentOrgId);
        }

        /// <summary>
        /// State Machine - Add New
        /// </summary>
        /// <param name="stateMachine"></param>
        /// <returns></returns>
        [HttpPost()]
        public Task AddStateMachine([FromBody] StateMachine stateMachine)
        {
            return _deviceAmdinManager.AddStateMachineAsync(stateMachine, UserEntityHeader, OrgEntityHeader);
        }

        /// <summary>
        /// State Machine - Update
        /// </summary>
        /// <param name="stateMachine"></param>
        /// <returns></returns>
        [HttpPut()]
        public Task UpdateAttributeSet([FromBody] StateMachine stateMachine)
        {
            return _deviceAmdinManager.UpdateStateMachineAsync(stateMachine, UserEntityHeader);
        }

        /// <summary>
        /// State Machines - Get for org
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
        /// State Machine - Get Detail
        /// </summary>
        /// <param name="statemachineid"></param>
        /// <returns></returns>
        [HttpGet("{statemachineid}")]
        public async Task<DetailResponse<StateMachine>> GetStateMachineAsync(String statemachineid)
        {
            var stateMachine = await _deviceAmdinManager.GetStateMachineAsync(statemachineid, OrgEntityHeader);

            var response = DetailResponse<StateMachine>.Create(stateMachine);

            return response;
        }

        /// <summary>
        ///  State - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("factory/state")]
        public DetailResponse<State> CreatState()
        {
            var response = DetailResponse<State>.Create();
            response.Model.Transitions = new ObservableCollection<StateTransition>();
            return response;
        }

        /// <summary>
        ///  State Event - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("factory/event")]
        public DetailResponse<StateMachineEvent> CreateEvent()
        {
            var response = DetailResponse<StateMachineEvent>.Create();
            return response;
        }

        /// <summary>
        ///  State - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("factory/transition")]
        public DetailResponse<StateTransition> CreateTransition()
        {
            var response = DetailResponse<StateTransition>.Create();
            response.Model.TransitionActions = new ObservableCollection<IEntityHeader>();
            return response;
        }
    }
}
