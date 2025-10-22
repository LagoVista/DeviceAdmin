// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 0518a231e11c85c72cb42d7babde1fa3f31dae040fd8a9874a61aa55a6d8d1a9
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
    public class NodeBaseTests : DeviceWorkflowTestBase
    {
        [TestMethod]
        public void NodeBaseTest_Valid()
        {
            var workflow = GetDeviceWorkflow();
            var attr = GetAttribute();
            workflow.Attributes.Add(attr);
            AssertIsValid(workflow);
        }

        [TestMethod]
        public void NodeBaseTest_MissingNodeName()
        {
            var workflow = GetDeviceWorkflow();
            var attr = GetAttribute();
            attr.Name = null;
            workflow.Attributes.Add(attr);
            AssertIsInValid(workflow);
        }

        [TestMethod]
        public void NodeBaseTest_MissingNodeKey()
        {
            var workflow = GetDeviceWorkflow();
            var attr = GetAttribute();
            attr.Key = null;
            workflow.Attributes.Add(attr);
            AssertIsInValid(workflow);
        }
    }
}
