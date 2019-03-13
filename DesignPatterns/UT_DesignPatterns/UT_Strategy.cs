using System;
using NUnit.Framework;

using DesignPatterns;

namespace UT_DesignPatterns
{
    [TestFixture]
    public class UT_Strategy
    {
        [Test]
        public void TestPlainDuck()
        {
            Duck regularDuck = new Duck(new IStrategyCall_Quack());
            Assert.AreEqual("Quack", regularDuck.Call());
        }

        [Test]
        public void TestMulardDuck()
        {
            Duck mulard = new Duck(new IStrategyCall_Qual());
            Assert.AreEqual("Qual", mulard.Call());
        }
    }
}