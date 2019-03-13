using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTdd.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class Test_Bank
    {
        [Test]
        public void Test_Empty()
        {
            Assert.AreEqual(0, 0);
        }
    }
}
