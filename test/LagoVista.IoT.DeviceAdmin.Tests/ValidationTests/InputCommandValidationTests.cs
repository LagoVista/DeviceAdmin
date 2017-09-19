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
        public void InputCommand_ValidMappings()
        {

        }
    }
}
