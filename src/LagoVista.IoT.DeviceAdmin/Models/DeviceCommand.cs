using LagoVista.Core.Attributes;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System.Collections.ObjectModel;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.DeviceCommand_Title, DeviceLibraryResources.Names.DeviceCommand_Description, DeviceLibraryResources.Names.DeviceCommand_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class DeviceCommand : KeyOwnedDeviceAdminBase, IValidateable
    {


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceCommand_Script, HelpResource: Resources.DeviceLibraryResources.Names.DeviceCommand_Script_Help, IsRequired:true, FieldType:FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources))]
        public string Script { get; set; }

        public Point DiagramLocation { get; set; }

    }
}
