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
using LagoVista.Core.Validation;
using LagoVista.Core.Models;

namespace LagoVista.IoT.DeviceAdmin.Rest.Controllers
{
    [Authorize]
    public class StateMachineController : LagoVistaBaseController
    {
        IDeviceAdminManager _deviceAdminManager;

        public StateMachineController(UserManager<AppUser> userManager, ILogger logger, IDeviceAdminManager deviceAdminManager) : base(userManager, logger)
        {
            _deviceAdminManager = deviceAdminManager;
        }

        #region Add New
        /// <summary>
        /// State Machine - Add New
        /// </summary>
        /// <param name="stateMachine"></param>
        /// <returns></returns>
        [HttpPost("/api/statemachine")]
        public Task AddStateMachine([FromBody] StateMachine stateMachine)
        {
            return _deviceAdminManager.AddStateMachineAsync(stateMachine, OrgEntityHeader, UserEntityHeader);
        }


        /// <summary>
        /// Event Set - Add
        /// </summary>
        /// <param name="eventSet"></param>
        /// <returns></returns>
        [HttpPost("/api/statemachine/eventset")]
        public Task AddEventSet([FromBody] EventSet eventSet)
        {
            return _deviceAdminManager.AddEventSetAsync(eventSet, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// State Set - Add
        /// </summary>
        /// <param name="stateSet"></param>
        /// <returns></returns>
        [HttpPost("/api/statemachine/stateset")]
        public Task AddStateSet([FromBody] StateSet stateSet)
        {
            return _deviceAdminManager.AddStateSetAsync(stateSet, OrgEntityHeader, UserEntityHeader);
        }
        #endregion

        #region Update
        /// <summary>
        /// State Machine - Update
        /// </summary>
        /// <param name="stateMachine"></param>
        /// <returns></returns>
        [HttpPut("/api/statemachine")]
        public Task UpdateStateMachine([FromBody] StateMachine stateMachine)
        {
            SetUpdatedProperties(stateMachine);
            return _deviceAdminManager.UpdateStateMachineAsync(stateMachine, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        ///  State Set - Update
        /// </summary>
        /// <param name="stateSet"></param>
        /// <returns></returns>
        [HttpPut("/api/statemachine/stateset")]
        public Task UpdateStateSet([FromBody] StateSet stateSet)
        {
            SetUpdatedProperties(stateSet);
            return _deviceAdminManager.UpdateStateSetAsync(stateSet, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Event Set - Update
        /// </summary>
        /// <param name="eventSet"></param>
        /// <returns></returns>
        [HttpPut("/api/statemachine/eventset")]
        public Task UpdateEventSet([FromBody] EventSet eventSet)
        {
            SetUpdatedProperties(eventSet);
            return _deviceAdminManager.UpdateEventSetAsync(eventSet, OrgEntityHeader, UserEntityHeader);
        }
        #endregion

        #region Read
        /// <summary>
        /// State Machine - Get Detail
        /// </summary>
        /// <param name="statemachineid"></param>
        /// <returns></returns>
        [HttpGet("/api/statemachine/{statemachineid}")]
        public async Task<DetailResponse<StateMachine>> GetStateMachineAsync(String statemachineid)
        {
            var stateMachine = await _deviceAdminManager.GetStateMachineAsync(statemachineid, OrgEntityHeader, UserEntityHeader);
            return DetailResponse<StateMachine>.Create(stateMachine);
        }

        /// <summary>
        /// Event Set - Get Detail
        /// </summary>
        /// <param name="eventSetId"></param>
        /// <returns></returns>
        [HttpGet("/api/statemachine/eventset/{eventSetId}")]
        public async Task<DetailResponse<EventSet>> GetEventSet(String eventSetId)
        {
            var eventSet = await _deviceAdminManager.GetEventSetAsync(eventSetId, OrgEntityHeader, UserEntityHeader);
            return DetailResponse<EventSet>.Create(eventSet);
        }

        /// <summary>
        /// State Machine - Get Detail
        /// </summary>
        /// <param name="stateSetId"></param>
        /// <returns></returns>
        [HttpGet("/api/statemachine/stateset/{stateSetId}")]
        public async Task<DetailResponse<StateSet>> GetStateSet(String stateSetId)
        {
            var stateMachine = await _deviceAdminManager.GetStateSetAsync(stateSetId, OrgEntityHeader, UserEntityHeader);
            return DetailResponse<StateSet>.Create(stateMachine);
        }
        #endregion

        #region Get For Org
        /// <summary>
        /// State Machines - Get for org
        /// </summary>
        /// <param name="orgId">Organization Id</param>
        /// <returns></returns>
        [HttpGet("/api/org/{orgid}/statemachines")]
        public async Task<ListResponse<StateMachineSummary>> GetStateMachinesForOrgAsync(String orgId)
        {
            var stateMachines = await _deviceAdminManager.GetStateMachinesForOrgAsync(orgId, UserEntityHeader);
            return ListResponse<StateMachineSummary>.Create(stateMachines);
        }

        /// <summary>
        /// Event Sets - Get for org
        /// </summary>
        /// <param name="orgId">Organization Id</param>
        /// <returns></returns>
        [HttpGet("/api/org/{orgid}/statemachine/eventsets")]
        public async Task<ListResponse<EventSetSummary>> GetEventSetsForOrgAsync(String orgId)
        {
            var eventSets = await _deviceAdminManager.GetEventSetsForOrgAsync(orgId, UserEntityHeader);
            return ListResponse<EventSetSummary>.Create(eventSets);
        }

        /// <summary>
        /// State Set - Get for org
        /// </summary>
        /// <param name="orgId">Organization Id</param>
        /// <returns></returns>
        [HttpGet("/api/org/{orgid}/statemachine/statesets")]
        public async Task<ListResponse<StateSetSummary>> GetStateSetsForOrgAsync(String orgId)
        {
            var stateSets = await _deviceAdminManager.GetStateSetsForOrgAsync(orgId, UserEntityHeader);
            return ListResponse<StateSetSummary>.Create(stateSets);
        }
        #endregion

        #region Delete 
        /// <summary>
        /// Event Set - Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/statemachine/eventset/{id}")]
        public Task<InvokeResult> DeleteEventSetAsync(string id)
        {
            return _deviceAdminManager.DeleteEventSetAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// State Set - Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/statemachine/stateset/{id}")]
        public Task<InvokeResult> DeleteStateSetAsync(string id)
        {
            return _deviceAdminManager.DeleteStateSetAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// State Machine - Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/statemachine/{id}")]
        public Task<InvokeResult> DeleteStateMachineAsync(string id)
        {
            return _deviceAdminManager.DeleteStateMachineAsync(id, OrgEntityHeader, UserEntityHeader);
        }
        #endregion

        #region Check In Use
        /// <summary>
        /// Event Set - Check In Use
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/statemachine/eventset/{id}/inuse")]
        public Task<DependentObjectCheckResult> CheckEventSetInUseAsync(string id)
        {
            return _deviceAdminManager.CheckInUseEventSetAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// State Set - Check In Use
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/statemachine/stateset/{id}/inuse")]
        public Task<DependentObjectCheckResult> CheckStateSetInUseAsync(string id)
        {
            return _deviceAdminManager.CheckInUseStateSetAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// State Machine - Check In Use
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/statemachine/{id}/inuse")]
        public Task<DependentObjectCheckResult> CheckStateMachineInUseAsync(string id)
        {
            return _deviceAdminManager.CheckInUseStateMachineAsync(id, OrgEntityHeader, UserEntityHeader);
        }
        #endregion

        #region Query Key In Use
        /// <summary>
        /// State Machine - Key in use
        /// </summary>
        /// <returns>Instance of Unit Set that can be populated.</returns>
        [HttpGet("/api/statemachine/{key}/keyinuse")]
        public async Task<bool> StateMachineKeyInUse(String key)
        {
            return await _deviceAdminManager.QueryStateMachineKeyInUseAsync(key, CurrentOrgId);
        }

        /// <summary>
        /// State Machine - Key in use
        /// </summary>
        /// <returns>Instance of Unit Set that can be populated.</returns>
        [HttpGet("/api/statemachine/stateset/{key}/keyinuse")]
        public async Task<bool> StateSetKeyInUse(String key)
        {
            return await _deviceAdminManager.QueryStateSetKeyInUseAsync(key, CurrentOrgId);
        }

        /// <summary>
        /// State Machine - Key in use
        /// </summary>
        /// <returns>Instance of Unit Set that can be populated.</returns>
        [HttpGet("/api/statemachine/eventset/{key}/keyinuse")]
        public async Task<bool> EventSetKeyInUse(String key)
        {
            return await _deviceAdminManager.QueryEventSetKeyInUseAsync(key, CurrentOrgId);
        }
        #endregion

        #region Factories
        /// <summary>
        /// State Machine - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/statemachine/factory")]
        public DetailResponse<StateMachine> NewStateMachine()
        {
            var stateMachine = DetailResponse<StateMachine>.Create();
            stateMachine.Model.Id = Guid.NewGuid().ToId();
            SetOwnedProperties(stateMachine.Model);
            SetAuditProperties(stateMachine.Model);

            return stateMachine;
        }

        /// <summary>
        /// State Set - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/statemachine/stateset/factory")]
        public DetailResponse<StateSet> CreateStateSet()
        {
            var response = DetailResponse<StateSet>.Create();
            response.Model.Id = Guid.NewGuid().ToId();            
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
            return response;
        }

        /// <summary>
        ///  State - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/statemachine/state/factory")]
        public DetailResponse<State> CreatState()
        {
            return DetailResponse<State>.Create();
        }

        /// <summary>
        /// Event Set - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/statemachine/eventset/factory")]
        public DetailResponse<EventSet> CreateEventSet()
        {
            var response = DetailResponse<EventSet>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);
            return response;
        }

        /// <summary>
        ///  Event - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/statemachine/event/factory")]
        public DetailResponse<Event> CreateEvent()
        {
            return DetailResponse<Event>.Create();
        }

        /// <summary>
        ///  Transition - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/statemachine/transition/factory")]
        public DetailResponse<StateTransition> CreateTransition()
        {
            return DetailResponse<StateTransition>.Create();
        }
        #endregion
    }
}