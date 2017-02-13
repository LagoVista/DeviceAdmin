using LagoVista.Core.Attributes;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System.Collections.ObjectModel;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.OutputCommand_Title, DeviceLibraryResources.Names.OutputCommand_Description, DeviceLibraryResources.Names.OutputCommand_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class OutputCommand : NodeBase, IValidateable
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.OutputCommand_Script, HelpResource: Resources.DeviceLibraryResources.Names.OutputCommand_Script_Help, IsRequired:true, FieldType:FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources))]
        public string Script { get; set; }
    }
}
