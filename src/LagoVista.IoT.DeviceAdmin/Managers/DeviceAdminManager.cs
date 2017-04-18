using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LagoVista.Core.Models;
using LagoVista.Core;
using LagoVista.Core.Validation;

namespace LagoVista.IoT.DeviceAdmin.Managers
{
    public class DeviceAdminManager : IDeviceAdminManager
    {
        IDeviceWorkflowRepo _deviceWorkflowRepo;
        ISharedActionRepo _sharedActionRepo;
        ISharedAtributeRepo _sharedAttributeRepo;
        IUnitSetRepo _unitSetRepo;
        IStateMachineRepo _stateMachineRepo;
        IStateSetRepo _stateSetRepo;
        IEventSetRepo _eventSetRepo;

        public DeviceAdminManager( ISharedActionRepo sharedActionRepo, IDeviceWorkflowRepo deviceWorkflowRepo, ISharedAtributeRepo sharedAttributeRepo,
            IUnitSetRepo unitSetRepo, IStateMachineRepo stateMachineRepo, IStateSetRepo stateSetRepo, IEventSetRepo eventSetRepo)
        {
            _deviceWorkflowRepo = deviceWorkflowRepo;
            _sharedActionRepo = sharedActionRepo;
            _sharedAttributeRepo = sharedAttributeRepo;
            _unitSetRepo = unitSetRepo;
            _stateMachineRepo = stateMachineRepo;
            _stateSetRepo = stateSetRepo;
            _eventSetRepo = eventSetRepo;
        }

        public async Task<InvokeResult> AddStateMachineAsync(StateMachine stateMachine, EntityHeader org, EntityHeader user)
        {
            var result = Validator.Validate(stateMachine, Actions.Create);
            if (result.IsValid)
            {
                await _stateMachineRepo.AddStateMachineAsync(stateMachine);
            }

            return result.ToActionResult();

        }

        public async Task<InvokeResult> AddSharedActionAsync(SharedAction sharedAction, EntityHeader org, EntityHeader user)
        {
            var result = Validator.Validate(sharedAction, Actions.Create);
            if (result.IsValid)
            {
                await _sharedActionRepo.AddSharedActionAsync(sharedAction);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> AddSharedAttributeAsync(SharedAttribute sharedAttribute, EntityHeader org, EntityHeader user)
        {
            var result = Validator.Validate(sharedAttribute, Actions.Create);
            if (result.IsValid)
            {
                await _sharedAttributeRepo.AddSharedAttributeAsync(sharedAttribute);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> AddUnitSetAsync(UnitSet unitSet, EntityHeader org, EntityHeader user)
        {
            var result = Validator.Validate(unitSet, Actions.Create);
            if (result.IsValid)
            {

                await _unitSetRepo.AddUnitSetAsync(unitSet);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> AddStateSetAsync(StateSet stateSet, EntityHeader org, EntityHeader user)
        {
            var result = Validator.Validate(stateSet, Actions.Create);
            if (result.IsValid)
            {
                await _stateSetRepo.AddStateSetAsync(stateSet);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> AddEventSetAsync(EventSet eventSet, EntityHeader org, EntityHeader user)
        {
            var result = Validator.Validate(eventSet, Actions.Create);
            if (result.IsValid)
            {
                await _eventSetRepo.AddEventSetAsync(eventSet);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> AddDeviceWorkflowAsync(DeviceWorkflow deviceWorkflow, EntityHeader org, EntityHeader user)
        {
            var result = Validator.Validate(deviceWorkflow, Actions.Create);

            if (result.IsValid)
            {
                await _deviceWorkflowRepo.AddDeviceWorkflowAsync(deviceWorkflow);
            }

            return result.ToActionResult();
        }


        public async Task<InvokeResult> UpdateStateMachineAsync(StateMachine stateMachine, EntityHeader user)
        {
            var result = Validator.Validate(stateMachine, Actions.Create);

            if (result.IsValid)
            {
                stateMachine.LastUpdatedBy = user;
                stateMachine.LastUpdatedDate = DateTime.Now.ToJSONString();

                await _stateMachineRepo.UpdateStateMachineAsync(stateMachine);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> UpdateSharedActionAsync(SharedAction sharedAction, EntityHeader user)
        {
            var result = Validator.Validate(sharedAction, Actions.Create);

            if (result.IsValid)
            {
                sharedAction.LastUpdatedBy = user;
                sharedAction.LastUpdatedDate = DateTime.Now.ToJSONString();
                await _sharedActionRepo.UpdateSharedActionAsync(sharedAction);
            }

            return result.ToActionResult();

        }

        public async Task<InvokeResult> UpdateSharedAttributeAsync(SharedAttribute sharedAttribute, EntityHeader user)
        {
            var result = Validator.Validate(sharedAttribute, Actions.Create);

            if (result.IsValid)
            {
                sharedAttribute.LastUpdatedBy = user;
                sharedAttribute.LastUpdatedDate = DateTime.Now.ToJSONString();

                await _sharedAttributeRepo.UpdateSharedAttributeAsync(sharedAttribute);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> UpdateUnitSetAsync(UnitSet unitSet, EntityHeader user)
        {
            var result = Validator.Validate(unitSet, Actions.Create);

            if (result.IsValid)
            {
                unitSet.LastUpdatedBy = user;
                unitSet.LastUpdatedDate = DateTime.Now.ToJSONString();
                await _unitSetRepo.UpdateUnitSetAsync(unitSet);
            }

            return result.ToActionResult();
        }    

        public async Task<InvokeResult> UpdateDeviceWorkflowAsync(DeviceWorkflow deviceWorkflow, EntityHeader user)
        {
            var result = Validator.Validate(deviceWorkflow, Actions.Create);

            if (result.IsValid)
            {
                deviceWorkflow.LastUpdatedBy = user;
                deviceWorkflow.LastUpdatedDate = DateTime.Now.ToJSONString();
                await _deviceWorkflowRepo.UpdateDeviceWorkflowAsync(deviceWorkflow);
            }

            return result.ToActionResult();
        }


        public async Task<InvokeResult> UpdateStateSetAsync(StateSet stateSet, EntityHeader user)
        {
            var result = Validator.Validate(stateSet, Actions.Create);

            if (result.IsValid)
            {
                stateSet.LastUpdatedBy = user;
                stateSet.LastUpdatedDate = DateTime.Now.ToJSONString();
                await _stateSetRepo.UpdateStateSetAsync(stateSet);
            }

            return result.ToActionResult();
        }

        public async Task<InvokeResult> UpdateEventSetAsync(EventSet eventSet, EntityHeader user)
        {
            var result = Validator.Validate(eventSet, Actions.Create);

            if (result.IsValid)
            {
                eventSet.LastUpdatedBy = user;
                eventSet.LastUpdatedDate = DateTime.Now.ToJSONString();
                await _eventSetRepo.UpdateEventSetAsync(eventSet);
            }

            return result.ToActionResult();
        }

        public async Task<StateMachine> GetStateMachineAsync(String id, EntityHeader org)
        {
            var stateMachine = await _stateMachineRepo.GetStateMachineAsync(id);
            if (!stateMachine.IsPublic && stateMachine.OwnerOrganization != org)
            {
                throw new Exception();
            }

            return stateMachine;
        }

        public async Task<SharedAction> GetSharedActionAsync(String id, EntityHeader org)
        {
            var sharedAction = await _sharedActionRepo.GetSharedActionAsync(id);
            if (!sharedAction.IsPublic && sharedAction.OwnerOrganization != org)
            {
                throw new Exception();
            }

            return  sharedAction ;
        }

        public async Task<SharedAttribute> GetSharedAttributeAsync(String id, EntityHeader org)
        {
            var sharedAttribute = await _sharedAttributeRepo.GetSharedAttributeAsync(id);
            if (!sharedAttribute.IsPublic && sharedAttribute.OwnerOrganization.Id != org.Id)
            {
                throw new Exception();
            }

            return  sharedAttribute ;
        }

        public async Task<UnitSet> GetAttributeUnitSetAsync(String id, EntityHeader org)
        {
            var unitSet = await _unitSetRepo.GetUnitSetAsync(id);
            if (!unitSet.IsPublic && (unitSet.OwnerOrganization.Id != org.Id))
            {
                throw new Exception();
            }

            return unitSet;
        }

        public Task<UnitSet> LoadAttributeUnitSetAsync(String id)
        {
            return _unitSetRepo.GetUnitSetAsync(id);
        }

        public async Task<DeviceWorkflow> GetDeviceWorkflowAsync(String id, EntityHeader org)
        {
            var deviceWorkflow = await _deviceWorkflowRepo.GetDeviceWorkflowAsync(id);
            if (!deviceWorkflow.IsPublic && deviceWorkflow.OwnerOrganization.Id != org.Id)
            {
                throw new Exception();
            }            

            return deviceWorkflow;
        }

        public async Task<DeviceWorkflow> LoadFullDeviceWorkflowAsync(string id)
        {
            var deviceWorkflow = await _deviceWorkflowRepo.GetDeviceWorkflowAsync(id);

            foreach (var attribute in deviceWorkflow.Attributes)
            {
                if (attribute.UnitSet.HasValue)
                {
                    attribute.UnitSet.Value = await LoadAttributeUnitSetAsync(attribute.UnitSet.Id);
                }

                if (attribute.StateSet.HasValue)
                {
                    attribute.StateSet.Value = await LoadStateSetAsync(attribute.StateSet.Id);
                }
            }

            foreach (var input in deviceWorkflow.Inputs)
            {
                if (input.UnitSet.HasValue)
                {
                    input.UnitSet.Value = await LoadAttributeUnitSetAsync(input.UnitSet.Id);
                }

                if (input.StateSet.HasValue)
                {
                    input.StateSet.Value = await LoadStateSetAsync(input.StateSet.Id);
                }
            }

            return deviceWorkflow;
        }

        public async Task<StateSet> GetStateSetAsync(String id, EntityHeader org)
        {
            var stateSet = await _stateSetRepo.GetStateSetAsync(id);
            if (!stateSet.IsPublic && (stateSet.OwnerOrganization.Id != org.Id))
            {
                throw new Exception();
            }

            return stateSet;
        }

        public Task<StateSet> LoadStateSetAsync(String id)
        {
            return _stateSetRepo.GetStateSetAsync(id);
        }

        public async Task<EventSet> GetEventSetAsync(String id, EntityHeader org)
        {
            var eventSet = await _eventSetRepo.GetEventSetAsync(id);
            if (!eventSet.IsPublic && (eventSet.OwnerOrganization.Id != org.Id))
            {
                throw new Exception();
            }

            return eventSet;
        }

        public Task<EventSet> LoadEventSetAsync(String id)
        {
            return _eventSetRepo.GetEventSetAsync(id);
        }

        public Task<IEnumerable<StateMachineSummary>> GetStateMachinesForOrgAsync(String orgId)
        {
            return _stateMachineRepo.GetStateMachinesForOrgAsync(orgId);
        }

        public Task<IEnumerable<UnitSetSummary>> GetUnitSetsForOrgAsync(String orgId)
        {
            return _unitSetRepo.GetUnitSetsForOrgAsync(orgId);
        }

        public Task<IEnumerable<SharedAttributeSummary>> GetSharedAttributesForOrgAsync(String orgId)
        {
            return _sharedAttributeRepo.GetSharedAttributesForOrgAsync(orgId);
        }

        public Task<IEnumerable<SharedActionSummary>> GetSharedActionsForOrgAsync(String orgId)
        {
            return _sharedActionRepo.GetSharedActionsForOrgAsync(orgId);
        }

        public Task<IEnumerable<DeviceWorkflowSummary>> GetDeviceWorkflowsForOrgsAsync(String orgId)
        {
            return _deviceWorkflowRepo.GetDeviceWorkflowsForOrgAsync(orgId);
        }

        public Task<IEnumerable<StateSetSummary>> GetStateSetsForOrgAsync(String orgId)
        {
            return _stateSetRepo.GetStateSetsForOrgAsync(orgId);
        }

        public Task<IEnumerable<EventSetSummary>> GetEventSetsForOrgAsync(String orgId)
        {
            return _eventSetRepo.GetEventSetsForOrgAsync(orgId);
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

        public Task<bool> QuerySharedActionKeyInUseAsync(String key, String orgId)
        {
            return _sharedActionRepo.QueryKeyInUseAsync(key, orgId);
        }

        public Task<bool> QuerySharedAttributeKeyInUseAsync(String key, String orgId)
        {
            return _sharedAttributeRepo.QueryKeyInUseAsync(key, orgId);
        }

        public Task<bool> QueryStateSetKeyInUseAsync(String key, String orgId)
        {
            return _stateSetRepo.QueryKeyInUseAsync(key, orgId);
        }

        public Task<bool> QueryEventSetKeyInUseAsync(String key, String orgId)
        {
            return _eventSetRepo.QueryKeyInUseAsync(key, orgId);
        }

    }
}
