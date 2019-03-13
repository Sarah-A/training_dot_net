using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_ErrorHandlers
{
    class Program
    {
        static void Main(string[] args)
        {
            CSThrowingException throwingObj = new CSThrowingException();

            for (int i = 0; i < 5; ++i)
            {
                try 
                {
                    Console.WriteLine("*********************************************\nCalling ThrowException with: {0}", (ExceptionType)i);
                    throwingObj.ThrowException((ExceptionType)i);
                }
                catch(MyException ex)
                {
                    Console.WriteLine("caught through MyException. Exception message: \n{0}",ex.Message);
                }
                catch(System.ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("caught through ArgumentOutOfRangeException. Exception message: \n{0}", ex.Message);
                }
                catch(System.ArgumentException ex)
                {
                    Console.WriteLine("caught through ArgumentException. Exception message: \n{0}", ex.Message);
                }
                catch(System.Exception ex)
                {
                    Console.WriteLine("caught through Exception. Exception message: \n{0}", ex.Message);
                }
                finally
                {
                    Console.WriteLine("in Finally clause...cleaning up :-) ");
                }
            }

            Console.WriteLine("**************************\n Now calling with error code: {0}", (ExceptionType)4);
            Console.WriteLine("Received error code: {0}", throwingObj.TryWithoutThrowingException((ExceptionType)4));
        }
    }
}
