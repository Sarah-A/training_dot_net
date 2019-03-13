using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_Lambda
{
    class EventGenerator
    {
        public event EventHandler<MyEventArgs> myEventHandler;

        public void GenerateEvent() 
        {
            
            MyEventArgs e = new MyEventArgs(4, 7);
            Console.WriteLine("Something happened so an event is generated");
            OnEvent(e);
        }

        private void OnEvent(MyEventArgs e)
        {
            var tempHandler = myEventHandler;

            if (tempHandler != null)
            {
                tempHandler(this, e);
            }
            else {
                Console.WriteLine("No events registered!!");
            }
        }

    }
}
