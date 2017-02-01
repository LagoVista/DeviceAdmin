using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using Newtonsoft.Json;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Unit_Title, Resources.DeviceLibraryResources.Names.Unit_Help, DeviceLibraryResources.Names.Unit_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel,typeof(DeviceLibraryResources))]
    public class Unit : IKeyedEntity, INamedEntity, IValidateable
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Unit_Abbreviation, IsRequired: true, MaxLength: 6, ResourceType: typeof(DeviceLibraryResources))]
        public String Abbreviation { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType:FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public String Description { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Unit_NumberDecimal, IsRequired: true, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceLibraryResources))]
        public int NumberDecimalPoints { get; set; }


        // Look at for running the scripts https://github.com/sebastienros/jint
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Unit_ConversionScript, FieldType:FieldTypes.NodeScript, HelpResource: Resources.DeviceLibraryResources.Names.Unit_ConversionScript_Help, ResourceType: typeof(DeviceLibraryResources))]
        public String ConversionScript { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Unit_IsDefault, FieldType:FieldTypes.CheckBox, HelpResource: Resources.DeviceLibraryResources.Names.Unit_IsDefault, ResourceType: typeof(DeviceLibraryResources))]
        public String IsDefault { get; set; }
    }

}
