using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSLanguageSandbox
{
    public class Document
    {
        public string Text { get; set; }

        // declare the delegate:
        public delegate string SendDocument();
        public string SendAndReport(SendDocument sendingDelegate)
        {
            return ("Sending " + sendingDelegate());            
        }       
    }

    public class EmailServer
    {
        public string SendEmail()
        {
            return "email";
        }
    }

    public class BlogPoster
    {
        public string PostBlog()
        {
            return "post";
        }
    }

    // another example that shows a list of function references inside the delegate:
    public class MyDouble {

        public double value { get; private set; }

        public MyDouble(double value)
        {
            this.value = value;
        }

        public delegate double NumberOperation(double num);

        public void ExecuteOperations(NumberOperation operationHandler)
        {
            this.value = operationHandler(this.value);
        }
    }

    public class MathUtilities
    {
        public static double Square(double num)
        {
            Console.WriteLine($"Square: {num}");
            return (num * num);
        }

        public static double SquareRoot(double num)
        {
            Console.WriteLine($"SquareRoot: {num}");
            return Math.Sqrt(num);
        }

        public static double AdvanceNumber(double num)
        {
            Console.WriteLine($"AdvanceNumber: {num}");
            return (num + 1);
            
        }

    }

    



   
}
