using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(Title:Resources.DeviceLibraryResources.Names.AttributeUnit_Title, Domain:DeviceAdminDomain.DeviceAdmin, UserHelp:Resources.DeviceLibraryResources.Names.AttributeUnit_Help, Description:Resources.DeviceLibraryResources.Names.AttributeUnit_Description, ResourceType: typeof(DeviceLibraryResources))]
    public class AttributeUnit : IKeyedEntity, INamedEntity
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public String Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.AttributeUnit_Abbreviation, IsRequired: true, MaxLength: 6, ResourceType: typeof(DeviceLibraryResources))]
        public String Abbreviation { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, ResourceType: typeof(DeviceLibraryResources))]
        public String Description { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.AttributeUnit_NumberDecimal, IsRequired: true, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceLibraryResources))]
        public int NumberDecimalPoints { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.AttributeUnit_ConversionScript, HelpResource: Resources.DeviceLibraryResources.Names.AttributeUnit_ConversionScript_Help, ResourceType: typeof(DeviceLibraryResources))]
        public String ConversionScript { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.AttributeUnit_IsDefault, HelpResource: Resources.DeviceLibraryResources.Names.AttributeUnit_ConversionScript_Help, ResourceType: typeof(DeviceLibraryResources))]
        public String IsDefault { get; set; }
    }

}
