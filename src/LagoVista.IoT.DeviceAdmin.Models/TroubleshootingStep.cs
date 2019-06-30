using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.TroubleShootingStep_Title,
    DeviceLibraryResources.Names.TroubleShootingStep_Help, DeviceLibraryResources.Names.TroubleShootingStep_Description,
              EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources))]
    public class TroubleshootingStep
    {
        public TroubleshootingStep()
        {
            Resources = new List<EntityHeader>();
        }

        public string Id { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.TroubleshootingStep_StepId, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: true)]
        public string StepId { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: true)]
        public string Name { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.TroubleshootingStep_Instructions, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: true)]
        public string Instructions { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.TroubleshootingSteps_ExpectedOutcome, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: true)]
        public string ExpectedOutcome { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.TroubleshootingStep_Problem, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: true)]
        public string Problem { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.TroubleshootingStep_Notes, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: true)]
        public string Notes { get; set; }


        [FormField(LabelResource: DeviceLibraryResources.Names.Common_Resources, FieldType: FieldTypes.ChildItem, ResourceType: typeof(DeviceLibraryResources))]
        public List<EntityHeader> Resources { get; set; }
    }
}
