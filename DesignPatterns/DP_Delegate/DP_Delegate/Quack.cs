using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Strategy
{
    class Quack : IQuackBehaviour
    {
        public void DoQuack()
        {
            Console.WriteLine("Quack Quack Quack");
        }
    }
}
