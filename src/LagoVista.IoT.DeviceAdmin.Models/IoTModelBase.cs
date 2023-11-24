using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class IoTModelBase : EntityBase, IValidateable, IDescriptionEntity
    {
        public IoTModelBase()
        {
            Notes = new ObservableCollection<AdminNote>();
            ValidationErrors = new ObservableCollection<ErrorMessage>();
            IsValid = true;
        }

       
        [CloneOptions(true)]
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Notes, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<AdminNote> Notes { get; set; }

        [CloneOptions(false)]
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsValid, FieldType:FieldTypes.Bool, IsUserEditable: false, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsValid { get; set; }

        [CloneOptions(false)]
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_ValidationErrors, FieldType: FieldTypes.ChildList, IsUserEditable: false, ResourceType:typeof(DeviceLibraryResources))]
        public ObservableCollection<ErrorMessage> ValidationErrors { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, IsUserEditable: false, ResourceType: typeof(DeviceLibraryResources))]
        public string Description { get; set; }

        public ObservableCollection<AdminNote> CloneNotes()
        {
            var notes = new ObservableCollection<AdminNote>();
            foreach(var note in notes)
            {
                notes.Add(note.Clone());
            }

            return notes;
        }
    }
}
