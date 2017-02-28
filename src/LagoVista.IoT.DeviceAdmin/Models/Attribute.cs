using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Attribute_Title, DeviceLibraryResources.Names.Attribute_Description, DeviceLibraryResources.Names.Attribute_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class Attribute : NodeBase, IValidateable
    {
        public Attribute()
        {

        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_AttributeType, EnumType:(typeof(ParameterTypes)), HelpResource: Resources.DeviceLibraryResources.Names.Attribute_AttributeType_Help, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceLibraryResources), WaterMark:Resources.DeviceLibraryResources.Names.Attribute_AttributeType_Select, IsRequired: true, IsUserEditable: true)]
        public EntityHeader AttributeType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_SetScript, WaterMark:Resources.DeviceLibraryResources.Names.Attribute_Script_Watermark, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_SetScript_Help, FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources))]
        public String OnSetScript { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_ReadOnly,  HelpResource: Resources.DeviceLibraryResources.Names.Attribute_ReadOnly_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool ReadOnly { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_UnitSet,  FieldType:FieldTypes.EntityHeaderPicker, WaterMark:Resources.DeviceLibraryResources.Names.Attribute_UnitSet_Watermark, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_UnitSet_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<UnitSet> UnitSet { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_States, FieldType: FieldTypes.EntityHeaderPicker, WaterMark: Resources.DeviceLibraryResources.Names.Atttribute_StateSet_Watermark, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_States_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<StateSet> StateSet { get; set; }
    }
}
