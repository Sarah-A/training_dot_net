using System;
using NUnit.Framework;
using CSLanguageSandbox;

namespace UT_LanguageSandbox
{
    [TestFixture]
    public class UT_Static
    {
        [Test]
        public void Test_CanCallStaticFunctionWithoutObject()
        {
            Assert.Equals(5, CS_Static.MyStaticFunction());
        }

        [Test]
        public void Test_CantCallStaticFunctionWithObject()
        {
            var myObject = new CS_Static();

            // The following calls will fail compilation:
            //myObject.MyStaticFunction();
            //myObject.myStaticField = 7;

        }
    }
}
