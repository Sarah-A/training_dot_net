﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_Events_NoArgs
{
    class Subscriber2
    {
        public void RegisterForNewUser(NewUserBroadcaster broadcaster)
        {
            broadcaster.NewUserEvent += DoOnNewUser;
        }

        public void UnRegisterForNewUser(NewUserBroadcaster broadcaster)
        {
            broadcaster.NewUserEvent -= DoOnNewUser;
        }

        private void DoOnNewUser(object sender, EventArgs e)
        {
            Console.WriteLine("*** In Subscriber 2. Recieved OnNewUser Event. Event args id empty");
        }
    }
}
