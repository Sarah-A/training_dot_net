using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLanguageSandbox
{
    public class CS_BoxingPerformance
    {
        public StringBuilder Sb { set; get; }  = new StringBuilder();

        public void AddToStringWithBoxing(int i)
        {
            Sb.Append($"{i},");
        }

        public void AddToStringWithoutBoxing(int i)
        {
            Sb.Append($"{i.ToString()},");
        }

    }
}
