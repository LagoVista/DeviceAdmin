using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using LagoVista.IoT.DeviceAdmin.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.CustomField_Title, Resources.DeviceLibraryResources.Names.CustomFIeld_Help, Resources.DeviceLibraryResources.Names.CustomField_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources))]
    public class CustomField : IKeyedEntity, IFormDescriptor
    {
        [JsonProperty("id")]
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_UniqueId, IsUserEditable: false, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Id { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name,  IsRequired:true, FieldType:FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public String Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_Label, IsRequired: true, HelpResource: Resources.DeviceLibraryResources.Names.CustomField_Label_Help, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public String Label { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_IsRequired, FieldType:FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsRequired { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_IsReadOnly, HelpResource:Resources.DeviceLibraryResources.Names.CustomField_IsReadOnly_Help, FieldType:FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsReadOnly{ get; set; }

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

        public void Validate(ValidationResult result)
        {
            if (EntityHeader.IsNullOrEmpty(FieldType)) result.AddUserError("Field Type is Required.");

            if(FieldType.Value == ParameterTypes.ValueWithUnit)
            {
                if (EntityHeader.IsNullOrEmpty(UnitSet)) result.AddUserError("If Value with Unit is selected for the Field Type, you must specify a Unit Set.");
            }
            else if(FieldType.Value == ParameterTypes.State)
            {
                if (EntityHeader.IsNullOrEmpty(StateSet)) result.AddUserError("If State Set is selected for the Field Type, you must specify a State Set.");
            }
            
        }
    }
}
