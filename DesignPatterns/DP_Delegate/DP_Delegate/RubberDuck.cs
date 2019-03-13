using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Strategy
{
    class RubberDuck : Duck
    {
        public RubberDuck()
        {
            _quackBehavior = new Squick();
        }

        public override void Display()
        {
            Console.WriteLine("Hi, I'm a Rubber Duck!");
        }

        
    }
}
