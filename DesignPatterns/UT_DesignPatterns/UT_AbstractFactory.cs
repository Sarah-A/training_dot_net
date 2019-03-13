using System;
using NUnit.Framework;
using DesignPatterns;

// TODO: Review SimpleFactory code + UT and move what is required here.

namespace UT_DesignPatterns
{
    [TestFixture]
    public class UT_AbstractFactory
    {
        [Test]
        public void AbstractStoreUT_TestNyStore()
        {
            PizzaStoreFactory pizzaStoreFactory = new PizzaStoreFactory();
            IPizzaStore pizzaStore = pizzaStoreFactory.CreateStore("New York");

            Assert.AreEqual("Preparing NY Style Cheesy Pizza\n" +
                           "Baking NY Style Cheesy Pizza\n" +
                           "Cutting NY Style Cheesy Pizza\n" +
                           "Boxing NY Style Cheesy Pizza\n",
                           pizzaStore.OrderPizza("Cheese"));


            Assert.AreEqual("Preparing NY Style Pepperoni Pizza\n" +
                           "Baking NY Style Pepperoni Pizza\n" +
                           "Cutting NY Style Pepperoni Pizza\n" +
                           "Boxing NY Style Pepperoni Pizza\n",
                           pizzaStore.OrderPizza("Pepperoni"));
        }

        //[Test]
        //public void AbstractStoreUT_TestChicagoStore()
        //{
        //    IPizzaStore chicagoPizzaStore = new ChicagoPizzaStore();

        //    Assert.AreEqual("Preparing Chicago Style Cheesy Pizza\n" +
        //                   "Baking Chicago Style Cheesy Pizza\n" +
        //                   "Cutting Chicago Style Cheesy Pizza\n" +
        //                   "Boxing Chicago Style Cheesy Pizza\n",
        //                   chicagoPizzaStore.OrderPizza("Cheese"));


        //    Assert.AreEqual("Preparing Chicago Style Pepperoni Pizza\n" +
        //                   "Baking Chicago Style Pepperoni Pizza\n" +
        //                   "Cutting Chicago Style Pepperoni Pizza\n" +
        //                   "Boxing Chicago Style Pepperoni Pizza\n",
        //                   chicagoPizzaStore.OrderPizza("Pepperoni"));
        //}
    }
}
