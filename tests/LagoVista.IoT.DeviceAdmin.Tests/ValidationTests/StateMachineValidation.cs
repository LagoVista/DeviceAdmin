// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: b5f97c405f3ebcc19711429753f308cc178350357195bae5c37186df9dc2f1fc
// IndexVersion: 2
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
    public class StateMachineValidation : NodeBaseTests
    {
        [TestMethod]
        public void StateMachine_Valid()
        {
            var workflow = GetDeviceWorkflow();
            var stm = GetStateMachine();

            workflow.StateMachines.Add(stm);

            AssertIsValid(workflow);
        }

        [TestMethod]
        public void StateMachine_DuplicateEvents_Invalid()
        {
            var workflow = GetDeviceWorkflow();
            var stm = GetStateMachine();

            stm.Events[1].Key = stm.Events[0].Key;

            workflow.StateMachines.Add(stm);
            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void StateMachine_DuplicateStates_Invalid()
        {
            var workflow = GetDeviceWorkflow();
            var stm = GetStateMachine();

            stm.States[1].Key = stm.States[0].Key;

            workflow.StateMachines.Add(stm);
            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void StateMachine_DuplicateVariables_Invalid()
        {
            var workflow = GetDeviceWorkflow();
            var stm = GetStateMachine();

            stm.Variables[1].Key = stm.Variables[0].Key;

            workflow.StateMachines.Add(stm);
            AssertIsInValid(workflow);
        }

    }
}
