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
        public void Test_AwaitOnCallBlocksRestOfFunction()
        {
            CSLanguageSandbox.CS_Async asyncObj = new CSLanguageSandbox.CS_Async();
            
            var asyncOperationTask = Task.Run<double>(async () => 
                                                await asyncObj.TestAsyncWithAwait(5));
            Assert.AreEqual(0, asyncOperationTask.Result);            
        }

        [Test]
        public void Test_AwaitAtEndOfFunction()
        {
            CSLanguageSandbox.CS_Async asyncObj = new CSLanguageSandbox.CS_Async();

            var asyncOperationTask = Task.Run<double>(async () =>
                                                await asyncObj.TestAwaitAtEnd(5));
            Assert.AreEqual(5, asyncOperationTask.Result);
        }
    }
}
