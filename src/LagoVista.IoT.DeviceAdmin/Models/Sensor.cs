using LagoVista.Core.Attributes;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.ObjectModel;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Attribute_Title, DeviceLibraryResources.Names.Attribute_Description, DeviceLibraryResources.Names.Attribute_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class Sensor : KeyOwnedDeviceAdminBase, IValidateable
    {
        public Sensor()
        {
            States = new ObservableCollection<State>();
            Units = new ObservableCollection<UnitSet>();
        }

        public enum SensorTypes
        {
            [EnumLabel("state", DeviceLibraryResources.Names.Sensor_Type_State, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.Sensor_Type_State_Help)]
            States,
            [EnumLabel("discrete", DeviceLibraryResources.Names.Sensor_Type_Discrete, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.Sensor_Type_Discrete_Help)]
            Discrete,
            [EnumLabel("discrete-units", DeviceLibraryResources.Names.Sensor_Type_Discrete_Units, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.Sensor_Type_Discrete_Units_Help)]
            DiscreteUnits
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Sensor_Type, EnumType:typeof(SensorTypes), HelpResource: Resources.DeviceLibraryResources.Names.Sensor_Type_Help, FieldType:FieldTypes.Picker, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public SensorTypes SensorType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Sensor_SetScript, HelpResource: Resources.DeviceLibraryResources.Names.Sensor_SetScript_Help, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: true)]
        public String Script { get; set; }


        
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Sensor_Units, HelpResource: Resources.DeviceLibraryResources.Names.Sensor_Units_Help, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<UnitSet> Units { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Sensor_States, HelpResource: Resources.DeviceLibraryResources.Names.Sensor_States_Help, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<State> States { get; set; }
        
        public Point DiagramLocation { get; set; }
    }
}
