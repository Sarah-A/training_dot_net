using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Division salesDivision = new Division("Sales");
            salesDivision.AddVP("Bob");
            salesDivision.AddVP("Karen");
            salesDivision.AddVP("Holly");
            salesDivision.AddVP("Shon");
            salesDivision.AddVP("Mitzi");

            // Test using hand-written iterator:
            Console.WriteLine(" Test using hand-written iterator: ");
            HandWrittenDivisionIterator handWrittenInterator;
            
            handWrittenInterator = salesDivision.GetHandWrittenIterator();
            while (handWrittenInterator.MoveNext())
            {
                VP vp = handWrittenInterator.Current;
                vp.Print();                
            }

            // Test using C# iterator:
            Console.WriteLine(" Test using build-in iterator: ");
            foreach (VP vp in salesDivision)
            { 
                vp.Print();
            }


        }
    }
}
