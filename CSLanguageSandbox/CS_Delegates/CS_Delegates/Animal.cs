using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_Delegates
{
    public class Animal
    {
        private string name;
            
        public Animal(string name){ this.name = name; }
        public string Name      // the public property for the internal member _name;
        {
            get { return name; }
        }

        
        public virtual void PrintName()
        { 
            Console.WriteLine("Animal name is: " + name);
        }
    }
}
