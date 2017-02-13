using LagoVista.Core.Attributes;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.InputCommand_Title, DeviceLibraryResources.Names.InputCommand_Parameters, DeviceLibraryResources.Names.InputCommand_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class InputCommand : NodeBase, IValidateable
    {

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.InputCommand_Parameters, HelpResource: Resources.DeviceLibraryResources.Names.InputCommandParameter_Help, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources), IsUserEditable: false)]
        public List<InputCommandParameter> Parameters { get; set; }

    }
}
