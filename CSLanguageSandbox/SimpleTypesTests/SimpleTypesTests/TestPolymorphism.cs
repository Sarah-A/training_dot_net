using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTypesTests
{
    class TestPoly_BaseClass
    {
        public string className;

        virtual public void ClassFunc()
        {
            Console.WriteLine("function in BaseClass");
        }
    }

    class TestPoly_Derv1 : TestPoly_BaseClass
    {
        int drv1;

        override public void ClassFunc()
        {
            Console.WriteLine("function in Derv1");
        }
    }

    class TestPoly_Derv2 : TestPoly_BaseClass
    {
        int drv2;

        override public void ClassFunc()
        {
            Console.WriteLine("function in Derv2");
        }
    }
}
