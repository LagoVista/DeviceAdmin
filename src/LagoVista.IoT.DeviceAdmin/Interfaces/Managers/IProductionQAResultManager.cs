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
