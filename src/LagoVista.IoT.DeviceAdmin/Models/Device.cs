using LagoVista.Core.Attributes;
using LagoVista.Core.Geo;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Resources;
using LagoVista.UserAdmin.Models.Account;
using LagoVista.UserAdmin.Models.Orgs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    /*
    public class Device : IoTModelBase, INoSQLEntity
    {
        private String _deviceId;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_DeviceId, IsRequired:true,
            ReqMessageResource:Resources.DeviceLibraryResources.Names.Device_DeviceId_Required, 
            HelpResource:Resources.DeviceLibraryResources.Names.Device_DeviceId_Help, 
            ResourceType: typeof(DeviceLibraryResources))]

        public String DatabaseName { get; set; }

        public String EntityType { get; set; }




        public string AttributeJSON { get; set; }

        public string CurrentStateJSON { get; set; }

        public String DeviceId
        {
            get { return _deviceId; }
            set { Set(ref _deviceId, value); }
        }

        private EntityHeader<OrganizationLocation> _organizationLocation;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_Location, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<OrganizationLocation> OrganiazationLocation
        {
            get { return _organizationLocation; }
            set { Set(ref _organizationLocation, value); }
        }

        private EntityHeader<Organization> _organization;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_Location, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<Organization> Organization
        {
            get { return _organization; }
            set { Set(ref _organization, value); }
        }

        private EntityHeader<AppUser> _ownerTechnician;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_Location, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<AppUser> OwnerTechnician
        {
            get { return _ownerTechnician; }
            set { Set(ref _ownerTechnician, value); }
        }

        private EntityHeader<AppUser> _ownerAdmin;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_Location, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<AppUser> OwnerAdmin
        {
            get { return _ownerAdmin; }
            set { Set(ref _ownerAdmin, value); }
        }


        private List<CustomField> _customFields;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Device_CustomFields, ResourceType: typeof(DeviceLibraryResources))]
        private List<CustomField> CustomFields
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
    */
}
