using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Managers
{
    public interface IPartManager
    {
        Task<InvokeResult> AddPartAsync(Part part, EntityHeader org, EntityHeader user);
        Task<InvokeResult> UpdatePartAsync(Part part, EntityHeader org, EntityHeader user);
        Task<ListResponse<PartSummary>> GetPartsSummaryAsync(ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<DependentObjectCheckResult> CheckInUseAsync(string id, EntityHeader org, EntityHeader user);
        Task<Part> GetPartAsync(string id, EntityHeader org, EntityHeader user);
        Task<Part> GetPartBySKUAsync(string sku, EntityHeader org, EntityHeader user);
        Task<Part> GetPartByPartNumberAsync(string partNumber, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeletePartAsync(string id, EntityHeader org, EntityHeader user);
    }
}
