using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLanguageSandbox
{
    public class CodeWarsKatas_8kyu
    {
        // In this kata, you are asked to square every digit of a number.
        // For example, if we run 9119 through the function, 811181 will come out, because 92 is 81 and 12 is 1.
        // Note: The function accepts an integer and returns an integer
        public static int SquareDigits(int n)
        {
            return int.Parse(string.Join("", n.ToString().Select(c => Math.Pow(int.Parse(c.ToString()), 2)).ToString()));            
        }

        // Take 2 strings s1 and s2 including only letters from ato z.Return a new sorted string, the longest possible, containing distinct letters,
        // each taken only once - coming from s1 or s2.
        // Examples:
        //    a = "xyaabbbccccdefww"
        //    b = "xxxxyyyyabklmopq"
        //    longest(a, b) -> "abcdefklmopqwxy"
            
        //    a = "abcdefghijklmnopqrstuvwxyz"
        //    longest(a, a) -> "abcdefghijklmnopqrstuvwxyz"
        public static string Longest(string s1, string s2)
        {
            return new string((s1 + s2).Distinct().OrderBy(x => x).ToArray());
        }

    }
}
