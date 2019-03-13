using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_AsyncronousProgrammingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<double> asyncTask = HandleAsynchTask();

            Console.WriteLine("Asynchronous Task in now Running...");

            string line = Console.ReadLine();
            Console.WriteLine("You entered (while async running): " + line);

            Console.WriteLine("Now waiting for task...");
            asyncTask.Wait();
            var result = asyncTask.Result;
            Console.WriteLine("Result = " + result);

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        static async Task<double> HandleAsynchTask()
        {
            var sum = 0.0;
            DateTime start = DateTime.Now;
            DateTime now;
            
            await Task.Run( () =>
           {
               do
               {
                   now = DateTime.Now;
                   sum += Math.Sqrt(now.Second ^ 5);
               } while (now < (start.AddSeconds(5)));               
           });

            return sum;
        }
    }
}
