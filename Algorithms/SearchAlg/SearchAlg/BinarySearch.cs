using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlg
{
    class BinarySearch
    {
        public static int Search(int[] arr, int val)
        {
            if(arr.Length == 0)
                return -1;

            return Search(arr, 0, arr.Length-1, val);
        }

        private static int Search(int[] arr, int fromIndx, int toIndx,int val)
        {
            if(fromIndx == toIndx)
            {
                if (arr[fromIndx] == val)
                    return fromIndx;
                else
                    return -1;
            }

            int midIndx = (fromIndx + toIndx) / 2;
            if(val < arr[midIndx])
            {
                return Search(arr, fromIndx, midIndx, val);
            }
            else if(val > arr[midIndx]) 
            {
                return Search(arr, midIndx + 1, toIndx, val);
            }
            else
            {
                return midIndx;
            }
        }
    }
}
