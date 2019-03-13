using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLanguageSandbox
{
    
    public static class StringExtensions
    {
        // This function extends the string class so that we can call 'Shout' on any string. 
        // Note: the static is mandatory and so is the 'this' before 'string' which is the class we're extending.
        public static string Shout(this string s)
        {
            return s.ToUpper() + "!!!";
        }
    }

}
