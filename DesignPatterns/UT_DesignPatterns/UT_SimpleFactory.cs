using System;
using NUnit.Framework;
using DesignPatterns;
//using Moq;

namespace UT_DesignPatterns
{
    [TestFixture]
    public class UT_SimpleFactory
    {
        [Test]
        public void SimpleStoreUT_TestCheesyPizza()
        {
            SimplePizzaStore pizzaStore = new SimplePizzaStore();
            Assert.AreEqual("Preparing Cheesy Pizza\n" +
                            "Baking Cheesy Pizza\n" +
                            "Cutting Cheesy Pizza\n" +
                            "Boxing Cheesy Pizza\n",
                            pizzaStore.OrderPizza("Cheese"));            
        }

        [Test]
        public void SimpleFactoryUT_TestPepperoniPizza()
        {
            IPizza pizza;
            SimplePizzaFactory pizzaFactory = new SimplePizzaFactory();

            pizza = pizzaFactory.CreatePizza("Pepperoni");
            Assert.AreEqual("Preparing Pepperoni Pizza\n", pizza.Prepare());
            Assert.AreEqual("Cutting Pepperoni Pizza\n", pizza.Cut());
            Assert.AreEqual("Baking Pepperoni Pizza\n", pizza.Bake());
            Assert.AreEqual("Boxing Pepperoni Pizza\n", pizza.Box());
        }
    }
}
