using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_Strategy
{
    class Sorting_BubbleSort : ISortingStrategy
    {
        public void Sort(int[] list)
        {
            Console.WriteLine("Using BubbleSort");
            BubbleSort(list, 0, list.Length-1);
        }

        private void BubbleSort(int[] list, int startIndx, int endIndx)
        {
            if (startIndx == endIndx)
            {
                return;
            }
            BubbleSort(list, startIndx, endIndx - 1);
            int elementToSort = list[endIndx];
            int i = endIndx - 1;
            while((i >= 0) && (list[i] > elementToSort))
            {
                list[i + 1] = list[i];
                --i;
            }
            list[i + 1] = elementToSort;
        }
    }
}
