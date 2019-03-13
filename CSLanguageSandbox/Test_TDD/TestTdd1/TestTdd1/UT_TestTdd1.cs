using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bank
{
    [TestFixture]
    public class AccountTest
    {
        [Test]
        public void TransferFunds()
        {
            Account source = new Account();
            source.Deposit(200.00F);
            Account destination = new Account();
            destination.Deposit(150.00F);

            source.TransferFunds(destination, 100.00F);
            Assert.AreEqual(250.00F, destination.Balance);
            Assert.AreEqual(100.00F, source.Balance);

        }

        [Test]
        public void DepositFunds()
        {
            Account source = new Account();
            source.Deposit(200.00F);
            Assert.AreEqual(200.00F, source.Balance);
        }

    }
}

namespace UnitTestDemo
{
    public class MyAccountingSoftware
    {

        public static void Main()
        {
            bank.Account DemoAccount = new bank.Account();
            DemoAccount.Deposit(1000.00F);
            DemoAccount.Withdraw(500.50F);
            Console.WriteLine("Our account balance is {0}", DemoAccount.Balance);
        }

    }
}
