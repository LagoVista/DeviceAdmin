// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 87a7a039f02bf4829571367452bc3331e65cb51637d45a3342798bd85899bd91
// IndexVersion: 2
// --- END CODE INDEX META ---
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
