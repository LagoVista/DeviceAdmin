using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.ObjectModel;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.WorkflowInput_Title, DeviceLibraryResources.Names.WorkflowInput_Description, DeviceLibraryResources.Names.WorkflowInput_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class WorkflowInput : NodeBase, IValidateable
    {
        public WorkflowInput()
        {
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.WorkflowInput_Type, WaterMark:DeviceLibraryResources.Names.WorkflowInput_Type_Watermark, EnumType:typeof(ParameterTypes), HelpResource: Resources.DeviceLibraryResources.Names.WorkflowInput_Type_Help, FieldType:FieldTypes.Picker, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public EntityHeader InputType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.WorkflowInput_SetScript, WaterMark: Resources.DeviceLibraryResources.Names.WorkflowInput_Script_Watermark, HelpResource: Resources.DeviceLibraryResources.Names.WorkflowInput_SetScript_Help, FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources))]
        public String OnSetScript { get; set; }
        
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.WorkflowInput_Units, WaterMark: Resources.DeviceLibraryResources.Names.WorkflowInput_UnitSet_Watermark, FieldType: FieldTypes.EntityHeaderPicker, HelpResource: Resources.DeviceLibraryResources.Names.WorkflowInput_Units_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<UnitSet> UnitSet { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.WorkflowInput_States, WaterMark:Resources.DeviceLibraryResources.Names.WorkflowInput_StateSet_Watermark, FieldType: FieldTypes.EntityHeaderPicker, HelpResource: Resources.DeviceLibraryResources.Names.WorkflowInput_States_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<StateSet> StateSet { get; set; }
    }
}
