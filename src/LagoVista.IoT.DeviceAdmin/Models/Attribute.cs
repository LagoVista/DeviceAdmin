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
            States = new ObservableCollection<State>();
            Units = new ObservableCollection<UnitSet>();
            Connections = new List<Connection>();
        }

        public enum AttributeTypes
        {
            [EnumLabel("state", DeviceLibraryResources.Names.Attribute_Type_States, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.Attribute_Type_State_Help)]
            States,
            [EnumLabel("discrete", DeviceLibraryResources.Names.Attribute_Type_Discrete, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.Attribute_Type_Discrete_Help)]
            Discrete,
            [EnumLabel("discrete-units", DeviceLibraryResources.Names.Attribute_Type_Discrete_Units, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.Attribute_Type_Discrete_Units_Help)]
            DiscreteUnits
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_AttributeType, EnumType:(typeof(AttributeTypes)), HelpResource: Resources.DeviceLibraryResources.Names.Attribute_AttributeType_Help, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceLibraryResources), WaterMark:Resources.DeviceLibraryResources.Names.Attribute_AttributeType_Select, IsRequired: true, IsUserEditable: true)]
        public EntityHeader AttributeType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_SetScript, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_SetScript_Help, FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Script { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_UnitSet, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_UnitSet_Help, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<UnitSet> Units { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_States, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_States_Help, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<State> States { get; set; }

        public Point DiagramLocation { get; set; }       
    }
}
