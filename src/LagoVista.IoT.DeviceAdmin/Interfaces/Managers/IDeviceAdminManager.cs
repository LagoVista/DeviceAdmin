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
        Task<InvokeResult> AddStateMachineAsync(StateMachine attribute, EntityHeader org, EntityHeader user);
        Task<InvokeResult> AddUnitSetAsync(UnitSet unitSet, EntityHeader org, EntityHeader user);
        Task<InvokeResult> AddStateSetAsync(StateSet stateSet, EntityHeader org, EntityHeader user);
        Task<InvokeResult> AddEventSetAsync(EventSet eventSet, EntityHeader org, EntityHeader user);

        Task<IEnumerable<DeviceWorkflowSummary>> GetDeviceWorkflowsForOrgsAsync(string orgId, EntityHeader user);
        Task<IEnumerable<StateMachineSummary>> GetStateMachinesForOrgAsync(string orgId, EntityHeader user);
        Task<IEnumerable<UnitSetSummary>> GetUnitSetsForOrgAsync(string orgId, EntityHeader user);
        Task<IEnumerable<StateSetSummary>> GetStateSetsForOrgAsync(string orgId, EntityHeader user);
        Task<IEnumerable<EventSetSummary>> GetEventSetsForOrgAsync(string orgId, EntityHeader user);

        Task<bool> QueryAttributeUnitSetKeyInUseAsync(string key, string orgId);
        Task<bool> QueryStateMachineKeyInUseAsync(string key, string orgId);
        Task<bool> QueryDeviceWorkflowKeyInUseAsync(String key, String orgId);
        Task<bool> QueryStateSetKeyInUseAsync(String key, String orgId);
        Task<bool> QueryEventSetKeyInUseAsync(String key, String orgId);

        Task<StateMachine> GetStateMachineAsync(string id, EntityHeader org, EntityHeader user);
        Task<UnitSet> GetUnitSetAsync(string id, EntityHeader org, EntityHeader user);
        Task<UnitSet> LoadAttributeUnitSetAsync(string id);

        Task<DeviceWorkflow> GetDeviceWorkflowAsync(string id, EntityHeader org, EntityHeader user);
        Task<DeviceWorkflow> LoadFullDeviceWorkflowAsync(string id);

        Task<StateSet> GetStateSetAsync(string id, EntityHeader org, EntityHeader user);
        Task<StateSet> LoadStateSetAsync(String id);
        Task<EventSet> GetEventSetAsync(string id, EntityHeader org, EntityHeader user);
        Task<EventSet> LoadEventSetAsync(string id);

        Task<InvokeResult> UpdateDeviceWorkflowAsync(DeviceWorkflow deviceConfig, EntityHeader org, EntityHeader user);
        Task<InvokeResult> UpdateStateMachineAsync(StateMachine attribute, EntityHeader org, EntityHeader user);
        Task<InvokeResult> UpdateUnitSetAsync(UnitSet unitSet, EntityHeader org, EntityHeader user);
        Task<InvokeResult> UpdateStateSetAsync(StateSet stateSet, EntityHeader org, EntityHeader user);
        Task<InvokeResult> UpdateEventSetAsync(EventSet stateSet, EntityHeader org, EntityHeader user);

        Task<InvokeResult> DeleteDeviceWorkflowAsync(String workflowId, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteStateMachineAsync(String stateMachineId, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteUnitSetAsync(String unitSetId, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteStateSetAsync(String stateSetId, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteEventSetAsync(String eventSetId, EntityHeader org, EntityHeader user);

        Task<DependentObjectCheckResult> CheckInUseDeviceWorkflowAsync(String workflowId, EntityHeader org, EntityHeader user);
        Task<DependentObjectCheckResult> CheckInUseStateMachineAsync(String stateMachineId, EntityHeader org, EntityHeader user);
        Task<DependentObjectCheckResult> CheckInUseUnitSetAsync(String unitSetId, EntityHeader org, EntityHeader user);
        Task<DependentObjectCheckResult> CheckInUseStateSetAsync(String stateSetId, EntityHeader org, EntityHeader user);
        Task<DependentObjectCheckResult> CheckInUseEventSetAsync(String eventSetId, EntityHeader org, EntityHeader user);

    }
}
