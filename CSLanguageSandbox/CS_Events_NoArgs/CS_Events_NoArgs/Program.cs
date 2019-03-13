using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_Events_NoArgs
{
    class Program
    {
        static void Main(string[] args)
        {
            NewUserBroadcaster broadcaster = new NewUserBroadcaster();
            Subscriber1 sb1 = new Subscriber1();
            Subscriber2 sb2 = new Subscriber2();

            Console.WriteLine("No subscribers yet - expect no printouts");
            broadcaster.AddNewUser("Shula", 5);

            sb1.RegisterForNewUser(broadcaster);
            sb2.RegisterForNewUser(broadcaster);
            sb1.RegisterForNewUser(broadcaster);

            Console.WriteLine("Subscribers: 1,2,1");
            broadcaster.AddNewUser("Yosef", 26);

            Console.WriteLine("Subscribers: 1,2");
            sb1.UnRegisterForNewUser(broadcaster);
            broadcaster.AddNewUser("Booli", 16);
        }
    }
}
