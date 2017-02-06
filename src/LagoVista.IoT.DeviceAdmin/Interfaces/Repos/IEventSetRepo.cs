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
        Task<IEnumerable<EventSetSummary>> GetEventSetsForOrgAsync(string orgId);
        Task<bool> QueryKeyInUseAsync(String key, String orgId);
    }
}
