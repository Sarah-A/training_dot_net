using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_Observer
{
    interface IDataBaseObserver
    {
        void DoOnDataBaseChange(String operation, String record);
    }
}
