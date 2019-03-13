using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Strategy
{
    abstract class Duck
    {
        //protected IFlyBehaviour _fly;
        protected IQuackBehaviour _quackBehavior;

        public void SetQuackBehavior(IQuackBehaviour newQuackBehavior)
        {
            _quackBehavior = newQuackBehavior;
        }

        public abstract void Display();
        public void Swim()
        {
            Console.WriteLine("I'm swimming la la la");
        }

        public void PerformQuack()
        {
            _quackBehavior.DoQuack();
        }

    }
}
