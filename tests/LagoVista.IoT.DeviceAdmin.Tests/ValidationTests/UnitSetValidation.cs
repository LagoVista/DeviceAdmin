// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 80620e2956031f42a6a724c2a11676f623c6e2ffaa22df4886ec829b85696a67
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LagoVista.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LagoVista.IoT.DeviceAdmin.Models.Unit;
using LagoVista.Core.Validation;

namespace LagoVista.IoT.DeviceAdmin.Tests.ValidationTests
{
    [TestClass]
    public class UnitSetValidation : ValidationTestBase
    {
        private UnitSet GetUnitSet()
        {
            var unitSet = new UnitSet();
            unitSet.CreatedBy = EntityHeader.Create(Guid.NewGuid().ToId(), "dontcare");
            unitSet.CreationDate = DateTime.Now.ToJSONString();
            unitSet.LastUpdatedBy = unitSet.CreatedBy;
            unitSet.LastUpdatedDate = unitSet.CreationDate;
            unitSet.Name = "MyStateSet";
            unitSet.Key = "mykey";

            unitSet.Units.Add(new Unit() { Key = "unit1", Name = "Unit Number One", IsDefault = true, Abbreviation = "s" });
            unitSet.Units.Add(new Unit() { Key = "unit2", Name = "Unit Number Two", IsDefault = false, ConversionType = EntityHeader<ConversionTypes>.Create(ConversionTypes.Factor), Abbreviation="s2", ConversionFactor = 1.5 });

            return unitSet;
        }

        [TestMethod]
        public void UnitSet_Factor_Valid()
        {
            var unitSet = GetUnitSet();

            var result = Validator.Validate(unitSet);

            AssertIsValid(result);
        }

        [TestMethod]
        public void UnitSet_Script_Valid()
        {
            var unitSet = GetUnitSet();
            unitSet.Units[1].ConversionType = EntityHeader<ConversionTypes>.Create(ConversionTypes.Script);
            unitSet.Units[1].ConversionFactor = null;
            unitSet.Units[1].ConversionToScript = "function convertToDefaultUnit(value: number) {return number;}";
            unitSet.Units[1].ConversionFromScript = "function convertFromDefaultUnit(value: number) {return number;}";

            var result = Validator.Validate(unitSet);

            AssertIsValid(result);
        }

        [TestMethod]
        public void UnitSet_OnUnitSets_Valid()
        {
            var unitSet = GetUnitSet();
            unitSet.Units.RemoveAt(1);
            var result = Validator.Validate(unitSet);

            AssertIsValid(result);
        }

        [TestMethod]
        public void UnitSet_NoUnitSets_InValid()
        {
            var unitSet = GetUnitSet();
            unitSet.Units.Clear();
            var result = Validator.Validate(unitSet);

            AssertIsInValid(result);
        }

        [TestMethod]
        public void UnitSet_MissingUnitKey_InValid()
        {
            var unitSet = GetUnitSet();
            unitSet.Units[1].Key = null;
            var result = Validator.Validate(unitSet);

            AssertIsInValid(result);
        }

        [TestMethod]
        public void UnitSet_DuplicateKeys_InValid()
        {
            var unitSet = GetUnitSet();
            unitSet.Units[1].Key = unitSet.Units[0].Key;
            var result = Validator.Validate(unitSet);

            AssertIsInValid(result);
        }

        [TestMethod]
        public void UnitSet_Duplicate_DefaultUnit_InValid()
        {
            var unitSet = GetUnitSet();
            unitSet.Units[0].IsDefault = true;
            unitSet.Units[1].IsDefault = true;
            var result = Validator.Validate(unitSet);

            AssertIsInValid(result);
        }

        [TestMethod]
        public void UnitSet_No_DefaultUnit_InValid()
        {
            var unitSet = GetUnitSet();
            unitSet.Units[0].IsDefault = false;
            unitSet.Units[0].ConversionType = EntityHeader<ConversionTypes>.Create(ConversionTypes.Factor);
            unitSet.Units[0].ConversionFactor = 2.5;
            unitSet.Units[1].IsDefault = false;
            var result = Validator.Validate(unitSet);

            AssertIsInValid(result);
        }

        [TestMethod]
        public void UnitSet_Unit_MissingConversionType_InValid()
        {
            var unitSet = GetUnitSet();
            unitSet.Units[0].IsDefault = true;
            unitSet.Units[1].IsDefault = false;
            unitSet.Units[1].ConversionFactor = null;
            var result = Validator.Validate(unitSet);

            AssertIsInValid(result);
        }

        [TestMethod]
        public void UnitSet_Unit_Missing_ConversionToScript_InValid()
        {
            var unitSet = GetUnitSet();

            unitSet.Units[1].ConversionType = EntityHeader<ConversionTypes>.Create(ConversionTypes.Script);
            unitSet.Units[1].ConversionFactor = null;
            unitSet.Units[1].ConversionToScript = null;
            unitSet.Units[1].ConversionFromScript = "function convertFromDefaultUnit(value: number) {return number;}";

            var result = Validator.Validate(unitSet);

            AssertIsInValid(result);
        }

        [TestMethod]
        public void UnitSet_Unit_Missing_ConversionFromScript_InValid()
        {
            var unitSet = GetUnitSet();

            unitSet.Units[1].ConversionType = EntityHeader<ConversionTypes>.Create(ConversionTypes.Script);
            unitSet.Units[1].ConversionFactor = null;
            unitSet.Units[1].ConversionToScript = "function convertToDefaultUnit(value: number) {return number;}"; ;
            unitSet.Units[1].ConversionFromScript = null;

            var result = Validator.Validate(unitSet);

            AssertIsInValid(result);
        }

        [TestMethod]
        public void UnitSet_Unit_Invalid_ConversionToScript_InValid()
        {
            var unitSet = GetUnitSet();

            unitSet.Units[1].ConversionType = EntityHeader<ConversionTypes>.Create(ConversionTypes.Script);
            unitSet.Units[1].ConversionFactor = null;
            unitSet.Units[1].ConversionToScript = "function XXXXXX(value: number) {return number;}"; ;
            unitSet.Units[1].ConversionFromScript = "function convertFromDefaultUnit(value: number) {return number;}";

            var result = Validator.Validate(unitSet);

            AssertIsInValid(result);
        }

        [TestMethod]
        public void UnitSet_Unit_Invalid_ConversionFromScript_InValid()
        {
            var unitSet = GetUnitSet();

            unitSet.Units[1].ConversionType = EntityHeader<ConversionTypes>.Create(ConversionTypes.Script);
            unitSet.Units[1].ConversionFactor = null;
            unitSet.Units[1].ConversionToScript = "function convertToDefaultUnit(value: number) {return number;}"; ;
            unitSet.Units[1].ConversionFromScript = "function YYYYYY(value: number) {return number;}";

            var result = Validator.Validate(unitSet);

            AssertIsInValid(result);
        }

    }
}
