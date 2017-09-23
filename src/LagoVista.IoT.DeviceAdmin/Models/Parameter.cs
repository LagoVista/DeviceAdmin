using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using static LagoVista.IoT.DeviceAdmin.Models.InputCommand;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public enum PayloadTypes
    {
        [EnumLabel(Parameter.ParameterLocation_QueryString, Resources.DeviceLibraryResources.Names.ParameterLocation_QueryString, typeof(Resources.DeviceLibraryResources))]
        QueryString,

        [EnumLabel(Parameter.ParameterLocation_JSON, Resources.DeviceLibraryResources.Names.ParameterLocation_JSON, typeof(Resources.DeviceLibraryResources))]
        Json,
        /*   [EnumLabel("xml", Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload_XML, typeof(Resources.DeviceLibraryResources))]
           Xml,
           [EnumLabel("form", Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload_Form, typeof(Resources.DeviceLibraryResources))]
           Form,*/
        /*[EnumLabel("none", Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload_None, typeof(Resources.DeviceLibraryResources))]
        None*/
    }

    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Parameter_Title, DeviceLibraryResources.Names.Parameter_Help, DeviceLibraryResources.Names.InputCommandParamter_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class Parameter : IFormDescriptor
    {
        public const string ParameterLocation_QueryString = "querystring";
        public const string ParameterLocation_JSON = "json";

        public string Id { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsRequired, FieldType:FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsRequired { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.ParameterLocation, HelpResource: Resources.DeviceLibraryResources.Names.ParameterLocation_Help, WaterMark: Resources.DeviceLibraryResources.Names.ParameterLocation_Watermark, FieldType: FieldTypes.Picker, EnumType: typeof(PayloadTypes), ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<PayloadTypes> ParameterLocation { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Parameter_Type, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, EnumType: typeof(ParameterTypes), WaterMark: DeviceLibraryResources.Names.Parameter_Type_Watermark)]
        public EntityHeader<ParameterTypes> ParameterType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public String Description { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_UnitSet, FieldType: FieldTypes.EntityHeaderPicker, WaterMark: Resources.DeviceLibraryResources.Names.Attribute_UnitSet_Watermark, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_UnitSet_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<UnitSet> UnitSet { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_States, FieldType: FieldTypes.EntityHeaderPicker, WaterMark: Resources.DeviceLibraryResources.Names.Atttribute_StateSet_Watermark, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_States_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<StateSet> StateSet { get; set; }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Parameter.Name),
                nameof(Parameter.Key),
                nameof(Parameter.IsRequired),
                nameof(Parameter.ParameterLocation),
                nameof(Parameter.ParameterType),
                nameof(Parameter.Description),
            };
        }

        public void Validate(ValidationResult result)
        {
            if(EntityHeader.IsNullOrEmpty(ParameterType))
            {
                result.AddUserError($"Parameter Type on Parameter {Name} is a required field.");
            }
            else if(ParameterType.Value == ParameterTypes.State && EntityHeader.IsNullOrEmpty(StateSet))
            {
                result.AddUserError($"Parameter Type on Parameter {Name} is a Value with Unit but no State Set has been provided.");

            }
            else if (ParameterType.Value == ParameterTypes.ValueWithUnit && EntityHeader.IsNullOrEmpty(UnitSet))
            {
                result.AddUserError($"Parameter Type on Parameter {Name} is a Value with Unit but no Unit Set has been provided.");
            }
        }
    }
}
