using System;
using NUnit.Framework;

using CSLanguageSandbox;
using System.Collections.Generic;

namespace UT_LanguageSandbox
{
    [TestFixture]
    public class UT_ExtenstionMethods
    {
        [Test]
        public void TestStringShout()
        {
            string testString = "my sentence";
            Assert.AreEqual("MY SENTENCE!!!", testString.Shout());


        }
    }
}
