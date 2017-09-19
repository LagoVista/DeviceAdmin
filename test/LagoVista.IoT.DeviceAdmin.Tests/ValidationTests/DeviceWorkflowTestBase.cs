using LagoVista.Core.Models;
using LagoVista.Core;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LagoVista.IoT.DeviceAdmin.Models.InputCommand;

namespace LagoVista.IoT.DeviceAdmin.Tests.ValidationTests
{
    public class DeviceWorkflowTestBase
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

            return stm;
        }

        protected OutputCommand GetOutputCommand()
        {
            return new OutputCommand()
            {
                Id = Guid.NewGuid().ToId(),
                Key = "outputone",
                Name = "Output Command One",
                CreatedBy = EntityHeader.Create(Guid.NewGuid().ToId(), "me"),
                LastUpdatedBy = EntityHeader.Create(Guid.NewGuid().ToId(), "me"),
                CreationDate = DateTime.UtcNow.ToJSONString(),
                LastUpdatedDate = DateTime.UtcNow.ToJSONString(),
            };
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

            inputCommand.Parameters.Add(new Parameter()
            {
                ParameterType = EntityHeader<ParameterTypes>.Create(ParameterTypes.State),
                Key = "strparm",
                Name = "String Parameter"
            });

            return inputCommand;
        }

        protected DeviceWorkflow GetDeviceWorkflow()
        {
            var workflow = new DeviceWorkflow()
            {
                Id = Guid.NewGuid().ToId(),
                Key = "Workflow123",
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

        protected void WriteResults(ValidationResult result)
        {
            Console.WriteLine("Errors (Expected if test Passed");
            Console.WriteLine("==================================================");

            foreach (var err in result.Errors)
            {
                Console.WriteLine(err.Message);
            }

            Console.WriteLine("");
            Console.WriteLine("Warnings (Expected if test Passed");
            Console.WriteLine("==================================================");

            if (result.Warnings.Count > 0)
            {
                foreach (var err in result.Warnings)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }

        protected void AssertIsValid(DeviceWorkflow workflow)
        {
            var result = Validator.Validate(workflow);
            WriteResults(result);
            Assert.IsTrue(result.Successful);
        }

        protected void AssertIsInValid(DeviceWorkflow workflow)
        {
            var result = Validator.Validate(workflow);
            WriteResults(result);
            Assert.IsFalse(result.Successful);
        }
    }
}
