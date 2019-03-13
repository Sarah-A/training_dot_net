using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTypesTests
{
    class TestForLoop
    {
        public void FizzBall()
        {
            bool devBy3_5 = false;
            for (int i = 1; i <= 100; ++i)
            {
                devBy3_5 = false;
                if ((i % 3) == 0)
                {
                    Console.Write("Fizz");
                    devBy3_5 = true;
                }
                if ((i % 5) == 0)
                {
                    Console.Write("Ball");
                    devBy3_5 = true;
                }
                if (!devBy3_5)
                {
                    Console.Write(i);
                }
                Console.WriteLine("");
            }
        }
    }
}
