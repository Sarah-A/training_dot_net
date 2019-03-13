using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_Strategy
{
    class IntList
    {
        private const int listLen = 11;
        private int[] list = new int[listLen];
        private ISortingStrategy sortingStrategy;

        public IntList(ISortingStrategy sortingStrategy)
        {
            this.sortingStrategy = sortingStrategy;

            Random rng = new Random();
            for (int i = 0; i < listLen; ++i)
            {
                list[i]= rng.Next(0,100);
            }

            Console.WriteLine("Original List:");
            Print();
        }

        public void Print()
        {
            for (int i = 0; i < listLen; ++i)
            {
                Console.Write(list[i]);
                Console.Write(" , ");
            }
            Console.WriteLine("");
        }

        public void Sort()
        {            
            sortingStrategy.Sort(list);
        }
    }
}
