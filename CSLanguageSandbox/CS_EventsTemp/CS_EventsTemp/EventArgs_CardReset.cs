using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_EventsTemp
{
    public class EventArgs_CardReset : EventArgs
    {
        private string cardReset;

        public EventArgs_CardReset(string reset)
        {
            cardReset = reset;
        }

        public string Reset {
            get { return cardReset; }
        }
    }
}
