using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_Lambda
{
    class Listener
    {
        public void Listener1Func(Object o, MyEventArgs e) 
        {
            Console.WriteLine("In Listener1Func. received arguments: {0}, {1} from object: {2}", e.X, e.Y, o);
        }

        public void Listener2Func(Object o, MyEventArgs e)
        {
            Console.WriteLine("In Listener2Func. received arguments: {0}, {1} from object: {2}", e.X, e.Y, o);
        }
    }
}
