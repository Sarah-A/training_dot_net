using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS_Events_Simple
{
    public class TimeEventArgs : EventArgs
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
    }

    public class Clock
    {
        private int hour;
        private int minute;
        private int second;

        // 1 - Define the delegate for the event handlers (see in the subscriber classes):
        //      convention: the delegate name should be <Event>EventHandler
        //public delegate void TimeChangedEventHandler(object clock, TimeEventArgs timeInfo);
        // Defining the delegate is redundant since we can use .Net EventHandler or EventHandler<> instead
        // when defining the event:


        // 2 - Define the event which is a list of event handlers to call when the event occures:
        //      convention: the event name should be describe the event
        //public event TimeChangedEventHandler TimeChanged;
        public event EventHandler<TimeEventArgs> TimeChanged;

        public void RunClock(int times)
        {
            for(int i=0 ; i<times; ++i)
            {
                Thread.Sleep(100);
                DateTime currentTime = DateTime.Now;
                if (currentTime.Second != this.second)
                {
                    TimeEventArgs timeEventArgs = new TimeEventArgs()
                    {
                        Hour = this.hour,
                        Minute = this.minute,
                        Second = this.second
                    };

                    // 5- invoke all the event handlers that subscribed to the event
                    TimeChanged?.Invoke(this, timeEventArgs);

                    this.hour = currentTime.Hour;
                    this.minute = currentTime.Minute;
                    this.second = currentTime.Second;

                }
            }
        }


    }

    public abstract class Subscriber
    {
        // 3 - Define the event handler abstract function to be implemented in all derived classes:
        //      The Event Handler: public void On<Event>(object source, EventArg e):
        public abstract void OnTimeChanged(object theClock, TimeEventArgs e);

        // 4- Define the Subscribe method that will be used by all derived classes to 
        //      subscribe to the event:
        public void Subscribe(Clock theClock)
        {
            theClock.TimeChanged += OnTimeChanged;
        }
    }

    public class VisibleClock : Subscriber
    {
        public override void OnTimeChanged(object theClock, TimeEventArgs e)
        {
            Console.WriteLine("{0}:{1}:{2}",
                                e.Hour.ToString(),
                                e.Minute.ToString(),
                                e.Second.ToString());
        }
    }

    public class Logger : Subscriber
    {
        public override void OnTimeChanged(object theClock, TimeEventArgs e)
        {
            Console.WriteLine("Logging event at {0}:{1}:{2}",
                                e.Hour.ToString(),
                                e.Minute.ToString(),
                                e.Second.ToString());
        }
    }


}
