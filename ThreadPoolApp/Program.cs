using System;
using System.Threading.Tasks;
using ThreadPoolApp.UseNormalThread;
using ThreadPoolApp.UseSemaphoreSlim;
using ThreadPoolApp.UseThreadPool;

namespace ThreadPoolApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello, threading using ThreadPool!");
            //ThreadPoolApplication.MyThreadPool(args);

            //Console.WriteLine("Hello, threading using Normal Thread!");
            //NormalThreadApplication.MyNormalThread(args);

            Console.WriteLine("Hello, threading using SemaphoreSlim!");
            await SemaphoreSlimDemo.MySemaphoreSlim(args);
        }
    }
}