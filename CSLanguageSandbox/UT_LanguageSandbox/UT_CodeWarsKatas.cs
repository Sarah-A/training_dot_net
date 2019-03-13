using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSLanguageSandbox;

namespace UT_LanguageSandbox
{
    [TestClass]
    public class UT_CodeWarsKatas
    {
        [TestMethod]
        public void TestSquareDigits()
        {
            Assert.AreEqual(811181, CodeWarsKatas_8kyu.SquareDigits(9119));
        }

        [TestMethod]
        public void Test_Longest()
        {
            //string s1 = new string("xyaabbbccccdefww");
            //string s2 = new string("xxxxyyyyabklmopq");

            Assert.AreEqual("abcdefklmopqwxy", CodeWarsKatas_8kyu.Longest("xyaabbbccccdefww", "xxxxyyyyabklmopq"));
        }
    }
}
