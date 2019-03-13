using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            MySingleton mySing1 = MySingleton.GetSingleton("obj1");
            MySingleton mySing2 = MySingleton.GetSingleton("obj2");
            MySingleton mySing3 = MySingleton.GetSingleton("obj3");

            mySing1.Print();
            mySing2.Print();
            mySing3.Print();
        }
    }
}
