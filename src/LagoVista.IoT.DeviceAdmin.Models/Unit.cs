using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Unit_Title, Resources.DeviceLibraryResources.Names.Unit_Help, DeviceLibraryResources.Names.Unit_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, 
        typeof(DeviceLibraryResources), FactoryUrl: "/api/deviceadmin/factory/unit")]
    public class Unit : IKeyedEntity, INamedEntity, IValidateable, IFormDescriptor
    {
        public Unit()
        {
            IsDefault = true;
        }
        public enum ConversionTypes
        {
            [EnumLabel(Unit.ConversionTypes_Factor, DeviceLibraryResources.Names.Unit_Conversion_Type_Factor, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.Unit_Conversion_Type_Factor_Help)]
            Factor,

            [EnumLabel(Unit.ConversionTypes_Script, DeviceLibraryResources.Names.Unit_Conversion_Type_Script, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.Unit_Conversion_Type_Script_Help)]
            Script,
        }

        public const string ConversionTypes_Factor = "factor";
        public const string ConversionTypes_Script = "script";

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Unit_Abbreviation, IsRequired: true, MaxLength: 6, ResourceType: typeof(DeviceLibraryResources))]
        public String Abbreviation { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public String Description { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Unit_NumberDecimal, IsRequired: true, FieldType: FieldTypes.Integer, HelpResource: Resources.DeviceLibraryResources.Names.Unit_NumberDecimal_Help, ResourceType: typeof(DeviceLibraryResources))]
        public int NumberDecimalPoints { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Unit_Conversion_Type, EnumType: typeof(ConversionTypes), HelpResource: Resources.DeviceLibraryResources.Names.Unit_Conversion_Type_Help, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<ConversionTypes> ConversionType { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Unit_Conversion_Type_Factor, FieldType: FieldTypes.Decimal, HelpResource: Resources.DeviceLibraryResources.Names.Unit_Conversion_Type_Factor_Help, ResourceType: typeof(DeviceLibraryResources))]
        public double? ConversionFactor { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Unit_ConversionTo_Script, WaterMark: Resources.DeviceLibraryResources.Names.Unit_Conversion_EditScriptWatermark, FieldType: FieldTypes.NodeScript, HelpResource: Resources.DeviceLibraryResources.Names.Unit_ConversionTo_Script_Help, ResourceType: typeof(DeviceLibraryResources))]
        public String ConversionToScript { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Unit_ConversionFrom_Script, WaterMark: Resources.DeviceLibraryResources.Names.Unit_Conversion_EditScriptWatermark, FieldType: FieldTypes.NodeScript, HelpResource: Resources.DeviceLibraryResources.Names.Unit_ConversionFrom_Script_Help, ResourceType: typeof(DeviceLibraryResources))]
        public String ConversionFromScript { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Unit_DisplayFormat, FieldType: FieldTypes.NodeScript, HelpResource: Resources.DeviceLibraryResources.Names.Unit_DisplayFormat_Help, ResourceType: typeof(DeviceLibraryResources))]
        public String DisplayFormat { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Unit_IsDefault, FieldType: FieldTypes.CheckBox, HelpResource: Resources.DeviceLibraryResources.Names.Unit_IsDefault, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsDefault { get; set; }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Unit.Name),
                nameof(Unit.Key),
                nameof(Unit.Description),
                nameof(Unit.Abbreviation),
                nameof(Unit.Key),
                nameof(Unit.NumberDecimalPoints),
                nameof(Unit.IsDefault),
                nameof(Unit.ConversionType),
                nameof(Unit.ConversionFactor),
                nameof(Unit.ConversionToScript),
                nameof(Unit.ConversionFromScript)
            };
        }

        public Unit Clone()
        {
            return new Unit()
            {
                Abbreviation = Abbreviation,
                ConversionFactor = ConversionFactor,
                ConversionFromScript = ConversionFromScript,
                ConversionToScript = ConversionToScript,
                ConversionType = ConversionType.Clone(),
                Description = Description,
                DisplayFormat = DisplayFormat,
                IsDefault = IsDefault,
                Key = Key,
                Name = Name,
                NumberDecimalPoints = NumberDecimalPoints
            };
        }

        [CustomValidator]
        public void Validate(ValidationResult result)
        {
            if (IsDefault)
            {
                ConversionType = null;
                ConversionFactor = null;
                ConversionToScript = null;
                ConversionFromScript = null;
            }
            else
            {
                if (EntityHeader.IsNullOrEmpty(ConversionType))
                {
                    result.AddUserError($"For non-default Units, on unit {Name} you must provide a conversion type.");
                }
                else
                {
                    switch (ConversionType.Value)
                    {
                        case ConversionTypes.Factor:
                            if (!ConversionFactor.HasValue) result.AddUserError($"For Units that specify a Conversion Type of a Conversion Factor, a Conversion Factor must be Provided on unit {Name}");
                            break;
                        case ConversionTypes.Script:
                            if (String.IsNullOrEmpty(ConversionToScript)) result.AddUserError($"Since you are using a conversion script on unit {Name}, you must provide the Conversion To Script");
                            if (String.IsNullOrEmpty(ConversionFromScript)) result.AddUserError($"Since you are using a conversion script on unit {Name}, you must provide the Conversion From Script");

                            //TODO: Should probably provide some sort of validation on the scripts, JInt, requires dotnetstandard 1.3 and need to think it through first, for now, just ensure it's not empty and contains the name of the method
                            /* For now, just make sure the script contains the name of the function, that will be called, the run time engine will handle and report invalid scripts */
                            if (!String.IsNullOrEmpty(ConversionToScript) && !ConversionToScript.Contains("convertToDefaultUnit")) result.AddUserError($"Convertion From Script on unit {Name} must contain an implementation of the function [convertToDefaultUnit]");
                            if (!String.IsNullOrEmpty(ConversionFromScript) && !ConversionFromScript.Contains("convertFromDefaultUnit")) result.AddUserError($"Convertion From Script on unit {Name} must contain an implementation of the function [convertFromDefaultUnit]");

                            break;
                    }
                }
            }
        }
    }

}
