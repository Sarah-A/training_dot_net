using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace bank
{
    public class Account
    {
        private float balance;
        public void Deposit(float amount)
        {
            balance += amount;
        }

        public void Withdraw(float amount)
        {
            balance -= amount;
        }

        public void TransferFunds(Account destination, float amount)
        {
        }

        public float Balance
        {
            get { return balance; }
        }
    }
}


