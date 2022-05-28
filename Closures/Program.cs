using System;
using System.Collections.Generic;

namespace Closures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // This call returns a function (i.e. n => n * factor).
            Func<int, int> calculator = CreateCalculator();
            // This statement calls n => n * factor.
            // factor is promoted from stack to heap so that it is alive.
            // The life time of factor is bind to the returned function.
            Console.WriteLine(calculator(2));

            // HOF usage
            var mapperWithHOF = new MapperWithHOF();
            var myList = new List<int> { 1, 2, 3, 4, 5 };

            int multiplyBy2(int num) => num * 2;
            var multipliedList = mapperWithHOF.Map(myList, multiplyBy2);
            // output { 2, 4, 6, 8, 10 };

            bool isEven(int num) => num % 2 == 0;
            var isEvenList = mapperWithHOF.Map(myList, isEven);
            // output { false, true, false, true, false };

            Func<int, int> Add(int a) => (int b) => a + b;

            var add9 = Add(9);

            var sum1 = add9(1);
            // output 10

            var sum2 = add9(2);
            // output 11

            // Can I do this way?
            // usage
            var mineList = new List<int> { 1, 2, 3, 4, 5 };

            Func<int, int> multiplyBy2Func = (int num) => num * 2;
            var multipliedByList = mapperWithHOF.Map(mineList, multiplyBy2Func);
            Console.WriteLine(string.Join(", ", multipliedByList));
            // output { 2, 4, 6, 8, 10 };

            Func<int, bool> isEvenFunc = (int num) => num % 2 == 0;
            var evenList = mapperWithHOF.Map(myList, isEvenFunc);
            Console.WriteLine(string.Join(", ", evenList));
            // output { false, true, false, true, false };

            // Practical use case of HOF in Repository pattern
            var _productRepository = new ProductRepository();
            // client code
            var allProducts = _productRepository.Get();
            var productsByCategoryId = _productRepository.Get(p => p.CategoryId == 1);
            var activeProducts = _productRepository.Get(p => p.IsActive);
        }

        // Step 1: Higher Order Functions
        // It is a factory design pattern. A factory for functions.
        static Func<int, int> CreateCalculator()
        {
            var factor = 42;

            //return (n) => { return n * factor; };
            return n => n * factor;
        }

        //// How a closure works behind the scene. A class is created behind the scene.
        //BestFriends CreateCalculatorInternal()
        //{
        //    return new BestFriends { factor = 42 };
        //}
    } 
    
    //// How a closure works behind the scene. A class is created behind the scene.
    //public class BestFriends
    //{
    //    public int factor;

    //    public int Calculator(int n) => n * factor;
    //}
}
