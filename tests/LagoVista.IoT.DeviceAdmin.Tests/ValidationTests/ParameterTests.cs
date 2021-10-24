using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LagoVista.IoT.DeviceAdmin.Tests.ValidationTests
{
    [TestClass]
    public class ParameterTests : DeviceWorkflowTestBase
    {        
        [TestMethod]
        public void Parameter_Valid()
        {
            var parameter = GetValidParameter();
            var result = new ValidationResult();
           parameter.Validate(result);
            AssertIsValid(result);
        }


        [TestMethod]
        public void Parameter_StateSet_Valid()
        {
            var parameter = GetValidParameter(ParameterTypes.State);
            var result = new ValidationResult();
            parameter.Validate(result);
            AssertIsValid(result);
        }

        [TestMethod]
        public void Parameter_UnitSet_Valid()
        {
            var parameter = GetValidParameter( ParameterTypes.ValueWithUnit);
            var result = new ValidationResult();
            parameter.Validate(result);
            AssertIsValid(result);
        }

        [TestMethod]
        public void Parameter_MissingStateSet_InValid()
        {
            var parameter = GetValidParameter(ParameterTypes.State);
            parameter.StateSet = null;
            var result = new ValidationResult();            
            parameter.Validate(result);
            AssertIsInValid(result);
        }

        [TestMethod]
        public void ParameterMissing_UnitSet_InValid()
        {
            var parameter = GetValidParameter(ParameterTypes.ValueWithUnit);
            parameter.UnitSet = null;
            var result = new ValidationResult();
            parameter.Validate(result);
            AssertIsInValid(result);
        }

    }
}
