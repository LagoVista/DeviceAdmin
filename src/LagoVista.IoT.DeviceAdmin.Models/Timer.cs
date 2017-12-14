using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Timer_Title, DeviceLibraryResources.Names.Timer_Description, DeviceLibraryResources.Names.Timer_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class Timer : NodeBase, IValidateable, IFormDescriptor
    {

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Timer_Days, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceLibraryResources))]
        public int Days { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Timer_Hours, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceLibraryResources))]
        public int Hours { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Timer_Minutes, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceLibraryResources))]
        public int Minutes { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Timer_Seconds, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceLibraryResources))]
        public int Seconds { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Timer_HourOfDay, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceLibraryResources))]
        public int HourOfDay { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Timer_MinuteOfDay, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceLibraryResources))]
        public int MinuteOfDay { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Timer_Sunday, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool Sunday { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Timer_Monday, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool Monday { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Timer_Tuesday, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool Tuesday { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Timer_Wednesday, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool Wednesday { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Timer_Thursday, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool Thursday { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Timer_Friday, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool Friday { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Timer_Saturday, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool Saturday { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Timer_DailyStartTime, HelpResource:Resources.DeviceLibraryResources.Names.Timer_DailyStartTime_Help, FieldType: FieldTypes.Time, ResourceType: typeof(DeviceLibraryResources))]
        public string DailyStartTime{ get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Timer_DailyEndTime, HelpResource: Resources.DeviceLibraryResources.Names.Timer_DailyEndTime_Help, FieldType: FieldTypes.Time, ResourceType: typeof(DeviceLibraryResources))]
        public string DailyEndTime { get; set; }

        public override string NodeType => NodeType_Timer;



        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Timer.Name),
                nameof(Timer.Key),
                nameof(Timer.Description),
                nameof(Timer.Days),
                nameof(Timer.Hours),
                nameof(Timer.Minutes),
                nameof(Timer.Seconds),
                nameof(Timer.HourOfDay),
                nameof(Timer.MinuteOfDay),
                nameof(Timer.Sunday),
                nameof(Timer.Monday),
                nameof(Timer.Tuesday),
                nameof(Timer.Wednesday),
                nameof(Timer.Thursday),
                nameof(Timer.Friday),
                nameof(Timer.Saturday),
                nameof(Timer.DailyStartTime),
                nameof(Timer.DailyEndTime)
            };
        }

        public void Validate(DeviceWorkflow workflow, ValidationResult resutl)
        {
            if(Validator.Validate(this).Successful)
            {

            }
        }
    }
}
