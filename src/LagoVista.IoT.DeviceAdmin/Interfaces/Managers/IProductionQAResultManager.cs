// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: c7c664d263c56405fb1685b5434605a45fa8177f10c063f7454725d10cf678cd
// IndexVersion: 2
// --- END CODE INDEX META ---
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
    public interface IProductionQAResultManager
    {
        Task<InvokeResult<ProductionQAResult>> CompleteQAAsync(string deviceTypeId, EntityHeader org, EntityHeader user);
        Task<InvokeResult<ProductionQAResult>> GetForSerialNumberAsync(int serialNumber);
        Task<InvokeResult<ProductionQAResult>> GetForSerialNumberAndDeviceTypeAsync(int serialNumber, string deviceTypeId);
        Task<ListResponse<ProductionQAResult>> GetForDeviceTypeAsync(string deviceTypeId,  ListRequest request, EntityHeader org, EntityHeader user);
        Task<InvokeResult<ProductionQAResult>> SetForDeviceAsync(int serialNumber, string deviceTypeId, string deviceUniqueId, EntityHeader org, EntityHeader user);
    }
}
