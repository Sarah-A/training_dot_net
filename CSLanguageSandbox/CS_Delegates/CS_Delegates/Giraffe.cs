using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_Delegates
{
    public class Giraffe : Animal
    {
        public Giraffe(string name) : base(name) { }

        public override void PrintName()
        {
            Console.WriteLine("Giraffe name is: " + Name);
        }

    }
}
