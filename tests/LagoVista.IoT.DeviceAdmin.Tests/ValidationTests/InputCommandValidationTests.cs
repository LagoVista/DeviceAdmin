// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: da0480286f5652709e35cbb09dfe7efe29faf7c4f7c7a281cd21d99191b3a89b
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Tests.ValidationTests
{
    [TestClass]
    public class InputCommandValidationTests : NodeBaseTests
    {

        [TestMethod]
        public void InputCommand_Valid()
        {
            var workflow = GetDeviceWorkflow();
            var inputCommand = GetInputCommand();
            workflow.InputCommands.Add(inputCommand);
            AssertIsValid(workflow);
        }

        [TestMethod]
        public void InputCommand_DuplicateKeysOnParamters_Invalid()
        {
            var workflow = GetDeviceWorkflow();
            var inputCommand = GetInputCommand();
            inputCommand.Parameters.Add(new Models.Parameter() { ParameterType = EntityHeader<ParameterTypes>.Create(ParameterTypes.String), ParameterLocation = EntityHeader<PayloadTypes>.Create(PayloadTypes.QueryString), Key = inputCommand.Parameters[0].Key, Name = inputCommand.Parameters[0].Name});
            workflow.InputCommands.Add(inputCommand);
            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void InputCommand_Attribute_MissingInputCommandParam_Invalid()
        {
            var workflow = GetDeviceWorkflow();
            var inputCommand = GetInputCommand();
            workflow.InputCommands.Add(inputCommand);
            workflow.Attributes.Add(GetAttribute());

            Connect(workflow.InputCommands[0], workflow.Attributes[0]);

            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void InputCommand_ValidMappings()
        {
            var workflow = GetDeviceWorkflow();
            var inputCommand = GetInputCommand();
            workflow.InputCommands.Add(inputCommand);
            workflow.Attributes.Add(GetAttribute());

            var connection = Connect(workflow.InputCommands[0], workflow.Attributes[0]);
            connection.Item1.InputCommandKey = inputCommand.Parameters[0].Key;

            AssertIsValid(workflow);
        }

        [TestMethod]
        public void InputCommand_Attribute_TypeMisMitch_InValid()
        {
            var workflow = GetDeviceWorkflow();
            var inputCommand = GetInputCommand();
            inputCommand.Parameters[0].ParameterType = EntityHeader<ParameterTypes>.Create(ParameterTypes.Integer);
            workflow.InputCommands.Add(inputCommand);
            workflow.Attributes.Add(GetAttribute());

            var connection = Connect(workflow.InputCommands[0], workflow.Attributes[0]);
            connection.Item1.InputCommandKey = inputCommand.Parameters[0].Key;

            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void InputCommand_Input_InvalidMapping()
        {
            var workflow = GetDeviceWorkflow();
            var inputCommand = GetInputCommand();
            workflow.InputCommands.Add(inputCommand);
            workflow.Inputs.Add(GetWorkflowInput());
             Connect(workflow.InputCommands[0], workflow.Inputs[0]);
            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void InputCommand_StateMachine_ValidMapping()
        {
            var workflow = GetDeviceWorkflow();
            var inputCommand = GetInputCommand();
            workflow.InputCommands.Add(inputCommand);
            workflow.StateMachines.Add(GetStateMachine());
            var connection = Connect(workflow.InputCommands[0], workflow.StateMachines[0]);
            connection.Item1.StateMachineEvent = new EntityHeader<Event>() { Id = workflow.StateMachines[0].Events[0].Key, Text = "dontcare" };
            AssertIsValid(workflow);
        }

        [TestMethod]
        public void InputCommand_StateMachine_EventNotSet_Invalid()
        {
            var workflow = GetDeviceWorkflow();
            var inputCommand = GetInputCommand();
            workflow.InputCommands.Add(inputCommand);
            workflow.StateMachines.Add(GetStateMachine());
            var connection = Connect(workflow.InputCommands[0], workflow.StateMachines[0]);
            AssertIsInValid(workflow);
        }


        [TestMethod]
        public void InputCommand_StateMachine_EventDoesntExist_Invalid()
        {
            var workflow = GetDeviceWorkflow();
            var inputCommand = GetInputCommand();
            workflow.InputCommands.Add(inputCommand);
            workflow.StateMachines.Add(GetStateMachine());
            var connection = Connect(workflow.InputCommands[0], workflow.StateMachines[0]);
            connection.Item1.StateMachineEvent = new EntityHeader<Event>() { Id = "statenotfound", Text = "dontcare" };
            AssertIsInValid(workflow);
        }
    }
}