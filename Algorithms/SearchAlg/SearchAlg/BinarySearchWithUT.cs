using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlg
{
    public class BinarySearchWithUT
    {
        public static int Search(int[] arr, int val)
        {
            
            int len = arr.Length;
            int fromIndx = 0;
            int toIndx = len - 1;
            
            while(len > 1)
            {
                int midIndx = (toIndx + fromIndx) / 2;
                if( val <= arr[midIndx])
                {
                    toIndx = midIndx;                    
                }
                else
                {
                    fromIndx = midIndx + 1;
                }
                len = toIndx - fromIndx + 1;
            }

            if( (len > 0) && (arr[fromIndx] == val))
                return fromIndx;
            else
                return -1;
            
        }
    }
}
