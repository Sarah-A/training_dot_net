using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using SearchAlg;


namespace UT_SearchAlgs
{
    [TestFixture]
    class UT_BinarySearchWithUT
    {
        [Test]
        public void UT_EmptyArray()
        {
            int[] arr = new int[]{};
            int result = BinarySearchWithUT.Search(arr, 5);

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void UT_ArrayLen1_ValFound()
        {
            int[] arr = new int[] { 5 };
            int result = BinarySearchWithUT.Search(arr, 5);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void UT_ArrayLen1_ValNotFound()
        {
            int[] arr = new int[] { 5 };
            int result = BinarySearchWithUT.Search(arr, 3);

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void UT_ArrayLen2_ValFound1st()
        {
            int[] arr = new int[] { 3, 5 };
            int result = BinarySearchWithUT.Search(arr, 3);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void UT_ArrayLen2_ValFoundLast()
        {
            int[] arr = new int[] { 3, 5 };
            int result = BinarySearchWithUT.Search(arr, 5);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void UT_ArrayLen2_ValFoundMiddleIndx()
        {
            int[] arr = new int[] { 3, 5, 9 };
            int result = BinarySearchWithUT.Search(arr, 5);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void UT_ArrayLen2_ValFoundMiddleIndxPlusOne()
        {
            int[] arr = new int[] { 3, 5, 9 };
            int result = BinarySearchWithUT.Search(arr, 9);

            Assert.AreEqual(2, result);
        }
        
    }
}
