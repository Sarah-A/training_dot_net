using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_LINQSimple
{
    public class CS_LINQ
    {
        public static void SimpleQueryOnList()
        {
            var primes = new List<int> { 1, 3, 5, 7, 11, 13, 17, 19, 23};
            var query = from val in primes
                        where val < 13
                        select val;
            foreach (var val in query)
            {
                Console.WriteLine(val);
            }
        }

        public static void SimpleMethodQueryOnList()
        {
            var primes = new List<int> { 1, 3, 5, 7, 11, 13, 17, 19, 23 };
            var methodQuery = primes
                                .Where(x => x < 13);
            foreach (var val in methodQuery)
            {
                Console.WriteLine(val);
            }
        }

        public static void PrintAllDoubleMethods()
        {
            var query = from method in typeof(double).GetMethods()
                        orderby method.Name
                        group method by method.Name into groups
                        select new { MethodName = groups.Key, NumberOfOverloads = groups.Count() };
            
            foreach (var method in query)
            {
                Console.WriteLine(method);
            }
        }

        public static void takeOperator()
        {
            var bigList = Enumerable.Range(1, 20);
            var littleList = bigList
                                .Take(5)
                                .Select(x => x * 10);

            foreach (var val in littleList)
            {
                Console.WriteLine(val);
            }
        }

        public static void zipOperator()
        {
            string[] firstNames = { "James", "Sharon", "Ken", "Jeff", "Aaron" };
            string[] lastNames = { "Cock", "MckFee", "Robinson", "Wilson", "Bond" };

            var fullNames = firstNames
                                .Zip(lastNames, (first, last) => (first + " , " + last));
            foreach (var name in fullNames)
            {
                Console.WriteLine(name);
            }
                      
        }
        
    }
}
