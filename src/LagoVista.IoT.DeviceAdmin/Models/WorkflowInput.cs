using LagoVista.Core.Attributes;
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
            States = new ObservableCollection<State>();
            Units = new ObservableCollection<UnitSet>();
        }

        public enum InputTypes
        {
            [EnumLabel("state", DeviceLibraryResources.Names.WorkflowInput_Type_State, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.WorkflowInput_Type_State_Help)]
            States,
            [EnumLabel("text", DeviceLibraryResources.Names.WorkflowInput_Type_Text, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.WorkflowInput_Type_Text_Help)]
            Text,
            [EnumLabel("discrete", DeviceLibraryResources.Names.WorkflowInput_Type_Discrete, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.WorkflowInput_Type_Discrete_Help)]
            Discrete,
            [EnumLabel("discrete-units", DeviceLibraryResources.Names.WorkflowInput_Type_Discrete_Units, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.WorkflowInput_Type_Discrete_Units_Help)]
            DiscreteUnits,
            [EnumLabel("geolocation", DeviceLibraryResources.Names.WorkflowInput_Type_GeoLocation, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.WorkflowInput_Type_GeoLocation_Help)]
            GeoLocation,
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.WorkflowInput_Type, EnumType:typeof(InputTypes), HelpResource: Resources.DeviceLibraryResources.Names.WorkflowInput_Type_Help, FieldType:FieldTypes.Picker, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public InputTypes InputType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.WorkflowInput_SetScript, HelpResource: Resources.DeviceLibraryResources.Names.WorkflowInput_SetScript_Help, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: true)]
        public String Script { get; set; }
        
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.WorkflowInput_Units, HelpResource: Resources.DeviceLibraryResources.Names.WorkflowInput_Units_Help, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<UnitSet> Units { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.WorkflowInput_States, HelpResource: Resources.DeviceLibraryResources.Names.WorkflowInput_States_Help, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<State> States { get; set; }
    }
}
