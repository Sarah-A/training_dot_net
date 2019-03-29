using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CSLanguageSandbox;


namespace UT_LanguageSandbox
{
    [TestFixture]
    class UT_BoxingPerformance
    {

        [Test]
        public void Test_StringBoxingPerformance()
        {
            var withBoxing = new CS_BoxingPerformance();
            var withoutBoxing = new CS_BoxingPerformance();
            var startTime = new DateTime();
            const int Times = 100000;

            Console.WriteLine("With Boxing:");
            startTime = DateTime.UtcNow;
            for (var i = 0; i < Times; i++)
            {
                withBoxing.AddToStringWithBoxing(i);
            }
            Console.WriteLine($"Total time: {DateTime.UtcNow - startTime}");

            Console.WriteLine("Without Boxing:");
            startTime = DateTime.UtcNow;
            for (var i = 0; i < Times; i++)
            {
                withoutBoxing.AddToStringWithBoxing(i);
            }
            Console.WriteLine($"Total time: {DateTime.UtcNow - startTime}");

            Assert.AreEqual(withBoxing.Sb.ToString(), withoutBoxing.Sb.ToString());


        }
    }
}
