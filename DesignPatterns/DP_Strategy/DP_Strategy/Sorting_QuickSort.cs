using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_Strategy
{
    class Sorting_QuickSort : ISortingStrategy
    {
        public void Sort(int[] list)
        {
            Console.WriteLine(" Using QuickSort");
            QuickSort(list, 0, list.Length - 1);
        }

        private void QuickSort(int[] list, int startIndx, int endIndx)
        {
            int size = endIndx - startIndx + 1;
            if( size < 2 )
            {
                return;
            }

            int splitIndx = (startIndx + endIndx) / 2;
            QuickSort(list, startIndx, splitIndx);
            QuickSort(list, splitIndx + 1, endIndx);
            int[] newList = new int[size];
            int newListIndx = 0;
            int indx1 = startIndx;
            int indx2 = splitIndx + 1;
            while( (indx1 <= splitIndx) && (indx2 <= endIndx) )
            {
                if (list[indx1] < list[indx2])
                {
                    newList[newListIndx++] = list[indx1++];
                }
                else 
                {
                    newList[newListIndx++] = list[indx2++];
                }
            }
            while (indx1 <= splitIndx)
            {
                newList[newListIndx++] = list[indx1++];
            }
            while (indx2 <= endIndx)
            {
                newList[newListIndx++] = list[indx2++];

            }
            Array.Copy(newList, 0, list, startIndx, size);

        }

        private void Merge(int[] list, int startIndx, int splitIndx, int endIndx)
        { 
            
            

        }

        private void switchElements(int[] list, int indx1, int indx2)
        { 
            int tmp = list[indx2];
            list[indx2] = list[indx1];
            list[indx1] = tmp;
        }

    }
}
