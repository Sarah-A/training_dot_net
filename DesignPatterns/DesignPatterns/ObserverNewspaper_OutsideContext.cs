using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//*************************************************************************************************************************************
//  There are three ways to implement the Observer pattern:
//  1. _OutsideContext
//  This means that the context code that knows about the subject and the observer and connect them together is external to them.
//  In this pattern, the update function passes all the parameters required by the observer.
//  2. _AutomaticRegistration
//      In this option, we pass the subject to the observer's constructor and have it register to it in the constructor and 
//      unregister in the destructor. In this pattern, the update function doesn't get any parameters since the observer can
//      directly access to subject
//  3. _CsFramework
//      This implementation uses the build in C# IObservable framework 
//  This file demonstrate the implementation using the _OutsideContect method
//*************************************************************************************************************************************

namespace DesignPatterns
{    

    //*************************************************************************************************************************************
    // This is the interface of the subject: the thing that the observer observes. The methods it has to support are:
    // RegisterObserver - to add an observer to the observers' list
    // UnregisterObserver - to remove an observer from the observers' list
    // NotifyObservers - to notify all the observers in the list that the event occured.
    //*************************************************************************************************************************************
    public interface ISubject_OC
    {
        void RegisterObserver(IObserver_OC newObserver);
        void UnregisterObserver(IObserver_OC observer);
        void NotifyObservers();
    }

    //*************************************************************************************************************************************
    // A concrete class that implements the ISubject interface.
    // in this case a newspaper - people can subscribe to it (or unsubscribe) and when a new newspapre is published, all subscribers
    // are informed.
    //*************************************************************************************************************************************
    public class Newspaper_OC : ISubject_OC
    {
        public Newspaper_OC(string name)
        {
            Name = name;
            LatestIssueNumber = 0;
            m_observers = new List<IObserver_OC> { };
        }

        public void RegisterObserver(IObserver_OC newObserver)
        {
            m_observers.Add(newObserver);
        }

        public void UnregisterObserver(IObserver_OC observer)
        {
            m_observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (IObserver_OC observer in m_observers)
            {
                observer.Update(LatestIssueNumber, LatestNews);
            }
        }

        public void NewIssue(string news)
        {
            LatestNews = news;
            ++LatestIssueNumber;
            NotifyObservers();
        }
        

        public string ReadNewspaper()
        {
            return string.Format("Newspaper: {0} - {1}\nNews: {2}\n", Name, LatestIssueNumber, LatestNews);
        }

        public string Name { get; private set; }
        public string LatestNews { get; private set; }
        public int LatestIssueNumber { get; private set; }

        private List<IObserver_OC> m_observers;

    }

    //*************************************************************************************************************************************
    /// <summary>
    ///  IObserver - the interface that implement the observer's side of the patter.
    /// Declares the Update method that will be called (in every registered observer) by the subject whenever an event occures.
    /// </summary>
    //*************************************************************************************************************************************
    public interface IObserver_OC
    {
        void Update(int issueNumber, string news);
    }

    //*************************************************************************************************************************************
    /// <summary>
    /// A concrete class of observer.
    /// In this case, a newspapre subscriber.
    /// </summary>
    //*************************************************************************************************************************************
    public class Subscriber_OC : IObserver_OC
    {      
        // public properties:
        public int LatestIssueNumber { get; private set; }
        public string LatestNews { get; private set; }

        // Methods:
        public Subscriber_OC()
        {
            LatestIssueNumber = 0;
            LatestNews = "";
        }

        public void Update(int issueNumber, string news)
        {
            LatestIssueNumber = issueNumber;
            LatestNews = news;
        }
        
    }

   }
