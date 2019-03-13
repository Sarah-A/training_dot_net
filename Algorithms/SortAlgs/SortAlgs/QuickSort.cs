using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace SortAlgs
{
    class QuickSort
    {
        public static void Sort(ArrayList arr)
        {
            if (arr.Count < 2) return;

            int midIndx = (arr.Count - 1) / 2;
            int midVal = (int)arr[midIndx];

            ArrayList leftArr = new ArrayList();
            ArrayList rightArr = new ArrayList();
 
            for( int i = 0 ; i < arr.Count ; i++)
            {
                if( i == midIndx)
                {
                    continue;
                }
                if ((int)arr[i] <= midVal)
                {
                    leftArr.Add(arr[i]);
                }
                else 
                {
                    rightArr.Add(arr[i]);
                }
            }

            Sort(leftArr);
            Sort(rightArr);

            int j = 0;
            for(int i = 0 ; i < leftArr.Count ; i++)
            {
                arr[j++] = leftArr[i];
            }
            arr[j++] = midVal;
            for(int i = 0 ; i < rightArr.Count ; i++)
            {
                arr[j++] = rightArr[i];
            }

        }
    }
}
