using Algorithms;
using Xunit;

namespace TestAlgorithms
{
    public class UT_SortedBinaryTree
    {
        [Fact]
        public void UT_TestSortedBinaryTree()
        {
            var tree = new SortedBinaryTree<int>();
            tree.Add(3);
            tree.Add(7);
            tree.Add(5);
            tree.Add(20);
            tree.Add(9);
            tree.Add(8);
            tree.Add(12);
            tree.Add(35);
            tree.Add(17);
            tree.Add(4);

            var sortedTree = tree.GetSortedVals();
            Assert.Equal<int[]>(new int[] { 3, 4, 5, 7, 8, 9, 12, 17, 20, 35 },
                                sortedTree);

        }
    }
}
