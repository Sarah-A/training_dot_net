using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class QuickSort
    {
        private static void Swap(int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }

        private static int Pivot(int[] arr, int fromIndex, int toIndex)
        {
            int pivot = arr[(fromIndex + toIndex)/2];

            int low = fromIndex;
            int high = toIndex;
            
            while( low <= high )
            {
                while (arr[low] < pivot)
                {
                    low++;
                }

                while  (arr[high] > pivot)
                {
                    high--;
                }
                if( low <= high)
                {
                    Swap(arr, low, high);
                    low++;
                    high--;
                }
            }
            return low;
        }

        private static void SortByIndexes(int[] arr, int fromIndex, int toIndex)
        {
            if (toIndex <= fromIndex)
            {
                return;
            }           
           
            var pivotIndex = Pivot(arr, fromIndex, toIndex);
            SortByIndexes(arr, fromIndex, pivotIndex - 1);
            SortByIndexes(arr, pivotIndex , toIndex);

        }

        public static void Sort(int[] arr)
        {
            SortByIndexes(arr, 0, arr.Length - 1);
        }
    }
}
