using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_EventsTemp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************************************************\n" +
                              " Testing Manual Events:\n" +
                              "**************************************************\n");
            TestEvents();

        }

        static void TestEvents()
        {
            CardReset cardReset = new CardReset();
            Listener1 ml1 = new Listener1(cardReset);
            Listener2 ml2 = new Listener2(cardReset);
            cardReset.Register_Manual_CardResetDelegate(ml1.CallWhenCardReset_ManualEvent);

            // register additional no-data event(2):
            cardReset.NoDateEventHandler += ml2.CallWhenCardReset_NoDataEvent;

            // register additional event handler with data:
            cardReset.CardResetEventHandler += ml1.CallWhenCardReset_CardResetEvent;

            cardReset.Reset();
        }
    }
}
