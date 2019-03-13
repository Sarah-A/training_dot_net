using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using BinaryTree;


namespace UT_BinaryTree
{
    [TestFixture]
    class UT_BinaryTree
    {
        private BinaryTree<int> tree;

        [SetUp]
        public void SetUp()
        {
            tree = new BinaryTree<int>();
        }
        

        private void InitTree(int[] vals)
        {            
            foreach(int val in vals)
            {
                tree.Add(val);
            }
        }

        [Test]
        public void UT_EmptyTree_GetLen()
        {
            InitTree(new int[] { });
           Assert.AreEqual(0, tree.Count);
        }

        [Test]
        public void UT_EmptyTree_GetVal()
        {
            InitTree(new int[] { });
            Assert.AreEqual(new int[] { }, tree.GetSortedVals());
        }

        [Test]
        public void UT_TreeLen1_GetLen()
        {
            InitTree(new int[] { 5 });
            Assert.AreEqual(1, tree.Count);
        }

        [Test]
        public void UT_TreeLen1_GetSortedVals()
        {
            InitTree(new int[] { 5 });
            Assert.AreEqual(new int[] {5} , tree.GetSortedVals());
        }
        

    }
}
