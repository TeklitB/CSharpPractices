using System;
using System.Diagnostics;

namespace ActionAndFuncDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            CountNearlyToInfinity();
            watch.Stop();
            Console.WriteLine($"Elapsed time => {watch.Elapsed}");

            Console.WriteLine("Hello World!");

            MeastureTime(() => CountNearlyToInfinity());

            Console.WriteLine($"The result is {MeastureTimeFunc(() => CalculateSomeResult())}");
        }

        // Step 1: Action delegates a function that takes no parameter and returns nothing (void)
        static void MeastureTime(Action action)
        {
            var watch = Stopwatch.StartNew();
            action();
            watch.Stop();
            Console.WriteLine($"Elapsed time => {watch.Elapsed}");
        }

        // Step 2: Func delegates a function that takes no parameter and returns nothing (void)
        static int MeastureTimeFunc(Func<int> f)
        {
            var watch = Stopwatch.StartNew();
            var result = f();
            watch.Stop();
            Console.WriteLine($"Elapsed time => {watch.Elapsed}");
            return result;
        }

        static void CountNearlyToInfinity()
        {
            for (long i = 0; i < 10000000000; i++)
            {

            }
        }
        
        // Simulate some interesting calculation
        static int CalculateSomeResult()
        {
            for (long i = 0; i < 10000000000; i++) ;

            return 42;
        }
    }
}
