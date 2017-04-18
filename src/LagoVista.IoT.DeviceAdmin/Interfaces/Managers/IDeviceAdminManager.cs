using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using models = LagoVista.IoT.DeviceAdmin.Models;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Managers
{
    public interface IDeviceAdminManager
    {
        Task<InvokeResult> AddDeviceWorkflowAsync(DeviceWorkflow deviceWorkflow, EntityHeader org, EntityHeader user);
        Task<InvokeResult> AddSharedActionAsync(SharedAction sharedAction, EntityHeader org, EntityHeader user);
        Task<InvokeResult> AddSharedAttributeAsync(SharedAttribute sharedAttribute, EntityHeader org, EntityHeader user);
        Task<InvokeResult> AddStateMachineAsync(StateMachine attribute, EntityHeader org, EntityHeader user);
        Task<InvokeResult> AddUnitSetAsync(UnitSet unitSet, EntityHeader org, EntityHeader user);
        Task<InvokeResult> AddStateSetAsync(StateSet stateSet, EntityHeader org, EntityHeader user);
        Task<InvokeResult> AddEventSetAsync(EventSet eventSet, EntityHeader org, EntityHeader user);

        Task<IEnumerable<DeviceWorkflowSummary>> GetDeviceWorkflowsForOrgsAsync(string orgId);
        Task<IEnumerable<SharedActionSummary>> GetSharedActionsForOrgAsync(string orgId);
        Task<IEnumerable<SharedAttributeSummary>> GetSharedAttributesForOrgAsync(string orgId);
        Task<IEnumerable<StateMachineSummary>> GetStateMachinesForOrgAsync(string orgId);
        Task<IEnumerable<UnitSetSummary>> GetUnitSetsForOrgAsync(string orgId);
        Task<IEnumerable<StateSetSummary>> GetStateSetsForOrgAsync(string orgId);
        Task<IEnumerable<EventSetSummary>> GetEventSetsForOrgAsync(string orgId);

        Task<bool> QuerySharedActionKeyInUseAsync(string key, string orgId);
        Task<bool> QueryAttributeUnitSetKeyInUseAsync(string key, string orgId);
        Task<bool> QuerySharedAttributeKeyInUseAsync(string key, string orgId);
        Task<bool> QueryStateMachineKeyInUseAsync(string key, string orgId);
        Task<bool> QueryDeviceWorkflowKeyInUseAsync(String key, String orgId);
        Task<bool> QueryStateSetKeyInUseAsync(String key, String orgId);
        Task<bool> QueryEventSetKeyInUseAsync(String key, String orgId);

        Task<StateMachine> GetStateMachineAsync(string id, EntityHeader org);
        Task<SharedAction> GetSharedActionAsync(string id, EntityHeader org);
        Task<SharedAttribute> GetSharedAttributeAsync(string id, EntityHeader org);
        Task<UnitSet> GetAttributeUnitSetAsync(string id, EntityHeader org);
        Task<UnitSet> LoadAttributeUnitSetAsync(string id);

        Task<DeviceWorkflow> GetDeviceWorkflowAsync(string id, EntityHeader org);
        Task<DeviceWorkflow> LoadFullDeviceWorkflowAsync(string id);

        Task<StateSet> GetStateSetAsync(string id, EntityHeader org);
        Task<StateSet> LoadStateSetAsync(String id);
        Task<EventSet> GetEventSetAsync(string id, EntityHeader org);
        Task<EventSet> LoadEventSetAsync(string id);

        Task<InvokeResult> UpdateDeviceWorkflowAsync(DeviceWorkflow deviceConfig, EntityHeader user);
        Task<InvokeResult> UpdateSharedActionAsync(SharedAction sharedAction, EntityHeader user);
        Task<InvokeResult> UpdateSharedAttributeAsync(SharedAttribute sharedAttribute, EntityHeader user);
        Task<InvokeResult> UpdateStateMachineAsync(StateMachine attribute, EntityHeader user);
        Task<InvokeResult> UpdateUnitSetAsync(UnitSet unitSet, EntityHeader user);
        Task<InvokeResult> UpdateStateSetAsync(StateSet stateSet, EntityHeader user);
        Task<InvokeResult> UpdateEventSetAsync(EventSet stateSet, EntityHeader user);
    }
}
