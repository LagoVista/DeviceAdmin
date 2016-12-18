using LagoVista.Core.Attributes;
using LagoVista.Core.Geo;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class Device : DeviceModelBase
    {
        private String _notes;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_DeviceNotes, FieldType:FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public String Notes
        {
            get { return _notes; }
            set { Set(ref _notes, value); }
        }

        private String _deviceId;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_DeviceId, IsRequired:true,
            ReqMessageResource:Resources.DeviceLibraryResources.Names.Device_DeviceId_Required, 
            HelpResource:Resources.DeviceLibraryResources.Names.Device_DeviceId_Help, 
            ResourceType: typeof(DeviceLibraryResources))]
        public String DeviceId
        {
            get { return _deviceId; }
            set { Set(ref _deviceId, value); }
        }

        private EntityHeader _accountLocation;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_Location, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader AccountLocation
        {
            get { return _accountLocation; }
            set { Set(ref _accountLocation, value); }
        }

        private EntityHeader _account;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_Location, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader Account
        {
            get { return _account; }
            set { Set(ref _account, value); }
        }

        private Dictionary<String, String> _customFields;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_CustomFields, ResourceType: typeof(DeviceLibraryResources))]
        private Dictionary<String, String> CustomFields
        {
            get { return _customFields; }
            set { Set(ref _customFields, value);}
        }

        private Byte? _batteryLevel;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_BatteryLevel, ResourceType: typeof(DeviceLibraryResources))]
        public byte? BatteryLevel
        {
            get { return _batteryLevel; }
            set { Set(ref _batteryLevel, value); }
        }

        private String _serialNumber;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_SerialNumber, ResourceType:typeof(DeviceLibraryResources))]
        public String SerialNumber
        {
            get { return _serialNumber; }
            set { Set(ref _serialNumber, value); }
        }

        private String _firmwareVersion;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_FirmwareVersion, ResourceType: typeof(DeviceLibraryResources))]
        public String FirmwareVersion
        {
            get { return _firmwareVersion; }
            set { Set(ref _firmwareVersion, value); }
        }

        private EntityHeader _deviceType;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_DeviceType, ResourceType: typeof(DeviceLibraryResources), IsRequired:true)]
        public EntityHeader DeviceType
        {
            get { return _deviceType; }
            set { Set(ref _deviceType, value); }
        }

        private EntityHeader _gateWayDevice;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_GatewayDevice, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader GatewayDevice
        {
            get { return _gateWayDevice; }
            set { Set(ref _gateWayDevice, value); }
        }

        IGeoLocation _geoLocation;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_GeoLocation, ResourceType: typeof(DeviceLibraryResources))]
        public IGeoLocation GeoLocation
        {
            get { return _geoLocation; }
            set { Set(ref _geoLocation, value); }
        }

        private bool _online;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_Online, ResourceType: typeof(DeviceLibraryResources))]
        public bool Online
        {
            get { return _online; }
            set { Set(ref _online, value); }
        }

        private EntityHeader _status;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_Status, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader Status
        {
            get { return _status; }
            set { Set(ref _status, value); }
        }

        private EntityHeader _connectionStatus;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_ConnectionStatus, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader ConnectionStatus
        {
            get { return _connectionStatus; }
            set { Set(ref _connectionStatus, value); }
        }

        private String _lastContact;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_LastContact, ResourceType: typeof(DeviceLibraryResources))]
        public String LastContact
        {
            get { return _lastContact; }
            set { Set(ref _lastContact, value); }
        }


    }
}
