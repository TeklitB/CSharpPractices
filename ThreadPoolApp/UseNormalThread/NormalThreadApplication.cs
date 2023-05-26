using System;
using System.Threading;

namespace ThreadPoolApp.UseNormalThread
{
    public class NormalThreadApplication
    {
        public static void MyNormalThread(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(MyMethod)
                {
                    Name = "Thread" + i
                };
                thread.Start();
            }
            Console.Read();
        }
        public static void MyMethod(object obj)
        {
            Thread thread = Thread.CurrentThread;
            string message = $"Background: {thread.IsBackground}, Thread Pool: {thread.IsThreadPoolThread}, Thread ID: {thread.ManagedThreadId}";
            Console.WriteLine(message);
        }
    }
}
