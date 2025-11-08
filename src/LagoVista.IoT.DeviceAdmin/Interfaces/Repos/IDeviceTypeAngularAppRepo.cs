// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: c318ab75431b52d0283190a03150eb9fdaaadd41d8bfc9cba5d67202461e6169
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IDeviceTypeAngularAppRepo
    {
        Task<InvokeResult<EntityHeader<string>>> AddAppFileAsync(string deviceTypeId, AngularTypeType fileType, byte[] appFile);
    }
}
