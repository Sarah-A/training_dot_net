using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

/****************************************
 * Todo:
 * Ugly code - improve!!
 * Supprt Returned SortedArray
 */

namespace DS_Heap
{
    [TestFixture]
    public class UT_Heap
    {
        [Test]
        public void Test_EmptyHeap()
        {
            Heap heap = new Heap();
            Assert.AreEqual(new int[] { }, heap.GetArray());
        }

        [Test]
        public void Test_HeapInsertOne()
        {
            Heap heap = new Heap();
            heap.Insert(5);
            Assert.AreEqual(new int[] { 5 }, heap.GetArray());
        }

        [Test]
        public void Test_HeapInsertRemoveOne()
        {
            Heap heap = new Heap();
            heap.Insert(5);
            Assert.AreEqual(5, heap.RemoveNext());
            Assert.AreEqual(new int[] {}, heap.GetArray());
        }


        [Test]
        public void Test_HeapInsertTwo()
        {
            Heap heap = new Heap();
            heap.Insert(8);
            heap.Insert(5);
            Assert.AreEqual(new int[] { 8, 5 }, heap.GetArray());
        }

        [Test]
        public void Test_HeapInsertTwoRemoveOne()
        {
            Heap heap = new Heap(new int[]{8, 5});
            Assert.AreEqual(8, heap.RemoveNext());
            Assert.AreEqual(new int[] { 5 }, heap.GetArray());
        }

        [Test]
        public void Test_HeapInsertTwoAndSort()
        {
            Heap heap = new Heap();
            heap.Insert(5);
            heap.Insert(8);
            Assert.AreEqual(new int[] { 8, 5 }, heap.GetArray());
        }

        [Test]
        public void Test_HeapInsertThreeRemoveOne()
        {
            Heap heap = new Heap(new int[] { 8, 5, 7 });
            Assert.AreEqual(8, heap.RemoveNext());
            Assert.AreEqual(new int[] { 7, 5 }, heap.GetArray());
        }

        [Test]
        public void Test_HeapInsertFiveAndSort()
        {
            Heap heap = new Heap();
            heap.Insert(5);
            heap.Insert(8);
            heap.Insert(10);
            heap.Insert(7);
            heap.Insert(12);
            Assert.AreEqual(new int[] { 12, 10 , 8 , 5 , 7 }, heap.GetArray());
        }

        [Test]
        public void Test_BuildHeapFromArray()
        {
            Heap heap = new Heap(new int[]{5, 8, 10, 7, 12});            
            Assert.AreEqual(new int[] { 12, 10, 8, 5, 7 }, heap.GetArray());
        }

        [Test]
        public void Test_MinHeap()
        {
            Heap heap = new Heap(new int[] { 5, 8, 10, 7, 12 }, HeapType.MIN_HEAP);
            Assert.AreEqual(new int[] { 5, 7 , 10, 8, 12}, heap.GetArray());
        }

        [Test]
        public void Test_MinHeapGetNext()
        {
            Heap heap = new Heap(new int[] { 12, 8, 10, 5, 7 }, HeapType.MIN_HEAP);
            Assert.AreEqual(5, heap.GetNext());
        }

        [Test]
        public void Test_MinHeapRemoveNext()
        {
            Heap heap = new Heap(new int[] { 12, 8, 10, 5, 7 }, HeapType.MIN_HEAP);
            Assert.AreEqual(5, heap.RemoveNext());
            Assert.AreEqual(new int[] { 7, 8, 12 , 10 }, heap.GetArray());
            Assert.AreEqual(7, heap.RemoveNext());
            Assert.AreEqual(8, heap.RemoveNext());
            Assert.AreEqual(10, heap.RemoveNext());
            Assert.AreEqual(12, heap.RemoveNext());
            Assert.AreEqual(new int[] {}, heap.GetArray());
        }

        

        [Test]
        public void Test_MaxHeap()
        {
            Heap heap = new Heap(new int[] { 5, 8, 10, 7, 12 }, HeapType.MAX_HEAP);
            Assert.AreEqual(new int[] { 12, 10, 8, 5 , 7}, heap.GetArray());
        }

        [Test]
        public void Test_MaxHeapGetNext()
        {
            Heap heap = new Heap(new int[] { 5, 8, 10, 7, 12 }, HeapType.MAX_HEAP);
            Assert.AreEqual( 12, heap.GetNext());
        }
    }
}
