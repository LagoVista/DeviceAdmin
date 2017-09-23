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

        protected void AssertIsValid(ValidationResult result)
        {
            WriteResults(result);
            Assert.IsTrue(result.Successful);
        }

        protected void AssertIsInValid(ValidationResult result, int errorCount = 1, int warningCount = 0)
        {
            WriteResults(result);
            Assert.IsFalse(result.Successful);
            //TODO: Right now we are just checking for valid/invalid, to do thig 100% right we should make sure the error message is the one expected for the condition, our error messages needs to be put into resources and use formatting for parameters to ensure this works right, right now we just assume that there is one error...short cut, probalby burn us, but need to ship!
            Assert.AreEqual(errorCount, result.Errors.Count);
            Assert.AreEqual(warningCount, result.Warnings.Count);
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
