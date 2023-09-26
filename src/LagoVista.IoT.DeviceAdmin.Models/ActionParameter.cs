using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using LagoVista.IoT.DeviceAdmin.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.ActionParameter_Title, DeviceLibraryResources.Names.ActionParameter_Description, DeviceLibraryResources.Names.ActionParameter_Help,
        EntityDescriptionAttribute.EntityTypes.SimpleModel,  typeof(DeviceLibraryResources), FactoryUrl: "/api/deviceadmin/factory/actionparameter/{id}")]
    public class ActionParameter : INamedEntity, IKeyedEntity, IFormDescriptor
    {
        [JsonProperty("id")]
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_UniqueId, IsUserEditable: false, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Id { get; set; }

        public enum ParameterTypes
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
            [EnumLabel("datetime", DeviceLibraryResources.Names.Parameter_Types_GeoLocation, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.WorkflowInput_Type_GeoLocation_Help)]
            DateTime,
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsRequired, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public bool IsRequired { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public String Name { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Parameter_Type, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false, WaterMark: DeviceLibraryResources.Names.Parameter_Type_Watermark)]
        public EntityHeader ParameterType { get; set; }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(ActionParameter.Name),
                nameof(ActionParameter.Key),
                nameof(ActionParameter.IsRequired),
                nameof(ActionParameter.ParameterType),
            };
        }
    }
}
