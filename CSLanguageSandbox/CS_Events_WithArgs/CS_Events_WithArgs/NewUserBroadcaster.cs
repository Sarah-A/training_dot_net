using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_Events_WithArgs
{
    //*****************************************************************************************
    // NewUserBroadcaster
    // This is the broadcaster class - the one that knows and fires the NewUser event
    //*****************************************************************************************
    class NewUserBroadcaster
    {
        // the event:
        public event EventHandler<NewUserEventArgs> NewUserEvent;

        // The is the function that fires the event:
        protected virtual void onNewUserEvent(NewUserEventArgs e)
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
            onNewUserEvent(new NewUserEventArgs(name, age));
        }
    }
}
