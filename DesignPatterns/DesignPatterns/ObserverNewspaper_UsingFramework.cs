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
//  This file demonstrate the implementation using the C# framework
//*************************************************************************************************************************************

namespace DesignPatterns
{
    public class NewspaperIssue
    {
        public int IssueNumber { get; private set; }
        public string IssueContents { get; private set; }

        public NewspaperIssue(int num, string news)
        {
            this.IssueNumber = num;
            this.IssueContents = news;
        }
    }

    public class Newspaper_FM : IObservable<NewspaperIssue>
    {
        private List<IObserver<NewspaperIssue>> m_observers;
        private List<NewspaperIssue> m_issues;
        public string Name { get; private set; }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<NewspaperIssue>> m_observers;
            private IObserver<NewspaperIssue> m_observer;

            public Unsubscriber(List<IObserver<NewspaperIssue>> observers, IObserver<NewspaperIssue> observer)
            {
                m_observers = observers;
                m_observer = observer;
            }

            public void Dispose()
            {
                if (m_observer != null)
                {
                    m_observers.Remove(m_observer);
                }
            }
        }
        
        public Newspaper_FM(string name)
        {
            Name = name;
            m_observers = new List<IObserver<NewspaperIssue>>();
            m_issues = new List<NewspaperIssue>();
        }

        public IDisposable Subscribe(IObserver<NewspaperIssue> newObserver)
        {
            if (!m_observers.Contains(newObserver))
            {
                m_observers.Add(newObserver);                
            }
            return new Unsubscriber(m_observers, newObserver);
        }

       

        public void NotifyObservers()
        {
            foreach (IObserver<NewspaperIssue> observer in m_observers)
            {
                observer.OnNext(m_issues.Last());
            }
        }

        public void NewIssue(string news)
        {
            Console.WriteLine("issue number: {0}", m_issues.Count.ToString());
            NewspaperIssue newIssue = new NewspaperIssue(m_issues.Count+1, news);
            m_issues.Add(newIssue);
            NotifyObservers();
        }

    }


    public class Subscriber_FM : IObserver<NewspaperIssue>
    {
        public int LatestIssueNumber { get; private set; }

        public Subscriber_FM()
        {
            LatestIssueNumber = 0;
        }

        //  Indicates that the provider has finished sending notifications.
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        // Informs the observer that an error has occurred.
        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(NewspaperIssue value)
        {
            LatestIssueNumber = value.IssueNumber;
        }

        
    }
}
