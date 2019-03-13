using System;
using NUnit.Framework;

using DesignPatterns;

namespace UT_DesignPatterns
{
    [TestFixture]
    public class UT_Decorator
    {
        [Test]        
        public void DecoratorUT_DarkRoast_NoDecorator()
        {
            Beverage beverage = new SmallCup(new DarkRoast());
            Assert.AreEqual("Small Dark Coffee", beverage.Description());
            Assert.AreEqual(5, beverage.Price());
        }

        [Test]
        public void DecoratorUT_DarkRoast_Mocha()
        {
            Beverage beverage = new SmallCup(new Mocha(new DarkRoast()));
            Assert.AreEqual("Small Dark Coffee with a dash of Choco", beverage.Description());
            Assert.AreEqual(6, beverage.Price());
        }

        [Test]
        public void DecoratorUT_Espresso_NoDecorator()
        {
            Beverage beverage = new SmallCup(new Espresso());
            Assert.AreEqual("Small Espresso", beverage.Description());
            Assert.AreEqual(6, beverage.Price());
        }

        [Test]
        public void DecoratorUT_Medium_Espresso_Mocha()
        {
            Beverage beverage = new MediumCup(new Mocha(new Espresso()));
            Assert.AreEqual("Medium Espresso with a dash of Choco", beverage.Description());
            Assert.AreEqual(14, beverage.Price());
        }

        [Test]
        public void DecoratorUT_Espresso_Mocha_Whip_Whip()
        {
            Beverage beverage = new SmallCup(new Whip(new Whip(new Mocha(new Espresso()))));
            Assert.AreEqual("Small Espresso with a dash of Choco with Whip on top with Whip on top", beverage.Description());
            Assert.AreEqual(8, beverage.Price());
        }

        [Test]
        public void DecoratorUT_Large_DarkRoast_Double_Mocha_Whip()
        {
            Beverage beverage = new LargeCup(new Whip(new Whip(new Mocha(new DarkRoast()))));
            Assert.AreEqual("Large Dark Coffee with a dash of Choco with Whip on top with Whip on top", beverage.Description());
            Assert.AreEqual(21, beverage.Price());
        }
    }
}
