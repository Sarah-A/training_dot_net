using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MoneyCoverter_TddByExample;

namespace UT_MoneyConverter
{
    [TestFixture]
    public class UT_Money
    {
        [Test]
        public void UT_Dollar_5mul2()
        {
            Money mn = new Money(5, "USD");
            Assert.AreEqual(10, mn.Multiply(2));
        }

        [Test]
        public void UT_Dollar_5mul3()
        {
            Money mn = new Money(5, "USD");
            Assert.AreEqual(15, mn.Multiply(3));
        }

        [Test]
        public void UT_Dollar_Equal()
        {
            Money mn1 = new Money(5, "USD");
            Money mn2 = new Money(5, "USD");
            Assert.AreEqual(true, mn1.Equals(mn2));
        }

        [Test]
        public void UT_Dollar_NotEqual()
        {
            Money mn1 = new Money(5, "USD");
            Money mn2 = new Money(6, "USD");
            Assert.AreEqual(false, mn1.Equals(mn2));
        }

        [Test]
        public void UT_NotEqual_DifferentCurrency()
        {
            Money mn1 = new Money(5, "USD");
            Money mn2 = new Money(4.49, "CHF");
            Assert.AreEqual(true, mn1.Equals(mn2));
        }

        [Test]
        public void UT_Equal_DifferentCurrency()
        {
            Money mn1 = new Money(5, "USD");
            Money mn2 = new Money(5, "CHF");
            Assert.AreEqual(false, mn1.Equals(mn2));
        }

        [Test]
        public void UT_Dollar_Sum()
        {
            Money mn1 = new Money(5, "USD");
            Money sum = new Money(11, "USD");
            Assert.AreEqual(sum, mn1.Plus(new Money(6, "USD")));
        }

        [Ignore("First need to implement equal - different currencies")]
        [Test]
        public void UT_Translated_Sum()
        {
            Money mn1 = new Money(5, "USD");
            Money sum = new Money(11, "USD");
            Assert.AreEqual(sum, mn1.Plus(new Money(6, "USD")));
        }
        
    }
}
