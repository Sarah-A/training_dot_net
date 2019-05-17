using System;

namespace Algorithms
{

	// TODO:
	// * Change internal implementation to be with ArrayList so I won't have length limitation.
	// * Change PropagateValueDown to Heapify and  add build-heap-from-array using Heapify from len/2.
	// * Make a unified Heap for min and max (with a parameter in the constructor)
	// * Make the Heap generic with ICompare
	public class MinHeap
	{
		private int[] _heap;
		public int Length { get; private set; }

		public MinHeap(int size)
		{
			_heap = new int[size];
			Length = 0;
		}

		private int LeftChildIndex(int index) => ((index * 2) + 1);
		private int RightChildIndex(int index) => ((index * 2) + 2);
		private int ParentIndex(int index) => (int)(Math.Floor((double)((index -1) / 2)));
		private bool IsLeaf(int index) => (LeftChildIndex(index) >= Length);

		private void PropagateValueUp(int fromIndex)
		{
			int value = _heap[fromIndex];
			bool swap = true;

			while(swap && (fromIndex > 0) )
			{   
				int parentIndex = ParentIndex(fromIndex);
				if (_heap[parentIndex] > value)
				{
					_heap[fromIndex] = _heap[parentIndex];
					fromIndex = parentIndex;
				}
				else
				{
					swap = false;
				}
			}

			_heap[fromIndex] = value;
		}

		private void PropagateValueDown(int fromIndex)
		{
			int value = _heap[fromIndex];
			bool swap = true;

			while(swap && !IsLeaf(fromIndex) )
			{
				int minChildIndex;
				int leftChildIndex = LeftChildIndex(fromIndex);
				int rightChildIndex = RightChildIndex(fromIndex);

				if ((rightChildIndex >= Length) || (_heap[leftChildIndex] < _heap[rightChildIndex]))
				{
					minChildIndex = leftChildIndex;
				}
				else
				{
					minChildIndex = rightChildIndex;
				}
				if (_heap[minChildIndex] < value )
				{
					_heap[fromIndex] = _heap[minChildIndex];
					fromIndex = minChildIndex;
				}
				else
				{
					swap = false;
				}            
			}

			_heap[fromIndex] = value;
		}

		public void Insert(int newValue)
		{
			if (Length >= _heap.Length)
			{
				throw new System.Exception("Heap is full");
			}

			_heap[Length] = newValue;
			Length++;

			PropagateValueUp(Length - 1);

		}

		public int Pop()
		{
			if (Length == 0)
			{
				throw new System.Exception("Heap Empty");
			}

			int value = _heap[0];
			_heap[0] = _heap[Length - 1];
			Length--;

			PropagateValueDown(0);
            return value;
		}

        public int[] ToArray()
        {
            int[] arr = new int[Length];
            Array.Copy(_heap, arr, Length);
            return arr;
        }
	}
}
