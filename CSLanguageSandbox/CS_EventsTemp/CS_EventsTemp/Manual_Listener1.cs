using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_EventsTemp
{
    public class Listener1
    {
        public Listener1(CardReset cardReset)
        {
            cardReset.Register_Manual_CardResetDelegate(CallWhenCardReset_ManualEvent);
            cardReset.NoDateEventHandler += CallWhenCardReset_NoDataEvent;
            cardReset.CardResetEventHandler += CallWhenCardReset_CardResetEvent;
        }

        public void CallWhenCardReset_ManualEvent(string reset)
        {
            Console.WriteLine(" In {0}.CallWhenCardReset_ManualEvent. Received Card Reset Event. Card Reset = {1}", this.GetType(), reset);
        }

        public void CallWhenCardReset_CardResetEvent(Object o, EventArgs_CardReset e)
        {
            Console.WriteLine(" In {0}.CallWhenCardReset_CardResetEvent. Received Card Reset Event. Card Reset = {1}", this.GetType(), e.Reset);
        }

        public void CallWhenCardReset_NoDataEvent(Object o, EventArgs e)
        {
            Console.WriteLine(" In {0}.CallWhenCardReset_NoDataEvent. Received Card Reset Event - No data supplied", this.GetType());
        }
    }
}
