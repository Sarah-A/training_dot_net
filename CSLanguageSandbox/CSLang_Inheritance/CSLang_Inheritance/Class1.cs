using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLang_Inheritance
{
    public class BaseClass
    {
        public virtual void Print()
        {
            Console.WriteLine("Printing from the BaseClass");
        }
    }

    public class Derived1 : BaseClass
    {
        public override void Print()
        {
            Console.WriteLine("Printing from the Derived1");
        }
    }

    public class Derived2 : Derived1
    {
        public override void Print()
        {
            Console.WriteLine("Printing from the Derived2");
        }
    }

    public class Derived3 : Derived2
    {
        public new void Print()
        {
            Console.WriteLine("Printing from the Derived3");
        }
    }

    public class CSLang_Inheritance
    {
        public static void Main()
        {
            BaseClass bs = new BaseClass();
            Derived1 dr1 = new Derived1();
            Derived2 dr2 = new Derived2();
            Derived3 dr3 = new Derived3();


            PrintRealObj(bs);
            PrintRealObj(dr1);
            PrintRealObj(dr2);
            Console.WriteLine("The following is a derived class with a new non-virtual function Print. Therefore, it will use the latest virtual Print it has which is Derived2 Print function:");
            PrintRealObj(dr3);
            
        }

        public static void PrintRealObj(BaseClass refToBaseOnly)
        {
            refToBaseOnly.Print();
        }
    }
}
