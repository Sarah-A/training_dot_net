using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_Delegates
{
    public class Lion : Animal
    {
        public Lion(string name) : base(name){}

        public override void PrintName()
        {
            Console.WriteLine("Lion name is: " + Name);
        }

        public void Roar()
        {
            Console.WriteLine("rrrrrrrrrrrrrrrrr");
        }
    }
}
