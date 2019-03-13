using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySort
{
    public class BinarySort_ThroughUT
    {
        public void Sort(int[] arr)
        {
            if (arr.Length < 1)
            {
                return;
            }
            BinarySort(arr, 0, arr.Length - 1);            
        }

        private void BinarySort(int[] arr, int fromIndx, int toIndx)
        {
            int len = toIndx - fromIndx + 1;
            if (fromIndx == toIndx) return;

            int midIndx = (fromIndx + toIndx) / 2;

            BinarySort(arr, 0, midIndx);
            BinarySort(arr, midIndx + 1, toIndx);
            
            Merge(arr, fromIndx, midIndx, toIndx);
        }

        private static void Merge(int[] arr, int fromIndx, int midIndx, int toIndx)
        {
            int len = toIndx - fromIndx + 1;
            int[] tempArr = new int[len];

            int rightIndx = fromIndx;
            int leftIndx = midIndx + 1;
            int tempIndx = 0;

            while ((rightIndx <= midIndx) && (leftIndx <= toIndx))
            {
                if (arr[leftIndx] < arr[rightIndx])
                {
                    CopyItemAndProgress(tempArr, ref tempIndx, arr, ref leftIndx);
                }
                else
                {
                    CopyItemAndProgress(tempArr, ref tempIndx, arr, ref rightIndx);
                }
            }
            
            while (leftIndx <= toIndx)
            {
                CopyItemAndProgress(tempArr, ref tempIndx, arr, ref leftIndx);
            }
            while (rightIndx <= midIndx)
            {
                CopyItemAndProgress(tempArr, ref tempIndx, arr, ref rightIndx);
            }

            Array.Copy(tempArr, 0, arr, fromIndx, len);
        }

        private static void CopyItemAndProgress(int[] destArr, ref int destIndx, int[] fromArr, ref int fromIndx)
        {
            destArr[destIndx++] = fromArr[fromIndx++];
        }
    }
}
