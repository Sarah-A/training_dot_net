using Algorithms;
using System;
using Xunit;

namespace TestAlgorithms
{
    public class UT_MinHeap
    {
        [Fact]
        public void UT_TestMinHeap()
        {
            var minHeap = new MinHeap(15);

			// todo: test after each addition with ToArray():

            minHeap.Insert(25);
            minHeap.Insert(8);
            minHeap.Insert(12);
            minHeap.Insert(31);
            minHeap.Insert(10);
            minHeap.Insert(9);
            minHeap.Insert(5);
            minHeap.Insert(3);
            minHeap.Insert(7);
            minHeap.Insert(20);
            minHeap.Insert(2);

            Assert.Equal<int[]>(new int[] { 2, 3, 8, 7, 5, 12, 9, 31, 10, 25, 20 },
								minHeap.ToArray());

            Assert.Equal<int>(2, minHeap.Pop());
            Assert.Equal<int[]>(new int[] { 3, 5, 8, 7, 20, 12, 9, 31, 10, 25 },
                                minHeap.ToArray());

            Assert.Equal<int>(3, minHeap.Pop());
            Assert.Equal<int[]>(new int[] { 5, 7, 8, 10, 20, 12, 9, 31, 25 },
                                minHeap.ToArray());

            Assert.Equal<int>(5, minHeap.Pop());
            Assert.Equal<int[]>(new int[] { 7, 10, 8, 25, 20, 12, 9, 31 },
                                minHeap.ToArray());

            Assert.Equal<int>(7, minHeap.Pop());
            Assert.Equal<int[]>(new int[] { 8, 10, 9, 25, 20, 12, 31 },
                                minHeap.ToArray());

            Assert.Equal<int>(8, minHeap.Pop());
            Assert.Equal<int[]>(new int[] { 9, 10, 12, 25, 20, 31 },
                                minHeap.ToArray());

			// kepp going unti empty.

        }
		
    }
}



/* 
 * TODO:
 * ThrowExceptionOnPopFromEmpty
 * 
 */