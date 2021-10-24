using LagoVista.Core.Models;
using LagoVista.Core;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LagoVista.IoT.DeviceAdmin.Tests.ValidationTests
{
    [TestClass]
    public class StateSetValidation : ValidationTestBase
    {
        private StateSet GetStateSet()
        {
            var stateSet = new StateSet();
            stateSet.CreatedBy = EntityHeader.Create(Guid.NewGuid().ToId(), "dontcare");
            stateSet.CreationDate = DateTime.Now.ToJSONString();
            stateSet.LastUpdatedBy = stateSet.CreatedBy;
            stateSet.LastUpdatedDate = stateSet.CreationDate;
            stateSet.Name = "MyStateSet";
            stateSet.Key = "mykey";

            stateSet.States.Add(new State() { Key = "state1", Name = "state1", IsInitialState = true });
            stateSet.States.Add(new State() { Key = "state2", Name = "state1" });

            return stateSet;
        }


        [TestMethod]
        public void StateSet_Valid()
        {
            var stateSet = GetStateSet();
            var result = Validator.Validate(stateSet);

            AssertIsValid(result);
        }

        [TestMethod]
        public void StateSet_EnumerationRequired_Valid()
        {
            var stateSet = GetStateSet();
            stateSet.RequireEnum = true;
            stateSet.States[0].EnumValue = 0;
            stateSet.States[1].EnumValue = 1;
            var result = Validator.Validate(stateSet);

            AssertIsValid(result);
        }

        [TestMethod]
        public void StateSet_EnumerationMissing_InValid()
        {
            var stateSet = GetStateSet();
            stateSet.RequireEnum = true;
            stateSet.States[0].EnumValue = 0;
            stateSet.States[1].EnumValue = null;
            var result = Validator.Validate(stateSet);

            AssertIsInValid(result);
        }

        [TestMethod]
        public void StateSet_EnumerationDuplicate_InValid()
        {
            var stateSet = GetStateSet();
            stateSet.RequireEnum = true;
            stateSet.States[0].EnumValue = 0;
            stateSet.States[1].EnumValue = 0;
            var result = Validator.Validate(stateSet);

            AssertIsInValid(result);
        }

        [TestMethod]
        public void StateSet_DuplicateKey_InValid()
        {
            var stateSet = GetStateSet();
            stateSet.States[1].Key = stateSet.States[0].Key;
            var result = Validator.Validate(stateSet);

            AssertIsInValid(result);
        }

        [TestMethod]
        public void StateSet_NoStates_InValid()
        {
            var stateSet = GetStateSet();
            stateSet.States.Clear();
            var result = Validator.Validate(stateSet);

            AssertIsInValid(result);
        }

        [TestMethod]
        public void StateSet_OneState_InValid()
        {
            var stateSet = GetStateSet();
            stateSet.States.RemoveAt(1);
            var result = Validator.Validate(stateSet);

            AssertIsInValid(result);
        }

        [TestMethod]
        public void StateSet_NoInitialState_InValid()
        {
            var stateSet = GetStateSet();
            stateSet.States[0].IsInitialState = false;
            stateSet.States[1].IsInitialState = false;
            var result = Validator.Validate(stateSet);

            AssertIsInValid(result);
        }

        [TestMethod]
        public void StateSet_TwoInitialStates_InValid()
        {
            var stateSet = GetStateSet();
            stateSet.States[0].IsInitialState = true;
            stateSet.States[1].IsInitialState = true;
            var result = Validator.Validate(stateSet);

            AssertIsInValid(result);
        }        
    }
}
