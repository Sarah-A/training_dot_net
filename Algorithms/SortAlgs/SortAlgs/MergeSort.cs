using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgs
{
    public class MergeSort
    {
        public static void Sort(int[] arr)
        {
            if(arr.Length > 1)
            {
                Sort(arr, 0, arr.Length - 1);
            }
        }

        private static void Sort(int[] arr, int fromIndx, int toIndx)
        {
                   
            if (fromIndx == toIndx)
                return;

            int midIndx = (fromIndx + toIndx) / 2;

            Sort(arr, fromIndx, midIndx);
            Sort(arr, midIndx + 1, toIndx);

            Merge(arr, fromIndx, midIndx, toIndx );

            

        }

        private static void Merge(int[] arr, int fromIndx, int midIndx, int toIndx)
        {
            int len = toIndx - fromIndx + 1;
            int leftIndx = fromIndx;
            int rightIndx = midIndx + 1;
            int tempIndx = 0;
            int[] tempArr = new int[len];

            while ((leftIndx <= midIndx) && (rightIndx <= toIndx))
            {
                if (arr[leftIndx] <= arr[rightIndx])
                {
                    tempArr[tempIndx++] = arr[leftIndx++];
                }
                else
                {
                    tempArr[tempIndx++] = arr[rightIndx++];
                }
            }
            Array.Copy(arr, leftIndx, tempArr, tempIndx, midIndx - leftIndx + 1);
            Array.Copy(arr, rightIndx, tempArr, tempIndx, toIndx - rightIndx + 1);

            Array.Copy(tempArr, 0, arr, fromIndx, tempArr.Length);
        }
    }
}
