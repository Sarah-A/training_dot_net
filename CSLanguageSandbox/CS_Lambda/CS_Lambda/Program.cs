using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test simple event generation, registration and firing:
            EventGenerator eventGenerator = new EventGenerator();
            Listener listener = new Listener();
            eventGenerator.myEventHandler += listener.Listener1Func;
            eventGenerator.myEventHandler += listener.Listener1Func;
            eventGenerator.myEventHandler += listener.Listener2Func;
            eventGenerator.myEventHandler += (o, e) =>
                                             {
                                                 Console.WriteLine("In Lambda listener. received arguments: {0}, {1} from object: {2}", e.X, e.Y, o);
                                             };


            eventGenerator.GenerateEvent();

            // Test simple lambdas generation and usage:
            //TestSimpleLambdas();

            
        }

        static void TestSimpleLambdas()
        { 
            Executer.ExecuteFunc((x, y) => x + y, 2, 3);
            Executer.ExecuteFunc((x, y) => x * y, 2, 3);
            Executer.ExecuteFunc((x, y) => x - y, 2, 3);
            Executer.ExecuteFunc((x, y) => {
                                            x += 2;
                                            y += 5;
                                            return y;                                            
                                            }, 
                                  2, 3);
        }
    }
}
