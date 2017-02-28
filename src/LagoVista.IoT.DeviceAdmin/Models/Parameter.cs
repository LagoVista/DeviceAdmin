using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;


namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Parameter_Title, DeviceLibraryResources.Names.Parameter_Help, DeviceLibraryResources.Names.InputCommandParamter_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class Parameter
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsRequired, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsRequired { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Parameter_Type, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, EnumType:typeof(ParameterTypes), WaterMark: DeviceLibraryResources.Names.Parameter_Type_Watermark)]
        public EntityHeader ParameterType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public String Description { get; set; }    }
}
