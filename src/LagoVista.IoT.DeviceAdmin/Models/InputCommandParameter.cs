using LagoVista.Core.Attributes;
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
            [EnumLabel("String", DeviceLibraryResources.Names.Parameter_Types_String, typeof(DeviceLibraryResources))]
            String,
            [EnumLabel("Integer", DeviceLibraryResources.Names.Parameter_Types_Integer, typeof(DeviceLibraryResources))]
            Integer,
            [EnumLabel("Decimal", DeviceLibraryResources.Names.Parameter_Types_Decimal, typeof(DeviceLibraryResources))]
            Decimal,
            [EnumLabel("TrueFalse", DeviceLibraryResources.Names.Parameter_Types_TrueFalse, typeof(DeviceLibraryResources))]
            TrueFalse
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsRequired, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public bool IsRequired { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public String Name { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.InputCommandParameter_Type, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public InputCommandParameterTypes ParameterType { get; set; }
    }
}

