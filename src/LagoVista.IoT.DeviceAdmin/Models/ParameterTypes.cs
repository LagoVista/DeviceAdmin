using LagoVista.Core.Attributes;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
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
        [EnumLabel("datetime", DeviceLibraryResources.Names.Parameter_Types_DateTime, typeof(DeviceLibraryResources))]
        DateTime,
        [EnumLabel("states", DeviceLibraryResources.Names.Parameter_Types_States, typeof(DeviceLibraryResources))]
        States,
        [EnumLabel("unitwithvalues", DeviceLibraryResources.Names.Parameter_Types_ValueWithUnit, typeof(DeviceLibraryResources))]
        UnitWithValues,
    }
}
