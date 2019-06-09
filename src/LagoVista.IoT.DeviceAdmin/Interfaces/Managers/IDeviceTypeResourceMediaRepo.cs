using LagoVista.Core.Interfaces;
using LagoVista.Core.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Managers
{
    public interface IMediaResourceRepo
    {
        Task<InvokeResult> AddMediaAsync(byte[] data, string org, string fileName, string contentType);
        Task<InvokeResult<byte[]>> GetMediaAsync(string fileName, string org);
    }

    public interface IDeviceTypeResourceMediaConnectionSettings
    {
        IConnectionSettings DeviceTypeResourceMediaConnection { get; }
    }
}
