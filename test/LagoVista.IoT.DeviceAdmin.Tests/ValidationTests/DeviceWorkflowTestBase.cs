using LagoVista.Core.Models;
using LagoVista.Core;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LagoVista.IoT.DeviceAdmin.Models.InputCommand;

namespace LagoVista.IoT.DeviceAdmin.Tests.ValidationTests
{
    public class DeviceWorkflowTestBase : ValidationTestBase
    {

        protected WorkflowInput GetWorkflowInput(ParameterTypes parameterType = ParameterTypes.String)
        {
            return new WorkflowInput()
            {
                Id = Guid.NewGuid().ToId(),
                Key = "inputone",
                InputType = EntityHeader<ParameterTypes>.Create(parameterType),
                Name = "Workflow Input One",
                CreatedBy = EntityHeader.Create(Guid.NewGuid().ToId(), "me"),
                LastUpdatedBy = EntityHeader.Create(Guid.NewGuid().ToId(), "me"),
                CreationDate = DateTime.UtcNow.ToJSONString(),
                LastUpdatedDate = DateTime.UtcNow.ToJSONString(),
            };
        }

        protected Parameter GetValidParameter(ParameterTypes parameterTypes = ParameterTypes.String, string key="myparameter")
        {
            var parameter = new Parameter()
            {
                Name = "parameter",
                Key = key,
                Id = "abc123",
                ParameterType = EntityHeader<ParameterTypes>.Create(parameterTypes),
            };

            if(parameterTypes == ParameterTypes.State)
            {
                parameter.StateSet = new EntityHeader<StateSet>() { Id = "abc123", Text = "dontcare" };
            }
            else if(parameterTypes == ParameterTypes.ValueWithUnit)
            {
                parameter.UnitSet = new EntityHeader<UnitSet>() { Id = "abc123", Text = "dontcare" };
            }

            return parameter;
        }

        protected LagoVista.IoT.DeviceAdmin.Models.Attribute GetAttribute(ParameterTypes parameterType = ParameterTypes.String)
        {
            return new LagoVista.IoT.DeviceAdmin.Models.Attribute()
            {
                Id = Guid.NewGuid().ToId(),
                Key = "attrone",
                AttributeType = EntityHeader<ParameterTypes>.Create(parameterType),
                Name = "Attribute One",
                CreatedBy = EntityHeader.Create(Guid.NewGuid().ToId(), "me"),
                LastUpdatedBy = EntityHeader.Create(Guid.NewGuid().ToId(), "me"),
                CreationDate = DateTime.UtcNow.ToJSONString(),
                LastUpdatedDate = DateTime.UtcNow.ToJSONString(),
            };
        }

        protected StateMachine GetStateMachine()
        {
            var stm = new StateMachine()
            {
                Id = Guid.NewGuid().ToId(),
                Key = "stmone",
                Name = "State Machine 1",
                CreatedBy = EntityHeader.Create(Guid.NewGuid().ToId(), "me"),
                LastUpdatedBy = EntityHeader.Create(Guid.NewGuid().ToId(), "me"),
                CreationDate = DateTime.UtcNow.ToJSONString(),
                LastUpdatedDate = DateTime.UtcNow.ToJSONString(),
            };

            stm.Events.Add(new Event() { Key = "event1", Name = "name", });
            stm.Events.Add(new Event() { Key = "event2", Name = "name", });
            stm.Events.Add(new Event() { Key = "event3", Name = "name", });

            stm.States.Add(new State() { Key = "state1", Name = "name", });
            stm.States.Add(new State() { Key = "state2", Name = "name", });
            stm.States.Add(new State() { Key = "state3", Name = "name", });

            stm.Variables.Add(GetValidParameter(key:"one"));
            stm.Variables.Add(GetValidParameter(key: "tw0"));
            stm.Variables.Add(GetValidParameter(key: "three"));

            return stm;
        }

        protected OutputCommand GetOutputCommand()
        {
            var outputCommand = new OutputCommand()
            {
                Id = Guid.NewGuid().ToId(),
                Key = "outputone",
                Name = "Output Command One",
                CreatedBy = EntityHeader.Create(Guid.NewGuid().ToId(), "me"),
                LastUpdatedBy = EntityHeader.Create(Guid.NewGuid().ToId(), "me"),
                CreationDate = DateTime.UtcNow.ToJSONString(),
                LastUpdatedDate = DateTime.UtcNow.ToJSONString(),
            };

            outputCommand.Parameters.Add(GetValidParameter());

            return outputCommand;
        }

        protected InputCommand GetInputCommand()
        {
            var inputCommand = new InputCommand()
            {
                Id = Guid.NewGuid().ToId(),
                Key = "inputcmdone",
                Name = "Input Command One",
                EndpointType = EntityHeader<EndpointTypes>.Create(EndpointTypes.RestGet),
                CreatedBy = EntityHeader.Create(Guid.NewGuid().ToId(), "me"),
                LastUpdatedBy = EntityHeader.Create(Guid.NewGuid().ToId(), "me"),
                CreationDate = DateTime.UtcNow.ToJSONString(),
                LastUpdatedDate = DateTime.UtcNow.ToJSONString(),
            };

            var parameter = GetValidParameter();
            parameter.ParameterLocation = EntityHeader<PayloadTypes>.Create(PayloadTypes.QueryString);
            inputCommand.Parameters.Add(parameter);

            return inputCommand;
        }

        protected DeviceWorkflow GetDeviceWorkflow()
        {
            var workflow = new DeviceWorkflow()
            {
                Id = Guid.NewGuid().ToId(),
                Key = "workflow123",
                Name = "My First Workflow",
                CreatedBy = EntityHeader.Create(Guid.NewGuid().ToId(), "NAME"),
                CreationDate = DateTime.UtcNow.ToJSONString()
            };

            workflow.LastUpdatedBy = workflow.CreatedBy;
            workflow.LastUpdatedDate = workflow.CreationDate;

            return workflow;
        }

        protected Tuple<Connection, Connection> Connect(NodeBase source, NodeBase dest)
        {
            var sourceConnection = new Connection()
            {
                NodeKey = dest.Key,
                NodeType = dest.NodeType,
                NodeName = dest.Name,
            };

            var destConnection = new Connection()
            {
                NodeKey = source.Key,
                NodeType = source.NodeType,
                NodeName = source.Name,
            };

            source.OutgoingConnections.Add(sourceConnection);
            dest.IncomingConnections.Add(destConnection);

            return new Tuple<Connection, Connection>(sourceConnection, destConnection);
        }

        protected void AssertIsValid(DeviceWorkflow workflow)
        {
            var result = Validator.Validate(workflow);
            AssertIsValid(result);
        }

        /// <summary>
        /// Assert the record is invalid.
        /// </summary>
        /// <param name="workflow"></param>
        /// <param name="errorCount">Expected number of errors</param>
        /// <param name="warningCount">Expected number of warnings</param>
        protected void AssertIsInValid(DeviceWorkflow workflow, int errorCount = 1, int warningCount = 0)
        {
            var result = Validator.Validate(workflow);
            AssertIsInValid(result, errorCount, warningCount);            
        }
    }
}
