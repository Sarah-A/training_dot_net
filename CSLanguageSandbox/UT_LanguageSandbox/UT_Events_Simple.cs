using System;
using NUnit.Framework;
using CS_Events_Simple;
using System.IO;

namespace UT_LanguageSandbox
{
    [TestFixture]
    public class UT_Events_Simple
    {
        [Test]
        public void Test_Events_Simple()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Clock clock = new Clock();
                VisibleClock visibleClock = new VisibleClock();
                Logger logger = new Logger();

                logger.Subscribe(clock);
                visibleClock.Subscribe(clock);

                clock.RunClock(20);
                string result = sw.ToString();
                Console.WriteLine(result);
                              
            }
          

        }
    }
}
