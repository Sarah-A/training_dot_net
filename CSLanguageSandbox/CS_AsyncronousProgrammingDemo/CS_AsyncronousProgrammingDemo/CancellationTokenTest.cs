using System;
using System.Threading;
using System.Threading.Tasks;

namespace CS_AsyncronousProgrammingDemo
{
    public class CancellationTokenTest
    {

        static async Task DoWorkAsync(CancellationToken token)
        {
            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Cancellation requested!");
                    token.ThrowIfCancellationRequested();
                }
            }
        }

    }
}