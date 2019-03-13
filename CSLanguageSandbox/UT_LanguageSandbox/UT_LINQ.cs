using System;
using NUnit.Framework;
using System.IO;
using CS_LINQSimple;

namespace UT_LanguageSandbox
{
    [TestFixture]
    public class UT_LinqSimple
    {
        [Test]
        public void Test_Linq()
        {
            // Do to lack of time - this function only domonstarte how the functions work.
            // I don't check them in any way.
                        
            CS_LINQ.SimpleQueryOnList();
            CS_LINQ.SimpleMethodQueryOnList();
            CS_LINQ.PrintAllDoubleMethods();
            CS_LINQ.takeOperator();
            CS_LINQ.zipOperator();




        }
    }
}
