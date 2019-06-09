using LagoVista.Core.Attributes;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceAdmin.Models
{

    public class TroubleshootingStep
    {
        public string Id { get; set; }
        public string Key { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: true)]
        public string Name { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.TroubleshootingStep_Instructions, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: true)]
        public string Instructions { get; set; }


        [FormField(LabelResource: DeviceLibraryResources.Names.Common_Resources, FieldType: FieldTypes.ChildItem, ResourceType: typeof(DeviceLibraryResources))]
        public List<MediaResource> Resources { get; set; }
    }
}
