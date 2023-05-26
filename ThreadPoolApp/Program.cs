using System;
using ThreadPoolApp.UseNormalThread;
using ThreadPoolApp.UseThreadPool;

namespace ThreadPoolApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, threading using ThreadPool!");
            //ThreadPoolApplication.MyThreadPool(args);

            Console.WriteLine("Hello, threading using Normal Thread!");
            NormalThreadApplication.MyNormalThread(args);
        }
    }
}