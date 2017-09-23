using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LagoVista.Core.Attributes;

namespace LagoVista.IoT.DeviceAdmin.Tests.ValidationTests
{
    [TestClass]
    public class WorkflowValidationTests : DeviceWorkflowTestBase
    {
        [TestMethod]
        public void WorkflowInput_Valid()
        {
            var workflow = GetDeviceWorkflow();

            var input = GetWorkflowInput();
            workflow.Inputs.Add(input);

            AssertIsValid(workflow);
        }

        [TestMethod]
        public void WorkflowInput_Attribute_Valid()
        {
            var workflow = GetDeviceWorkflow();

            var input = GetWorkflowInput();
            workflow.Inputs.Add(input);

            var attr = GetAttribute();
            workflow.Attributes.Add(attr);

            var connections = Connect(input, attr);

            AssertIsValid(workflow);
        }

        [TestMethod]
        public void WorkflowInput_Attribute_StateSetAttribute_Valid()
        {
            var workflow = GetDeviceWorkflow();

            var input = GetWorkflowInput(ParameterTypes.State);
            input.StateSet = new EntityHeader<StateSet>() { Id = "sts1", Text = "StateSetOne" };
            workflow.Inputs.Add(input);

            var attr = GetAttribute(ParameterTypes.State);
            attr.StateSet = new EntityHeader<StateSet>() { Id = "sts1", Text = "StateSetOne" };
            workflow.Attributes.Add(attr);

            var connections = Connect(input, attr);

            AssertIsValid(workflow);
        }

        [TestMethod]
        public void WorkflowInput_Attribute_UnitSetAttribute_Valid()
        {
            var workflow = GetDeviceWorkflow();

            var input = GetWorkflowInput(ParameterTypes.ValueWithUnit);
            input.UnitSet = new EntityHeader<UnitSet>() { Id = "uns1", Text = "UnitSetOne" };
            workflow.Inputs.Add(input);

            var attr = GetAttribute(ParameterTypes.ValueWithUnit);
            attr.UnitSet = new EntityHeader<UnitSet>() { Id = "uns1", Text = "UnitSetOne" };
            workflow.Attributes.Add(attr);

            var connections = Connect(input, attr);

            AssertIsValid(workflow);
        }

        [TestMethod]
        public void WorkflowInput_Attribute_TypeMisMatch_InValid()
        {
            var workflow = GetDeviceWorkflow();

            var input = GetWorkflowInput(ParameterTypes.String);
            workflow.Inputs.Add(input);

            var attr = GetAttribute(ParameterTypes.DateTime);
            workflow.Attributes.Add(attr);

            var connections = Connect(input, attr);

            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void WorkflowInput_Attribute_StateSetAttributeMisMatch_InValid()
        {
            var workflow = GetDeviceWorkflow();

            var input = GetWorkflowInput(ParameterTypes.State);
            input.StateSet = new EntityHeader<StateSet>() { Id = "sts1", Text = "StateSetOne" };
            workflow.Inputs.Add(input);

            var attr = GetAttribute(ParameterTypes.State);
            attr.StateSet = new EntityHeader<StateSet>() { Id = "sts5", Text = "StateSetOne" };
            workflow.Attributes.Add(attr);

            var connections = Connect(input, attr);

            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void WorkflowInput_Attribute_UnitSetAttribute_InValid()
        {
            var workflow = GetDeviceWorkflow();

            var input = GetWorkflowInput(ParameterTypes.ValueWithUnit);
            input.UnitSet = new EntityHeader<UnitSet>() { Id = "uns1", Text = "UnitSetOne" };
            workflow.Inputs.Add(input);

            var attr = GetAttribute(ParameterTypes.ValueWithUnit);
            attr.UnitSet = new EntityHeader<UnitSet>() { Id = "sts5", Text = "UnitSetOne" };
            workflow.Attributes.Add(attr);

            var connections = Connect(input, attr);

            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void WorfklowInput_InputCommand_InvalidMapping()
        {
            var workflow = GetDeviceWorkflow();
            workflow.Inputs.Add(GetWorkflowInput());
            workflow.InputCommands.Add(GetInputCommand());
            Connect(workflow.Inputs[0], workflow.InputCommands[0]);
            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void WorfklowInput_Input_InvalidMapping()
        {
            var workflow = GetDeviceWorkflow();
            workflow.Inputs.Add(GetWorkflowInput());
            var wfi = GetWorkflowInput();
            wfi.Key = "VALUE1";
            workflow.Inputs.Add(wfi);
            Connect(workflow.Inputs[0], workflow.Inputs[1]);
            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void WorkflowInput_StateMachine_Valid()
        {
            var workflow = GetDeviceWorkflow();
            workflow.Inputs.Add(GetWorkflowInput());
            workflow.StateMachines.Add(GetStateMachine());

            var connection = Connect(workflow.Inputs[0], workflow.StateMachines[0]);
            connection.Item1.StateMachineEvent = new EntityHeader<Event>() { Id = workflow.StateMachines[0].Events[0].Key, Text = workflow.StateMachines[0].Events[0].Name };

            AssertIsValid(workflow);
        }

        [TestMethod]
        public void WorkflowInput_StateMachine_MissingTransition_InValid()
        {
            var workflow = GetDeviceWorkflow();
            workflow.Inputs.Add(GetWorkflowInput());
            workflow.StateMachines.Add(GetStateMachine());

            var connection = Connect(workflow.Inputs[0], workflow.StateMachines[0]);
            connection.Item1.StateMachineEvent = null;

            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void WorkflowInput_StateMachine_EventNotFound_InValid()
        {
            var workflow = GetDeviceWorkflow();
            workflow.Inputs.Add(GetWorkflowInput());
            workflow.StateMachines.Add(GetStateMachine());

            var connection = Connect(workflow.Inputs[0], workflow.StateMachines[0]);
            connection.Item1.StateMachineEvent = new EntityHeader<Event>() { Id = "SOMEOTHERKEY", Text = workflow.StateMachines[0].Events[0].Name };

            AssertIsInValid(workflow);
        }
    }

    public class Item : IValidateable
    {
        [FormField(IsRequired:true)]
        public string Name { get; set; }
    }

}
