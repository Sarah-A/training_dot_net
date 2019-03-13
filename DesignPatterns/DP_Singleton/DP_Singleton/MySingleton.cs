using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Singleton
{
    public class MySingleton
    {
        private static int _counter = 0;
        private static MySingleton _singletonObject;
        private string _testVal;

        private MySingleton(string newVal)
        {
           this._testVal = newVal;
        }

        public static MySingleton GetSingleton(string newVal)
        {
            if(_counter == 0)
            {
                ++_counter;
                _singletonObject = new MySingleton(newVal);
            }
            return _singletonObject;
        }

        public void Print()
        {
            Console.WriteLine(_testVal);
        }
    }
}
