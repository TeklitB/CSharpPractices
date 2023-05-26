using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolApp.LimitingConcurrentOperations
{
    public class LimitConcurrentOperations
    {
        static readonly SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(initialCount: 1);

        static void LimitConcurrentOperationsSemaphoreSlim(string[] args)
        {
            var tasks = new List<Task>();

            for (var i = 0; i < 10; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    SemaphoreSlim.Wait();

                    Console.WriteLine($"Start task, CurrentCount: {SemaphoreSlim.CurrentCount}");
                    Thread.Sleep(100);
                    Console.WriteLine($"End task, CurrentCount: {SemaphoreSlim.CurrentCount}");

                    SemaphoreSlim.Release();
                    SemaphoreSlim.Release();
                }));

            }

            Task.WaitAll(tasks.ToArray());
        }
    }
}
