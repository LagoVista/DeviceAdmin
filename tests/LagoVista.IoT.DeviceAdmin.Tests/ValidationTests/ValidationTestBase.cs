// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: f7d3df0d72d05472a9be466456bb6efbc9264aaed99efa9be14a3dd469d490d5
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Core.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Tests.ValidationTests
{
    public class ValidationTestBase
    {
        protected void WriteResults(ValidationResult result)
        {
            Console.WriteLine("Errors (Expected if test Passed");
            Console.WriteLine("==================================================");

            foreach (var err in result.Errors)
            {
                Console.WriteLine(err.Message);
            }

            Console.WriteLine("");
            Console.WriteLine("Warnings (Expected if test Passed");
            Console.WriteLine("==================================================");

            if (result.Warnings.Count > 0)
            {
                foreach (var err in result.Warnings)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }

        protected void AssertIsValid(ValidationResult result)
        {
            WriteResults(result);
            Assert.IsTrue(result.Successful);
        }


        protected void AssertIsInValid(ValidationResult result, int errorCount = 1, int warningCount = 0)
        {
            WriteResults(result);
            Assert.IsFalse(result.Successful);
            //TODO: Right now we are just checking for valid/invalid, to do thig 100% right we should make sure the error message is the one expected for the condition, our error messages needs to be put into resources and use formatting for parameters to ensure this works right, right now we just assume that there is one error...short cut, probalby burn us, but need to ship!
            Assert.AreEqual(errorCount, result.Errors.Count);
            Assert.AreEqual(warningCount, result.Warnings.Count);
        }
    }
}
