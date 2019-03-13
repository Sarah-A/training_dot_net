using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Heap
{
    public enum HeapType { MIN_HEAP, MAX_HEAP};

    public class Heap
    {
        private ArrayList _heap = new ArrayList();
        private HeapType _heapType;

        // TODO: should use lambda and/or delegates to make this more elegant.
        private bool ShouldSwitch(int val1, int val2)
        {
            if(_heapType == HeapType.MAX_HEAP)
            {
                return (val1 < val2);
            }
            else
            {
                return (val1 > val2);
            }
        }

        private int GetLeftChild(int node)
        {
            int lChild = (node * 2) + 1;

            if(_heap.Count <= lChild)
            {
                return -1;
            }
            else
            {
                return lChild;
            }
        }

        private int GetRightChild(int node)
        {
            int rChild = (node + 1) * 2;

            if (_heap.Count <= rChild)
            {
                return -1;
            }
            else
            {
                return rChild;
            }
        }
        
        private int GetParent(int node)
        {
            if(node > 0)
            {
                return ((node - 1) / 2);
            }
            else
            {
                return -1;
            }
        }

        public Heap(HeapType heapType = HeapType.MAX_HEAP) 
        {
            // todo - need to choose comparison algorithm instead.
            _heapType = heapType;
        }

        public Heap(int[] fromArray, HeapType heapType = HeapType.MAX_HEAP)
        {
            _heapType = heapType;

            foreach(int val in fromArray)
            {
                Insert(val);
            }
        }

        private int GetNextIndx(int indx)
        {
            if(_heapType == HeapType.MAX_HEAP)
            {
                return GetMaxIndx(indx);
            }
            else 
            {
                return GetMinIndx(indx);
            }
        }

        private int GetMaxIndx(int indx)
        {
            int rIndx = GetRightChild(indx);
            int lIndx = GetLeftChild(indx);
            int maxChild;

            if(rIndx < 0)
            {
                if(lIndx < 0)
                {
                    return -1;
                }
                else
                {
                    maxChild = lIndx;
                }
            }
            else 
            { 
                maxChild = ((int)_heap[rIndx] > (int)_heap[lIndx]) ? rIndx : lIndx;
            }

            if((int)_heap[maxChild] > (int)_heap[indx])
            {
                return maxChild;
            }
            else
            {
                return -1;
            }
        }

        private int GetMinIndx(int indx)
        {
            int rIndx = GetRightChild(indx);
            int lIndx = GetLeftChild(indx);
            int minChild;

            if (rIndx < 0)
            {
                if (lIndx < 0)
                {
                    return -1;
                }
                else
                {
                    minChild = lIndx;
                }
            }
            else
            {
                minChild = ((int)_heap[rIndx] < (int)_heap[lIndx]) ? rIndx : lIndx;
            }

            if ((int)_heap[minChild] < (int)_heap[indx])
            {
                return minChild;
            }
            else
            {
                return -1;
            }
        }

        private void Heapify(int node)
        {
            int maxIndx = -1;

            while((maxIndx = GetNextIndx(node) ) != -1)
            {
                object tmp = _heap[maxIndx];
                _heap[maxIndx] = _heap[node];
                _heap[node] = tmp;
                node = maxIndx;
            }
        }
                       
        public int[] GetArray()
        {
            int[] arr = new int[_heap.Count];
            _heap.CopyTo(arr);
            return arr;
        }

        public void Insert(int newVal)
        {
            _heap.Add(newVal);

            int node = _heap.Count - 1;
            bool switched = true;

            while( switched && (node > 0) )
            {
                int parent = GetParent(node);
                if(ShouldSwitch((int)_heap[parent] , (int)_heap[node]))
                {
                    SwitchElements(node, parent);
                    node = parent;
                }
                else 
                {
                    switched = false;
                }
                
            }
        }

        private void SwitchElements(int indx1, int indx2)
        {
            Object tmp = _heap[indx2];
            _heap[indx2] = _heap[indx1];
            _heap[indx1] = tmp;
        }


        public object GetNext()
        {
            return _heap[0];
        }

        public object RemoveNext()
        {
            object next = GetNext();
            _heap.Remove(next);
            Heapify((_heap.Count - 1) / 2);
            return next;
        }
    }
}
