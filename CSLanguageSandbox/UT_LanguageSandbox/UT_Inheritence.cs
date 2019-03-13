using System;
using NUnit.Framework;
using CS_Inheritence;
using System.Collections.Generic;

namespace UT_LanguageSandbox
{
    [TestFixture]
    public class UT_Inheritence
    {
        [Test]
        public void TestListOfEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string workResult = "";
            
            employees.Add(new Employee("Joe", "Cook", "Haifa", "New York", "5376"));
            employees.Add(new Manager("Dave", "Base", "Miami", "Florida", "5227"));

            foreach (Employee emp in employees)
            {
                workResult += emp.DoWork() + " ";                
            }
            Assert.AreEqual("Employee doing work! Manager doing work! ", workResult);
            Assert.AreEqual("Name: Joe Address: Cook, Haifa, New York, 5376 Salary: 5000",
                            employees[0].ToString());
        }
    }
}
