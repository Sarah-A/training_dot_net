using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Strategy
{
    class MulardDuck : Duck
    {
        public MulardDuck()
        {
            _quackBehavior = new Quack();
        }

        public override void Display()
        {
            Console.WriteLine("Hi, I'm a Mullard Duck!");
        }
    }
}
