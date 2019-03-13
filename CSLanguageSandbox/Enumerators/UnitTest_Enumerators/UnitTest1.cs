using System;
using NUnit.Framework;
using Enumerators;

namespace UnitTest_Enumerators
{
    [TestFixture]
    public class Test_Person
    {
        [Test]
        public void TestCompare_SameSurnameDifferentNames()
        {
            Person person1 = new Person("Abe", "Ashri");
            Person person2 = new Person("Sarah", "Ashri");
                        
            Assert.AreEqual(-1, person1.CompareTo(person2));
            Assert.AreEqual(1, person2.CompareTo(person1));
        }

        [Test]
        public void TestCompare_SameSurnameNames()
        {
            Person person1 = new Person("Abe", "Ashri");
            Person person2 = new Person("Abe", "Ashri");

            Assert.AreEqual(0, person1.CompareTo(person2));
            
        }

        
    }
}
