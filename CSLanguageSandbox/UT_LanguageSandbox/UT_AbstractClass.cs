using System;
using NUnit.Framework;
using CSLanguageSandbox;

namespace UT_LanguageSandbox
{
    [TestFixture]
    public class UT_AbstractClass
    {
        private string AnimalHello(Animal animal)
        {
            return animal.GetHello();
        }

        [Test]
        public void TestAbstractClassWithVar()
        {
            var cat = new Cat("Felix");
            var dog = new Dog("Molly");

            Assert.AreEqual("I'm a cat. My Name is: Felix", AnimalHello(cat));
            Assert.AreEqual("I'm a dog. My Name is: Molly", AnimalHello(dog));

        }

        [Test]
        public void TestAbstractClassWithBase()
        {
            Animal cat = new Cat("Felix");
            Animal dog = new Dog("Molly");

            Assert.AreEqual("I'm a cat. My Name is: Felix", AnimalHello(cat));
            Assert.AreEqual("I'm a dog. My Name is: Molly", AnimalHello(dog));

        }
    }
}
