// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 3f60b56dd9925d9e47975619354784bac1708b92f2bfdf96d43760c7d3bbee58
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IPartRepo
    {
        Task AddPartAsync(Part part);
        Task<Part> GetPartAsync(String partId);
        Task<Part> GetPartBySKUAsync(string orgId, String sku);
        Task<Part> GetPartByPartNumberAsync(string orgId, String partNumber);
        Task UpdatePartAsync(Part part);
        Task<ListResponse<PartSummary>> GetPartsForOrgAsync(string orgId, ListRequest listRequest);
        Task DeletePartAsync(string partId);
    }
}
