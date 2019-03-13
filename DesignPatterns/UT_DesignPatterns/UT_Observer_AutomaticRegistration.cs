using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using DesignPatterns;

namespace UT_DesignPatterns
{
    [TestClass]
    public class UT_Observer_AR
    {
        [TestMethod]
        public void Observer_AR_OneSubscriber_SubcriberCalled()
        {
            Newspaper_AR herald = new Newspaper_AR("Herald");
            Subscriber_AR subscriber1 = new Subscriber_AR(herald);
                        
            herald.NewIssue("issue number 1");

            Assert.AreEqual(1, subscriber1.LatestIssueNumber);
            
        }

        [TestMethod]
        public void Observer_AR_TwoSubscribers_SubcribersCalled()
        {
            Newspaper_AR herald = new Newspaper_AR("Herald");
            Subscriber_AR subscriber1 = new Subscriber_AR(herald);
            Subscriber_AR subscriber2 = new Subscriber_AR(herald);

            herald.NewIssue("issue number 1");
            herald.NewIssue("issue number 2");

            Assert.AreEqual(2, subscriber1.LatestIssueNumber);
            Assert.AreEqual(2, subscriber2.LatestIssueNumber);

        }

        // TODO: unsubscribing should be done in the subscriber's destructor - need to test with MOCKS
    }
}

// todo: how to mock a function cll on a real object?