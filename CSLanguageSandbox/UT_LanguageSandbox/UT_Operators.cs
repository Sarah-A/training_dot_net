using System;
using NUnit.Framework;
using CSLanguageSandbox;

namespace UT_LanguageSandbox
{
    [TestFixture]
    public class UT_Operators
    {
        [Test]
        public void NullOperation_When_InitWithNull_ShouldInitToNull()
        {
            string nullValue = null;
            var val = nullValue?.Length;
            Assert.AreEqual(null, val);
        }

        [Test]
        public void NullOperation_When_InitWithValue_ShouldInitToValue()
        {
            string nullValue = "test";
            var val = nullValue?.Length;
            Assert.AreEqual(4, val);
        }

        [Test]
        public void NullOperation_When_AssignedWithNull_ShouldAssignToNull()
        {
            string nullValue = null;
            int? val = 5;
            val = nullValue?.Length;
            Assert.AreEqual(5, val);
        }
    }
}
