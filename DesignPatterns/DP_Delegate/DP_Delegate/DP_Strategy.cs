using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DP_Strategy
{
    class DP_Strategy
    {
        public static void Main()
        {
            RubberDuck rubberD = new RubberDuck();
            MulardDuck mullardD = new MulardDuck();

            rubberD.Display();
            rubberD.Swim();
            rubberD.PerformQuack();

            mullardD.Display();
            mullardD.Swim();
            mullardD.PerformQuack();

            

        }
    }
}
