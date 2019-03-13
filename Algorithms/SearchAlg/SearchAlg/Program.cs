using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlg
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 4, 6, 8, 12, 15, 16, 35, 37, 95 };
            Console.WriteLine("Array: {0}", string.Join(", ", arr));
            SearchAndWrite(arr, 5);
            SearchAndWrite(arr, 8);
            SearchAndWrite(arr, 15);
            SearchAndWrite(arr, 95); 
        }

        private static void SearchAndWrite(int[] arr, int val)
        {
            Console.WriteLine("value: {0} in place: {1}", val, BinarySearch.Search(arr,val));
        }
    }
}
