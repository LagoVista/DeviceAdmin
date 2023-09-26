using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LagoVista.Core.Models;
using LagoVista.Core;
using LagoVista.Core.Validation;
using LagoVista.Core.Managers;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.Core.Exceptions;
using LagoVista.IoT.DeviceAdmin.Resources;

namespace LagoVista.IoT.DeviceAdmin.Managers
{
    public class DeviceAdminManager : ManagerBase, IDeviceAdminManager
    {
        IDeviceWorkflowRepo _deviceWorkflowRepo;
        IUnitSetRepo _unitSetRepo;
        IStateMachineRepo _stateMachineRepo;
        IStateSetRepo _stateSetRepo;
        IEventSetRepo _eventSetRepo;

        public DeviceAdminManager(IDeviceWorkflowRepo deviceWorkflowRepo, IUnitSetRepo unitSetRepo, IStateMachineRepo stateMachineRepo,
            IStateSetRepo stateSetRepo, IEventSetRepo eventSetRepo, IDependencyManager depManager, ISecurity securityManager, IAdminLogger logger, IAppConfig appConfig) :
            base(logger, appConfig, depManager, securityManager)
        {
            _deviceWorkflowRepo = deviceWorkflowRepo;
            _unitSetRepo = unitSetRepo;
            _stateMachineRepo = stateMachineRepo;
            _stateSetRepo = stateSetRepo;
            _eventSetRepo = eventSetRepo;
        }

    
        public async Task<InvokeResult> AddStateMachineAsync(StateMachine stateMachine, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(stateMachine, AuthorizeResult.AuthorizeActions.Create, user, org);
            ValidationCheck(stateMachine, Actions.Create);
            await _stateMachineRepo.AddStateMachineAsync(stateMachine);
            return InvokeResult.Success;

        }

        public async Task<InvokeResult> AddUnitSetAsync(UnitSet unitSet, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(unitSet, AuthorizeResult.AuthorizeActions.Create, user, org);
            ValidationCheck(unitSet, Actions.Create);
            await _unitSetRepo.AddUnitSetAsync(unitSet);
            return InvokeResult.Success;
        }

        public async Task<InvokeResult> AddStateSetAsync(StateSet stateSet, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(stateSet, AuthorizeResult.AuthorizeActions.Create, user, org);
            ValidationCheck(stateSet, Actions.Create);
            await _stateSetRepo.AddStateSetAsync(stateSet);
            return InvokeResult.Success;
        }

        public async Task<InvokeResult> AddEventSetAsync(EventSet eventSet, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(eventSet, AuthorizeResult.AuthorizeActions.Create, user, org);
            ValidationCheck(eventSet, Actions.Create);
            await _eventSetRepo.AddEventSetAsync(eventSet);
            return InvokeResult.Success;
        }

        public async Task<InvokeResult> AddDeviceWorkflowAsync(DeviceWorkflow deviceWorkflow, EntityHeader org, EntityHeader user)
        {
            if(!this.IsForInitialization)
                await AuthorizeAsync(deviceWorkflow, AuthorizeResult.AuthorizeActions.Create, user, org);
            
            ValidationCheck(deviceWorkflow, Actions.Create);
            await _deviceWorkflowRepo.AddDeviceWorkflowAsync(deviceWorkflow);
            return InvokeResult.Success;
        }

        public async Task<InvokeResult> UpdateStateMachineAsync(StateMachine stateMachine, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(stateMachine, AuthorizeResult.AuthorizeActions.Update, user, org);
            ValidationCheck(stateMachine, Actions.Update);
            stateMachine.LastUpdatedBy = user;
            stateMachine.LastUpdatedDate = DateTime.Now.ToJSONString();
            await _stateMachineRepo.UpdateStateMachineAsync(stateMachine);
            return InvokeResult.Success;
        }

        public async Task<InvokeResult> UpdateUnitSetAsync(UnitSet unitSet, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(unitSet, AuthorizeResult.AuthorizeActions.Update, user, org);
            ValidationCheck(unitSet, Actions.Update);
            unitSet.LastUpdatedBy = user;
            unitSet.LastUpdatedDate = DateTime.Now.ToJSONString();
            await _unitSetRepo.UpdateUnitSetAsync(unitSet);
            return InvokeResult.Success;
        }

        public async Task<InvokeResult> UpdateDeviceWorkflowAsync(DeviceWorkflow deviceWorkflow, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(deviceWorkflow, AuthorizeResult.AuthorizeActions.Update, user, org);
            ValidationCheck(deviceWorkflow, Actions.Update);
            deviceWorkflow.LastUpdatedBy = user;
            deviceWorkflow.LastUpdatedDate = DateTime.Now.ToJSONString();
            await _deviceWorkflowRepo.UpdateDeviceWorkflowAsync(deviceWorkflow);
            return InvokeResult.Success;
        }


        public async Task<InvokeResult> UpdateStateSetAsync(StateSet stateSet, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(stateSet, AuthorizeResult.AuthorizeActions.Update, user, org);
            ValidationCheck(stateSet, Actions.Update);
            stateSet.LastUpdatedBy = user;
            stateSet.LastUpdatedDate = DateTime.Now.ToJSONString();
            await _stateSetRepo.UpdateStateSetAsync(stateSet);
            return InvokeResult.Success;
        }

        public async Task<InvokeResult> UpdateEventSetAsync(EventSet eventSet, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(eventSet, AuthorizeResult.AuthorizeActions.Update, user, org);
            ValidationCheck(eventSet, Actions.Update);
            eventSet.LastUpdatedBy = user;
            eventSet.LastUpdatedDate = DateTime.Now.ToJSONString();
            await _eventSetRepo.UpdateEventSetAsync(eventSet);
            return InvokeResult.Success;
        }

        public async Task<StateMachine> GetStateMachineAsync(String id, EntityHeader org, EntityHeader user)
        {
            var stateMachine = await _stateMachineRepo.GetStateMachineAsync(id);
            await AuthorizeAsync(stateMachine, AuthorizeResult.AuthorizeActions.Read, user, org);
            return stateMachine;
        }

        public async Task<UnitSet> GetAttributeUnitSetAsync(String id, EntityHeader org, EntityHeader user)
        {
            var unitSet = await _unitSetRepo.GetUnitSetAsync(id);
            await AuthorizeAsync(unitSet, AuthorizeResult.AuthorizeActions.Read, user, org);
            return unitSet;
        }

        public async Task<DeviceWorkflow> GetDeviceWorkflowAsync(String id, EntityHeader org, EntityHeader user)
        {
            var deviceWorkflow = await _deviceWorkflowRepo.GetDeviceWorkflowAsync(id);
            await AuthorizeAsync(deviceWorkflow, AuthorizeResult.AuthorizeActions.Read, user, org);
            return deviceWorkflow;
        }

        public async Task<InvokeResult<DeviceWorkflow>> LoadFullDeviceWorkflowAsync(string id, EntityHeader org, EntityHeader user)
        {
            DeviceWorkflow deviceWorkflow = null;
            try
            {
                deviceWorkflow = await _deviceWorkflowRepo.GetDeviceWorkflowAsync(id);
            }
            catch(RecordNotFoundException)
            {
                return InvokeResult<DeviceWorkflow>.FromErrors(ErrorCodes.CouldNotLoadDeviceWorkflow.ToErrorMessage($"WorkflowId={id}"));
            }

            if (deviceWorkflow.Attributes == null) deviceWorkflow.Attributes = new List<Models.Attribute>();
            if (deviceWorkflow.Inputs == null) deviceWorkflow.Inputs = new List<WorkflowInput>();

            var result = new InvokeResult<DeviceWorkflow>();
            foreach (var attribute in deviceWorkflow.Attributes)
            {
                if (attribute.AttributeType != null && attribute.AttributeType.Value == ParameterTypes.ValueWithUnit)
                {
                    /* Will catch validation errors later, so just try to load */
                    if (!EntityHeader.IsNullOrEmpty(attribute.UnitSet))
                    {
                        try
                        {
                            attribute.UnitSet.Value = await GetAttributeUnitSetAsync(attribute.UnitSet.Id, org, user);
                        }
                        catch (RecordNotFoundException)
                        {
                            result.Errors.Add(ErrorCodes.CouldNotLoadUnitSet.ToErrorMessage($"AttributeId={attribute.Id},UnitSetId={attribute.UnitSet.Id}"));
                        }
                    }
                }

                if (!EntityHeader.IsNullOrEmpty(attribute.StateSet))
                {
                    try
                    {
                        attribute.StateSet.Value = await GetStateSetAsync(attribute.StateSet.Id, org, user);
                    }
                    catch (RecordNotFoundException)
                    {
                        result.Errors.Add(ErrorCodes.CouldNotLoadStateSet.ToErrorMessage($"AttributeId={attribute.Id},StateSetId={attribute.StateSet.Id}"));
                    }
                }
            }

            foreach (var input in deviceWorkflow.Inputs)
            {
                if (!EntityHeader.IsNullOrEmpty(input.UnitSet))
                {
                    try
                    {
                        input.UnitSet.Value = await GetAttributeUnitSetAsync(input.UnitSet.Id, org, user);
                    }
                    catch (RecordNotFoundException)
                    {
                        result.Errors.Add(ErrorCodes.CouldNotLoadUnitSet.ToErrorMessage($"InputId={input.Id},UnitSetId={input.UnitSet.Id}"));
                    }
                }

                if (!EntityHeader.IsNullOrEmpty(input.StateSet))
                {
                    try
                    {
                        input.StateSet.Value = await GetStateSetAsync(input.StateSet.Id, org, user);
                    }
                    catch (RecordNotFoundException)
                    {
                        result.Errors.Add(ErrorCodes.CouldNotLoadStateSet.ToErrorMessage($"InputId={input.Id},StateSetId={input.StateSet.Id}"));
                    }
                }
            }

            foreach (var inputCommand in deviceWorkflow.InputCommands)
            {
                if (inputCommand.Parameters != null)
                {
                    foreach (var param in inputCommand.Parameters)
                    {
                        if (param.ParameterType.Value == ParameterTypes.State)
                        {
                            param.StateSet.Value = await _stateSetRepo.GetStateSetAsync(param.StateSet.Id);
                        }
                    }
                }
            }

            if (result.Successful)
            {
                return InvokeResult<DeviceWorkflow>.Create(deviceWorkflow);
            }

            return result;
        }

        public async Task<StateSet> GetStateSetAsync(String id, EntityHeader org, EntityHeader user)
        {
            var stateSet = await _stateSetRepo.GetStateSetAsync(id);
            await AuthorizeAsync(stateSet, AuthorizeResult.AuthorizeActions.Read, user, org);
            return stateSet;
        }

        public async Task<EventSet> GetEventSetAsync(String id, EntityHeader org, EntityHeader user)
        {
            var eventSet = await _eventSetRepo.GetEventSetAsync(id);
            await AuthorizeAsync(eventSet, AuthorizeResult.AuthorizeActions.Read, user, org);
            return eventSet;
        }

        public async Task<IEnumerable<StateMachineSummary>> GetStateMachinesForOrgAsync(String orgId, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, orgId, typeof(StateMachine));
            return await _stateMachineRepo.GetStateMachinesForOrgAsync(orgId);
        }

        public async Task<IEnumerable<UnitSetSummary>> GetUnitSetsForOrgAsync(String orgId, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, orgId, typeof(UnitSet));
            return await _unitSetRepo.GetUnitSetsForOrgAsync(orgId);
        }

        public async Task<IEnumerable<DeviceWorkflowSummary>> GetDeviceWorkflowsForOrgsAsync(String orgId, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, orgId, typeof(DeviceWorkflow));
            return await _deviceWorkflowRepo.GetDeviceWorkflowsForOrgAsync(orgId);
        }

        public async Task<IEnumerable<StateSetSummary>> GetStateSetsForOrgAsync(String orgId, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, orgId, typeof(StateSet));
            return await _stateSetRepo.GetStateSetsForOrgAsync(orgId);
        }

        public async Task<IEnumerable<EventSetSummary>> GetEventSetsForOrgAsync(String orgId, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, orgId, typeof(EventSet));
            return await _eventSetRepo.GetEventSetsForOrgAsync(orgId);
        }


        public Task<bool> QueryDeviceWorkflowKeyInUseAsync(String key, String orgId)
        {
            return _deviceWorkflowRepo.QueryKeyInUseAsync(key, orgId);
        }

        public Task<bool> QueryStateMachineKeyInUseAsync(String key, String orgId)
        {
            return _stateMachineRepo.QueryKeyInUseAsync(key, orgId);
        }

        public Task<bool> QueryAttributeUnitSetKeyInUseAsync(String key, String orgId)
        {
            return _unitSetRepo.QueryKeyInUseAsync(key, orgId);
        }


        public Task<bool> QueryStateSetKeyInUseAsync(String key, String orgId)
        {
            return _stateSetRepo.QueryKeyInUseAsync(key, orgId);
        }

        public Task<bool> QueryEventSetKeyInUseAsync(String key, String orgId)
        {
            return _eventSetRepo.QueryKeyInUseAsync(key, orgId);
        }

        public async Task<InvokeResult> DeleteDeviceWorkflowAsync(string workflowId, EntityHeader org, EntityHeader user)
        {
            var deviceWorkflow = await _deviceWorkflowRepo.GetDeviceWorkflowAsync(workflowId);
            await AuthorizeAsync(deviceWorkflow, AuthorizeResult.AuthorizeActions.Delete, user, org);
            await ConfirmNoDepenenciesAsync(deviceWorkflow);
            await _deviceWorkflowRepo.DeleteDeviceWorkflowAsync(deviceWorkflow.Id);

            return InvokeResult.Success;
        }

        public async Task<InvokeResult> DeleteStateMachineAsync(string stateMachineId, EntityHeader org, EntityHeader user)
        {
            var stateMachine = await _stateMachineRepo.GetStateMachineAsync(stateMachineId);
            await AuthorizeAsync(stateMachine, AuthorizeResult.AuthorizeActions.Delete, user, org);
            await ConfirmNoDepenenciesAsync(stateMachine);
            await _stateMachineRepo.DeleteStateMachineAsync(stateMachineId);

            return InvokeResult.Success;
        }

        public async Task<InvokeResult> DeleteUnitSetAsync(string unitSetId, EntityHeader org, EntityHeader user)
        {
            var unitSet = await _unitSetRepo.GetUnitSetAsync(unitSetId);
            await AuthorizeAsync(unitSet, AuthorizeResult.AuthorizeActions.Delete, user, org);
            await ConfirmNoDepenenciesAsync(unitSet);
            await _unitSetRepo.DeleteUnitSetAsync(unitSetId);
            return InvokeResult.Success;
        }

        public async Task<InvokeResult> DeleteStateSetAsync(string stateSetId, EntityHeader org, EntityHeader user)
        {
            var stateSet = await _stateSetRepo.GetStateSetAsync(stateSetId);
            await AuthorizeAsync(stateSet, AuthorizeResult.AuthorizeActions.Delete, user, org);
            await ConfirmNoDepenenciesAsync(stateSet);
            await _stateSetRepo.DeleteStateSetAsync(stateSetId);
            return InvokeResult.Success;
        }

        public async Task<InvokeResult> DeleteEventSetAsync(string eventSetId, EntityHeader org, EntityHeader user)
        {
            var eventSet = await _eventSetRepo.GetEventSetAsync(eventSetId);
            await AuthorizeAsync(eventSet, AuthorizeResult.AuthorizeActions.Delete, user, org);
            await ConfirmNoDepenenciesAsync(eventSet);
            await _eventSetRepo.DeleteEventSetAsync(eventSetId);
            return InvokeResult.Success;
        }

        public async Task<DependentObjectCheckResult> CheckInUseDeviceWorkflowAsync(string workflowId, EntityHeader org, EntityHeader user)
        {
            var eventSet = await _deviceWorkflowRepo.GetDeviceWorkflowAsync(workflowId);
            await AuthorizeAsync(eventSet, AuthorizeResult.AuthorizeActions.Read, user, org);
            return await CheckForDepenenciesAsync(eventSet);
        }

        public async Task<DependentObjectCheckResult> CheckInUseStateMachineAsync(string stateMachineId, EntityHeader org, EntityHeader user)
        {
            var stateMachine = await _stateMachineRepo.GetStateMachineAsync(stateMachineId);
            await AuthorizeAsync(stateMachine, AuthorizeResult.AuthorizeActions.Read, user, org);
            return await CheckForDepenenciesAsync(stateMachine);
        }

        public async Task<DependentObjectCheckResult> CheckInUseUnitSetAsync(string unitSetId, EntityHeader org, EntityHeader user)
        {
            var unitSet = await _unitSetRepo.GetUnitSetAsync(unitSetId);
            await AuthorizeAsync(unitSet, AuthorizeResult.AuthorizeActions.Read, user, org);
            return await CheckForDepenenciesAsync(unitSet);
        }

        public async Task<DependentObjectCheckResult> CheckInUseStateSetAsync(string stateSetId, EntityHeader org, EntityHeader user)
        {
            var stateSet = await _stateSetRepo.GetStateSetAsync(stateSetId);
            await AuthorizeAsync(stateSet, AuthorizeResult.AuthorizeActions.Read, user, org);
            return await CheckForDepenenciesAsync(stateSet);
        }

        public async Task<DependentObjectCheckResult> CheckInUseEventSetAsync(string eventSetId, EntityHeader org, EntityHeader user)
        {
            var eventSet = await _eventSetRepo.GetEventSetAsync(eventSetId);
            await AuthorizeAsync(eventSet, AuthorizeResult.AuthorizeActions.Read, user, org);
            return await CheckForDepenenciesAsync(eventSet);
        }
    }
}
