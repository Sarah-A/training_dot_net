using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_Events_WithArgs
{
    public class NewUserEventArgs : System.EventArgs
    {
        public readonly string userName;
        public readonly int userAge;

        public NewUserEventArgs(string name, int age)
        {
            userName = name;
            userAge = age;
        }
    }
}
