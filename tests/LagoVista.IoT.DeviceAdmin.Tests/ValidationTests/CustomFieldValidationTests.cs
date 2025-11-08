// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: f525cf0f6d8d4ba541756346977d54075aa2934d222b75f2258e5a1ad71daa0d
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LagoVista.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Tests.ValidationTests
{
    [TestClass]
    public class CustomFieldValidationTests
    {
        private void WriteErrors(ValidationResult result)
        {
            foreach (var err in result.Errors)
            {
                Console.WriteLine(err.Message);
            }
        }


        [TestMethod]
        public void CustomField_MissingFieldType_Invalid()
        {
            var field = new CustomField();
            field.IsRequired = false;

            var result = new ValidationResult();
            field.Label = "Field1";
            field.Validate(String.Empty, result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(1, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_NotRequired_Empty_Valid()
        {
            var field = new CustomField();
            field.Label = "Field1";
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.String);
            field.IsRequired = false;

            var result = new ValidationResult();
            field.Validate(String.Empty, result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(0, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_NotRequired_Null_Valid()
        {
            var field = new CustomField();
            field.Label = "Field1";
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.String);
            field.IsRequired = false;

            var result = new ValidationResult();
            field.Validate(null, result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(0, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_Required_Null_Invalid()
        {
            var field = new CustomField();
            field.Label = "Field1";
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.String);
            field.IsRequired = true;

            var result = new ValidationResult();
            field.Validate(null, result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(1, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_Required_Null_Invalid_DisplaysFullErrorMessage()
        {
            var field = new CustomField();
            field.Label = "Field1";
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.String);
            field.IsRequired = true;

            var result = new ValidationResult();
            field.Validate(null, result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual("Field1 is a required field.", result.Errors.FirstOrDefault()?.Message);
        }

        [TestMethod]
        public void CustomField_Required_Empty_Invalid()
        {
            var field = new CustomField();
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.String);
            field.IsRequired = true;

            var result = new ValidationResult();
            field.Validate(String.Empty, result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(1, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_Required_ValidDate()
        {
            var field = new CustomField();
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.DateTime);
            field.IsRequired = true;

            var result = new ValidationResult();
            field.Validate(DateTime.UtcNow.ToJSONString(), result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(0, result.Errors.Count);
        }


        [TestMethod]
        public void CustomField_Required_InvalidDate()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.DateTime);

            var result = new ValidationResult();
            field.Validate("Fadfadf234", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(1, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_GeoLocation_Valid()
        {
            var field = new CustomField();
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.GeoLocation);
            field.Label = "My GeoLocation";
            field.IsRequired = true;

            var result = new ValidationResult();
            field.Validate("-32.42411,44.423422", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(0, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_GeoLocation_Invalid()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.Label = "My GeoLocation";
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.GeoLocation);

            var result = new ValidationResult();
            field.Validate("-32.424X1,44.42422", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(1, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_GeoLocation_Invalid2()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.Label = "My GeoLocation";
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.GeoLocation);

            var result = new ValidationResult();
            field.Validate("-100.42431,44.42422", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(1, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_Required_ValidState()
        {
            var field = new CustomField();
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.State);
            field.Label = "Field1";
            field.IsRequired = true;
            field.StateSet = new Core.Models.EntityHeader<StateSet>()
            {
                Id = Guid.NewGuid().ToId(),
                Text = "muystateset",
                Value = new StateSet()
                {
                    States = new List<State>()
                    {
                        new State()
                        {
                            Key = "state1"
                        }
                    }
                }
            };

            var result = new ValidationResult();
            field.Validate("state1", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(0, result.Errors.Count);
        }


        [TestMethod]
        public void CustomField_Required_InvalidState()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.Label = "Field1";
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.State);
            field.StateSet = new Core.Models.EntityHeader<StateSet>()
            {
                Id = Guid.NewGuid().ToId(),
                Text = "muystateset",
                Value = new StateSet()
                {
                    States = new List<State>()
                    {
                        new State()
                        {
                            Key = "state1"
                        }
                    }
                }
            };

            var result = new ValidationResult();
            field.Validate("state2", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(1, result.Errors.Count);
        }


        [TestMethod]
        public void CustomField_Required_ValidDecimal()
        {
            var field = new CustomField();
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.Decimal);
            field.IsRequired = true;

            var result = new ValidationResult();
            field.Validate("32.5", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(0, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_Required_InvalidDecimal()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.Decimal);

            var result = new ValidationResult();
            field.Validate("Fadfadf234", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(1, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_Required_ValidValueWithUnit()
        {
            var field = new CustomField();
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.ValueWithUnit);
            field.IsRequired = true;

            var result = new ValidationResult();
            field.Validate("32.5", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(0, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_Required_InvalidValidWithUnit()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.ValueWithUnit);

            var result = new ValidationResult();
            field.Validate("Fadfadf234", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(1, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_Required_ValidInteger()
        {
            var field = new CustomField();
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.Integer);
            field.IsRequired = true;

            var result = new ValidationResult();
            field.Validate("32", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(0, result.Errors.Count);
        }
        
        [TestMethod]
        public void CustomField_Required_InvalidInteger()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.Integer);

            var result = new ValidationResult();
            field.Validate("Fadfadf234", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(1, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_Required_ValidTrue()
        {
            var field = new CustomField();
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.TrueFalse);
            field.IsRequired = true;

            var result = new ValidationResult();
            field.Validate("true", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(0, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_Required_ValidFalse()
        {
            var field = new CustomField();
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.TrueFalse);
            field.IsRequired = true;

            var result = new ValidationResult();
            field.Validate("false", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(0, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_Required_InvalidTrueFalse()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.TrueFalse);

            var result = new ValidationResult();
            field.Validate("Fadfadf234", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(1, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_Required_ValidMinValue_Decimal()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.MinValue = 50;
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.Decimal);

            var result = new ValidationResult();
            field.Validate("64", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(0, result.Errors.Count);
        }


        [TestMethod]
        public void CustomField_Required_ValidMaxValue_Decimal()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.MaxValue = 100;
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.Decimal);

            var result = new ValidationResult();
            field.Validate("98.3", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(0, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_Required_ValidMinValue_Integer()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.MinValue = 22;
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.Integer);

            var result = new ValidationResult();
            field.Validate("44", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(0, result.Errors.Count);
        }


        [TestMethod]
        public void CustomField_Required_ValidMaxValue_Integer()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.MaxValue = 100;
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.Integer);

            var result = new ValidationResult();
            field.Validate("95", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(0, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_Required_ValidMinValue_ValueWithUnit()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.MinValue = 42;
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.ValueWithUnit);

            var result = new ValidationResult();
            field.Validate("55.5", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(0, result.Errors.Count);
        }


        [TestMethod]
        public void CustomField_Required_ValidMaxValue_ValueWithUnit()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.MaxValue = 100;
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.ValueWithUnit);

            var result = new ValidationResult();
            field.Validate("87.4", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(0, result.Errors.Count);
        }


        [TestMethod]
        public void CustomField_Required_InvalidMinValue_Decimal()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.MinValue = 42;
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.Decimal);

            var result = new ValidationResult();
            field.Validate("33.3", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(1, result.Errors.Count);
        }


        [TestMethod]
        public void CustomField_Required_InvalidMaxValue_Decimal()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.MaxValue = 100;
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.Decimal);

            var result = new ValidationResult();
            field.Validate("102.3", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(1, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_Required_InvalidMinValue_Integer()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.MinValue = 42;
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.Integer);

            var result = new ValidationResult();
            field.Validate("35", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(1, result.Errors.Count);
        }


        [TestMethod]
        public void CustomField_Required_InvalidMaxValue_Integer()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.MaxValue = 100;
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.Integer);

            var result = new ValidationResult();
            field.Validate("105", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(1, result.Errors.Count);
        }

        [TestMethod]
        public void CustomField_Required_InvalidMinValue_ValueWithUnit()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.MinValue = 42;
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.ValueWithUnit);

            var result = new ValidationResult();
            field.Validate("35.5", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(1, result.Errors.Count);
        }


        [TestMethod]
        public void CustomField_Required_InvalidMaxValue_ValueWithUnit()
        {
            var field = new CustomField();
            field.IsRequired = true;
            field.MaxValue = 100;
            field.FieldType = Core.Models.EntityHeader<ParameterTypes>.Create(ParameterTypes.ValueWithUnit);

            var result = new ValidationResult();
            field.Validate("105.3", result, Actions.Any);
            WriteErrors(result);
            Assert.AreEqual(1, result.Errors.Count);
        }

    }
}
