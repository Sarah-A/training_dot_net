using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_Lambda
{
    public delegate int TwoArgsComp(int x, int y);

    class Executer
    {
        static public void ExecuteFunc(TwoArgsComp func, int x, int y)
        {
            Console.WriteLine("Executing function: {0} (func) {1} = {2}", x, y, func(x, y));
        }
    }
}
