using LagoVista.Core.Attributes;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class SummaryData : ISummaryData
    {
        [ListColumn(Visible: false)]
        public String Id { get; set; }

        [ListColumn(HeaderResource: Resources.DeviceLibraryResources.Names.Common_IsPublic, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsPublic { get; set; }

        [ListColumn(HeaderResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources))]
        public String Name { get; set; }

        [ListColumn(HeaderResource: Resources.DeviceLibraryResources.Names.Common_Key, ResourceType: typeof(DeviceLibraryResources))]
        public String Key { get; set; }

        [ListColumn(HeaderResource: Resources.DeviceLibraryResources.Names.Common_Description, ResourceType: typeof(DeviceLibraryResources))]
        public string Description { get; set; }
    }
}
