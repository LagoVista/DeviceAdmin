using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class IoTModelBase : ModelBase, INamedEntity, IIDEntity, IAuditableEntity
    {
        public IoTModelBase()
        {
            Notes = new ObservableCollection<AdminNote>();
            ValidationErrors = new ObservableCollection<ErrorMessage>();
            IsValid = true;
        }

        [JsonProperty("id")]
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_UniqueId, IsUserEditable: false, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Id { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_CreationDate, FieldType: FieldTypes.JsonDateTime, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public String CreationDate { get; set; }

        //[FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_CreatedBy, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public EntityHeader CreatedBy { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_LastUpdated, FieldType: FieldTypes.JsonDateTime, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public String LastUpdatedDate { get; set; }

        //[FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_LastUpdatedBy, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public EntityHeader LastUpdatedBy { get; set; }

        private String _name;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: true)]
        public String Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private String _description;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public String Description
        {
            get { return _description; }
            set { Set(ref _description, value); }
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Notes, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<AdminNote> Notes { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsValid, FieldType:FieldTypes.Bool, IsUserEditable: false, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsValid { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_ValidationErrors, FieldType: FieldTypes.ChildList, IsUserEditable: false, ResourceType:typeof(DeviceLibraryResources))]
        public ObservableCollection<ErrorMessage> ValidationErrors { get; set; }

    }
}
