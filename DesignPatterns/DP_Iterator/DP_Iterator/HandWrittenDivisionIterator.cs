using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DP_Iterator
{
    class HandWrittenDivisionIterator
    {
        private VP[] vps;
        private int indx = -1;

        public HandWrittenDivisionIterator(VP[] vps)
        {
            this.vps = vps;
        }

        public bool MoveNext()
        {
            ++indx;
            return( (indx < vps.Length) && (vps[indx] != null));
        }

        public VP Current
        {
            get 
            {
                if ((indx < 0) || (indx >= vps.Length))
                {
                    throw new InvalidOperationException();
                }
                return vps[indx];
            }
        }

        public void Reset()
        {
            indx = -1;
        }
    }
}
