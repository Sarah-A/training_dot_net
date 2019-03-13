using System;
using NUnit.Framework;
using CS_CompositionVsAggregation;

namespace UT_LanguageSandbox
{
    [TestFixture]
    public class UT_CompositionVsAggregation
    {
        [Test]
        public void When_EmployeeWithNoInsurace_SouldReturnValidEmployee()
        {
            Employee joe = new Employee("Joe", "Cook", "Haifa", "New York", "5376");
            Assert.AreEqual("Joe Cook Haifa New York 5376", joe.ToString());
            
        }

        [Test]
        public void When_EmployeeWithInsurace_SouldReturnEmployeeAndInsuracne()
        {
            Employee joe = new Employee("Joe", "Cook", "Haifa", "New York", "5376");
            joe.Insurance = new InsuranceInfo()
            {
                PolicyName = "Life",
                PolicyId = "1234"
            };

            Assert.AreEqual("Joe Cook Haifa New York 5376 Life 1234", joe.ToString());
        }
    }
}
