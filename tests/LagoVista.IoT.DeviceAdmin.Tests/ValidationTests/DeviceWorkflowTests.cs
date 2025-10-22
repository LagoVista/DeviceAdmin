// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: f6728fe521ded2cb0973c5004226cceb1b9d8601f5fb6ed78da57b68d26f9b70
// IndexVersion: 0
// --- END CODE INDEX META ---
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Tests.ValidationTests
{
    [TestClass]
    public class DeviceWorkflowTests : DeviceWorkflowTestBase
    {
        [TestMethod]
        public void DuplicatKeys_On_WorkflowInputs_Invalid()
        {
            var workflow = GetDeviceWorkflow();
            workflow.Inputs.Add(GetWorkflowInput());
            workflow.Inputs.Add(GetWorkflowInput());

            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void DuplicatKeys_On_Attributes_Invalid()
        {
            var workflow = GetDeviceWorkflow();
            workflow.Attributes.Add(GetAttribute());
            workflow.Attributes.Add(GetAttribute());

            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void DuplicateKeys_On_InputCommands_Invalid()
        {
            var workflow = GetDeviceWorkflow();
            workflow.InputCommands.Add(GetInputCommand());
            workflow.InputCommands.Add(GetInputCommand());

            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void DuplicateKeys_On_OutputCommands_Invalid()
        {
            var workflow = GetDeviceWorkflow();
            workflow.OutputCommands.Add(GetOutputCommand());
            workflow.OutputCommands.Add(GetOutputCommand());

            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void DuplicateKeys_On_StateMachines_Invalid()
        {
            var workflow = GetDeviceWorkflow();
            workflow.StateMachines.Add(GetStateMachine());
            workflow.StateMachines.Add(GetStateMachine());

            AssertIsInValid(workflow);
        }
    }
}
