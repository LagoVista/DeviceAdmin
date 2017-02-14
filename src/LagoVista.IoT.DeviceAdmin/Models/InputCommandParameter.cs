using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.InputCommandParameter_Title, DeviceLibraryResources.Names.InputCommandParameter_Help, DeviceLibraryResources.Names.InputCommandParamter_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class InputCommandParameter
    {
        public enum InputCommandParameterTypes
        {
            [EnumLabel("string", DeviceLibraryResources.Names.Parameter_Types_String, typeof(DeviceLibraryResources))]
            String,
            [EnumLabel("integer", DeviceLibraryResources.Names.Parameter_Types_Integer, typeof(DeviceLibraryResources))]
            Integer,
            [EnumLabel("decimal", DeviceLibraryResources.Names.Parameter_Types_Decimal, typeof(DeviceLibraryResources))]
            Decimal,
            [EnumLabel("true-false", DeviceLibraryResources.Names.Parameter_Types_TrueFalse, typeof(DeviceLibraryResources))]
            TrueFalse,
            [EnumLabel("geolocation", DeviceLibraryResources.Names.Parameter_Types_GeoLocation, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.WorkflowInput_Type_GeoLocation_Help)]
            GeoLocation,

        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsRequired, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsRequired { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.InputCommandParameter_Type, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, EnumType:typeof(InputCommandParameterTypes), WaterMark: DeviceLibraryResources.Names.Parameter_Type_Watermark)]
        public EntityHeader ParameterType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public String Description { get; set; }
    }
}

