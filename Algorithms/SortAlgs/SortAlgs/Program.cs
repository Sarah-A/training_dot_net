using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SortAlgs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 5, 9, 3, 6, 17, 29, 24, 21, 35, 7 };
            ArrayList lstArr = new ArrayList(arr);

            Console.WriteLine("Original array: ");
            PrintArrayList(lstArr);
            QuickSort.Sort(lstArr);
            Console.WriteLine("Sorted array: ");
            PrintArrayList(lstArr);

            //Console.WriteLine("Original array: {0}", string.Join(" , ", arr));
            //MergeSort.Sort(arr);
            //Console.WriteLine("Sorted array: {0}", string.Join(" , ", arr));
        }

        static private void PrintArrayList( ArrayList lst)
        {
            foreach( int item in lst)
            {
                Console.Write("{0}, ", item);
            }
        }
    }
}
