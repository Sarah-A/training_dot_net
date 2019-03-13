using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_Events_WithArgs
{
    class Subscriber1
    {

        public void RegisterForNewUser(NewUserBroadcaster broadcaster)
        {
            broadcaster.NewUserEvent += DoOnNewUser;
        }

        public void UnRegisterForNewUser(NewUserBroadcaster broadcaster)
        {
            broadcaster.NewUserEvent -= DoOnNewUser;
        }

        private void DoOnNewUser(object sender, NewUserEventArgs e)
        {
            Console.WriteLine("*** In Subscriber 1. Recieved OnNewUser Event.");
            Console.WriteLine("New user: {0} Age: {1}", e.userName, e.userAge);

        }
    }
}
