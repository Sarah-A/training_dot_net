using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_Iterator
{
    class VP
    {
        private string name;        
        private string division;

        public VP(string name, string division)
        { 
            this.name = name;
            this.division = division;
        }

        public string GetName()
        {
            return name;
        }

        public void Print()
        {
            Console.WriteLine(" VP name: " + name + "\t division: " + division);
        }
    }
}
