using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySort
{
    class BinarySort_Recursion : BinarySort
    {
        public void BinarySort_Sort(int[] array)
        {
                      
            BinarySort(array, 0, array.Length - 1);
        }

        private void BinarySort(int[] array, int fromIndx, int toIndx)
        {
            int arrayLen = toIndx + 1 - fromIndx;

            if( arrayLen < 2)
            {
                return;
            }

            int middleIndx = (fromIndx + toIndx) / 2;
            
            BinarySort(array, fromIndx, middleIndx);
            BinarySort(array, middleIndx + 1, toIndx);

            int orgIndx = fromIndx;
            
            int[] tempArray = new int[arrayLen];
            Array.Copy(array, fromIndx, tempArray, 0, arrayLen);

            int tempArrayLeftIndx = 0;
            int tempArrayMidIndx = middleIndx - fromIndx;
            int tempArrayRightIndx = tempArrayMidIndx + 1;

            while ((tempArrayLeftIndx <= tempArrayMidIndx) && (tempArrayRightIndx <= arrayLen - 1))
            {
                if (tempArray[tempArrayLeftIndx] < tempArray[tempArrayRightIndx])
                {
                    array[orgIndx++] = tempArray[tempArrayLeftIndx++];
                }
                else 
                {
                    array[orgIndx++] = tempArray[tempArrayRightIndx++];
                }
            }
            while (tempArrayLeftIndx <= tempArrayMidIndx)
            {
                array[orgIndx++] = tempArray[tempArrayLeftIndx++];
            }
            while (tempArrayRightIndx < arrayLen - 1)
            {
                array[orgIndx++] = tempArray[tempArrayRightIndx++];
            }

        }
    }
}
