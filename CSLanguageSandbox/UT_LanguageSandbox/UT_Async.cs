using System;
using NUnit.Framework;
using CSLanguageSandbox;
using System.Threading.Tasks;

namespace UT_LanguageSandbox
{
    [TestFixture]
    public class UT_Async
    {
        [Test]
        public void Test_AwaitBlocksRestOfTask()
        {
            CSLanguageSandbox.CS_Async asyncObj = new CSLanguageSandbox.CS_Async();
            
            var asyncOperationTask = Task.Run<double>(async () => 
                                                await asyncObj.TestAwaitAtStart(10));
            Assert.AreEqual(0, asyncOperationTask.Result);            
        }

        [Test]
        public void Test_AwaitAtEndOfFunction()
        {
            CSLanguageSandbox.CS_Async asyncObj = new CSLanguageSandbox.CS_Async();

            var asyncOperationTask = Task.Run<double>(async () =>
                                                await asyncObj.TestAwaitAtEnd(10));
            Assert.AreEqual(10, asyncOperationTask.Result);
        }

        [Test]
        public void Test_AwaitDoesntBlockThread()
        {
            CSLanguageSandbox.CS_Async asyncObj = new CSLanguageSandbox.CS_Async();
            var beforeAsyncCalls = DateTime.Now;

            Task<int> asyncOperationTask1 = asyncObj.TestAwaitAtEnd(10);
            Task<int> asyncOperationTask2 = asyncObj.TestAwaitAtStart(10);

            asyncOperationTask1.Wait();
            asyncOperationTask2.Wait();

            var afterAsyncCalls = DateTime.Now;
            var totalTimeInSeconds = (int)(afterAsyncCalls - beforeAsyncCalls).TotalSeconds;

            Assert.AreEqual(10, totalTimeInSeconds);
        }


        [Test]
        public void Test_SerialExecutionWillTakeFullTime()
        {
            CSLanguageSandbox.CS_Async asyncObj = new CSLanguageSandbox.CS_Async();
            var beforeAsyncCalls = DateTime.Now;

            Task<int> asyncOperationTask1 = asyncObj.TestAwaitAtEnd(10);
            asyncOperationTask1.Wait();

            Task<int> asyncOperationTask2 = asyncObj.TestAwaitAtStart(10);
            asyncOperationTask2.Wait();

            var afterAsyncCalls = DateTime.Now;
            var totalTimeInSeconds = (int)(afterAsyncCalls - beforeAsyncCalls).TotalSeconds;

            Console.WriteLine($"AwaitAtStart: {asyncOperationTask2.Result}, AwaitAtEnd: {asyncOperationTask1.Result}");
            Assert.AreEqual(20, totalTimeInSeconds);
        }
    }
}
