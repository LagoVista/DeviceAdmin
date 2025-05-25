using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static LagoVista.IoT.DeviceAdmin.Managers.DeviceTypeManager;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IDeviceTypeAngularAppRepo
    {
        Task<InvokeResult<EntityHeader<string>>> AddAppFileAsync(string deviceTypeId, AngularTypeType fileType, byte[] appFile);
    }
}
