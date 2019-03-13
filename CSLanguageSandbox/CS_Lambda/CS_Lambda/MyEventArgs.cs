using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_Lambda
{
    class MyEventArgs : EventArgs
    {
        private int x;
        private int y;

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public MyEventArgs(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
