using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_EventsTemp
{
    public delegate void Manual_CardResetDelegate(string cardReset);
    
    public class CardReset
    {   

        //*******************************************************
        // Manual Delegates:
        //*******************************************************
        private Manual_CardResetDelegate manual_cardResetDelegate = null;

        public void Register_Manual_CardResetDelegate(Manual_CardResetDelegate d)
        {
            manual_cardResetDelegate += d;
        }

        public void UnRegister_Manual_CardResetDelegate(Manual_CardResetDelegate d)
        {
            manual_cardResetDelegate -= d;
        }

        private void OnCardReset_ManualDelegate(string reset)
        {
            var tempDelegate = manual_cardResetDelegate;
            if (tempDelegate != null)
            {
                tempDelegate(reset);
            }
        }


        //*******************************************************
        // No data event handler:
        //*******************************************************
        public event EventHandler NoDateEventHandler;

        protected virtual void OnCardReset_NoDataEvent(EventArgs e)
        {
            var temp = NoDateEventHandler;
            if (NoDateEventHandler != null)
            {
                NoDateEventHandler(this, e);
            }
        }

        //*******************************************************
        // Event Handler with data:
        //*******************************************************

        public event EventHandler<EventArgs_CardReset> CardResetEventHandler;

        protected virtual void OnCardReset_CardResetDataEvent(EventArgs_CardReset e)
        {
            var temp = CardResetEventHandler;
            if (CardResetEventHandler != null)
            {
                CardResetEventHandler(this, e);
            }
        }



        //*******************************************************
        // Triggering event:
        //*******************************************************
        public void Reset()
        { 
            string reset= "3F1315FA099211";

            Console.WriteLine("Card was reset - calling manual event");
            OnCardReset_ManualDelegate(reset);

            Console.WriteLine("---------------- calling CardReset EventHandler");
            OnCardReset_CardResetDataEvent(new EventArgs_CardReset(reset));

            Console.WriteLine("---------------- calling No Data EventHandler");
            OnCardReset_NoDataEvent(EventArgs.Empty);


        }
    }
}
