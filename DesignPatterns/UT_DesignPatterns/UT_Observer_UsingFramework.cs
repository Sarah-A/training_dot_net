using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using DesignPatterns;

namespace UT_DesignPatterns
{
    [TestClass]
    public class UT_Observer_FR
    {

        [TestMethod]
        public void Observer_FM_SubscriberNotCalledBeforeRegistered()
        {
            Newspaper_FM herald = new Newspaper_FM("Herald");
            Subscriber_FM subscriber1 = new Subscriber_FM();

            // not called before being resistered:
            herald.NewIssue("issue number 1");
            Assert.AreEqual(0, subscriber1.LatestIssueNumber);
        }

        [TestMethod]
        public void Observer_FM_OneSubscriber_SubcriberCalled()
        {
            Newspaper_FM herald = new Newspaper_FM("herald");
            Subscriber_FM subscriber1 = new Subscriber_FM();

            IDisposable unSubscriber1 = herald.Subscribe(subscriber1);

            Console.WriteLine("Testing: {0}", 6.ToString());
            herald.NewIssue("issue number 1");

            Assert.AreEqual(1, subscriber1.LatestIssueNumber);
        }

        [TestMethod]
        public void Observer_FM_SubscriberNotCalledAfterBeingRemoved()
        {
            Newspaper_FM herald = new Newspaper_FM("Herald");
            Subscriber_FM subscriber1 = new Subscriber_FM();

            IDisposable unSubscriber1 = herald.Subscribe(subscriber1);

            // not called before being resistered:
            herald.NewIssue("issue number 1");
            unSubscriber1.Dispose();
            herald.NewIssue("issue number 2");
            Assert.AreEqual(1, subscriber1.LatestIssueNumber);
        }

        [TestMethod]
        public void Observer_FM_TwoSubscribers_SubcribersCalled()
        {
            Newspaper_FM herald = new Newspaper_FM("Herald");
            Subscriber_FM subscriber1 = new Subscriber_FM();
            Subscriber_FM subscriber2 = new Subscriber_FM();

            IDisposable unSubscriber1 = herald.Subscribe(subscriber1);
            IDisposable unSubscriber2 = herald.Subscribe(subscriber2);

            // not called before being resistered:
            herald.NewIssue("issue number 1");
            herald.NewIssue("issue number 2");
            Assert.AreEqual(2, subscriber1.LatestIssueNumber);
            Assert.AreEqual(2, subscriber2.LatestIssueNumber);
        }

        [TestMethod]
        public void Observer_FM_TwoSubscribers_SubcriberRemoved()
        {
            Newspaper_FM herald = new Newspaper_FM("Herald");
            Subscriber_FM subscriber1 = new Subscriber_FM();
            Subscriber_FM subscriber2 = new Subscriber_FM();

            IDisposable unSubscriber1 = herald.Subscribe(subscriber1);
            IDisposable unSubscriber2 = herald.Subscribe(subscriber2);

            // not called before being resistered:
            herald.NewIssue("issue number 1");
            unSubscriber1.Dispose();
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