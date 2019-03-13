using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BinarySort;


namespace BinarySort
{
    [TestFixture]
    class TestBinarySort
    {

        private void RunAndVerifyTest(int[] testArr, int[] expectedArr)
        {
            BinarySort_ThroughUT binarySortUT = new BinarySort_ThroughUT();

            binarySortUT.Sort(testArr);

            //Console.Write(" Sorted array: {0}", string.Join(" , ", testArr));

            Assert.AreEqual(expectedArr, testArr);
        }

        [Test]
        public void test_arrayLen0()
        {
            int[] testArr = new int[0] { };
            int[] expectedArr = new int[0] { };

            RunAndVerifyTest(testArr, expectedArr);
        }

        [Test]
        public void test_arrayLen1()
        {
            int[] testArr = new int[] { 5 };
            int[] expectedArr = new int[] { 5 };

            RunAndVerifyTest(testArr, expectedArr);            
        }

        [Test]
        public void test_arrayLen2_Unsorted()
        {
            int[] testArr = new int[] { 7, 5 };
            int[] expectedArr = new int[] { 5, 7};

            RunAndVerifyTest(testArr, expectedArr);

        }

        [Test]
        public void test_arrayLen2_PriSorted()
        {
            int[] testArr = new int[] { 5, 7 };
            int[] expectedArr = new int[] { 5, 7 };

            RunAndVerifyTest(testArr, expectedArr);
        }

        [Test]
        public void test_arrayLen3()
        {
            int[] testArr = new int[] { 5, 7, 3 };
            int[] expectedArr = new int[] { 3, 5, 7 };

            RunAndVerifyTest(testArr, expectedArr);

        }
    }
}
