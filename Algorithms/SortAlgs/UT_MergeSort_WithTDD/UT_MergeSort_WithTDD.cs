using System;
using NUnit.Framework;
using SortAlgs;

namespace UT_SortAlgs
{
    [TestFixture]
    public class UT_MergeSort_WithTDD
    {
        [Test]
        public void UT_EmptyArray()
        {
            int[] arr = new int[0];
            MergeSort_WithTDD.Sort(arr);

            Assert.AreEqual(new int[0], arr);
        }

        [Test]
        public void UT_ArrayLen1()
        {
            int[] arr = new int[]{5};
            MergeSort_WithTDD.Sort(arr);

            Assert.AreEqual(new int[]{5}, arr);
        }

        [Test]
        public void UT_ArrayLen2_Sorted()
        {
            int[] arr = new int[] { 5 , 7 };
            MergeSort_WithTDD.Sort(arr);

            Assert.AreEqual(new int[] { 5 , 7 }, arr);
        }

        [Test]
        public void UT_ArrayLen2_UnSorted()
        {
            int[] arr = new int[] { 7 , 5 };
            MergeSort_WithTDD.Sort(arr);

            Assert.AreEqual(new int[] { 5, 7 }, arr);
        }

       
    }
}
