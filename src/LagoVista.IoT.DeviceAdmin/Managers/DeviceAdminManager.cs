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
        IDeviceConfigurationRepo _deviceConfigRepo;
        ISharedActionRepo _sharedActionRepo;
        ISharedAtributeRepo _sharedAttributeRepo;
        IUnitSetRepo _unitSetRepo;
        IStateMachineRepo _stateMachineRepo;
        IStateSetRepo _stateSetRepo;
        IEventSetRepo _eventSetRepo;

        public DeviceAdminManager(IDeviceConfigurationRepo deviceConfigRepo, ISharedActionRepo sharedActionRepo, ISharedAtributeRepo sharedAttributeRepo,
            IUnitSetRepo unitSetRepo, IStateMachineRepo stateMachineRepo, IStateSetRepo stateSetRepo, IEventSetRepo eventSetRepo)
        {
            _deviceConfigRepo = deviceConfigRepo;
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



        public async Task<InvokeResult> AddDeviceConfigurationAsync(DeviceConfiguration deviceConfiguration, EntityHeader org, EntityHeader user)
        {
            var result = Validator.Validate(deviceConfiguration, Actions.Create);

            if (result.IsValid)
            {
                await _deviceConfigRepo.AddDeviceConfigurationAsync(deviceConfiguration);
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

        public async Task<InvokeResult> UpdateDeviceConfigurationAsync(DeviceConfiguration deviceConfig, EntityHeader user)
        {
            var result = Validator.Validate(deviceConfig, Actions.Create);

            if (result.IsValid)
            {
                deviceConfig.LastUpdatedBy = user;
                deviceConfig.LastUpdatedDate = DateTime.Now.ToJSONString();
                await _deviceConfigRepo.UpdateDeviceConfigurationAsync(deviceConfig);
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

        public async Task<DeviceConfiguration> GetDeviceConfigurationAsync(String id, EntityHeader org)
        {
            var deviceConfig = await _deviceConfigRepo.GetDeviceConfigurationAsync(id);
            if (!deviceConfig.IsPublic && deviceConfig.OwnerOrganization.Id != org.Id)
            {
                throw new Exception();
            }

            return deviceConfig;
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

        public async Task<EventSet> GetEventSetAsync(String id, EntityHeader org)
        {
            var eventSet = await _eventSetRepo.GetEventSetAsync(id);
            if (!eventSet.IsPublic && (eventSet.OwnerOrganization.Id != org.Id))
            {
                throw new Exception();
            }

            return eventSet;
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

        public Task<IEnumerable<DeviceConfigurationSummary>> GetDeviceConfigurationsForOrgsAsync(String orgId)
        {
            return _deviceConfigRepo.GetDeviceConfigurationsForOrgAsync(orgId);
        }

        public Task<IEnumerable<StateSetSummary>> GetStateSetsForOrgAsync(String orgId)
        {
            return _stateSetRepo.GetStateSetsForOrgAsync(orgId);
        }

        public Task<IEnumerable<EventSetSummary>> GetEventSetsForOrgAsync(String orgId)
        {
            return _eventSetRepo.GetEventSetsForOrgAsync(orgId);
        }


        public Task<bool> QueryDeviceConfigurationKeyInUseAsync(String key, String orgId)
        {
            return _deviceConfigRepo.QueryKeyInUseAsync(key, orgId);
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
