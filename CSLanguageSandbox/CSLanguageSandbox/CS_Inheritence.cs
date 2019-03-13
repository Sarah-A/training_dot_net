using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Inheritence
{
    public class AddressInfo
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }

    public class InsuranceInfo
    {
        public string PolicyName { get; set; }
        public string PolicyId { get; set; }
    }
    
    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        // Employee has a composition relation with AddressInfo since:
        // You can't have an Employee without an address and when the Employee is deleted,
        // so does its address.
        public AddressInfo Address { get; set; }

        // Employee has an aggregation relationship with InsuranceInfo since:
        // You CAN have an Employee without an insurnace. and the Insurance lifespan is
        // independent of the employee. You can create and distroy insurance while the 
        // employee still exist.
        public InsuranceInfo Insurance { get; set; }

        public Employee(string name, string street, string city, string state, string postalCode, double salary = 5000)
        {
            Name = name;
            Salary = salary;
            Address = new AddressInfo()
            {
                Street = street,
                City = city,
                State = state,
                PostalCode = postalCode
            };
        }

        public virtual string DoWork()
        {
            return "Employee doing work!";
        }

        public override string ToString()
        {
            string retVal = "Name: " + Name + 
                            " Address: " +
                            Address.Street + ", " +
                            Address.City + ", " +
                            Address.State + ", " +
                            Address.PostalCode + " Salary: " + 
                            Salary.ToString();

            if (Insurance != null)
            {
                retVal += " Insurance: " + Insurance.PolicyName +
                          " " + Insurance.PolicyId;
            }

            return retVal;

        }
    }

    public class Manager : Employee
    {
        public Manager(string name, string street, string city, string state, string postalCode)
            : base(name, street, city, state, postalCode)
        { }

        public override string DoWork()
        {
            return "Manager doing work!";
        }

        public string GivePraise()
        {
            return "Manager giving praise";
        }
    }
}
