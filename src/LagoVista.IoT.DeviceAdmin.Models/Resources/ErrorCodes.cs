// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 831a768c37dc8fd3a414a3ec0574ef69c2ea7de124f76e921baa83ec716ef80d
// IndexVersion: 2
// --- END CODE INDEX META ---
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
