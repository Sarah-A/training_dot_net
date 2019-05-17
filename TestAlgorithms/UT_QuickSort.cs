using Algorithms;
using Xunit;

namespace TestAlgorithms
{
    public class UT_QuickSort
    {
        [Fact]
        public void TestQuickSortWithEmptyArray()
        {
            int[] arr = new int[] { };
            QuickSort.Sort(arr);
            Assert.Equal<int[]>(new int[]{ }, arr);
        }

        [Fact]
        public void TestQuickSortWithLengthOne()
        {
            int[] arr = new int[] { 5 };
            QuickSort.Sort(arr);
            Assert.Equal<int[]>(new int[] { 5 }, arr);
        }

        [Fact]
        public void TestQuickSortWithLengthTwoSorted()
        {
            int[] arr = new int[] { 5 , 8};
            QuickSort.Sort(arr);
            Assert.Equal<int[]>(new int[] { 5, 8 }, arr);
        }

        [Fact]
        public void TestQuickSortWithLengthTwoUnsorted()
        {
            int[] arr = new int[] { 15, 8 };
            QuickSort.Sort(arr);
            Assert.Equal<int[]>(new int[] { 8, 15 }, arr);
        }

        [Fact]
        public void TestQuickSortWithLongerArray()
        {
            int[] inputArray = new int[] { 25, 8, 12, 31, 10 , 9, 5, 3, 7, 20 , 2 };
            int[] expectedResult = new int[] { 2, 3, 5, 7, 8, 9, 10, 12, 20, 25, 31 };

            QuickSort.Sort(inputArray);
            Assert.Equal<int[]>(expectedResult ,inputArray);
        }

    }
}

