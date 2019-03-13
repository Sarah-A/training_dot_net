using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_ErrorHandlers
{
    public class MyException : System.ArgumentException
    {
        public MyException(string message) :base(message){}
    }
}
