using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IEventSetRepo
    {
        Task AddEventSetAsync(EventSet eventSet);
        Task<EventSet> GetEventSetAsync(String eventSetId);
        Task UpdateEventSetAsync(EventSet eventSet);
        Task<ListResponse<EventSetSummary>> GetEventSetsForOrgAsync(string orgId, ListRequest listRequest);
        Task<bool> QueryKeyInUseAsync(String key, String orgId);
        Task DeleteEventSetAsync(string eventSetId);
    }
}
