using LagoVista.Core.Attributes;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System.Collections.ObjectModel;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.OutputCommand_Title, DeviceLibraryResources.Names.OutputCommand_Description, DeviceLibraryResources.Names.OutputCommand_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class OutputCommand : NodeBase, IValidateable
    {
        public OutputCommand()
        {
            Parameters = new ObservableCollection<Parameter>();
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.OutputCommand_Script, HelpResource: Resources.DeviceLibraryResources.Names.OutputCommand_Script_Help, IsRequired:true, FieldType:FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources))]
        public string OnExecuteScript { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.InputCommand_Parameters, HelpResource: Resources.DeviceLibraryResources.Names.Parameter_Help, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<Parameter> Parameters { get; set; }

        public override string NodeType => NodeType_OutputCommand;
    }
}
