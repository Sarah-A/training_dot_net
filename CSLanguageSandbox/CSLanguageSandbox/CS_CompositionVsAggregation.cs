using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_CompositionVsAggregation
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

        // Employee has a composition relation with AddressInfo since:
        // You can't have an Employee without an address and when the Employee is deleted,
        // so does its address.
        public AddressInfo Address { get; set; }

        // Employee has an aggregation relationship with InsuranceInfo since:
        // You CAN have an Employee without an insurnace. and the Insurance lifespan is
        // independent of the employee. You can create and distroy insurance while the 
        // employee still exist.
        public InsuranceInfo Insurance { get; set; }

        public Employee(string name, string street, string city, string state, string postalCode)
        {
            Name = name;
            Address = new AddressInfo()
            {
                Street = street,
                City = city,
                State = state,
                PostalCode = postalCode
            };
        }

        public override string ToString()
        {
            string retVal = Name + " " +
                            Address.Street + " " +
                            Address.City + " " +
                            Address.State + " " +
                            Address.PostalCode;

            if (Insurance != null)
            {
                retVal += " " + Insurance.PolicyName +
                          " " + Insurance.PolicyId;
            }

            return retVal;

        }
    }
}
