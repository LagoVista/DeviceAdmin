// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 8fdc4df090fc8145a7af3ad26d379e884497efb3c1b2e1ac38f450a3b4c7876f
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using System;
using System.Collections.Generic;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core;

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

    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Parameter_Title, DeviceLibraryResources.Names.Parameter_Help, 
        DeviceLibraryResources.Names.InputCommandParamter_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, 
        typeof(DeviceLibraryResources), FactoryUrl: "/api/deviceadmin/factory/parameter")]
    public class Parameter : IFormDescriptor, IFormConditionalFields
    {
        public const string ParameterLocation_QueryString = "querystring";
        public const string ParameterLocation_JSON = "json";

        public Parameter()
        {
            Id = Guid.NewGuid().ToId();
        }

        public string Id { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsRequired, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsRequired { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Parameter_MaximumValue, ResourceType: typeof(DeviceLibraryResources))]
        public double? MaxValue { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Parameter_MinimumValue, ResourceType: typeof(DeviceLibraryResources))]
        public double? MinValue { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Parameter_DefaultValue, ResourceType: typeof(DeviceLibraryResources))]
        public object DefaultValue { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.ParameterLocation, HelpResource: Resources.DeviceLibraryResources.Names.ParameterLocation_Help, 
            WaterMark: Resources.DeviceLibraryResources.Names.ParameterLocation_Watermark, FieldType: FieldTypes.Picker, EnumType: typeof(PayloadTypes), ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<PayloadTypes> ParameterLocation { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Parameter_Type, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, EnumType: typeof(ParameterTypes), WaterMark: DeviceLibraryResources.Names.Parameter_Type_Watermark)]
        public EntityHeader<ParameterTypes> ParameterType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public String Description { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_UnitSet, FieldType: FieldTypes.EntityHeaderPicker, EntityHeaderPickerUrl: "/api/deviceadmin/unitsets",
            WaterMark: Resources.DeviceLibraryResources.Names.Attribute_UnitSet_Watermark, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_UnitSet_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<UnitSet> UnitSet { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_States, FieldType: FieldTypes.EntityHeaderPicker, EntityHeaderPickerUrl: "/api/statemachine/statesets",
            WaterMark: Resources.DeviceLibraryResources.Names.Atttribute_StateSet_Watermark, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_States_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<StateSet> StateSet { get; set; }

        public FormConditionals GetConditionalFields()
        {
            return new FormConditionals()
            {
                ConditionalFields = { nameof(MinValue), nameof(MaxValue), nameof(UnitSet), nameof(StateSet) },
                Conditionals =
                {
                    new FormConditional()
                    {
                         Field = nameof(ParameterType),
                         Value = TypeSystem.Decimal,
                         VisibleFields = { nameof(MinValue), nameof(MaxValue) },
                    },
                    new FormConditional()
                    {
                         Field = nameof(ParameterType),
                         Value = TypeSystem.Integer,
                         VisibleFields = { nameof(MinValue), nameof(MaxValue) },
                    },
                    new FormConditional()
                    {
                         Field = nameof(ParameterType),
                         Value = TypeSystem.State,
                         VisibleFields = { nameof(StateSet)},
                         RequiredFields = {nameof(StateSet)}
                    },
                    new FormConditional()
                    {
                         Field = nameof(ParameterType),
                         Value = TypeSystem.ValueWithUnit,
                         VisibleFields = { nameof(UnitSet)},
                         RequiredFields = {nameof(UnitSet)}
                    }
                }

            };
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(ParameterType),
                nameof(Key),
                nameof(IsRequired),
                nameof(MinValue),
                nameof(MaxValue),
                nameof(DefaultValue),
                nameof(ParameterLocation),
                nameof(UnitSet),
                nameof(StateSet),
                nameof(Description),
            };
        }

        public void Validate(ValidationResult result)
        {
            if (EntityHeader.IsNullOrEmpty(ParameterType))
            {
                result.AddUserError($"Parameter Type on Parameter {Name} is a required field.");
            }
            else if (ParameterType.Value == ParameterTypes.State && EntityHeader.IsNullOrEmpty(StateSet))
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
