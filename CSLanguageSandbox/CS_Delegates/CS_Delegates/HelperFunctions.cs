using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_Delegates
{
    class HelperFunctions
    {
        

        public static void ManipulateAndPrint(int[] vals, IntManipulator d)
        {
            if (d == null)
            {
                Console.WriteLine("Delegate is empty");
                return;
            }
            for (int i = 0; i < vals.Length; ++i)
            {
                Console.WriteLine("Value in index " + i);
                Console.Write(d(ref vals[i]) + " , ");
                Console.WriteLine("");
            }

        }
    }
}
