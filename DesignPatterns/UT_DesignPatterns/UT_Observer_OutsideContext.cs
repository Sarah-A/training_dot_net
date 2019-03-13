using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using DesignPatterns;

namespace UT_DesignPatterns
{
    [TestClass]
    public class UT_Observer_OC
    {
        [TestMethod]
        public void Observer_OC_SubscriberNotCalledBeforeRegistered()
        {
            Newspaper_OC herald = new Newspaper_OC("Herald");
            Subscriber_OC subscriber1 = new Subscriber_OC();

            // not called before being resistered:
            herald.NewIssue("issue number 1");
            Assert.AreEqual(0, subscriber1.LatestIssueNumber);
        }


       
        [TestMethod]
        public void Observer_OC_OneSubscriber_SubcriberCalled()
        {
            Newspaper_OC herald = new Newspaper_OC("Herald");
            Subscriber_OC subscriber1 = new Subscriber_OC();

            herald.RegisterObserver(subscriber1);
            herald.NewIssue("issue number 1");
            Assert.AreEqual(1, subscriber1.LatestIssueNumber);
        }

        [TestMethod]
        public void Observer_OC_SubscriberNotCalledAfterBeingRemoved()
        {
            Newspaper_OC herald = new Newspaper_OC("Herald");
            Subscriber_OC subscriber1 = new Subscriber_OC();

            herald.RegisterObserver(subscriber1);

            // not called before being resistered:
            herald.NewIssue("issue number 1");
            herald.UnregisterObserver(subscriber1);
            herald.NewIssue("issue number 2");
            Assert.AreEqual(1, subscriber1.LatestIssueNumber);
        }

        [TestMethod]
        public void Observer_OC_TwoSubscribers_SubcribersCalled()
        {
            Newspaper_OC herald = new Newspaper_OC("Herald");
            Subscriber_OC subscriber1 = new Subscriber_OC();
            Subscriber_OC subscriber2 = new Subscriber_OC();

            herald.RegisterObserver(subscriber1);
            herald.RegisterObserver(subscriber2);

            herald.NewIssue("issue number 1");
            herald.NewIssue("issue number 2");

            Assert.AreEqual(2, subscriber1.LatestIssueNumber);
            Assert.AreEqual(2, subscriber2.LatestIssueNumber);

        }

        [TestMethod]
        public void Observer_OC_TwoSubscribers_SubcriberRemoved()
        {
            Newspaper_OC herald = new Newspaper_OC("Herald");
            Subscriber_OC subscriber1 = new Subscriber_OC();
            Subscriber_OC subscriber2 = new Subscriber_OC();

            herald.RegisterObserver(subscriber1);
            herald.RegisterObserver(subscriber2);

            herald.NewIssue("issue number 1");
            herald.UnregisterObserver(subscriber1);
            herald.NewIssue("issue number 2");

            Assert.AreEqual(1, subscriber1.LatestIssueNumber);
            Assert.AreEqual(2, subscriber2.LatestIssueNumber);

        }

        // Todo: 
        // 1. remove newspaper from subscriber. Instead - update will receive newspaper.
        //    also do the subscriber and remove_subscriber from the outside (context code).
        //    in order to test that a subscriber was removed successfully
        //    !! This (above is problematic since 
        // Add another example using C# built-in Observable class
    }
}

// todo: how to mock a function cll on a real object?