using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_ErrorHandlers
{
    public enum ExceptionType { Excp_NoException = 0, Excp_MyException = 1, Excp_ArgumentException, Excp_ArgumentOutOfRangeException };

    public class CSThrowingException
    {
    
        public void ThrowException(ExceptionType throwExp)
        {
            int status = TryWithoutThrowingException(throwExp);

            switch ((ExceptionType) status)
            {
                case ExceptionType.Excp_NoException:
                    return;
                    break;
                case ExceptionType.Excp_MyException:
                    throw new MyException("MyException");
                    break;
                case ExceptionType.Excp_ArgumentException:
                    throw new System.ArgumentException("ArgumentException thrown");
                    break;
                case ExceptionType.Excp_ArgumentOutOfRangeException:
                    throw new System.ArgumentOutOfRangeException("ArgumentOutOfRangeException thrown");
                    break;
                default:
                    throw new System.NotSupportedException("NotSupportedException thrown");
                    break;
            }

        }


        // This private function implement the TryXXX pattern - it supports returning an error code
        // but is the user cannot handle the error code, they can call the ThrowException function
        // that uses this one and returns exceptions instead of error codes.
        public int TryWithoutThrowingException(ExceptionType throwExp)
        {

            return (int)throwExp;
        }
    }
}
