using LagoVista.Core.Attributes;
using LagoVista.IoT.DeviceAdmin.Models.Resources;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public enum ParameterTypes
    {
        [EnumLabel(TypeSystem.String, DeviceLibraryResources.Names.Parameter_Types_String, typeof(DeviceLibraryResources))]
        String,
        [EnumLabel(TypeSystem.Integer, DeviceLibraryResources.Names.Parameter_Types_Integer, typeof(DeviceLibraryResources))]
        Integer,
        [EnumLabel(TypeSystem.Decimal, DeviceLibraryResources.Names.Parameter_Types_Decimal, typeof(DeviceLibraryResources))]
        Decimal,
        [EnumLabel(TypeSystem.TrueFalse, DeviceLibraryResources.Names.Parameter_Types_TrueFalse, typeof(DeviceLibraryResources))]
        TrueFalse,
        [EnumLabel(TypeSystem.Geolocation, DeviceLibraryResources.Names.Parameter_Types_GeoLocation, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.WorkflowInput_Type_GeoLocation_Help)]
        GeoLocation,
        [EnumLabel(TypeSystem.DateTime, DeviceLibraryResources.Names.Parameter_Types_DateTime, typeof(DeviceLibraryResources))]
        DateTime,
        [EnumLabel(TypeSystem.State, DeviceLibraryResources.Names.Parameter_Types_States, typeof(DeviceLibraryResources))]
        State,
        [EnumLabel(TypeSystem.ValueWithUnit, DeviceLibraryResources.Names.Parameter_Types_ValueWithUnit, typeof(DeviceLibraryResources))]
        ValueWithUnit,
        [EnumLabel(TypeSystem.Image, DeviceLibraryResources.Names.Parameter_Types_Image, typeof(DeviceLibraryResources))]
        Image,
        [EnumLabel(TypeSystem.DecimalArray, DeviceLibraryResources.Names.Parameter_Types_DecimalArray, typeof(DeviceLibraryResources))]
        DecimalArray,
        [EnumLabel(TypeSystem.IntArray, DeviceLibraryResources.Names.Parameter_Types_IntArray, typeof(DeviceLibraryResources))]
        IntArray,
        [EnumLabel(TypeSystem.StringArray, DeviceLibraryResources.Names.Parameter_Types_StringArray, typeof(DeviceLibraryResources))]
        StringArray,
        [EnumLabel(TypeSystem.MLInference, DeviceLibraryResources.Names.Parameter_Types_MLInference, typeof(DeviceLibraryResources))]
        MLInference,
        [EnumLabel(TypeSystem.Object, DeviceLibraryResources.Names.Parameter_Types_Object, typeof(DeviceLibraryResources))]
        Object
    }

    public class TypeSystem
    {
        public const string String = "string";
        public const string Integer = "integer";
        public const string Decimal = "decimal";
        public const string TrueFalse = "true-false";
        public const string Geolocation = "geolocation";
        public const string DateTime = "datetime";
        public const string State = "state";
        public const string Image = "image";
        public const string MLInference = "mlinference";
        public const string Object = "object";
        public const string DecimalArray = "decimalarray";
        public const string ValueWithUnit = "valuewithunit";
        public const string IntArray = "intarray";
        public const string StringArray = "stringarray";

    }
}
