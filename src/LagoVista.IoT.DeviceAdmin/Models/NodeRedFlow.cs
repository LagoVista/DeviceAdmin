using LagoVista.Core.Attributes;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(Title: Resources.DeviceLibraryResources.Names.NodeRedFlow_Title, Domain: DeviceAdminDomain.DeviceAdmin, UserHelp: Resources.DeviceLibraryResources.Names.NodeRedFlow_Help, Description: Resources.DeviceLibraryResources.Names.NodeRedFlow_Description, ResourceType: typeof(DeviceLibraryResources))]
    public class NodeRedFlow
    {
        public String NodeRedFlowId { get; set; }
        public String Uri { get; set; }
    }
}
