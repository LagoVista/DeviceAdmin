using LagoVista.IoT.DeviceAdmin.Models.Resources;
using LagoVista.IoT.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceAdmin.Resources
{
    public class ErrorCodes
    {        
        public static ErrorCode CouldNotLoadDeviceWorkflow => new ErrorCode() { Code = "SLN3001", Message = DeviceLibraryResources.Err_CouldNotLoadDeviceWorkflow };
        public static ErrorCode CouldNotLoadStateSet => new ErrorCode() { Code = "SLN3002", Message = DeviceLibraryResources.Err_CouldNotLoadStateSet };
        public static ErrorCode CouldNotLoadUnitSet => new ErrorCode() { Code = "SLN3003", Message = DeviceLibraryResources.Err_CouldNotLoadUnitSet };
    }
}
