using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_Observer
{
    class DataBaseObserver1 : IDataBaseObserver
    {
        public void DoOnDataBaseChange(String operation, String record) 
        { 
            Console.Write("Observer 1 - the client - recieved message that data base has changed!!");
            Console.WriteLine("\t operation: " + operation + "\t record: " + record);
        }
    }
}
