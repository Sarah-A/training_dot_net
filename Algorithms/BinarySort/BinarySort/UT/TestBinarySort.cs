using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace BinarySort.UT
{
    [TestFixture]
    class TestBinarySort
    {

        private void RunAndVerifyTest(int[] testArr, int[] expectedArr)
        {
            BinarySort_ThroughUT binarySortUT = new BinarySort_ThroughUT();

            binarySortUT.Sort(testArr);

            Assert.AreEqual(expectedArr, testArr);
        }

        [Test]
        public void test_arrayLen0()
        {
            RunAndVerifyTest(new int[0] { }, new int[0] { });
        }

        [Test]
        public void test_arrayLen1()
        {
            RunAndVerifyTest(new int[] { 5 }, new int[] { 5 });            
        }

        [Test]
        public void test_arrayLen2_Unsorted()
        {
            RunAndVerifyTest(new int[] { 7 , 5 }, new int[] { 5 , 7 });  

        }

        [Test]
        public void test_arrayLen2_PriSorted()
        {
            RunAndVerifyTest(new int[] { 5 , 7 }, new int[] { 5, 7 });
        }

        [Test]
        public void test_arrayLen3()
        {
            RunAndVerifyTest(new int[] { 5, 7, 3 }, new int[] {3, 5, 7 });
        }
    }
}
