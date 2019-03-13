using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Strategy
{
    class Squick : IQuackBehaviour
    {
        public void DoQuack()
        {
            Console.WriteLine("Squick Squick");
        }
    }
}
