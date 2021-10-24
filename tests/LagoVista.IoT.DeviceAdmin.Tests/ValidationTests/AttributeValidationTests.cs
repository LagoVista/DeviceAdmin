using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LagoVista.IoT.DeviceAdmin.Tests.ValidationTests
{
    [TestClass]
    public class AttributeValidationTests : DeviceWorkflowTestBase
    {
        [TestMethod]
        public void Attribute_Valid()
        {
            var workflow = GetDeviceWorkflow();
            var attr = GetAttribute();
            workflow.Attributes.Add(attr);
            AssertIsValid(workflow);
        }


        [TestMethod]
        public void Attribute_AttributeTypeMissing_Invalid()
        {
            var workflow = GetDeviceWorkflow();

            var attr = GetAttribute();
            attr.AttributeType = null;
            workflow.Attributes.Add(attr);

            AssertIsInValid(workflow);
        }


        [TestMethod]
        public void Attribute_MissingStateSet_Invalid()
        {
            var workflow = GetDeviceWorkflow();

            var attr = GetAttribute(ParameterTypes.State);
            workflow.Attributes.Add(attr);

            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void Attribute_MissingUnitSet_Invalid()
        {
            var workflow = GetDeviceWorkflow();

            var attr = GetAttribute(ParameterTypes.ValueWithUnit);
            workflow.Attributes.Add(attr);

            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void Attribute_HasStateSet_Valid()
        {
            var workflow = GetDeviceWorkflow();

            var attr = GetAttribute(ParameterTypes.State);
            attr.StateSet =new EntityHeader<StateSet>() { Id = "1234", Text = "dontcare" };
            workflow.Attributes.Add(attr);

            AssertIsValid(workflow);
        }

        [TestMethod]
        public void Attribute_HasUnitSet_Valid()
        {
            var workflow = GetDeviceWorkflow();

            var attr = GetAttribute(ParameterTypes.ValueWithUnit);
            attr.UnitSet = new EntityHeader<UnitSet>() { Id = "1234", Text = "dontcare" };
            workflow.Attributes.Add(attr);

            AssertIsValid(workflow);
        }

        #region Invalid Connection Tests
        [TestMethod]
        public void Attribute_WorkflowInput_InValidConnection()
        {
            var workflow = GetDeviceWorkflow();
            workflow.Attributes.Add(GetAttribute());
            workflow.Inputs.Add(GetWorkflowInput());

            Connect(workflow.Attributes[0], workflow.Inputs[0]);

            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void Attribute_InputCommand_InValidConnection()
        {
            var workflow = GetDeviceWorkflow();
            workflow.Attributes.Add(GetAttribute());
            workflow.InputCommands.Add(GetInputCommand());

            Connect(workflow.Attributes[0], workflow.InputCommands[0]);

            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void Attribute_Attribute_InValidConnection()
        {
            var workflow = GetDeviceWorkflow();
            workflow.Attributes.Add(GetAttribute());
            var attr = GetAttribute();
            attr.Key = "key2";
            workflow.Attributes.Add(attr);

            Connect(workflow.Attributes[0], workflow.Attributes[0]);

            AssertIsValid(workflow);
        }
        #endregion


        #region State Machine Tests
        [TestMethod]
        public void Attribute_StateMachine_Valid()
        {
            var workflow = GetDeviceWorkflow();
            workflow.Attributes.Add(GetAttribute());
            workflow.StateMachines.Add(GetStateMachine());

            var connection = Connect(workflow.Attributes[0], workflow.StateMachines[0]);
            connection.Item1.StateMachineEvent = new EntityHeader<Event>() { Id = workflow.StateMachines[0].Events[0].Key, Text = workflow.StateMachines[0].Events[0].Name };

            AssertIsValid(workflow);
        }

        [TestMethod]
        public void Attribute_StateMachine_MissingTransition_InValid()
        {
            var workflow = GetDeviceWorkflow();
            workflow.Attributes.Add(GetAttribute());
            workflow.StateMachines.Add(GetStateMachine());

            var connection = Connect(workflow.Attributes[0], workflow.StateMachines[0]);
            connection.Item1.StateMachineEvent = null;

            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void Attribute_StateMachine_EventNotFound_InValid()
        {
            var workflow = GetDeviceWorkflow();
            workflow.Attributes.Add(GetAttribute());
            workflow.StateMachines.Add(GetStateMachine());

            var connection = Connect(workflow.Attributes[0], workflow.StateMachines[0]);
            connection.Item1.StateMachineEvent = new EntityHeader<Event>() { Id = "SOMEOTHERKEY", Text = workflow.StateMachines[0].Events[0].Name };

            AssertIsInValid(workflow);
        }
        #endregion
    }
}
