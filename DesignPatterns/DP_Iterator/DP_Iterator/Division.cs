using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DP_Iterator
{
    class Division
    {
        string name;
        VP[] vps = new VP[100];
        private int vpsNum = 0;

        public Division(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void AddVP(string name)
        {
            if (vpsNum < 100)
            {
                vps[vpsNum++] = new VP(name, this.name);
            }
            else
            {
                Console.WriteLine("Too many VPs in division - 100 VPs!");
            }
        }

        public HandWrittenDivisionIterator GetHandWrittenIterator()
        {
            return new HandWrittenDivisionIterator(vps);
        }

        // implement the build-in enumerator:
        public IEnumerator GetEnumerator()
        {
            for( int i = 0 ; ( (i < vps.Length) && (vps[i] != null) ) ; ++i )
            {
                yield return vps[i];
            }
        }

    }
}
