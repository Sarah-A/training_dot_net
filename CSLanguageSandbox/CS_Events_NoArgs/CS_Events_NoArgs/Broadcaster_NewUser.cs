using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_Events_NoArgs
{
    class NewUserBroadcaster
    {
        public event EventHandler NewUserEvent;

        protected virtual void OnNewUserEvent(EventArgs e)
        {
            var temp = NewUserEvent;
            if (temp != null)
            {
                temp(this, e);
            }
        }


        // just a normal procesing function that recognizes a new user:
        public void AddNewUser(string name, int age)
        {
            Console.WriteLine("--- In broadcaster - added a new user:");
            Console.WriteLine("New user: {0} Age: {1}", name, age);
            OnNewUserEvent(EventArgs.Empty);
        }
    }
}
