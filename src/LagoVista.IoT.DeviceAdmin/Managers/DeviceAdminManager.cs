using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LagoVista.Core.Models;
using LagoVista.Core;

namespace LagoVista.IoT.DeviceAdmin.Managers
{
    public class DeviceAdminManager : IDeviceAdminManager
    {
        IDeviceConfigurationRepo _deviceConfigRepo;
        ISharedActionRepo _sharedActionRepo;
        ISharedAtributeRepo _sharedAttributeRepo;
        IAttributeUnitSetRepo _unitSetRepo;
        IStateMachineRepo _stateMachineRepo;

        public DeviceAdminManager(IDeviceConfigurationRepo deviceConfigRepo, ISharedActionRepo sharedActionRepo, ISharedAtributeRepo sharedAttributeRepo,
            IAttributeUnitSetRepo unitSetRepo, IStateMachineRepo stateMachineRepo)
        {
            _deviceConfigRepo = deviceConfigRepo;
            _sharedActionRepo = sharedActionRepo;
            _sharedAttributeRepo = sharedAttributeRepo;
            _unitSetRepo = unitSetRepo;
            _stateMachineRepo = stateMachineRepo;
        }

        public Task AddStateMachineAsync(StateMachine attribute, EntityHeader org, EntityHeader user)
        {
            attribute.Id = Guid.NewGuid().ToId();
            attribute.OwnerOrganization = org;
            attribute.LastUpdatedBy = user;
            attribute.CreatedBy = user;
            attribute.CreationDate = DateTime.Now.ToJSONString();
            attribute.LastUpdatedDate = attribute.CreationDate;

            return _stateMachineRepo.AddStateMachineAsync(attribute);
        }

        public Task AddSharedActionAsync(SharedAction sharedAction, EntityHeader org, EntityHeader user)
        {
            sharedAction.Id = Guid.NewGuid().ToId();
            sharedAction.OwnerOrganization = org;
            sharedAction.LastUpdatedBy = user;
            sharedAction.CreatedBy = user;
            sharedAction.CreationDate = DateTime.Now.ToJSONString();
            sharedAction.LastUpdatedDate = sharedAction.CreationDate;

            return _sharedActionRepo.AddSharedActionAsync(sharedAction);
        }

        public Task AddSharedAttributeAsync(SharedAttribute sharedAttribute, EntityHeader org, EntityHeader user)
        {
            sharedAttribute.Id = Guid.NewGuid().ToId();
            sharedAttribute.OwnerOrganization = org;
            sharedAttribute.LastUpdatedBy = user;
            sharedAttribute.CreatedBy = user;
            sharedAttribute.CreationDate = DateTime.Now.ToJSONString();
            sharedAttribute.LastUpdatedDate = sharedAttribute.CreationDate;

            return _sharedAttributeRepo.AddSharedAttributeAsync(sharedAttribute);
        }

        public Task AddUnitSetAsync(AttributeUnitSet unitSet, EntityHeader org, EntityHeader user)
        {
            unitSet.Id = Guid.NewGuid().ToId();
            unitSet.OwnerOrganization = org;
            unitSet.LastUpdatedBy = user;
            unitSet.CreatedBy = user;
            unitSet.CreationDate = DateTime.Now.ToJSONString();
            unitSet.LastUpdatedDate = unitSet.CreationDate;

            return _unitSetRepo.AddUnitSetAsync(unitSet);
        }
        public Task AddDeviceConfigurationAsync(DeviceConfiguration deviceConfiguration, EntityHeader org, EntityHeader user)
        {
            deviceConfiguration.Id = Guid.NewGuid().ToId();
            deviceConfiguration.OwnerOrganization = org;
            deviceConfiguration.LastUpdatedBy = user;
            deviceConfiguration.CreatedBy = user;
            deviceConfiguration.CreationDate = DateTime.Now.ToJSONString();
            deviceConfiguration.LastUpdatedDate = deviceConfiguration.CreationDate;

            return _deviceConfigRepo.AddDeviceConfigurationAsync(deviceConfiguration);
        }

        public Task UpdateStateMachineAsync(StateMachine attribute,  EntityHeader user)
        {
            attribute.LastUpdatedBy = user;
            attribute.LastUpdatedDate = DateTime.Now.ToJSONString();

            return _stateMachineRepo.UpdateStateMachineAsync(attribute);
        }

        public Task UpdateSharedActionAsync(SharedAction sharedAction,  EntityHeader user)
        {
            sharedAction.LastUpdatedBy = user;
            sharedAction.LastUpdatedDate = DateTime.Now.ToJSONString(); 

            return _sharedActionRepo.UpdateSharedActionAsync(sharedAction);
        }

        public Task UpdateSharedAttributeAsync(SharedAttribute sharedAttribute,  EntityHeader user)
        {
            sharedAttribute.LastUpdatedBy = user;
            sharedAttribute.LastUpdatedDate = DateTime.Now.ToJSONString();

            return _sharedAttributeRepo.UpdateSharedAttributeAsync(sharedAttribute);
        }

        public Task UpdateUnitSetAsync(AttributeUnitSet unitSet,  EntityHeader user)
        {
            unitSet.LastUpdatedBy = user;
            unitSet.LastUpdatedDate = DateTime.Now.ToJSONString();
            return _unitSetRepo.UpdateUnitSetAsync(unitSet);
        }

        public Task UpdateDeviceConfigurationAsync(DeviceConfiguration deviceConfig, EntityHeader user)
        {
            deviceConfig.LastUpdatedBy = user;
            deviceConfig.LastUpdatedDate = DateTime.Now.ToJSONString();
            return _deviceConfigRepo.UpdateDeviceConfigurationAsync(deviceConfig);
        }

        public async Task<StateMachine> GetStateMachineAsync(String id, EntityHeader org)
        {
            var stateMachine = await _stateMachineRepo.GetStateMachineAsync(id);
            if(!stateMachine.IsPublic && stateMachine.OwnerOrganization != org)
            {
                throw new Exception();
            }

            return stateMachine;
        }

        public async Task<SharedAction> SetSharedActionAsync(String id, EntityHeader org)
        {
            var sharedAction = await _sharedActionRepo.GetSharedActionAsync(id);
            if (!sharedAction.IsPublic && sharedAction.OwnerOrganization != org)
            {
                throw new Exception();
            }

            return sharedAction;
        }

        public async Task<SharedAttribute> GetSharedAttribute(String id, EntityHeader org)
        {
            var sharedAttribute = await _sharedAttributeRepo.GetSharedAttributeAsync(id);
            if (!sharedAttribute.IsPublic && sharedAttribute.OwnerOrganization != org)
            {
                throw new Exception();
            }

            return sharedAttribute;
        }

        public async Task<AttributeUnitSet> GetUnitSetAsync(String id, EntityHeader org)
        {
            var unitSet = await _unitSetRepo.GetUnitSetAsync(id);
            if (!unitSet.IsPublic && unitSet.OwnerOrganization != org)
            {
                throw new Exception();
            }

            return unitSet;
        }

        public async Task<DeviceConfiguration> GetDeviceConfigurationAsync(String id, EntityHeader org)
        {
            var deviceConfig = await _deviceConfigRepo.GetDeviceConfigurationAsync(id);
            if (!deviceConfig.IsPublic && deviceConfig.OwnerOrganization != org)
            {
                throw new Exception();
            }

            return deviceConfig;
        }

        public  Task<IEnumerable<StateMachineSummary>> GetStateMachinesForOrgAsync(String orgId)
        {
            return _stateMachineRepo.GetStateMachinesForOrgAsync(orgId);
        }

        public Task<IEnumerable<AttributeUnitSetSummary>> GetUnitSetsForOrgAsync(String orgId)
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
    }
}
