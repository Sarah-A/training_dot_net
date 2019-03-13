using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IntList iList_BubbleSort = new IntList(new Sorting_BubbleSort());
            iList_BubbleSort.Sort();
            iList_BubbleSort.Print();


            IntList iList_QuickSort = new IntList(new Sorting_QuickSort());
            iList_QuickSort.Sort();
            iList_QuickSort.Print();


            
        }
                
    }
}
