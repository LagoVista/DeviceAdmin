/*9/4/2017 09:15:54*/
using System.Globalization;
using System.Reflection;

//Resources:DeviceLibraryResources:Action_AssociatedAttribute
namespace LagoVista.IoT.DeviceAdmin.Resources
{
	public class DeviceLibraryResources
	{
        private static global::System.Resources.ResourceManager _resourceManager;
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static global::System.Resources.ResourceManager ResourceManager 
		{
            get 
			{
                if (object.ReferenceEquals(_resourceManager, null)) 
				{
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LagoVista.IoT.DeviceAdmin.Resources.DeviceLibraryResources", typeof(DeviceLibraryResources).GetTypeInfo().Assembly);
                    _resourceManager = temp;
                }
                return _resourceManager;
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
		
		public static string Action_AssociatedAttribute { get { return GetResourceString("Action_AssociatedAttribute"); } }
//Resources:DeviceLibraryResources:Action_AssociatedAttribute_Help

		public static string Action_AssociatedAttribute_Help { get { return GetResourceString("Action_AssociatedAttribute_Help"); } }
//Resources:DeviceLibraryResources:Action_Description

		public static string Action_Description { get { return GetResourceString("Action_Description"); } }
//Resources:DeviceLibraryResources:Action_ExecuteFromGet

		public static string Action_ExecuteFromGet { get { return GetResourceString("Action_ExecuteFromGet"); } }
//Resources:DeviceLibraryResources:Action_ExecuteFromGet_Help

		public static string Action_ExecuteFromGet_Help { get { return GetResourceString("Action_ExecuteFromGet_Help"); } }
//Resources:DeviceLibraryResources:Action_ExecuteFromPost

		public static string Action_ExecuteFromPost { get { return GetResourceString("Action_ExecuteFromPost"); } }
//Resources:DeviceLibraryResources:Action_ExecuteFromPost_Help

		public static string Action_ExecuteFromPost_Help { get { return GetResourceString("Action_ExecuteFromPost_Help"); } }
//Resources:DeviceLibraryResources:Action_ExecuteFromScript

		public static string Action_ExecuteFromScript { get { return GetResourceString("Action_ExecuteFromScript"); } }
//Resources:DeviceLibraryResources:Action_ExecuteFromScript_Help

		public static string Action_ExecuteFromScript_Help { get { return GetResourceString("Action_ExecuteFromScript_Help"); } }
//Resources:DeviceLibraryResources:Action_ExecuteFromStateMachine

		public static string Action_ExecuteFromStateMachine { get { return GetResourceString("Action_ExecuteFromStateMachine"); } }
//Resources:DeviceLibraryResources:Action_ExecuteFromstateMachine_Help

		public static string Action_ExecuteFromstateMachine_Help { get { return GetResourceString("Action_ExecuteFromstateMachine_Help"); } }
//Resources:DeviceLibraryResources:Action_Help

		public static string Action_Help { get { return GetResourceString("Action_Help"); } }
//Resources:DeviceLibraryResources:Action_NodeRedFlows

		public static string Action_NodeRedFlows { get { return GetResourceString("Action_NodeRedFlows"); } }
//Resources:DeviceLibraryResources:Action_RemoteUri

		public static string Action_RemoteUri { get { return GetResourceString("Action_RemoteUri"); } }
//Resources:DeviceLibraryResources:Action_Script

		public static string Action_Script { get { return GetResourceString("Action_Script"); } }
//Resources:DeviceLibraryResources:Action_Shared

		public static string Action_Shared { get { return GetResourceString("Action_Shared"); } }
//Resources:DeviceLibraryResources:Action_Standard_Help

		public static string Action_Standard_Help { get { return GetResourceString("Action_Standard_Help"); } }
//Resources:DeviceLibraryResources:Action_Title

		public static string Action_Title { get { return GetResourceString("Action_Title"); } }
//Resources:DeviceLibraryResources:ActionParameter_Description

		public static string ActionParameter_Description { get { return GetResourceString("ActionParameter_Description"); } }
//Resources:DeviceLibraryResources:ActionParameter_Help

		public static string ActionParameter_Help { get { return GetResourceString("ActionParameter_Help"); } }
//Resources:DeviceLibraryResources:ActionParameter_Title

		public static string ActionParameter_Title { get { return GetResourceString("ActionParameter_Title"); } }
//Resources:DeviceLibraryResources:Actoin_Parameter_Key_Help

		public static string Actoin_Parameter_Key_Help { get { return GetResourceString("Actoin_Parameter_Key_Help"); } }
//Resources:DeviceLibraryResources:AdminNote_Description

		public static string AdminNote_Description { get { return GetResourceString("AdminNote_Description"); } }
//Resources:DeviceLibraryResources:AdminNote_Help

		public static string AdminNote_Help { get { return GetResourceString("AdminNote_Help"); } }
//Resources:DeviceLibraryResources:AdminNote_Title

		public static string AdminNote_Title { get { return GetResourceString("AdminNote_Title"); } }
//Resources:DeviceLibraryResources:Attribute_AttributeType

		public static string Attribute_AttributeType { get { return GetResourceString("Attribute_AttributeType"); } }
//Resources:DeviceLibraryResources:Attribute_AttributeType_Help

		public static string Attribute_AttributeType_Help { get { return GetResourceString("Attribute_AttributeType_Help"); } }
//Resources:DeviceLibraryResources:Attribute_AttributeType_Select

		public static string Attribute_AttributeType_Select { get { return GetResourceString("Attribute_AttributeType_Select"); } }
//Resources:DeviceLibraryResources:Attribute_Description

		public static string Attribute_Description { get { return GetResourceString("Attribute_Description"); } }
//Resources:DeviceLibraryResources:Attribute_Direction

		public static string Attribute_Direction { get { return GetResourceString("Attribute_Direction"); } }
//Resources:DeviceLibraryResources:Attribute_Direction_Help

		public static string Attribute_Direction_Help { get { return GetResourceString("Attribute_Direction_Help"); } }
//Resources:DeviceLibraryResources:Attribute_Direction_Input

		public static string Attribute_Direction_Input { get { return GetResourceString("Attribute_Direction_Input"); } }
//Resources:DeviceLibraryResources:Attribute_Direction_InputAndOutput

		public static string Attribute_Direction_InputAndOutput { get { return GetResourceString("Attribute_Direction_InputAndOutput"); } }
//Resources:DeviceLibraryResources:Attribute_Direction_Output

		public static string Attribute_Direction_Output { get { return GetResourceString("Attribute_Direction_Output"); } }
//Resources:DeviceLibraryResources:Attribute_Help

		public static string Attribute_Help { get { return GetResourceString("Attribute_Help"); } }
//Resources:DeviceLibraryResources:Attribute_ReadOnly

		public static string Attribute_ReadOnly { get { return GetResourceString("Attribute_ReadOnly"); } }
//Resources:DeviceLibraryResources:Attribute_ReadOnly_Help

		public static string Attribute_ReadOnly_Help { get { return GetResourceString("Attribute_ReadOnly_Help"); } }
//Resources:DeviceLibraryResources:Attribute_Script_Watermark

		public static string Attribute_Script_Watermark { get { return GetResourceString("Attribute_Script_Watermark"); } }
//Resources:DeviceLibraryResources:Attribute_SetScript

		public static string Attribute_SetScript { get { return GetResourceString("Attribute_SetScript"); } }
//Resources:DeviceLibraryResources:Attribute_SetScript_Help

		public static string Attribute_SetScript_Help { get { return GetResourceString("Attribute_SetScript_Help"); } }
//Resources:DeviceLibraryResources:Attribute_Shared

		public static string Attribute_Shared { get { return GetResourceString("Attribute_Shared"); } }
//Resources:DeviceLibraryResources:Attribute_SharedAttribute_Help

		public static string Attribute_SharedAttribute_Help { get { return GetResourceString("Attribute_SharedAttribute_Help"); } }
//Resources:DeviceLibraryResources:Attribute_States

		public static string Attribute_States { get { return GetResourceString("Attribute_States"); } }
//Resources:DeviceLibraryResources:Attribute_States_Help

		public static string Attribute_States_Help { get { return GetResourceString("Attribute_States_Help"); } }
//Resources:DeviceLibraryResources:Attribute_Title

		public static string Attribute_Title { get { return GetResourceString("Attribute_Title"); } }
//Resources:DeviceLibraryResources:Attribute_Type_Boolean

		public static string Attribute_Type_Boolean { get { return GetResourceString("Attribute_Type_Boolean"); } }
//Resources:DeviceLibraryResources:Attribute_Type_Boolean_Help

		public static string Attribute_Type_Boolean_Help { get { return GetResourceString("Attribute_Type_Boolean_Help"); } }
//Resources:DeviceLibraryResources:Attribute_Type_Discrete

		public static string Attribute_Type_Discrete { get { return GetResourceString("Attribute_Type_Discrete"); } }
//Resources:DeviceLibraryResources:Attribute_Type_Discrete_Help

		public static string Attribute_Type_Discrete_Help { get { return GetResourceString("Attribute_Type_Discrete_Help"); } }
//Resources:DeviceLibraryResources:Attribute_Type_Discrete_Units

		public static string Attribute_Type_Discrete_Units { get { return GetResourceString("Attribute_Type_Discrete_Units"); } }
//Resources:DeviceLibraryResources:Attribute_Type_Discrete_Units_Help

		public static string Attribute_Type_Discrete_Units_Help { get { return GetResourceString("Attribute_Type_Discrete_Units_Help"); } }
//Resources:DeviceLibraryResources:Attribute_Type_GeoLocation

		public static string Attribute_Type_GeoLocation { get { return GetResourceString("Attribute_Type_GeoLocation"); } }
//Resources:DeviceLibraryResources:Attribute_Type_GeoLocation_Help

		public static string Attribute_Type_GeoLocation_Help { get { return GetResourceString("Attribute_Type_GeoLocation_Help"); } }
//Resources:DeviceLibraryResources:Attribute_Type_State_Help

		public static string Attribute_Type_State_Help { get { return GetResourceString("Attribute_Type_State_Help"); } }
//Resources:DeviceLibraryResources:Attribute_Type_States

		public static string Attribute_Type_States { get { return GetResourceString("Attribute_Type_States"); } }
//Resources:DeviceLibraryResources:Attribute_Type_Text

		public static string Attribute_Type_Text { get { return GetResourceString("Attribute_Type_Text"); } }
//Resources:DeviceLibraryResources:Attribute_Type_Text_Help

		public static string Attribute_Type_Text_Help { get { return GetResourceString("Attribute_Type_Text_Help"); } }
//Resources:DeviceLibraryResources:Attribute_UnitSet

		public static string Attribute_UnitSet { get { return GetResourceString("Attribute_UnitSet"); } }
//Resources:DeviceLibraryResources:Attribute_UnitSet_Help

		public static string Attribute_UnitSet_Help { get { return GetResourceString("Attribute_UnitSet_Help"); } }
//Resources:DeviceLibraryResources:Attribute_UnitSet_Watermark

		public static string Attribute_UnitSet_Watermark { get { return GetResourceString("Attribute_UnitSet_Watermark"); } }
//Resources:DeviceLibraryResources:Atttribute_StateSet_Watermark

		public static string Atttribute_StateSet_Watermark { get { return GetResourceString("Atttribute_StateSet_Watermark"); } }
//Resources:DeviceLibraryResources:Common_CreatedBy

		public static string Common_CreatedBy { get { return GetResourceString("Common_CreatedBy"); } }
//Resources:DeviceLibraryResources:Common_CreationDate

		public static string Common_CreationDate { get { return GetResourceString("Common_CreationDate"); } }
//Resources:DeviceLibraryResources:Common_Description

		public static string Common_Description { get { return GetResourceString("Common_Description"); } }
//Resources:DeviceLibraryResources:Common_IsPublic

		public static string Common_IsPublic { get { return GetResourceString("Common_IsPublic"); } }
//Resources:DeviceLibraryResources:Common_IsRequired

		public static string Common_IsRequired { get { return GetResourceString("Common_IsRequired"); } }
//Resources:DeviceLibraryResources:Common_IsValid

		public static string Common_IsValid { get { return GetResourceString("Common_IsValid"); } }
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
//Resources:DeviceLibraryResources:Common_Note

		public static string Common_Note { get { return GetResourceString("Common_Note"); } }
//Resources:DeviceLibraryResources:Common_Notes

		public static string Common_Notes { get { return GetResourceString("Common_Notes"); } }
//Resources:DeviceLibraryResources:Common_PageNumberOne

		public static string Common_PageNumberOne { get { return GetResourceString("Common_PageNumberOne"); } }
//Resources:DeviceLibraryResources:Common_UniqueId

		public static string Common_UniqueId { get { return GetResourceString("Common_UniqueId"); } }
//Resources:DeviceLibraryResources:Common_ValidationErrors

		public static string Common_ValidationErrors { get { return GetResourceString("Common_ValidationErrors"); } }
//Resources:DeviceLibraryResources:CusotmField_HelpText_Help

		public static string CusotmField_HelpText_Help { get { return GetResourceString("CusotmField_HelpText_Help"); } }
//Resources:DeviceLibraryResources:CustomField_Description

		public static string CustomField_Description { get { return GetResourceString("CustomField_Description"); } }
//Resources:DeviceLibraryResources:CustomField_FieldType

		public static string CustomField_FieldType { get { return GetResourceString("CustomField_FieldType"); } }
//Resources:DeviceLibraryResources:CustomField_FieldType_Bool

		public static string CustomField_FieldType_Bool { get { return GetResourceString("CustomField_FieldType_Bool"); } }
//Resources:DeviceLibraryResources:CustomField_FieldType_Date

		public static string CustomField_FieldType_Date { get { return GetResourceString("CustomField_FieldType_Date"); } }
//Resources:DeviceLibraryResources:CustomField_FIeldType_DateTime

		public static string CustomField_FIeldType_DateTime { get { return GetResourceString("CustomField_FIeldType_DateTime"); } }
//Resources:DeviceLibraryResources:CustomField_FieldType_Decimal

		public static string CustomField_FieldType_Decimal { get { return GetResourceString("CustomField_FieldType_Decimal"); } }
//Resources:DeviceLibraryResources:CustomField_FieldType_Email

		public static string CustomField_FieldType_Email { get { return GetResourceString("CustomField_FieldType_Email"); } }
//Resources:DeviceLibraryResources:CustomField_FieldType_Integer

		public static string CustomField_FieldType_Integer { get { return GetResourceString("CustomField_FieldType_Integer"); } }
//Resources:DeviceLibraryResources:CustomField_FieldType_IPAddress

		public static string CustomField_FieldType_IPAddress { get { return GetResourceString("CustomField_FieldType_IPAddress"); } }
//Resources:DeviceLibraryResources:CustomField_FieldType_Key

		public static string CustomField_FieldType_Key { get { return GetResourceString("CustomField_FieldType_Key"); } }
//Resources:DeviceLibraryResources:CustomField_FieldType_Password

		public static string CustomField_FieldType_Password { get { return GetResourceString("CustomField_FieldType_Password"); } }
//Resources:DeviceLibraryResources:CustomField_FieldType_String

		public static string CustomField_FieldType_String { get { return GetResourceString("CustomField_FieldType_String"); } }
//Resources:DeviceLibraryResources:CustomField_FieldType_Time

		public static string CustomField_FieldType_Time { get { return GetResourceString("CustomField_FieldType_Time"); } }
//Resources:DeviceLibraryResources:CustomField_FieldType_WebSite

		public static string CustomField_FieldType_WebSite { get { return GetResourceString("CustomField_FieldType_WebSite"); } }
//Resources:DeviceLibraryResources:CustomFIeld_Help

		public static string CustomFIeld_Help { get { return GetResourceString("CustomFIeld_Help"); } }
//Resources:DeviceLibraryResources:CustomField_HelpText

		public static string CustomField_HelpText { get { return GetResourceString("CustomField_HelpText"); } }
//Resources:DeviceLibraryResources:CustomField_IsReadOnly

		public static string CustomField_IsReadOnly { get { return GetResourceString("CustomField_IsReadOnly"); } }
//Resources:DeviceLibraryResources:CustomField_IsReadOnly_Help

		public static string CustomField_IsReadOnly_Help { get { return GetResourceString("CustomField_IsReadOnly_Help"); } }
//Resources:DeviceLibraryResources:CustomField_IsRequired

		public static string CustomField_IsRequired { get { return GetResourceString("CustomField_IsRequired"); } }
//Resources:DeviceLibraryResources:CustomField_Label

		public static string CustomField_Label { get { return GetResourceString("CustomField_Label"); } }
//Resources:DeviceLibraryResources:CustomField_RegEx

		public static string CustomField_RegEx { get { return GetResourceString("CustomField_RegEx"); } }
//Resources:DeviceLibraryResources:CustomField_RegEx_Help

		public static string CustomField_RegEx_Help { get { return GetResourceString("CustomField_RegEx_Help"); } }
//Resources:DeviceLibraryResources:CustomField_Title

		public static string CustomField_Title { get { return GetResourceString("CustomField_Title"); } }
//Resources:DeviceLibraryResources:CustomFieldCollection_Description

		public static string CustomFieldCollection_Description { get { return GetResourceString("CustomFieldCollection_Description"); } }
//Resources:DeviceLibraryResources:CustomFieldCollection_Help

		public static string CustomFieldCollection_Help { get { return GetResourceString("CustomFieldCollection_Help"); } }
//Resources:DeviceLibraryResources:CustomFieldCollection_Title

		public static string CustomFieldCollection_Title { get { return GetResourceString("CustomFieldCollection_Title"); } }
//Resources:DeviceLibraryResources:CustomFields_DefaultValue

		public static string CustomFields_DefaultValue { get { return GetResourceString("CustomFields_DefaultValue"); } }
//Resources:DeviceLibraryResources:CustomFields_DefaultValue_Help

		public static string CustomFields_DefaultValue_Help { get { return GetResourceString("CustomFields_DefaultValue_Help"); } }
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
//Resources:DeviceLibraryResources:Device_Online

		public static string Device_Online { get { return GetResourceString("Device_Online"); } }
//Resources:DeviceLibraryResources:Device_SerialNumber

		public static string Device_SerialNumber { get { return GetResourceString("Device_SerialNumber"); } }
//Resources:DeviceLibraryResources:Device_Status

		public static string Device_Status { get { return GetResourceString("Device_Status"); } }
//Resources:DeviceLibraryResources:DeviceConfiguration_Description

		public static string DeviceConfiguration_Description { get { return GetResourceString("DeviceConfiguration_Description"); } }
//Resources:DeviceLibraryResources:DeviceConfiguration_Help

		public static string DeviceConfiguration_Help { get { return GetResourceString("DeviceConfiguration_Help"); } }
//Resources:DeviceLibraryResources:DeviceConfiguration_Title

		public static string DeviceConfiguration_Title { get { return GetResourceString("DeviceConfiguration_Title"); } }
//Resources:DeviceLibraryResources:DeviceConfiguration_Version

		public static string DeviceConfiguration_Version { get { return GetResourceString("DeviceConfiguration_Version"); } }
//Resources:DeviceLibraryResources:DeviceType_DefaultConfiguration

		public static string DeviceType_DefaultConfiguration { get { return GetResourceString("DeviceType_DefaultConfiguration"); } }
//Resources:DeviceLibraryResources:DeviceType_DefaultConfiguration_Help

		public static string DeviceType_DefaultConfiguration_Help { get { return GetResourceString("DeviceType_DefaultConfiguration_Help"); } }
//Resources:DeviceLibraryResources:DeviceType_DefaultConfiguration_Select

		public static string DeviceType_DefaultConfiguration_Select { get { return GetResourceString("DeviceType_DefaultConfiguration_Select"); } }
//Resources:DeviceLibraryResources:DeviceType_Description

		public static string DeviceType_Description { get { return GetResourceString("DeviceType_Description"); } }
//Resources:DeviceLibraryResources:DeviceType_Help

		public static string DeviceType_Help { get { return GetResourceString("DeviceType_Help"); } }
//Resources:DeviceLibraryResources:DeviceType_Manufacturer

		public static string DeviceType_Manufacturer { get { return GetResourceString("DeviceType_Manufacturer"); } }
//Resources:DeviceLibraryResources:DeviceType_ModelNumber

		public static string DeviceType_ModelNumber { get { return GetResourceString("DeviceType_ModelNumber"); } }
//Resources:DeviceLibraryResources:DeviceType_Title

		public static string DeviceType_Title { get { return GetResourceString("DeviceType_Title"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_Attributes

		public static string DeviceWorkflow_Attributes { get { return GetResourceString("DeviceWorkflow_Attributes"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_Attributes_Help

		public static string DeviceWorkflow_Attributes_Help { get { return GetResourceString("DeviceWorkflow_Attributes_Help"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_ConfigVersion

		public static string DeviceWorkflow_ConfigVersion { get { return GetResourceString("DeviceWorkflow_ConfigVersion"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_CustomFields

		public static string DeviceWorkflow_CustomFields { get { return GetResourceString("DeviceWorkflow_CustomFields"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_Description

		public static string DeviceWorkflow_Description { get { return GetResourceString("DeviceWorkflow_Description"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_Environment

		public static string DeviceWorkflow_Environment { get { return GetResourceString("DeviceWorkflow_Environment"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_Environment_Development

		public static string DeviceWorkflow_Environment_Development { get { return GetResourceString("DeviceWorkflow_Environment_Development"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_Environment_Development_Help

		public static string DeviceWorkflow_Environment_Development_Help { get { return GetResourceString("DeviceWorkflow_Environment_Development_Help"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_Environment_Production

		public static string DeviceWorkflow_Environment_Production { get { return GetResourceString("DeviceWorkflow_Environment_Production"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_Environment_Production_Help

		public static string DeviceWorkflow_Environment_Production_Help { get { return GetResourceString("DeviceWorkflow_Environment_Production_Help"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_Environment_Staging

		public static string DeviceWorkflow_Environment_Staging { get { return GetResourceString("DeviceWorkflow_Environment_Staging"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_Environment_Staging_Help

		public static string DeviceWorkflow_Environment_Staging_Help { get { return GetResourceString("DeviceWorkflow_Environment_Staging_Help"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_Help

		public static string DeviceWorkflow_Help { get { return GetResourceString("DeviceWorkflow_Help"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_InputCommands

		public static string DeviceWorkflow_InputCommands { get { return GetResourceString("DeviceWorkflow_InputCommands"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_InputCommands_Help

		public static string DeviceWorkflow_InputCommands_Help { get { return GetResourceString("DeviceWorkflow_InputCommands_Help"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_Inputs

		public static string DeviceWorkflow_Inputs { get { return GetResourceString("DeviceWorkflow_Inputs"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_OutputCommands

		public static string DeviceWorkflow_OutputCommands { get { return GetResourceString("DeviceWorkflow_OutputCommands"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_Pages

		public static string DeviceWorkflow_Pages { get { return GetResourceString("DeviceWorkflow_Pages"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_Pages_Help

		public static string DeviceWorkflow_Pages_Help { get { return GetResourceString("DeviceWorkflow_Pages_Help"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_Timer

		public static string DeviceWorkflow_Timer { get { return GetResourceString("DeviceWorkflow_Timer"); } }
//Resources:DeviceLibraryResources:DeviceWorkflow_Title

		public static string DeviceWorkflow_Title { get { return GetResourceString("DeviceWorkflow_Title"); } }
//Resources:DeviceLibraryResources:Environment


		///<summary>
		///You can configure different environments so you can test your configurations prior to putting them into production
		///</summary>
		public static string Environment { get { return GetResourceString("Environment"); } }
//Resources:DeviceLibraryResources:Environment_Dev

		public static string Environment_Dev { get { return GetResourceString("Environment_Dev"); } }
//Resources:DeviceLibraryResources:Environment_Help

		public static string Environment_Help { get { return GetResourceString("Environment_Help"); } }
//Resources:DeviceLibraryResources:Environment_Production

		public static string Environment_Production { get { return GetResourceString("Environment_Production"); } }
//Resources:DeviceLibraryResources:Environment_Test

		public static string Environment_Test { get { return GetResourceString("Environment_Test"); } }
//Resources:DeviceLibraryResources:Environments


		///<summary>
		///You can configure different environments so you can test your configurations prior to putting them into production
		///</summary>
		public static string Environments { get { return GetResourceString("Environments"); } }
//Resources:DeviceLibraryResources:EventSet_Description

		public static string EventSet_Description { get { return GetResourceString("EventSet_Description"); } }
//Resources:DeviceLibraryResources:EventSet_Events

		public static string EventSet_Events { get { return GetResourceString("EventSet_Events"); } }
//Resources:DeviceLibraryResources:EventSet_Help

		public static string EventSet_Help { get { return GetResourceString("EventSet_Help"); } }
//Resources:DeviceLibraryResources:EventSet_IsLocked

		public static string EventSet_IsLocked { get { return GetResourceString("EventSet_IsLocked"); } }
//Resources:DeviceLibraryResources:EventSet_IsLocked_Help

		public static string EventSet_IsLocked_Help { get { return GetResourceString("EventSet_IsLocked_Help"); } }
//Resources:DeviceLibraryResources:EventSet_Title

		public static string EventSet_Title { get { return GetResourceString("EventSet_Title"); } }
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
//Resources:DeviceLibraryResources:InputCommand_Description

		public static string InputCommand_Description { get { return GetResourceString("InputCommand_Description"); } }
//Resources:DeviceLibraryResources:InputCommand_EndpointPayload

		public static string InputCommand_EndpointPayload { get { return GetResourceString("InputCommand_EndpointPayload"); } }
//Resources:DeviceLibraryResources:InputCommand_EndpointPayload_Form

		public static string InputCommand_EndpointPayload_Form { get { return GetResourceString("InputCommand_EndpointPayload_Form"); } }
//Resources:DeviceLibraryResources:InputCommand_EndpointPayload_Help

		public static string InputCommand_EndpointPayload_Help { get { return GetResourceString("InputCommand_EndpointPayload_Help"); } }
//Resources:DeviceLibraryResources:InputCommand_EndpointPayload_JSON

		public static string InputCommand_EndpointPayload_JSON { get { return GetResourceString("InputCommand_EndpointPayload_JSON"); } }
//Resources:DeviceLibraryResources:InputCommand_EndpointPayload_None

		public static string InputCommand_EndpointPayload_None { get { return GetResourceString("InputCommand_EndpointPayload_None"); } }
//Resources:DeviceLibraryResources:InputCommand_EndpointPayload_QueryString

		public static string InputCommand_EndpointPayload_QueryString { get { return GetResourceString("InputCommand_EndpointPayload_QueryString"); } }
//Resources:DeviceLibraryResources:InputCommand_EndpointPayload_Watermark

		public static string InputCommand_EndpointPayload_Watermark { get { return GetResourceString("InputCommand_EndpointPayload_Watermark"); } }
//Resources:DeviceLibraryResources:InputCommand_EndpointPayload_XML

		public static string InputCommand_EndpointPayload_XML { get { return GetResourceString("InputCommand_EndpointPayload_XML"); } }
//Resources:DeviceLibraryResources:InputCommand_EndpointType

		public static string InputCommand_EndpointType { get { return GetResourceString("InputCommand_EndpointType"); } }
//Resources:DeviceLibraryResources:InputCommand_EndpointType_Help

		public static string InputCommand_EndpointType_Help { get { return GetResourceString("InputCommand_EndpointType_Help"); } }
//Resources:DeviceLibraryResources:InputCommand_EndpointType_Internal

		public static string InputCommand_EndpointType_Internal { get { return GetResourceString("InputCommand_EndpointType_Internal"); } }
//Resources:DeviceLibraryResources:InputCommand_EndpointType_Internal_Help

		public static string InputCommand_EndpointType_Internal_Help { get { return GetResourceString("InputCommand_EndpointType_Internal_Help"); } }
//Resources:DeviceLibraryResources:InputCommand_EndpointType_REST_Delete

		public static string InputCommand_EndpointType_REST_Delete { get { return GetResourceString("InputCommand_EndpointType_REST_Delete"); } }
//Resources:DeviceLibraryResources:InputCommand_EndpointType_REST_Get

		public static string InputCommand_EndpointType_REST_Get { get { return GetResourceString("InputCommand_EndpointType_REST_Get"); } }
//Resources:DeviceLibraryResources:InputCommand_EndpointType_REST_Post

		public static string InputCommand_EndpointType_REST_Post { get { return GetResourceString("InputCommand_EndpointType_REST_Post"); } }
//Resources:DeviceLibraryResources:InputCommand_EndpointType_REST_Put

		public static string InputCommand_EndpointType_REST_Put { get { return GetResourceString("InputCommand_EndpointType_REST_Put"); } }
//Resources:DeviceLibraryResources:InputCommand_EndpointType_Watermark

		public static string InputCommand_EndpointType_Watermark { get { return GetResourceString("InputCommand_EndpointType_Watermark"); } }
//Resources:DeviceLibraryResources:InputCommand_Help

		public static string InputCommand_Help { get { return GetResourceString("InputCommand_Help"); } }
//Resources:DeviceLibraryResources:InputCommand_Parameters

		public static string InputCommand_Parameters { get { return GetResourceString("InputCommand_Parameters"); } }
//Resources:DeviceLibraryResources:InputCommand_Script

		public static string InputCommand_Script { get { return GetResourceString("InputCommand_Script"); } }
//Resources:DeviceLibraryResources:InputCommand_Script_Help

		public static string InputCommand_Script_Help { get { return GetResourceString("InputCommand_Script_Help"); } }
//Resources:DeviceLibraryResources:InputCommand_Title

		public static string InputCommand_Title { get { return GetResourceString("InputCommand_Title"); } }
//Resources:DeviceLibraryResources:InputCommandParamter_Description

		public static string InputCommandParamter_Description { get { return GetResourceString("InputCommandParamter_Description"); } }
//Resources:DeviceLibraryResources:NodeRedFlow_Description

		public static string NodeRedFlow_Description { get { return GetResourceString("NodeRedFlow_Description"); } }
//Resources:DeviceLibraryResources:NodeRedFlow_Help

		public static string NodeRedFlow_Help { get { return GetResourceString("NodeRedFlow_Help"); } }
//Resources:DeviceLibraryResources:NodeRedFlow_Title

		public static string NodeRedFlow_Title { get { return GetResourceString("NodeRedFlow_Title"); } }
//Resources:DeviceLibraryResources:OutputCommand_Description

		public static string OutputCommand_Description { get { return GetResourceString("OutputCommand_Description"); } }
//Resources:DeviceLibraryResources:OutputCommand_Help

		public static string OutputCommand_Help { get { return GetResourceString("OutputCommand_Help"); } }
//Resources:DeviceLibraryResources:OutputCommand_Script

		public static string OutputCommand_Script { get { return GetResourceString("OutputCommand_Script"); } }
//Resources:DeviceLibraryResources:OutputCommand_Script_Help

		public static string OutputCommand_Script_Help { get { return GetResourceString("OutputCommand_Script_Help"); } }
//Resources:DeviceLibraryResources:OutputCommand_Title

		public static string OutputCommand_Title { get { return GetResourceString("OutputCommand_Title"); } }
//Resources:DeviceLibraryResources:Page_Description

		public static string Page_Description { get { return GetResourceString("Page_Description"); } }
//Resources:DeviceLibraryResources:Page_Help

		public static string Page_Help { get { return GetResourceString("Page_Help"); } }
//Resources:DeviceLibraryResources:Page_Name

		public static string Page_Name { get { return GetResourceString("Page_Name"); } }
//Resources:DeviceLibraryResources:Page_PageNumber

		public static string Page_PageNumber { get { return GetResourceString("Page_PageNumber"); } }
//Resources:DeviceLibraryResources:Page_Title

		public static string Page_Title { get { return GetResourceString("Page_Title"); } }
//Resources:DeviceLibraryResources:Parameter_Help

		public static string Parameter_Help { get { return GetResourceString("Parameter_Help"); } }
//Resources:DeviceLibraryResources:Parameter_Title

		public static string Parameter_Title { get { return GetResourceString("Parameter_Title"); } }
//Resources:DeviceLibraryResources:Parameter_Type

		public static string Parameter_Type { get { return GetResourceString("Parameter_Type"); } }
//Resources:DeviceLibraryResources:Parameter_Type_Watermark

		public static string Parameter_Type_Watermark { get { return GetResourceString("Parameter_Type_Watermark"); } }
//Resources:DeviceLibraryResources:Parameter_Types

		public static string Parameter_Types { get { return GetResourceString("Parameter_Types"); } }
//Resources:DeviceLibraryResources:Parameter_Types_DateTime

		public static string Parameter_Types_DateTime { get { return GetResourceString("Parameter_Types_DateTime"); } }
//Resources:DeviceLibraryResources:Parameter_Types_Decimal

		public static string Parameter_Types_Decimal { get { return GetResourceString("Parameter_Types_Decimal"); } }
//Resources:DeviceLibraryResources:Parameter_Types_GeoLocation

		public static string Parameter_Types_GeoLocation { get { return GetResourceString("Parameter_Types_GeoLocation"); } }
//Resources:DeviceLibraryResources:Parameter_Types_Integer

		public static string Parameter_Types_Integer { get { return GetResourceString("Parameter_Types_Integer"); } }
//Resources:DeviceLibraryResources:Parameter_Types_States

		public static string Parameter_Types_States { get { return GetResourceString("Parameter_Types_States"); } }
//Resources:DeviceLibraryResources:Parameter_Types_String

		public static string Parameter_Types_String { get { return GetResourceString("Parameter_Types_String"); } }
//Resources:DeviceLibraryResources:Parameter_Types_TrueFalse

		public static string Parameter_Types_TrueFalse { get { return GetResourceString("Parameter_Types_TrueFalse"); } }
//Resources:DeviceLibraryResources:Parameter_Types_ValueWithUnit

		public static string Parameter_Types_ValueWithUnit { get { return GetResourceString("Parameter_Types_ValueWithUnit"); } }
//Resources:DeviceLibraryResources:Parameters

		public static string Parameters { get { return GetResourceString("Parameters"); } }
//Resources:DeviceLibraryResources:State_Description

		public static string State_Description { get { return GetResourceString("State_Description"); } }
//Resources:DeviceLibraryResources:State_Title

		public static string State_Title { get { return GetResourceString("State_Title"); } }
//Resources:DeviceLibraryResources:State_UserHelp

		public static string State_UserHelp { get { return GetResourceString("State_UserHelp"); } }
//Resources:DeviceLibraryResources:StateMachine

		public static string StateMachine { get { return GetResourceString("StateMachine"); } }
//Resources:DeviceLibraryResources:StateMachine_Description

		public static string StateMachine_Description { get { return GetResourceString("StateMachine_Description"); } }
//Resources:DeviceLibraryResources:StateMachine_Event

		public static string StateMachine_Event { get { return GetResourceString("StateMachine_Event"); } }
//Resources:DeviceLibraryResources:StateMachine_Events

		public static string StateMachine_Events { get { return GetResourceString("StateMachine_Events"); } }
//Resources:DeviceLibraryResources:StateMachine_Events_Help

		public static string StateMachine_Events_Help { get { return GetResourceString("StateMachine_Events_Help"); } }
//Resources:DeviceLibraryResources:StateMachine_Exception_OnInvalidEvent

		public static string StateMachine_Exception_OnInvalidEvent { get { return GetResourceString("StateMachine_Exception_OnInvalidEvent"); } }
//Resources:DeviceLibraryResources:StateMachine_Exception_OnInvalidEvent_Help

		public static string StateMachine_Exception_OnInvalidEvent_Help { get { return GetResourceString("StateMachine_Exception_OnInvalidEvent_Help"); } }
//Resources:DeviceLibraryResources:StateMachine_Initialization_Actions

		public static string StateMachine_Initialization_Actions { get { return GetResourceString("StateMachine_Initialization_Actions"); } }
//Resources:DeviceLibraryResources:StateMachine_Initialization_Actions_Help

		public static string StateMachine_Initialization_Actions_Help { get { return GetResourceString("StateMachine_Initialization_Actions_Help"); } }
//Resources:DeviceLibraryResources:StateMachine_InitialState

		public static string StateMachine_InitialState { get { return GetResourceString("StateMachine_InitialState"); } }
//Resources:DeviceLibraryResources:StateMachine_InitialState_Help

		public static string StateMachine_InitialState_Help { get { return GetResourceString("StateMachine_InitialState_Help"); } }
//Resources:DeviceLibraryResources:StateMachine_NewState

		public static string StateMachine_NewState { get { return GetResourceString("StateMachine_NewState"); } }
//Resources:DeviceLibraryResources:StateMachine_NewState_Help

		public static string StateMachine_NewState_Help { get { return GetResourceString("StateMachine_NewState_Help"); } }
//Resources:DeviceLibraryResources:StateMachine_Pages

		public static string StateMachine_Pages { get { return GetResourceString("StateMachine_Pages"); } }
//Resources:DeviceLibraryResources:StateMachine_Pages_Help

		public static string StateMachine_Pages_Help { get { return GetResourceString("StateMachine_Pages_Help"); } }
//Resources:DeviceLibraryResources:StateMachine_State

		public static string StateMachine_State { get { return GetResourceString("StateMachine_State"); } }
//Resources:DeviceLibraryResources:StateMachine_State_Action

		public static string StateMachine_State_Action { get { return GetResourceString("StateMachine_State_Action"); } }
//Resources:DeviceLibraryResources:StateMachine_State_DiagramX

		public static string StateMachine_State_DiagramX { get { return GetResourceString("StateMachine_State_DiagramX"); } }
//Resources:DeviceLibraryResources:StateMachine_State_DiagramY

		public static string StateMachine_State_DiagramY { get { return GetResourceString("StateMachine_State_DiagramY"); } }
//Resources:DeviceLibraryResources:StateMachine_State_IsInitialState

		public static string StateMachine_State_IsInitialState { get { return GetResourceString("StateMachine_State_IsInitialState"); } }
//Resources:DeviceLibraryResources:StateMachine_State_IsInitialState_Help

		public static string StateMachine_State_IsInitialState_Help { get { return GetResourceString("StateMachine_State_IsInitialState_Help"); } }
//Resources:DeviceLibraryResources:StateMachine_State_TransitionInAction

		public static string StateMachine_State_TransitionInAction { get { return GetResourceString("StateMachine_State_TransitionInAction"); } }
//Resources:DeviceLibraryResources:StateMachine_State_TransitionInAction_Help

		public static string StateMachine_State_TransitionInAction_Help { get { return GetResourceString("StateMachine_State_TransitionInAction_Help"); } }
//Resources:DeviceLibraryResources:StateMachine_State_Transitions

		public static string StateMachine_State_Transitions { get { return GetResourceString("StateMachine_State_Transitions"); } }
//Resources:DeviceLibraryResources:StateMachine_State_Transitions_Help

		public static string StateMachine_State_Transitions_Help { get { return GetResourceString("StateMachine_State_Transitions_Help"); } }
//Resources:DeviceLibraryResources:StateMachine_States

		public static string StateMachine_States { get { return GetResourceString("StateMachine_States"); } }
//Resources:DeviceLibraryResources:StateMachine_Title

		public static string StateMachine_Title { get { return GetResourceString("StateMachine_Title"); } }
//Resources:DeviceLibraryResources:StateMachine_Transition_Action

		public static string StateMachine_Transition_Action { get { return GetResourceString("StateMachine_Transition_Action"); } }
//Resources:DeviceLibraryResources:StateMachine_Transition_Action_Help

		public static string StateMachine_Transition_Action_Help { get { return GetResourceString("StateMachine_Transition_Action_Help"); } }
//Resources:DeviceLibraryResources:StateMachine_Transition_EventHelp

		public static string StateMachine_Transition_EventHelp { get { return GetResourceString("StateMachine_Transition_EventHelp"); } }
//Resources:DeviceLibraryResources:StateMachine_Transition_Script

		public static string StateMachine_Transition_Script { get { return GetResourceString("StateMachine_Transition_Script"); } }
//Resources:DeviceLibraryResources:StateMachine_Transition_State

		public static string StateMachine_Transition_State { get { return GetResourceString("StateMachine_Transition_State"); } }
//Resources:DeviceLibraryResources:StateMachine_Transitions

		public static string StateMachine_Transitions { get { return GetResourceString("StateMachine_Transitions"); } }
//Resources:DeviceLibraryResources:StateMachine_UserHelp

		public static string StateMachine_UserHelp { get { return GetResourceString("StateMachine_UserHelp"); } }
//Resources:DeviceLibraryResources:StateMachine_Variables

		public static string StateMachine_Variables { get { return GetResourceString("StateMachine_Variables"); } }
//Resources:DeviceLibraryResources:StateMachine_Variables_Help

		public static string StateMachine_Variables_Help { get { return GetResourceString("StateMachine_Variables_Help"); } }
//Resources:DeviceLibraryResources:StateMachineEvent_Description

		public static string StateMachineEvent_Description { get { return GetResourceString("StateMachineEvent_Description"); } }
//Resources:DeviceLibraryResources:StateMachineEvent_Title

		public static string StateMachineEvent_Title { get { return GetResourceString("StateMachineEvent_Title"); } }
//Resources:DeviceLibraryResources:StateMachineEvent_UserHelp

		public static string StateMachineEvent_UserHelp { get { return GetResourceString("StateMachineEvent_UserHelp"); } }
//Resources:DeviceLibraryResources:StateMachines

		public static string StateMachines { get { return GetResourceString("StateMachines"); } }
//Resources:DeviceLibraryResources:StateSet_Description

		public static string StateSet_Description { get { return GetResourceString("StateSet_Description"); } }
//Resources:DeviceLibraryResources:StateSet_Help

		public static string StateSet_Help { get { return GetResourceString("StateSet_Help"); } }
//Resources:DeviceLibraryResources:StateSet_IsLocked

		public static string StateSet_IsLocked { get { return GetResourceString("StateSet_IsLocked"); } }
//Resources:DeviceLibraryResources:StateSet_IsLocked_Help

		public static string StateSet_IsLocked_Help { get { return GetResourceString("StateSet_IsLocked_Help"); } }
//Resources:DeviceLibraryResources:StateSet_States

		public static string StateSet_States { get { return GetResourceString("StateSet_States"); } }
//Resources:DeviceLibraryResources:StateSet_Title

		public static string StateSet_Title { get { return GetResourceString("StateSet_Title"); } }
//Resources:DeviceLibraryResources:StateTransition_Description

		public static string StateTransition_Description { get { return GetResourceString("StateTransition_Description"); } }
//Resources:DeviceLibraryResources:StateTransition_Title

		public static string StateTransition_Title { get { return GetResourceString("StateTransition_Title"); } }
//Resources:DeviceLibraryResources:StateTransition_UserHelp

		public static string StateTransition_UserHelp { get { return GetResourceString("StateTransition_UserHelp"); } }
//Resources:DeviceLibraryResources:Timer_DailyEndTime

		public static string Timer_DailyEndTime { get { return GetResourceString("Timer_DailyEndTime"); } }
//Resources:DeviceLibraryResources:Timer_DailyEndTime_Help

		public static string Timer_DailyEndTime_Help { get { return GetResourceString("Timer_DailyEndTime_Help"); } }
//Resources:DeviceLibraryResources:Timer_DailyStartTime

		public static string Timer_DailyStartTime { get { return GetResourceString("Timer_DailyStartTime"); } }
//Resources:DeviceLibraryResources:Timer_DailyStartTime_Help

		public static string Timer_DailyStartTime_Help { get { return GetResourceString("Timer_DailyStartTime_Help"); } }
//Resources:DeviceLibraryResources:Timer_Days

		public static string Timer_Days { get { return GetResourceString("Timer_Days"); } }
//Resources:DeviceLibraryResources:Timer_Description

		public static string Timer_Description { get { return GetResourceString("Timer_Description"); } }
//Resources:DeviceLibraryResources:Timer_Friday

		public static string Timer_Friday { get { return GetResourceString("Timer_Friday"); } }
//Resources:DeviceLibraryResources:Timer_Help

		public static string Timer_Help { get { return GetResourceString("Timer_Help"); } }
//Resources:DeviceLibraryResources:Timer_HourOfDay

		public static string Timer_HourOfDay { get { return GetResourceString("Timer_HourOfDay"); } }
//Resources:DeviceLibraryResources:Timer_Hours

		public static string Timer_Hours { get { return GetResourceString("Timer_Hours"); } }
//Resources:DeviceLibraryResources:Timer_MinuteOfDay

		public static string Timer_MinuteOfDay { get { return GetResourceString("Timer_MinuteOfDay"); } }
//Resources:DeviceLibraryResources:Timer_Minutes

		public static string Timer_Minutes { get { return GetResourceString("Timer_Minutes"); } }
//Resources:DeviceLibraryResources:Timer_Monday

		public static string Timer_Monday { get { return GetResourceString("Timer_Monday"); } }
//Resources:DeviceLibraryResources:Timer_Saturday

		public static string Timer_Saturday { get { return GetResourceString("Timer_Saturday"); } }
//Resources:DeviceLibraryResources:Timer_Script

		public static string Timer_Script { get { return GetResourceString("Timer_Script"); } }
//Resources:DeviceLibraryResources:Timer_Seconds

		public static string Timer_Seconds { get { return GetResourceString("Timer_Seconds"); } }
//Resources:DeviceLibraryResources:Timer_Sunday

		public static string Timer_Sunday { get { return GetResourceString("Timer_Sunday"); } }
//Resources:DeviceLibraryResources:Timer_Thursday

		public static string Timer_Thursday { get { return GetResourceString("Timer_Thursday"); } }
//Resources:DeviceLibraryResources:Timer_Title

		public static string Timer_Title { get { return GetResourceString("Timer_Title"); } }
//Resources:DeviceLibraryResources:Timer_Tuesday

		public static string Timer_Tuesday { get { return GetResourceString("Timer_Tuesday"); } }
//Resources:DeviceLibraryResources:Timer_Wednesday

		public static string Timer_Wednesday { get { return GetResourceString("Timer_Wednesday"); } }
//Resources:DeviceLibraryResources:Unit_Abbreviation

		public static string Unit_Abbreviation { get { return GetResourceString("Unit_Abbreviation"); } }
//Resources:DeviceLibraryResources:Unit_Conversion_EditScriptWatermark

		public static string Unit_Conversion_EditScriptWatermark { get { return GetResourceString("Unit_Conversion_EditScriptWatermark"); } }
//Resources:DeviceLibraryResources:Unit_Conversion_Factor

		public static string Unit_Conversion_Factor { get { return GetResourceString("Unit_Conversion_Factor"); } }
//Resources:DeviceLibraryResources:Unit_Conversion_Factor_Help

		public static string Unit_Conversion_Factor_Help { get { return GetResourceString("Unit_Conversion_Factor_Help"); } }
//Resources:DeviceLibraryResources:Unit_Conversion_Type

		public static string Unit_Conversion_Type { get { return GetResourceString("Unit_Conversion_Type"); } }
//Resources:DeviceLibraryResources:Unit_Conversion_Type_Factor

		public static string Unit_Conversion_Type_Factor { get { return GetResourceString("Unit_Conversion_Type_Factor"); } }
//Resources:DeviceLibraryResources:Unit_Conversion_Type_Factor_Help

		public static string Unit_Conversion_Type_Factor_Help { get { return GetResourceString("Unit_Conversion_Type_Factor_Help"); } }
//Resources:DeviceLibraryResources:Unit_Conversion_Type_Help

		public static string Unit_Conversion_Type_Help { get { return GetResourceString("Unit_Conversion_Type_Help"); } }
//Resources:DeviceLibraryResources:Unit_Conversion_Type_Script

		public static string Unit_Conversion_Type_Script { get { return GetResourceString("Unit_Conversion_Type_Script"); } }
//Resources:DeviceLibraryResources:Unit_Conversion_Type_Script_Help

		public static string Unit_Conversion_Type_Script_Help { get { return GetResourceString("Unit_Conversion_Type_Script_Help"); } }
//Resources:DeviceLibraryResources:Unit_ConversionScript

		public static string Unit_ConversionScript { get { return GetResourceString("Unit_ConversionScript"); } }
//Resources:DeviceLibraryResources:Unit_ConversionScript_Help

		public static string Unit_ConversionScript_Help { get { return GetResourceString("Unit_ConversionScript_Help"); } }
//Resources:DeviceLibraryResources:Unit_Definitions

		public static string Unit_Definitions { get { return GetResourceString("Unit_Definitions"); } }
//Resources:DeviceLibraryResources:Unit_Description

		public static string Unit_Description { get { return GetResourceString("Unit_Description"); } }
//Resources:DeviceLibraryResources:Unit_DisplayFormat

		public static string Unit_DisplayFormat { get { return GetResourceString("Unit_DisplayFormat"); } }
//Resources:DeviceLibraryResources:Unit_DisplayFormat_Help

		public static string Unit_DisplayFormat_Help { get { return GetResourceString("Unit_DisplayFormat_Help"); } }
//Resources:DeviceLibraryResources:Unit_Help

		public static string Unit_Help { get { return GetResourceString("Unit_Help"); } }
//Resources:DeviceLibraryResources:Unit_IsDefault

		public static string Unit_IsDefault { get { return GetResourceString("Unit_IsDefault"); } }
//Resources:DeviceLibraryResources:Unit_IsDefault_Help

		public static string Unit_IsDefault_Help { get { return GetResourceString("Unit_IsDefault_Help"); } }
//Resources:DeviceLibraryResources:Unit_NumberDecimal

		public static string Unit_NumberDecimal { get { return GetResourceString("Unit_NumberDecimal"); } }
//Resources:DeviceLibraryResources:Unit_Title

		public static string Unit_Title { get { return GetResourceString("Unit_Title"); } }
//Resources:DeviceLibraryResources:UnitSet_DefaultUnit

		public static string UnitSet_DefaultUnit { get { return GetResourceString("UnitSet_DefaultUnit"); } }
//Resources:DeviceLibraryResources:UnitSet_Description

		public static string UnitSet_Description { get { return GetResourceString("UnitSet_Description"); } }
//Resources:DeviceLibraryResources:UnitSet_Help

		public static string UnitSet_Help { get { return GetResourceString("UnitSet_Help"); } }
//Resources:DeviceLibraryResources:UnitSet_IsLocked

		public static string UnitSet_IsLocked { get { return GetResourceString("UnitSet_IsLocked"); } }
//Resources:DeviceLibraryResources:UnitSet_IsLocked_Help

		public static string UnitSet_IsLocked_Help { get { return GetResourceString("UnitSet_IsLocked_Help"); } }
//Resources:DeviceLibraryResources:UnitSet_Title

		public static string UnitSet_Title { get { return GetResourceString("UnitSet_Title"); } }
//Resources:DeviceLibraryResources:UnitSet_Units

		public static string UnitSet_Units { get { return GetResourceString("UnitSet_Units"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Description

		public static string WorkflowInput_Description { get { return GetResourceString("WorkflowInput_Description"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Help

		public static string WorkflowInput_Help { get { return GetResourceString("WorkflowInput_Help"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Script_Watermark

		public static string WorkflowInput_Script_Watermark { get { return GetResourceString("WorkflowInput_Script_Watermark"); } }
//Resources:DeviceLibraryResources:WorkflowInput_SetScript

		public static string WorkflowInput_SetScript { get { return GetResourceString("WorkflowInput_SetScript"); } }
//Resources:DeviceLibraryResources:WorkflowInput_SetScript_Help

		public static string WorkflowInput_SetScript_Help { get { return GetResourceString("WorkflowInput_SetScript_Help"); } }
//Resources:DeviceLibraryResources:WorkflowInput_States

		public static string WorkflowInput_States { get { return GetResourceString("WorkflowInput_States"); } }
//Resources:DeviceLibraryResources:WorkflowInput_States_Help

		public static string WorkflowInput_States_Help { get { return GetResourceString("WorkflowInput_States_Help"); } }
//Resources:DeviceLibraryResources:WorkflowInput_StateSet_Watermark

		public static string WorkflowInput_StateSet_Watermark { get { return GetResourceString("WorkflowInput_StateSet_Watermark"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Title

		public static string WorkflowInput_Title { get { return GetResourceString("WorkflowInput_Title"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Type

		public static string WorkflowInput_Type { get { return GetResourceString("WorkflowInput_Type"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Type_Boolean

		public static string WorkflowInput_Type_Boolean { get { return GetResourceString("WorkflowInput_Type_Boolean"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Type_Boolean_Help

		public static string WorkflowInput_Type_Boolean_Help { get { return GetResourceString("WorkflowInput_Type_Boolean_Help"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Type_Description

		public static string WorkflowInput_Type_Description { get { return GetResourceString("WorkflowInput_Type_Description"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Type_Discrete

		public static string WorkflowInput_Type_Discrete { get { return GetResourceString("WorkflowInput_Type_Discrete"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Type_Discrete_Help

		public static string WorkflowInput_Type_Discrete_Help { get { return GetResourceString("WorkflowInput_Type_Discrete_Help"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Type_Discrete_Units

		public static string WorkflowInput_Type_Discrete_Units { get { return GetResourceString("WorkflowInput_Type_Discrete_Units"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Type_Discrete_Units_Help

		public static string WorkflowInput_Type_Discrete_Units_Help { get { return GetResourceString("WorkflowInput_Type_Discrete_Units_Help"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Type_GeoLocation

		public static string WorkflowInput_Type_GeoLocation { get { return GetResourceString("WorkflowInput_Type_GeoLocation"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Type_GeoLocation_Help

		public static string WorkflowInput_Type_GeoLocation_Help { get { return GetResourceString("WorkflowInput_Type_GeoLocation_Help"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Type_Help

		public static string WorkflowInput_Type_Help { get { return GetResourceString("WorkflowInput_Type_Help"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Type_State

		public static string WorkflowInput_Type_State { get { return GetResourceString("WorkflowInput_Type_State"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Type_State_Help

		public static string WorkflowInput_Type_State_Help { get { return GetResourceString("WorkflowInput_Type_State_Help"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Type_Text

		public static string WorkflowInput_Type_Text { get { return GetResourceString("WorkflowInput_Type_Text"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Type_Text_Help

		public static string WorkflowInput_Type_Text_Help { get { return GetResourceString("WorkflowInput_Type_Text_Help"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Type_Watermark

		public static string WorkflowInput_Type_Watermark { get { return GetResourceString("WorkflowInput_Type_Watermark"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Units

		public static string WorkflowInput_Units { get { return GetResourceString("WorkflowInput_Units"); } }
//Resources:DeviceLibraryResources:WorkflowInput_Units_Help

		public static string WorkflowInput_Units_Help { get { return GetResourceString("WorkflowInput_Units_Help"); } }
//Resources:DeviceLibraryResources:WorkflowInput_UnitSet_Watermark

		public static string WorkflowInput_UnitSet_Watermark { get { return GetResourceString("WorkflowInput_UnitSet_Watermark"); } }

		public static class Names
		{
			public const string Action_AssociatedAttribute = "Action_AssociatedAttribute";
			public const string Action_AssociatedAttribute_Help = "Action_AssociatedAttribute_Help";
			public const string Action_Description = "Action_Description";
			public const string Action_ExecuteFromGet = "Action_ExecuteFromGet";
			public const string Action_ExecuteFromGet_Help = "Action_ExecuteFromGet_Help";
			public const string Action_ExecuteFromPost = "Action_ExecuteFromPost";
			public const string Action_ExecuteFromPost_Help = "Action_ExecuteFromPost_Help";
			public const string Action_ExecuteFromScript = "Action_ExecuteFromScript";
			public const string Action_ExecuteFromScript_Help = "Action_ExecuteFromScript_Help";
			public const string Action_ExecuteFromStateMachine = "Action_ExecuteFromStateMachine";
			public const string Action_ExecuteFromstateMachine_Help = "Action_ExecuteFromstateMachine_Help";
			public const string Action_Help = "Action_Help";
			public const string Action_NodeRedFlows = "Action_NodeRedFlows";
			public const string Action_RemoteUri = "Action_RemoteUri";
			public const string Action_Script = "Action_Script";
			public const string Action_Shared = "Action_Shared";
			public const string Action_Standard_Help = "Action_Standard_Help";
			public const string Action_Title = "Action_Title";
			public const string ActionParameter_Description = "ActionParameter_Description";
			public const string ActionParameter_Help = "ActionParameter_Help";
			public const string ActionParameter_Title = "ActionParameter_Title";
			public const string Actoin_Parameter_Key_Help = "Actoin_Parameter_Key_Help";
			public const string AdminNote_Description = "AdminNote_Description";
			public const string AdminNote_Help = "AdminNote_Help";
			public const string AdminNote_Title = "AdminNote_Title";
			public const string Attribute_AttributeType = "Attribute_AttributeType";
			public const string Attribute_AttributeType_Help = "Attribute_AttributeType_Help";
			public const string Attribute_AttributeType_Select = "Attribute_AttributeType_Select";
			public const string Attribute_Description = "Attribute_Description";
			public const string Attribute_Direction = "Attribute_Direction";
			public const string Attribute_Direction_Help = "Attribute_Direction_Help";
			public const string Attribute_Direction_Input = "Attribute_Direction_Input";
			public const string Attribute_Direction_InputAndOutput = "Attribute_Direction_InputAndOutput";
			public const string Attribute_Direction_Output = "Attribute_Direction_Output";
			public const string Attribute_Help = "Attribute_Help";
			public const string Attribute_ReadOnly = "Attribute_ReadOnly";
			public const string Attribute_ReadOnly_Help = "Attribute_ReadOnly_Help";
			public const string Attribute_Script_Watermark = "Attribute_Script_Watermark";
			public const string Attribute_SetScript = "Attribute_SetScript";
			public const string Attribute_SetScript_Help = "Attribute_SetScript_Help";
			public const string Attribute_Shared = "Attribute_Shared";
			public const string Attribute_SharedAttribute_Help = "Attribute_SharedAttribute_Help";
			public const string Attribute_States = "Attribute_States";
			public const string Attribute_States_Help = "Attribute_States_Help";
			public const string Attribute_Title = "Attribute_Title";
			public const string Attribute_Type_Boolean = "Attribute_Type_Boolean";
			public const string Attribute_Type_Boolean_Help = "Attribute_Type_Boolean_Help";
			public const string Attribute_Type_Discrete = "Attribute_Type_Discrete";
			public const string Attribute_Type_Discrete_Help = "Attribute_Type_Discrete_Help";
			public const string Attribute_Type_Discrete_Units = "Attribute_Type_Discrete_Units";
			public const string Attribute_Type_Discrete_Units_Help = "Attribute_Type_Discrete_Units_Help";
			public const string Attribute_Type_GeoLocation = "Attribute_Type_GeoLocation";
			public const string Attribute_Type_GeoLocation_Help = "Attribute_Type_GeoLocation_Help";
			public const string Attribute_Type_State_Help = "Attribute_Type_State_Help";
			public const string Attribute_Type_States = "Attribute_Type_States";
			public const string Attribute_Type_Text = "Attribute_Type_Text";
			public const string Attribute_Type_Text_Help = "Attribute_Type_Text_Help";
			public const string Attribute_UnitSet = "Attribute_UnitSet";
			public const string Attribute_UnitSet_Help = "Attribute_UnitSet_Help";
			public const string Attribute_UnitSet_Watermark = "Attribute_UnitSet_Watermark";
			public const string Atttribute_StateSet_Watermark = "Atttribute_StateSet_Watermark";
			public const string Common_CreatedBy = "Common_CreatedBy";
			public const string Common_CreationDate = "Common_CreationDate";
			public const string Common_Description = "Common_Description";
			public const string Common_IsPublic = "Common_IsPublic";
			public const string Common_IsRequired = "Common_IsRequired";
			public const string Common_IsValid = "Common_IsValid";
			public const string Common_Key = "Common_Key";
			public const string Common_Key_Help = "Common_Key_Help";
			public const string Common_Key_Validation = "Common_Key_Validation";
			public const string Common_LastUpdated = "Common_LastUpdated";
			public const string Common_LastUpdatedBy = "Common_LastUpdatedBy";
			public const string Common_Name = "Common_Name";
			public const string Common_Note = "Common_Note";
			public const string Common_Notes = "Common_Notes";
			public const string Common_PageNumberOne = "Common_PageNumberOne";
			public const string Common_UniqueId = "Common_UniqueId";
			public const string Common_ValidationErrors = "Common_ValidationErrors";
			public const string CusotmField_HelpText_Help = "CusotmField_HelpText_Help";
			public const string CustomField_Description = "CustomField_Description";
			public const string CustomField_FieldType = "CustomField_FieldType";
			public const string CustomField_FieldType_Bool = "CustomField_FieldType_Bool";
			public const string CustomField_FieldType_Date = "CustomField_FieldType_Date";
			public const string CustomField_FIeldType_DateTime = "CustomField_FIeldType_DateTime";
			public const string CustomField_FieldType_Decimal = "CustomField_FieldType_Decimal";
			public const string CustomField_FieldType_Email = "CustomField_FieldType_Email";
			public const string CustomField_FieldType_Integer = "CustomField_FieldType_Integer";
			public const string CustomField_FieldType_IPAddress = "CustomField_FieldType_IPAddress";
			public const string CustomField_FieldType_Key = "CustomField_FieldType_Key";
			public const string CustomField_FieldType_Password = "CustomField_FieldType_Password";
			public const string CustomField_FieldType_String = "CustomField_FieldType_String";
			public const string CustomField_FieldType_Time = "CustomField_FieldType_Time";
			public const string CustomField_FieldType_WebSite = "CustomField_FieldType_WebSite";
			public const string CustomFIeld_Help = "CustomFIeld_Help";
			public const string CustomField_HelpText = "CustomField_HelpText";
			public const string CustomField_IsReadOnly = "CustomField_IsReadOnly";
			public const string CustomField_IsReadOnly_Help = "CustomField_IsReadOnly_Help";
			public const string CustomField_IsRequired = "CustomField_IsRequired";
			public const string CustomField_Label = "CustomField_Label";
			public const string CustomField_RegEx = "CustomField_RegEx";
			public const string CustomField_RegEx_Help = "CustomField_RegEx_Help";
			public const string CustomField_Title = "CustomField_Title";
			public const string CustomFieldCollection_Description = "CustomFieldCollection_Description";
			public const string CustomFieldCollection_Help = "CustomFieldCollection_Help";
			public const string CustomFieldCollection_Title = "CustomFieldCollection_Title";
			public const string CustomFields_DefaultValue = "CustomFields_DefaultValue";
			public const string CustomFields_DefaultValue_Help = "CustomFields_DefaultValue_Help";
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
			public const string Device_Online = "Device_Online";
			public const string Device_SerialNumber = "Device_SerialNumber";
			public const string Device_Status = "Device_Status";
			public const string DeviceConfiguration_Description = "DeviceConfiguration_Description";
			public const string DeviceConfiguration_Help = "DeviceConfiguration_Help";
			public const string DeviceConfiguration_Title = "DeviceConfiguration_Title";
			public const string DeviceConfiguration_Version = "DeviceConfiguration_Version";
			public const string DeviceType_DefaultConfiguration = "DeviceType_DefaultConfiguration";
			public const string DeviceType_DefaultConfiguration_Help = "DeviceType_DefaultConfiguration_Help";
			public const string DeviceType_DefaultConfiguration_Select = "DeviceType_DefaultConfiguration_Select";
			public const string DeviceType_Description = "DeviceType_Description";
			public const string DeviceType_Help = "DeviceType_Help";
			public const string DeviceType_Manufacturer = "DeviceType_Manufacturer";
			public const string DeviceType_ModelNumber = "DeviceType_ModelNumber";
			public const string DeviceType_Title = "DeviceType_Title";
			public const string DeviceWorkflow_Attributes = "DeviceWorkflow_Attributes";
			public const string DeviceWorkflow_Attributes_Help = "DeviceWorkflow_Attributes_Help";
			public const string DeviceWorkflow_ConfigVersion = "DeviceWorkflow_ConfigVersion";
			public const string DeviceWorkflow_CustomFields = "DeviceWorkflow_CustomFields";
			public const string DeviceWorkflow_Description = "DeviceWorkflow_Description";
			public const string DeviceWorkflow_Environment = "DeviceWorkflow_Environment";
			public const string DeviceWorkflow_Environment_Development = "DeviceWorkflow_Environment_Development";
			public const string DeviceWorkflow_Environment_Development_Help = "DeviceWorkflow_Environment_Development_Help";
			public const string DeviceWorkflow_Environment_Production = "DeviceWorkflow_Environment_Production";
			public const string DeviceWorkflow_Environment_Production_Help = "DeviceWorkflow_Environment_Production_Help";
			public const string DeviceWorkflow_Environment_Staging = "DeviceWorkflow_Environment_Staging";
			public const string DeviceWorkflow_Environment_Staging_Help = "DeviceWorkflow_Environment_Staging_Help";
			public const string DeviceWorkflow_Help = "DeviceWorkflow_Help";
			public const string DeviceWorkflow_InputCommands = "DeviceWorkflow_InputCommands";
			public const string DeviceWorkflow_InputCommands_Help = "DeviceWorkflow_InputCommands_Help";
			public const string DeviceWorkflow_Inputs = "DeviceWorkflow_Inputs";
			public const string DeviceWorkflow_OutputCommands = "DeviceWorkflow_OutputCommands";
			public const string DeviceWorkflow_Pages = "DeviceWorkflow_Pages";
			public const string DeviceWorkflow_Pages_Help = "DeviceWorkflow_Pages_Help";
			public const string DeviceWorkflow_Timer = "DeviceWorkflow_Timer";
			public const string DeviceWorkflow_Title = "DeviceWorkflow_Title";
			public const string Environment = "Environment";
			public const string Environment_Dev = "Environment_Dev";
			public const string Environment_Help = "Environment_Help";
			public const string Environment_Production = "Environment_Production";
			public const string Environment_Test = "Environment_Test";
			public const string Environments = "Environments";
			public const string EventSet_Description = "EventSet_Description";
			public const string EventSet_Events = "EventSet_Events";
			public const string EventSet_Help = "EventSet_Help";
			public const string EventSet_IsLocked = "EventSet_IsLocked";
			public const string EventSet_IsLocked_Help = "EventSet_IsLocked_Help";
			public const string EventSet_Title = "EventSet_Title";
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
			public const string InputCommand_Description = "InputCommand_Description";
			public const string InputCommand_EndpointPayload = "InputCommand_EndpointPayload";
			public const string InputCommand_EndpointPayload_Form = "InputCommand_EndpointPayload_Form";
			public const string InputCommand_EndpointPayload_Help = "InputCommand_EndpointPayload_Help";
			public const string InputCommand_EndpointPayload_JSON = "InputCommand_EndpointPayload_JSON";
			public const string InputCommand_EndpointPayload_None = "InputCommand_EndpointPayload_None";
			public const string InputCommand_EndpointPayload_QueryString = "InputCommand_EndpointPayload_QueryString";
			public const string InputCommand_EndpointPayload_Watermark = "InputCommand_EndpointPayload_Watermark";
			public const string InputCommand_EndpointPayload_XML = "InputCommand_EndpointPayload_XML";
			public const string InputCommand_EndpointType = "InputCommand_EndpointType";
			public const string InputCommand_EndpointType_Help = "InputCommand_EndpointType_Help";
			public const string InputCommand_EndpointType_Internal = "InputCommand_EndpointType_Internal";
			public const string InputCommand_EndpointType_Internal_Help = "InputCommand_EndpointType_Internal_Help";
			public const string InputCommand_EndpointType_REST_Delete = "InputCommand_EndpointType_REST_Delete";
			public const string InputCommand_EndpointType_REST_Get = "InputCommand_EndpointType_REST_Get";
			public const string InputCommand_EndpointType_REST_Post = "InputCommand_EndpointType_REST_Post";
			public const string InputCommand_EndpointType_REST_Put = "InputCommand_EndpointType_REST_Put";
			public const string InputCommand_EndpointType_Watermark = "InputCommand_EndpointType_Watermark";
			public const string InputCommand_Help = "InputCommand_Help";
			public const string InputCommand_Parameters = "InputCommand_Parameters";
			public const string InputCommand_Script = "InputCommand_Script";
			public const string InputCommand_Script_Help = "InputCommand_Script_Help";
			public const string InputCommand_Title = "InputCommand_Title";
			public const string InputCommandParamter_Description = "InputCommandParamter_Description";
			public const string NodeRedFlow_Description = "NodeRedFlow_Description";
			public const string NodeRedFlow_Help = "NodeRedFlow_Help";
			public const string NodeRedFlow_Title = "NodeRedFlow_Title";
			public const string OutputCommand_Description = "OutputCommand_Description";
			public const string OutputCommand_Help = "OutputCommand_Help";
			public const string OutputCommand_Script = "OutputCommand_Script";
			public const string OutputCommand_Script_Help = "OutputCommand_Script_Help";
			public const string OutputCommand_Title = "OutputCommand_Title";
			public const string Page_Description = "Page_Description";
			public const string Page_Help = "Page_Help";
			public const string Page_Name = "Page_Name";
			public const string Page_PageNumber = "Page_PageNumber";
			public const string Page_Title = "Page_Title";
			public const string Parameter_Help = "Parameter_Help";
			public const string Parameter_Title = "Parameter_Title";
			public const string Parameter_Type = "Parameter_Type";
			public const string Parameter_Type_Watermark = "Parameter_Type_Watermark";
			public const string Parameter_Types = "Parameter_Types";
			public const string Parameter_Types_DateTime = "Parameter_Types_DateTime";
			public const string Parameter_Types_Decimal = "Parameter_Types_Decimal";
			public const string Parameter_Types_GeoLocation = "Parameter_Types_GeoLocation";
			public const string Parameter_Types_Integer = "Parameter_Types_Integer";
			public const string Parameter_Types_States = "Parameter_Types_States";
			public const string Parameter_Types_String = "Parameter_Types_String";
			public const string Parameter_Types_TrueFalse = "Parameter_Types_TrueFalse";
			public const string Parameter_Types_ValueWithUnit = "Parameter_Types_ValueWithUnit";
			public const string Parameters = "Parameters";
			public const string State_Description = "State_Description";
			public const string State_Title = "State_Title";
			public const string State_UserHelp = "State_UserHelp";
			public const string StateMachine = "StateMachine";
			public const string StateMachine_Description = "StateMachine_Description";
			public const string StateMachine_Event = "StateMachine_Event";
			public const string StateMachine_Events = "StateMachine_Events";
			public const string StateMachine_Events_Help = "StateMachine_Events_Help";
			public const string StateMachine_Exception_OnInvalidEvent = "StateMachine_Exception_OnInvalidEvent";
			public const string StateMachine_Exception_OnInvalidEvent_Help = "StateMachine_Exception_OnInvalidEvent_Help";
			public const string StateMachine_Initialization_Actions = "StateMachine_Initialization_Actions";
			public const string StateMachine_Initialization_Actions_Help = "StateMachine_Initialization_Actions_Help";
			public const string StateMachine_InitialState = "StateMachine_InitialState";
			public const string StateMachine_InitialState_Help = "StateMachine_InitialState_Help";
			public const string StateMachine_NewState = "StateMachine_NewState";
			public const string StateMachine_NewState_Help = "StateMachine_NewState_Help";
			public const string StateMachine_Pages = "StateMachine_Pages";
			public const string StateMachine_Pages_Help = "StateMachine_Pages_Help";
			public const string StateMachine_State = "StateMachine_State";
			public const string StateMachine_State_Action = "StateMachine_State_Action";
			public const string StateMachine_State_DiagramX = "StateMachine_State_DiagramX";
			public const string StateMachine_State_DiagramY = "StateMachine_State_DiagramY";
			public const string StateMachine_State_IsInitialState = "StateMachine_State_IsInitialState";
			public const string StateMachine_State_IsInitialState_Help = "StateMachine_State_IsInitialState_Help";
			public const string StateMachine_State_TransitionInAction = "StateMachine_State_TransitionInAction";
			public const string StateMachine_State_TransitionInAction_Help = "StateMachine_State_TransitionInAction_Help";
			public const string StateMachine_State_Transitions = "StateMachine_State_Transitions";
			public const string StateMachine_State_Transitions_Help = "StateMachine_State_Transitions_Help";
			public const string StateMachine_States = "StateMachine_States";
			public const string StateMachine_Title = "StateMachine_Title";
			public const string StateMachine_Transition_Action = "StateMachine_Transition_Action";
			public const string StateMachine_Transition_Action_Help = "StateMachine_Transition_Action_Help";
			public const string StateMachine_Transition_EventHelp = "StateMachine_Transition_EventHelp";
			public const string StateMachine_Transition_Script = "StateMachine_Transition_Script";
			public const string StateMachine_Transition_State = "StateMachine_Transition_State";
			public const string StateMachine_Transitions = "StateMachine_Transitions";
			public const string StateMachine_UserHelp = "StateMachine_UserHelp";
			public const string StateMachine_Variables = "StateMachine_Variables";
			public const string StateMachine_Variables_Help = "StateMachine_Variables_Help";
			public const string StateMachineEvent_Description = "StateMachineEvent_Description";
			public const string StateMachineEvent_Title = "StateMachineEvent_Title";
			public const string StateMachineEvent_UserHelp = "StateMachineEvent_UserHelp";
			public const string StateMachines = "StateMachines";
			public const string StateSet_Description = "StateSet_Description";
			public const string StateSet_Help = "StateSet_Help";
			public const string StateSet_IsLocked = "StateSet_IsLocked";
			public const string StateSet_IsLocked_Help = "StateSet_IsLocked_Help";
			public const string StateSet_States = "StateSet_States";
			public const string StateSet_Title = "StateSet_Title";
			public const string StateTransition_Description = "StateTransition_Description";
			public const string StateTransition_Title = "StateTransition_Title";
			public const string StateTransition_UserHelp = "StateTransition_UserHelp";
			public const string Timer_DailyEndTime = "Timer_DailyEndTime";
			public const string Timer_DailyEndTime_Help = "Timer_DailyEndTime_Help";
			public const string Timer_DailyStartTime = "Timer_DailyStartTime";
			public const string Timer_DailyStartTime_Help = "Timer_DailyStartTime_Help";
			public const string Timer_Days = "Timer_Days";
			public const string Timer_Description = "Timer_Description";
			public const string Timer_Friday = "Timer_Friday";
			public const string Timer_Help = "Timer_Help";
			public const string Timer_HourOfDay = "Timer_HourOfDay";
			public const string Timer_Hours = "Timer_Hours";
			public const string Timer_MinuteOfDay = "Timer_MinuteOfDay";
			public const string Timer_Minutes = "Timer_Minutes";
			public const string Timer_Monday = "Timer_Monday";
			public const string Timer_Saturday = "Timer_Saturday";
			public const string Timer_Script = "Timer_Script";
			public const string Timer_Seconds = "Timer_Seconds";
			public const string Timer_Sunday = "Timer_Sunday";
			public const string Timer_Thursday = "Timer_Thursday";
			public const string Timer_Title = "Timer_Title";
			public const string Timer_Tuesday = "Timer_Tuesday";
			public const string Timer_Wednesday = "Timer_Wednesday";
			public const string Unit_Abbreviation = "Unit_Abbreviation";
			public const string Unit_Conversion_EditScriptWatermark = "Unit_Conversion_EditScriptWatermark";
			public const string Unit_Conversion_Factor = "Unit_Conversion_Factor";
			public const string Unit_Conversion_Factor_Help = "Unit_Conversion_Factor_Help";
			public const string Unit_Conversion_Type = "Unit_Conversion_Type";
			public const string Unit_Conversion_Type_Factor = "Unit_Conversion_Type_Factor";
			public const string Unit_Conversion_Type_Factor_Help = "Unit_Conversion_Type_Factor_Help";
			public const string Unit_Conversion_Type_Help = "Unit_Conversion_Type_Help";
			public const string Unit_Conversion_Type_Script = "Unit_Conversion_Type_Script";
			public const string Unit_Conversion_Type_Script_Help = "Unit_Conversion_Type_Script_Help";
			public const string Unit_ConversionScript = "Unit_ConversionScript";
			public const string Unit_ConversionScript_Help = "Unit_ConversionScript_Help";
			public const string Unit_Definitions = "Unit_Definitions";
			public const string Unit_Description = "Unit_Description";
			public const string Unit_DisplayFormat = "Unit_DisplayFormat";
			public const string Unit_DisplayFormat_Help = "Unit_DisplayFormat_Help";
			public const string Unit_Help = "Unit_Help";
			public const string Unit_IsDefault = "Unit_IsDefault";
			public const string Unit_IsDefault_Help = "Unit_IsDefault_Help";
			public const string Unit_NumberDecimal = "Unit_NumberDecimal";
			public const string Unit_Title = "Unit_Title";
			public const string UnitSet_DefaultUnit = "UnitSet_DefaultUnit";
			public const string UnitSet_Description = "UnitSet_Description";
			public const string UnitSet_Help = "UnitSet_Help";
			public const string UnitSet_IsLocked = "UnitSet_IsLocked";
			public const string UnitSet_IsLocked_Help = "UnitSet_IsLocked_Help";
			public const string UnitSet_Title = "UnitSet_Title";
			public const string UnitSet_Units = "UnitSet_Units";
			public const string WorkflowInput_Description = "WorkflowInput_Description";
			public const string WorkflowInput_Help = "WorkflowInput_Help";
			public const string WorkflowInput_Script_Watermark = "WorkflowInput_Script_Watermark";
			public const string WorkflowInput_SetScript = "WorkflowInput_SetScript";
			public const string WorkflowInput_SetScript_Help = "WorkflowInput_SetScript_Help";
			public const string WorkflowInput_States = "WorkflowInput_States";
			public const string WorkflowInput_States_Help = "WorkflowInput_States_Help";
			public const string WorkflowInput_StateSet_Watermark = "WorkflowInput_StateSet_Watermark";
			public const string WorkflowInput_Title = "WorkflowInput_Title";
			public const string WorkflowInput_Type = "WorkflowInput_Type";
			public const string WorkflowInput_Type_Boolean = "WorkflowInput_Type_Boolean";
			public const string WorkflowInput_Type_Boolean_Help = "WorkflowInput_Type_Boolean_Help";
			public const string WorkflowInput_Type_Description = "WorkflowInput_Type_Description";
			public const string WorkflowInput_Type_Discrete = "WorkflowInput_Type_Discrete";
			public const string WorkflowInput_Type_Discrete_Help = "WorkflowInput_Type_Discrete_Help";
			public const string WorkflowInput_Type_Discrete_Units = "WorkflowInput_Type_Discrete_Units";
			public const string WorkflowInput_Type_Discrete_Units_Help = "WorkflowInput_Type_Discrete_Units_Help";
			public const string WorkflowInput_Type_GeoLocation = "WorkflowInput_Type_GeoLocation";
			public const string WorkflowInput_Type_GeoLocation_Help = "WorkflowInput_Type_GeoLocation_Help";
			public const string WorkflowInput_Type_Help = "WorkflowInput_Type_Help";
			public const string WorkflowInput_Type_State = "WorkflowInput_Type_State";
			public const string WorkflowInput_Type_State_Help = "WorkflowInput_Type_State_Help";
			public const string WorkflowInput_Type_Text = "WorkflowInput_Type_Text";
			public const string WorkflowInput_Type_Text_Help = "WorkflowInput_Type_Text_Help";
			public const string WorkflowInput_Type_Watermark = "WorkflowInput_Type_Watermark";
			public const string WorkflowInput_Units = "WorkflowInput_Units";
			public const string WorkflowInput_Units_Help = "WorkflowInput_Units_Help";
			public const string WorkflowInput_UnitSet_Watermark = "WorkflowInput_UnitSet_Watermark";
		}
	}
}

