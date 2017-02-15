using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.InputCommand_Title, DeviceLibraryResources.Names.InputCommand_Parameters, DeviceLibraryResources.Names.InputCommand_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class InputCommand : NodeBase, IValidateable
    {
        public enum PayloadTypes
        {
            [EnumLabel("json", Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload_JSON, typeof(Resources.DeviceLibraryResources))]
            Json,
            [EnumLabel("xml", Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload_XML, typeof(Resources.DeviceLibraryResources))]
            Xml,
            [EnumLabel("form", Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload_Form, typeof(Resources.DeviceLibraryResources))]
            Form,
            [EnumLabel("none", Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload_None, typeof(Resources.DeviceLibraryResources))]
            None
        }

        public enum EndpointTypes
        {
            [EnumLabel("get", Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_REST_Get, typeof(Resources.DeviceLibraryResources))]
            RestGet,
            [EnumLabel("post", Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_REST_Post, typeof(Resources.DeviceLibraryResources))]
            RestPost,
            [EnumLabel("put", Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_REST_Put, typeof(Resources.DeviceLibraryResources))]
            RestPut,
            [EnumLabel("delete", Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_REST_Delete, typeof(Resources.DeviceLibraryResources))]
            RestDelete,
            [EnumLabel("internal", Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_REST_Get, typeof(Resources.DeviceLibraryResources), Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_Internal_Help)]
            Internal
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.InputCommand_Parameters, HelpResource: Resources.DeviceLibraryResources.Names.InputCommandParameter_Help, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public List<InputCommandParameter> Parameters { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.InputCommand_Script, HelpResource: Resources.DeviceLibraryResources.Names.InputCommand_Script_Help, FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources))]
        public String Script { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.InputCommand_EndpointType, HelpResource: Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_Help, WaterMark:Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_Watermark, FieldType: FieldTypes.Picker, EnumType:typeof(EndpointTypes), ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public EntityHeader EndpointType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload, HelpResource: Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload_Help, WaterMark: Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload_Watermark, FieldType: FieldTypes.Picker, EnumType:typeof(PayloadTypes), ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader EndpointPayload { get; set; }
    }
}
