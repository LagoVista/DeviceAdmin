using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using LagoVista.IoT.DeviceAdmin.Resources;
using Newtonsoft.Json;
using System;
using System.Linq;
using LagoVista.Core;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.CustomField_Title, Resources.DeviceLibraryResources.Names.CustomFIeld_Help, Resources.DeviceLibraryResources.Names.CustomField_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources))]
    public class CustomField : IKeyedEntity, IFormDescriptor
    {
        [JsonProperty("id")]
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_UniqueId, IsUserEditable: false, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Id { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, IsRequired: true, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public String Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_Label, IsRequired: true, HelpResource: Resources.DeviceLibraryResources.Names.CustomField_Label_Help, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public String Label { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_IsRequired, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsRequired { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_IsReadOnly, HelpResource: Resources.DeviceLibraryResources.Names.CustomField_IsReadOnly_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsReadOnly { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_MinValue, FieldType: FieldTypes.Decimal, ResourceType: typeof(DeviceLibraryResources))]
        public double? MinValue { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_MaxValue, FieldType: FieldTypes.Decimal, ResourceType: typeof(DeviceLibraryResources))]
        public double? MaxValue { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_FieldType, EnumType: (typeof(ParameterTypes)), FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceLibraryResources), WaterMark: Resources.DeviceLibraryResources.Names.CustomField_FieldType_Watermark, IsRequired: true, IsUserEditable: true)]

        public EntityHeader<ParameterTypes> FieldType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_UnitSet, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources), WaterMark: Resources.DeviceLibraryResources.Names.CustomField_UnitSet_Select)]
        public EntityHeader<UnitSet> UnitSet { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_StateSet, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources), WaterMark: Resources.DeviceLibraryResources.Names.CustomField_StateSet_Select)]
        public EntityHeader<StateSet> StateSet { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, ValidationRegEx: Constants.KeyRegEx, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomFields_DefaultValue, FieldType: FieldTypes.Text, HelpResource: DeviceLibraryResources.Names.CustomFields_DefaultValue_Help, ResourceType: typeof(DeviceLibraryResources))]
        public String DefaultValue { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_RegEx, HelpResource: Resources.DeviceLibraryResources.Names.CustomField_RegEx_Help, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public String RegEx { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_HelpText, HelpResource: Resources.DeviceLibraryResources.Names.CusotmField_HelpText_Help, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public string HelpText { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Custom_PropertyId, HelpResource: Resources.DeviceLibraryResources.Names.Custom_PropertyId_Help, FieldType: FieldTypes.Integer, IsRequired:false, ResourceType: typeof(DeviceLibraryResources))]
        public int RemotePropertyId { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Custom_RemoteProperty, HelpResource: Resources.DeviceLibraryResources.Names.Custom_RemoteProperty_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsRemoteProperty { get; set; }

        /// <summary>
        /// This will likely be a good candiate to reorder the list
        /// </summary>
        public int Order { get; set; }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(CustomField.Name),
                nameof(CustomField.Label),
                nameof(CustomField.IsRequired),
                nameof(CustomField.IsReadOnly),
                nameof(CustomField.FieldType),
                nameof(CustomField.Key),
                nameof(CustomField.DefaultValue),
                nameof(CustomField.RegEx),
                nameof(CustomField.HelpText),
            };
        }

        public void Validate(string value, ValidationResult result, Actions action)
        {
            if (EntityHeader.IsNullOrEmpty(FieldType)) result.AddSystemError($"Custom field {Label} missing field type, invalid configuration, contact administorator");
             
            if (IsRequired && String.IsNullOrEmpty(value))
            {
                result.AddUserError($"{Label} is a required field.");
                return;
            }

            if (String.IsNullOrEmpty(value))
            {
                return;
            }


            switch (FieldType.Value)
            {
                case ParameterTypes.DateTime:
                    if (!value.SuccessfulJSONDate()) result.AddUserError($"Date must be in ISO 8601 format YYYY-MM-DDTHH:MM:SS.SSSZ for {Label}");
                    break;
                case ParameterTypes.Decimal:
                    if (!double.TryParse(value, out double dbl)) result.AddUserError($"Invalid Double Value for {Label}");
                    break;
                case ParameterTypes.GeoLocation:
                    var geo = value.ToGeoLocation();
                    if (geo == null) result.AddUserError($"Invalid geo location on {Label}, found [value], expected [-DD.MMMMMM,-DDD.MMMMMM].");
                    break;
                case ParameterTypes.Integer:
                    if (!int.TryParse(value, out int intValue)) result.AddUserError($"Invalid Integer Value for {Label}");
                    break;
                case ParameterTypes.State:
                    if (StateSet == null)
                    {
                        result.AddSystemError($"Data type was State, but no state set provided, invalid configuration on {Label}");
                    }
                    else if (StateSet.Value == null)
                    {
                        result.AddSystemError($"StateSet was present but value was not, invalid configuration on {Label}");
                    }
                    else
                    {
                        if (!StateSet.Value.States.Where(stat => stat.Key == value).Any()) result.AddUserError($"Attempt to set property to invalid date {value}, possible values are [{StateSet.Value.States.Select(st => st.Key).Aggregate((cur, nxt) => cur + "," + nxt)}] for {Label}");
                    }
                    break;
                case ParameterTypes.TrueFalse:
                    if (value != "true" && value != "false") result.AddUserError($"Value must be [true] or [false] for {Label}");
                    break;
                case ParameterTypes.ValueWithUnit:
                    if (!double.TryParse(value, out double dblVal)) result.AddUserError($"Invalid Number Value for {Label}");
                    break;
            }


            if (FieldType.Value == ParameterTypes.Decimal ||
                FieldType.Value == ParameterTypes.Integer ||
                FieldType.Value == ParameterTypes.ValueWithUnit)
            {
                if(Double.TryParse(value, out double outValue))
                {
                    if (MinValue.HasValue && outValue < MinValue.Value) result.AddUserError($"Supplied Value {outValue} on {Label} is less then minimum allowable value {MinValue.Value}");
                    if (MaxValue.HasValue && outValue > MaxValue.Value) result.AddUserError($"Supplied Value {outValue} on {Label} is greather then maximum allowable value {MaxValue.Value}");
                }
            }
        }

        [CustomValidator]
        public void Validate(ValidationResult result, Actions action)
        {
            if (EntityHeader.IsNullOrEmpty(FieldType)) result.AddUserError("Field Type is Required.");

            if (FieldType.Value == ParameterTypes.ValueWithUnit)
            {
                if (EntityHeader.IsNullOrEmpty(UnitSet)) result.AddUserError("If Value with Unit is selected for the Field Type, you must specify a Unit Set.");
            }
            else if (FieldType.Value == ParameterTypes.State)
            {
                if (EntityHeader.IsNullOrEmpty(StateSet)) result.AddUserError("If State Set is selected for the Field Type, you must specify a State Set.");
            }
        }
    }
}
