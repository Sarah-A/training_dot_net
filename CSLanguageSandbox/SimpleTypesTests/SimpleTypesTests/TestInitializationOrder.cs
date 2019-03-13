using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTypesTests
{
    public class TestInitializationOrder_Base
    {
        public int x = 1;   // init 2nd

        public TestInitializationOrder_Base(int x)      // init 4th
        { 
            this.x = this.x + x;
            Console.WriteLine("In Base. x = " + this.x.ToString());
        }
    }

    public class TestInitializationOrder_Drv : TestInitializationOrder_Base
    {
        public int y = 2;                       // init 1st

        public TestInitializationOrder_Drv(int y) : base(y + 5) // base(y+5) init 3rd
        {                                                       // init 5th
            this.y = y;
            Console.WriteLine("In Drv. x = " + base.x.ToString() + " y = " + this.y.ToString());
        }

    }
}
