using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLanguageSandbox
{
    public class CS_Async
    {

        
        public async Task<int> TestAsyncWithAwait(int delayInSeconds)
        {
            var endWait = await SimulateAsynchMethodAsync(delayInSeconds);
            var startWait = DateTime.Now;            

            return (int)(endWait - startWait).TotalSeconds;
        }

        public async Task<int> TestAwaitAtEnd(int delayInSeconds)
        {
            var endWaitTask = SimulateAsynchMethodAsync(delayInSeconds);
            var startWait = DateTime.Now;

            var endWait = await endWaitTask;
            return (int)(endWait - startWait).TotalSeconds;
        }

        public async Task<DateTime> SimulateAsynchMethodAsync(int delayInSeconds)
        {
            await Task.Delay(delayInSeconds * 1000);
            return DateTime.Now;
        }
    }
}
