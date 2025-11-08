// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 0987548db9fd35397c4ef15234ec3f53e20b3d89c89ae4f82e4717035e9e3535
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Managers
{
    public interface IDeviceAdminManager
    {
        Task<InvokeResult> AddDeviceWorkflowAsync(DeviceWorkflow deviceWorkflow, EntityHeader org, EntityHeader user);
        Task<InvokeResult> AddStateMachineAsync(StateMachine attribute, EntityHeader org, EntityHeader user);
        Task<InvokeResult> AddUnitSetAsync(UnitSet unitSet, EntityHeader org, EntityHeader user);
        Task<InvokeResult> AddStateSetAsync(StateSet stateSet, EntityHeader org, EntityHeader user);
        Task<InvokeResult> AddEventSetAsync(EventSet eventSet, EntityHeader org, EntityHeader user);

        Task<ListResponse<DeviceWorkflowSummary>> GetDeviceWorkflowsForOrgsAsync(string orgId, EntityHeader user, ListRequest listRequest);
        Task<ListResponse<StateMachineSummary>> GetStateMachinesForOrgAsync(string orgId, EntityHeader user, ListRequest listRequest);
        Task<ListResponse<UnitSetSummary>> GetUnitSetsForOrgAsync(string orgId, EntityHeader user, ListRequest listRequest);
        Task<ListResponse<StateSetSummary>> GetStateSetsForOrgAsync(string orgId, EntityHeader user, ListRequest listRequest);
        Task<ListResponse<EventSetSummary>> GetEventSetsForOrgAsync(string orgId, EntityHeader user, ListRequest listRequest);

        Task<bool> QueryAttributeUnitSetKeyInUseAsync(string key, string orgId);
        Task<bool> QueryStateMachineKeyInUseAsync(string key, string orgId);
        Task<bool> QueryDeviceWorkflowKeyInUseAsync(String key, String orgId);
        Task<bool> QueryStateSetKeyInUseAsync(String key, String orgId);
        Task<bool> QueryEventSetKeyInUseAsync(String key, String orgId);

        Task<StateMachine> GetStateMachineAsync(string id, EntityHeader org, EntityHeader user);
        Task<UnitSet> GetAttributeUnitSetAsync(string id, EntityHeader org, EntityHeader user);
        
        Task<DeviceWorkflow> GetDeviceWorkflowAsync(string id, EntityHeader org, EntityHeader user);
        Task<InvokeResult<DeviceWorkflow>> LoadFullDeviceWorkflowAsync(string id, EntityHeader org, EntityHeader user);

        Task<StateSet> GetStateSetAsync(string id, EntityHeader org, EntityHeader user);
        Task<EventSet> GetEventSetAsync(string id, EntityHeader org, EntityHeader user);
        
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

        bool IsForInitialization { get; set; }
    }
}
