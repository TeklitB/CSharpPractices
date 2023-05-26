using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolApp.UseSemaphoreSlim
{
    public class SemaphoreSlimDemo
    {
        // Only 3 threads can access resource simulteniously
        static SemaphoreSlim semaphore = new SemaphoreSlim(initialCount: 3);
        public async static Task MySemaphoreSlim(string[] args)
        {
            var tasks = new List<Task>();
            for (int i = 1; i <= 5; i++)
            {
                int count = i;
                await semaphore.WaitAsync();
                await Task.Delay(1000 * count);
                var t = Task.Run(async () => await SemaphoreSlimMethodAsync("Thread " + count, 1000 * count));
                tasks.Add(t);
                //t.Start();
            }

            await Task.WhenAll(tasks);

            Console.ReadLine();
        }
        private async static Task SemaphoreSlimMethodAsync(string name, int seconds)
        {
            Console.WriteLine($"{name} Waits to access resource");
            //await semaphore.WaitAsync();
            Console.WriteLine($"{name} was granted access to resource");
            await Task.Delay(seconds);
            Console.WriteLine($"{name} is completed");
            semaphore.Release();
        }
    }
}
