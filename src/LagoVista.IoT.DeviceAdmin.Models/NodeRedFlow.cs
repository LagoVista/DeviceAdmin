// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: d708da8ac388fc26abc7deb772a5402412c8c0dc584ba1692d9ff497093737e6
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Attributes;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.NodeRedFlow_Title, Resources.DeviceLibraryResources.Names.NodeRedFlow_Help, Resources.DeviceLibraryResources.Names.NodeRedFlow_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources))]
    public class NodeRedFlow
    {
        public String NodeRedFlowId { get; set; }
        public String Uri { get; set; }
    }
}
