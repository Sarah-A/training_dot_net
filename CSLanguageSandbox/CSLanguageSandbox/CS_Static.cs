using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLanguageSandbox
{
    class CS_Static
    {
        public static int myStaticField = 5;

        static public int MyStaticFunction()
        {
            Console.WriteLine($"Returning the value of myStaticField: ${myStaticField}");
            return myStaticField;
        }
    }
}
