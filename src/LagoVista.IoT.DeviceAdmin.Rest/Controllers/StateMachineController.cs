using LagoVista.Core.Interfaces;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Web.Common.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LagoVista.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LagoVista.IoT.DeviceAdmin.Resources;
using LagoVista.UserAdmin.Models.Account;

namespace LagoVista.IoT.DeviceAdmin.Rest.Controllers
{
    [Authorize]
    [Route("api/statemachines")]
    public class StateMachineController : LagoVistaBaseController
    {
        IDeviceAdminManager _deviceAdminManager;

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
            _deviceAdminManager = deviceAdminManager;
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
            stateMachine.Model.Pages.Add(new Page()
            {
                PageNumber = 1,
                Name = DeviceLibraryResources.Common_PageNumberOne
            });

            SetOwnedProperties(stateMachine.Model);
            SetAuditProperties(stateMachine.Model);

            return stateMachine;
        }

        /// <summary>
        /// State Machine - Key in use
        /// </summary>
        /// <returns>Instance of Unit Set that can be populated.</returns>
        [HttpGet("keyinuse/{key}")]
        public async Task<bool> StateMachineKeyInUse(String key)
        {
            return await _deviceAdminManager.QueryStateMachineKeyInUseAsync(key, CurrentOrgId);
        }

        /// <summary>
        /// State Machine - Key in use
        /// </summary>
        /// <returns>Instance of Unit Set that can be populated.</returns>
        [HttpGet("stateset/keyinuse/{key}")]
        public async Task<bool> StateSetKeyInUse(String key)
        {
            return await _deviceAdminManager.QueryStateSetKeyInUseAsync(key, CurrentOrgId);
        }

        /// <summary>
        /// State Machine - Key in use
        /// </summary>
        /// <returns>Instance of Unit Set that can be populated.</returns>
        [HttpGet("eventset/keyinuse/{key}")]
        public async Task<bool> EventSetKeyInUse(String key)
        {
            return await _deviceAdminManager.QueryEventSetKeyInUseAsync(key, CurrentOrgId);
        }

        /// <summary>
        /// State Machine - Add New
        /// </summary>
        /// <param name="stateMachine"></param>
        /// <returns></returns>
        [HttpPost()]
        public Task AddStateMachine([FromBody] StateMachine stateMachine)
        {
            return _deviceAdminManager.AddStateMachineAsync(stateMachine, UserEntityHeader, OrgEntityHeader);
        }

        /// <summary>
        /// State Machine - Update
        /// </summary>
        /// <param name="stateMachine"></param>
        /// <returns></returns>
        [HttpPut()]
        public Task UpdateStateMachine([FromBody] StateMachine stateMachine)
        {
            return _deviceAdminManager.UpdateStateMachineAsync(stateMachine, UserEntityHeader);
        }

        /// <summary>
        /// State Machines - Get for org
        /// </summary>
        /// <param name="orgId">Organization Id</param>
        /// <returns></returns>
        [HttpGet("statemachines/{orgid}")]
        public async Task<ListResponse<StateMachineSummary>> GetStateMachinesForOrgAsync(String orgId)
        {
            var stateMachines = await _deviceAdminManager.GetStateMachinesForOrgAsync(orgId);
            var response = ListResponse<StateMachineSummary>.Create(stateMachines);

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
            var stateMachine = await _deviceAdminManager.GetStateMachineAsync(statemachineid, OrgEntityHeader);

            var response = DetailResponse<StateMachine>.Create(stateMachine);

            return response;
        }


        /// <summary>
        /// State Machine - Get Detail
        /// </summary>
        /// <param name="stateSetId"></param>
        /// <returns></returns>
        [HttpGet("stateset/{stateSetId}")]
        public async Task<DetailResponse<StateSet>> GetStateSet(String stateSetId)
        {
            var stateMachine = await _deviceAdminManager.GetStateSetAsync(stateSetId, OrgEntityHeader);

            var response = DetailResponse<StateSet>.Create(stateMachine);

            return response;
        }

        /// <summary>
        /// Event Machine - Get Detail
        /// </summary>
        /// <param name="eventSetId"></param>
        /// <returns></returns>
        [HttpGet("eventset/{eventSetId}")]
        public async Task<DetailResponse<EventSet>> GetEventSet(String eventSetId)
        {
            var eventSet = await _deviceAdminManager.GetEventSetAsync(eventSetId, OrgEntityHeader);

            var response = DetailResponse<EventSet>.Create(eventSet);
            return response;
        }



        /// <summary>
        /// Event Sets - Get for org
        /// </summary>
        /// <param name="orgId">Organization Id</param>
        /// <returns></returns>
        [HttpGet("eventsets/{orgid}")]
        public async Task<ListResponse<EventSetSummary>> GetEventSetsForOrgAsync(String orgId)
        {
            var eventSets = await _deviceAdminManager.GetEventSetsForOrgAsync(orgId);
            return ListResponse<EventSetSummary>.Create(eventSets);
        }


        /// <summary>
        /// State Set - Get for org
        /// </summary>
        /// <param name="orgId">Organization Id</param>
        /// <returns></returns>
        [HttpGet("statesets/{orgid}")]
        public async Task<ListResponse<StateSetSummary>> GetStateSetsForOrgAsync(String orgId)
        {
            var stateSets = await _deviceAdminManager.GetStateSetsForOrgAsync(orgId);
            return ListResponse<StateSetSummary>.Create(stateSets);
        }


        /// <summary>
        /// State Set - Add
        /// </summary>
        /// <param name="stateSet"></param>
        /// <returns></returns>
        [HttpPost("stateset")]
        public Task AddStateSet([FromBody] StateSet stateSet)
        {
            return _deviceAdminManager.AddStateSetAsync(stateSet, UserEntityHeader, OrgEntityHeader);
        }

        /// <summary>
        /// Event Set - Add
        /// </summary>
        /// <param name="eventSet"></param>
        /// <returns></returns>
        [HttpPost("eventset")]
        public Task AddEventSet([FromBody] EventSet eventSet)
        {
            return _deviceAdminManager.AddEventSetAsync(eventSet, UserEntityHeader, OrgEntityHeader);
        }

        /// <summary>
        ///  State Set - Update
        /// </summary>
        /// <param name="stateSet"></param>
        /// <returns></returns>
        [HttpPut("stateset")]
        public Task UpdateStateSet([FromBody] StateSet stateSet)
        {
            return _deviceAdminManager.UpdateStateSetAsync(stateSet, UserEntityHeader);
        }

        /// <summary>
        /// Update Event - Set
        /// </summary>
        /// <param name="eventSet"></param>
        /// <returns></returns>
        [HttpPut("eventset")]
        public Task UpdateEventSet([FromBody] EventSet eventSet)
        {
            return _deviceAdminManager.UpdateEventSetAsync(eventSet, UserEntityHeader);
        }

        /// <summary>
        /// State Set - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("factory/stateset")]
        public DetailResponse<StateSet> CreateStateSet()
        {
            var response = DetailResponse<StateSet>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            response.Model.States = new List<State>();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
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
            return response;
        }

        /// <summary>
        /// State Set - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("factory/eventset")]
        public DetailResponse<EventSet> CreateEventSet()
        {
            var response = DetailResponse<EventSet>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
            return response;
        }


        /// <summary>
        ///  State Event - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("factory/event")]
        public DetailResponse<Event> CreateEvent()
        {
            var response = DetailResponse<Event>.Create();
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
            return response;
        }
    }
}