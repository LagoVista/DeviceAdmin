using System.Globalization;
using System.Reflection;

//Resources:DeviceLibraryResources:AttributeUnit_Abbreviation
namespace LagoVista.IoT.DeviceAdmin.Resources
{
	public class DeviceLibraryResources
	{
        private static global::System.Resources.ResourceManager resourceMan;
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static global::System.Resources.ResourceManager ResourceManager 
		{
            get 
			{
                if (object.ReferenceEquals(resourceMan, null)) 
				{
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LagoVista.IoT.DeviceAdmin.Resources.DeviceLibraryResources", typeof(DeviceLibraryResources).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Returns the formatted resource string.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static string GetResourceString(string key, params string[] tokens)
		{
			var culture = CultureInfo.CurrentCulture;;
            var str = ResourceManager.GetString(key, culture);

			for(int i = 0; i < tokens.Length; i += 2)
				str = str.Replace(tokens[i], tokens[i+1]);
										
            return str;
        }
        
        /// <summary>
        ///   Returns the formatted resource string.
        /// </summary>
		/*
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static HtmlString GetResourceHtmlString(string key, params string[] tokens)
		{
			var str = GetResourceString(key, tokens);
							
			if(str.StartsWith("HTML:"))
				str = str.Substring(5);

			return new HtmlString(str);
        }*/
		
		public static string AttributeUnit_Abbreviation { get { return GetResourceString("AttributeUnit_Abbreviation"); } }
//Resources:DeviceLibraryResources:AttributeUnit_ConversionScript

		public static string AttributeUnit_ConversionScript { get { return GetResourceString("AttributeUnit_ConversionScript"); } }
//Resources:DeviceLibraryResources:AttributeUnit_ConversionScript_Help

		public static string AttributeUnit_ConversionScript_Help { get { return GetResourceString("AttributeUnit_ConversionScript_Help"); } }
//Resources:DeviceLibraryResources:AttributeUnit_IsDefault

		public static string AttributeUnit_IsDefault { get { return GetResourceString("AttributeUnit_IsDefault"); } }
//Resources:DeviceLibraryResources:AttributeUnit_NumberDecimal

		public static string AttributeUnit_NumberDecimal { get { return GetResourceString("AttributeUnit_NumberDecimal"); } }
//Resources:DeviceLibraryResources:AttributeUnitDefinitions

		public static string AttributeUnitDefinitions { get { return GetResourceString("AttributeUnitDefinitions"); } }
//Resources:DeviceLibraryResources:AttributeUnitSet_Help

		public static string AttributeUnitSet_Help { get { return GetResourceString("AttributeUnitSet_Help"); } }
//Resources:DeviceLibraryResources:Common_CreatedBy

		public static string Common_CreatedBy { get { return GetResourceString("Common_CreatedBy"); } }
//Resources:DeviceLibraryResources:Common_CreationDate

		public static string Common_CreationDate { get { return GetResourceString("Common_CreationDate"); } }
//Resources:DeviceLibraryResources:Common_Description

		public static string Common_Description { get { return GetResourceString("Common_Description"); } }
//Resources:DeviceLibraryResources:Common_IsPublic

		public static string Common_IsPublic { get { return GetResourceString("Common_IsPublic"); } }
//Resources:DeviceLibraryResources:Common_Key

		public static string Common_Key { get { return GetResourceString("Common_Key"); } }
//Resources:DeviceLibraryResources:Common_Key_Help

		public static string Common_Key_Help { get { return GetResourceString("Common_Key_Help"); } }
//Resources:DeviceLibraryResources:Common_Key_Validation

		public static string Common_Key_Validation { get { return GetResourceString("Common_Key_Validation"); } }
//Resources:DeviceLibraryResources:Common_LastUpdated

		public static string Common_LastUpdated { get { return GetResourceString("Common_LastUpdated"); } }
//Resources:DeviceLibraryResources:Common_LastUpdatedBy

		public static string Common_LastUpdatedBy { get { return GetResourceString("Common_LastUpdatedBy"); } }
//Resources:DeviceLibraryResources:Common_Name

		public static string Common_Name { get { return GetResourceString("Common_Name"); } }
//Resources:DeviceLibraryResources:Common_UniqueId

		public static string Common_UniqueId { get { return GetResourceString("Common_UniqueId"); } }
//Resources:DeviceLibraryResources:Device_Account

		public static string Device_Account { get { return GetResourceString("Device_Account"); } }
//Resources:DeviceLibraryResources:Device_BatteryLevel

		public static string Device_BatteryLevel { get { return GetResourceString("Device_BatteryLevel"); } }
//Resources:DeviceLibraryResources:Device_Capabilities

		public static string Device_Capabilities { get { return GetResourceString("Device_Capabilities"); } }
//Resources:DeviceLibraryResources:Device_ConnectionStatus

		public static string Device_ConnectionStatus { get { return GetResourceString("Device_ConnectionStatus"); } }
//Resources:DeviceLibraryResources:Device_CustomFields

		public static string Device_CustomFields { get { return GetResourceString("Device_CustomFields"); } }
//Resources:DeviceLibraryResources:Device_Description

		public static string Device_Description { get { return GetResourceString("Device_Description"); } }
//Resources:DeviceLibraryResources:Device_DeviceId

		public static string Device_DeviceId { get { return GetResourceString("Device_DeviceId"); } }
//Resources:DeviceLibraryResources:Device_DeviceId_Help

		public static string Device_DeviceId_Help { get { return GetResourceString("Device_DeviceId_Help"); } }
//Resources:DeviceLibraryResources:Device_DeviceId_Required

		public static string Device_DeviceId_Required { get { return GetResourceString("Device_DeviceId_Required"); } }
//Resources:DeviceLibraryResources:Device_DeviceNotes

		public static string Device_DeviceNotes { get { return GetResourceString("Device_DeviceNotes"); } }
//Resources:DeviceLibraryResources:Device_DeviceType

		public static string Device_DeviceType { get { return GetResourceString("Device_DeviceType"); } }
//Resources:DeviceLibraryResources:Device_FirmwareVersion

		public static string Device_FirmwareVersion { get { return GetResourceString("Device_FirmwareVersion"); } }
//Resources:DeviceLibraryResources:Device_GatewayDevice

		public static string Device_GatewayDevice { get { return GetResourceString("Device_GatewayDevice"); } }
//Resources:DeviceLibraryResources:Device_GeoLocation

		public static string Device_GeoLocation { get { return GetResourceString("Device_GeoLocation"); } }
//Resources:DeviceLibraryResources:Device_IsBatteryPowered

		public static string Device_IsBatteryPowered { get { return GetResourceString("Device_IsBatteryPowered"); } }
//Resources:DeviceLibraryResources:Device_LastContact

		public static string Device_LastContact { get { return GetResourceString("Device_LastContact"); } }
//Resources:DeviceLibraryResources:Device_Location

		public static string Device_Location { get { return GetResourceString("Device_Location"); } }
//Resources:DeviceLibraryResources:Device_Manufacturer

		public static string Device_Manufacturer { get { return GetResourceString("Device_Manufacturer"); } }
//Resources:DeviceLibraryResources:Device_ModelNumber

		public static string Device_ModelNumber { get { return GetResourceString("Device_ModelNumber"); } }
//Resources:DeviceLibraryResources:Device_Online

		public static string Device_Online { get { return GetResourceString("Device_Online"); } }
//Resources:DeviceLibraryResources:Device_SerialNumber

		public static string Device_SerialNumber { get { return GetResourceString("Device_SerialNumber"); } }
//Resources:DeviceLibraryResources:Device_Status

		public static string Device_Status { get { return GetResourceString("Device_Status"); } }
//Resources:DeviceLibraryResources:DeviceCapability_Account

		public static string DeviceCapability_Account { get { return GetResourceString("DeviceCapability_Account"); } }
//Resources:DeviceLibraryResources:DeviceCapability_Category

		public static string DeviceCapability_Category { get { return GetResourceString("DeviceCapability_Category"); } }
//Resources:DeviceLibraryResources:DeviceCapability_Direction

		public static string DeviceCapability_Direction { get { return GetResourceString("DeviceCapability_Direction"); } }
//Resources:DeviceLibraryResources:DeviceCapability_Direction_Both

		public static string DeviceCapability_Direction_Both { get { return GetResourceString("DeviceCapability_Direction_Both"); } }
//Resources:DeviceLibraryResources:DeviceCapability_Direction_Input

		public static string DeviceCapability_Direction_Input { get { return GetResourceString("DeviceCapability_Direction_Input"); } }
//Resources:DeviceLibraryResources:DeviceCapability_Direction_Output

		public static string DeviceCapability_Direction_Output { get { return GetResourceString("DeviceCapability_Direction_Output"); } }
//Resources:DeviceLibraryResources:DeviceCapability_Group

		public static string DeviceCapability_Group { get { return GetResourceString("DeviceCapability_Group"); } }
//Resources:DeviceLibraryResources:DeviceCapability_IsPublic

		public static string DeviceCapability_IsPublic { get { return GetResourceString("DeviceCapability_IsPublic"); } }
//Resources:DeviceLibraryResources:DeviceCapability_Name

		public static string DeviceCapability_Name { get { return GetResourceString("DeviceCapability_Name"); } }
//Resources:DeviceLibraryResources:DeviceCapability_Units

		public static string DeviceCapability_Units { get { return GetResourceString("DeviceCapability_Units"); } }
//Resources:DeviceLibraryResources:DeviceType_Capabilities

		public static string DeviceType_Capabilities { get { return GetResourceString("DeviceType_Capabilities"); } }
//Resources:DeviceLibraryResources:DeviceType_CustomFields

		public static string DeviceType_CustomFields { get { return GetResourceString("DeviceType_CustomFields"); } }
//Resources:DeviceLibraryResources:DeviceType_DocLink

		public static string DeviceType_DocLink { get { return GetResourceString("DeviceType_DocLink"); } }
//Resources:DeviceLibraryResources:DeviceType_IsPublic

		public static string DeviceType_IsPublic { get { return GetResourceString("DeviceType_IsPublic"); } }
//Resources:DeviceLibraryResources:DeviceType_Manufacture

		public static string DeviceType_Manufacture { get { return GetResourceString("DeviceType_Manufacture"); } }
//Resources:DeviceLibraryResources:DeviceType_Model

		public static string DeviceType_Model { get { return GetResourceString("DeviceType_Model"); } }
//Resources:DeviceLibraryResources:DeviceType_Name

		public static string DeviceType_Name { get { return GetResourceString("DeviceType_Name"); } }
//Resources:DeviceLibraryResources:DeviceType_States

		public static string DeviceType_States { get { return GetResourceString("DeviceType_States"); } }
//Resources:DeviceLibraryResources:Gateway_Account

		public static string Gateway_Account { get { return GetResourceString("Gateway_Account"); } }
//Resources:DeviceLibraryResources:Gateway_Address

		public static string Gateway_Address { get { return GetResourceString("Gateway_Address"); } }
//Resources:DeviceLibraryResources:Gateway_Address_Help

		public static string Gateway_Address_Help { get { return GetResourceString("Gateway_Address_Help"); } }
//Resources:DeviceLibraryResources:Gateway_CustomFields

		public static string Gateway_CustomFields { get { return GetResourceString("Gateway_CustomFields"); } }
//Resources:DeviceLibraryResources:Gateway_Description

		public static string Gateway_Description { get { return GetResourceString("Gateway_Description"); } }
//Resources:DeviceLibraryResources:Gateway_Device_Id

		public static string Gateway_Device_Id { get { return GetResourceString("Gateway_Device_Id"); } }
//Resources:DeviceLibraryResources:Gateway_GeoLocation

		public static string Gateway_GeoLocation { get { return GetResourceString("Gateway_GeoLocation"); } }
//Resources:DeviceLibraryResources:Gateway_Location

		public static string Gateway_Location { get { return GetResourceString("Gateway_Location"); } }
//Resources:DeviceLibraryResources:Gateway_Manufacturer

		public static string Gateway_Manufacturer { get { return GetResourceString("Gateway_Manufacturer"); } }
//Resources:DeviceLibraryResources:Gateway_ModelNumber

		public static string Gateway_ModelNumber { get { return GetResourceString("Gateway_ModelNumber"); } }
//Resources:DeviceLibraryResources:Gateway_Name

		public static string Gateway_Name { get { return GetResourceString("Gateway_Name"); } }
//Resources:DeviceLibraryResources:Gateway_Notes

		public static string Gateway_Notes { get { return GetResourceString("Gateway_Notes"); } }
//Resources:DeviceLibraryResources:Gateway_SerialNumber

		public static string Gateway_SerialNumber { get { return GetResourceString("Gateway_SerialNumber"); } }
//Resources:DeviceLibraryResources:Gatway_Firmware_Version

		public static string Gatway_Firmware_Version { get { return GetResourceString("Gatway_Firmware_Version"); } }

		public static class Names
		{
			public const string AttributeUnit_Abbreviation = "AttributeUnit_Abbreviation";
			public const string AttributeUnit_ConversionScript = "AttributeUnit_ConversionScript";
			public const string AttributeUnit_ConversionScript_Help = "AttributeUnit_ConversionScript_Help";
			public const string AttributeUnit_IsDefault = "AttributeUnit_IsDefault";
			public const string AttributeUnit_NumberDecimal = "AttributeUnit_NumberDecimal";
			public const string AttributeUnitDefinitions = "AttributeUnitDefinitions";
			public const string AttributeUnitSet_Help = "AttributeUnitSet_Help";
			public const string Common_CreatedBy = "Common_CreatedBy";
			public const string Common_CreationDate = "Common_CreationDate";
			public const string Common_Description = "Common_Description";
			public const string Common_IsPublic = "Common_IsPublic";
			public const string Common_Key = "Common_Key";
			public const string Common_Key_Help = "Common_Key_Help";
			public const string Common_Key_Validation = "Common_Key_Validation";
			public const string Common_LastUpdated = "Common_LastUpdated";
			public const string Common_LastUpdatedBy = "Common_LastUpdatedBy";
			public const string Common_Name = "Common_Name";
			public const string Common_UniqueId = "Common_UniqueId";
			public const string Device_Account = "Device_Account";
			public const string Device_BatteryLevel = "Device_BatteryLevel";
			public const string Device_Capabilities = "Device_Capabilities";
			public const string Device_ConnectionStatus = "Device_ConnectionStatus";
			public const string Device_CustomFields = "Device_CustomFields";
			public const string Device_Description = "Device_Description";
			public const string Device_DeviceId = "Device_DeviceId";
			public const string Device_DeviceId_Help = "Device_DeviceId_Help";
			public const string Device_DeviceId_Required = "Device_DeviceId_Required";
			public const string Device_DeviceNotes = "Device_DeviceNotes";
			public const string Device_DeviceType = "Device_DeviceType";
			public const string Device_FirmwareVersion = "Device_FirmwareVersion";
			public const string Device_GatewayDevice = "Device_GatewayDevice";
			public const string Device_GeoLocation = "Device_GeoLocation";
			public const string Device_IsBatteryPowered = "Device_IsBatteryPowered";
			public const string Device_LastContact = "Device_LastContact";
			public const string Device_Location = "Device_Location";
			public const string Device_Manufacturer = "Device_Manufacturer";
			public const string Device_ModelNumber = "Device_ModelNumber";
			public const string Device_Online = "Device_Online";
			public const string Device_SerialNumber = "Device_SerialNumber";
			public const string Device_Status = "Device_Status";
			public const string DeviceCapability_Account = "DeviceCapability_Account";
			public const string DeviceCapability_Category = "DeviceCapability_Category";
			public const string DeviceCapability_Direction = "DeviceCapability_Direction";
			public const string DeviceCapability_Direction_Both = "DeviceCapability_Direction_Both";
			public const string DeviceCapability_Direction_Input = "DeviceCapability_Direction_Input";
			public const string DeviceCapability_Direction_Output = "DeviceCapability_Direction_Output";
			public const string DeviceCapability_Group = "DeviceCapability_Group";
			public const string DeviceCapability_IsPublic = "DeviceCapability_IsPublic";
			public const string DeviceCapability_Name = "DeviceCapability_Name";
			public const string DeviceCapability_Units = "DeviceCapability_Units";
			public const string DeviceType_Capabilities = "DeviceType_Capabilities";
			public const string DeviceType_CustomFields = "DeviceType_CustomFields";
			public const string DeviceType_DocLink = "DeviceType_DocLink";
			public const string DeviceType_IsPublic = "DeviceType_IsPublic";
			public const string DeviceType_Manufacture = "DeviceType_Manufacture";
			public const string DeviceType_Model = "DeviceType_Model";
			public const string DeviceType_Name = "DeviceType_Name";
			public const string DeviceType_States = "DeviceType_States";
			public const string Gateway_Account = "Gateway_Account";
			public const string Gateway_Address = "Gateway_Address";
			public const string Gateway_Address_Help = "Gateway_Address_Help";
			public const string Gateway_CustomFields = "Gateway_CustomFields";
			public const string Gateway_Description = "Gateway_Description";
			public const string Gateway_Device_Id = "Gateway_Device_Id";
			public const string Gateway_GeoLocation = "Gateway_GeoLocation";
			public const string Gateway_Location = "Gateway_Location";
			public const string Gateway_Manufacturer = "Gateway_Manufacturer";
			public const string Gateway_ModelNumber = "Gateway_ModelNumber";
			public const string Gateway_Name = "Gateway_Name";
			public const string Gateway_Notes = "Gateway_Notes";
			public const string Gateway_SerialNumber = "Gateway_SerialNumber";
			public const string Gatway_Firmware_Version = "Gatway_Firmware_Version";
		}
	}
}
