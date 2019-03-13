using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS_Events_WithAnonymousMethods
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

        public delegate void TimeChangeHandler(object clock, TimeEventArgs timeInfo);
        public event TimeChangeHandler TimeChanged;

        public void RunClock(int times)
        {
            for (int i = 0; i < times; ++i)
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

                    TimeChanged?.Invoke(this, timeEventArgs);
                    this.hour = currentTime.Hour;
                    this.minute = currentTime.Minute;
                    this.second = currentTime.Second;

                }
            }
        }
    }

    public class VisibleClock
    {
        public void Subscribe(Clock theClock)
        {
            // using an anonymous function to define and use the delegate function:
            theClock.TimeChanged += delegate (object sender, TimeEventArgs e)
            {
                Console.WriteLine("{0}:{1}:{2}",
                                    e.Hour.ToString(),
                                    e.Minute.ToString(),
                                    e.Second.ToString());
            };
        }
    }

    public class Logger
    {
        public void Subscribe(Clock theClock)
        {
            theClock.TimeChanged += delegate (object sender, TimeEventArgs e)
            {
                Console.WriteLine("Logging event at {0}:{1}:{2}",
                                e.Hour.ToString(),
                                e.Minute.ToString(),
                                e.Second.ToString());
            };
            
        }


    }
}
