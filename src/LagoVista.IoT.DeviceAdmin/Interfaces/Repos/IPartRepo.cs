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
