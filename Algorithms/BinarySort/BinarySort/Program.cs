using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySort
{
    class Program
    {
    
        static void Main(string[] args)
        {
            // Sort By Recursion
            BinarySort_Recursion sortByRecursion = new BinarySort_Recursion();
            int[] arr = new int[]{17, 13, 8, 6, 11, 5};

            Console.WriteLine("The array before BinarySort_Recursion:");
            Console.Write(string.Join(", ",arr));

            sortByRecursion.BinarySort_Sort(arr);

            Console.WriteLine("The array after BinarySort_Recursion:");
            Console.Write(string.Join(", ",arr));

        }

        

      
    }
}
