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

        public enum AttributeTypes
        {
            [EnumLabel("state", DeviceLibraryResources.Names.Attribute_Type_States, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.Attribute_Type_State_Help)]
            States,
            [EnumLabel("text", DeviceLibraryResources.Names.Attribute_Type_Text, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.Attribute_Type_Text_Help)]
            Text,
            [EnumLabel("discrete", DeviceLibraryResources.Names.Attribute_Type_Discrete, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.Attribute_Type_Discrete_Help)]
            Discrete,
            [EnumLabel("discrete-units", DeviceLibraryResources.Names.Attribute_Type_Discrete_Units, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.Attribute_Type_Discrete_Units_Help)]
            DiscreteUnits,
            [EnumLabel("geolocation", DeviceLibraryResources.Names.Attribute_Type_GeoLocation, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.Attribute_Type_GeoLocation_Help)]
            GeoLocation,
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_AttributeType, EnumType:(typeof(AttributeTypes)), HelpResource: Resources.DeviceLibraryResources.Names.Attribute_AttributeType_Help, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceLibraryResources), WaterMark:Resources.DeviceLibraryResources.Names.Attribute_AttributeType_Select, IsRequired: true, IsUserEditable: true)]
        public EntityHeader AttributeType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_SetScript, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_SetScript_Help, FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Script { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_UnitSet, FieldType:FieldTypes.EntityHeaderPicker, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_UnitSet_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<UnitSet> UnitSet { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_States, FieldType: FieldTypes.EntityHeaderPicker, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_States_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<StateSet> StateSet { get; set; }
    }
}
