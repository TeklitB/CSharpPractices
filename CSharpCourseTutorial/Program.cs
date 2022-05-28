using System;

namespace CSharpCourseTutorial
{
    class Program
    {
        /// <summary>
        /// Step 2: Create a delegate that defines a type for the common set of functions.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        delegate int MathOperation(int x, int y);

        // Step 4: Delegates work very well with generic functions.
        delegate T Combine<T>(T x, T y);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MathOperation f = Add;
            Console.WriteLine(f(42, 42));
            f = Subtract;
            Console.WriteLine(f(84, 42));

            CalculateAndPrint(21, 21, Add);
            CalculateAndPrint(21, 21, Subtract);

            // Step 3: Delegate can be placed inline where they should be used called anonymous function.
            // That is the function does not have a nmae
            CalculateAndPrint(12, 12, delegate (int x, int y)
            {
                return x + y;
            });

            // Step 4: The anonymous function can be written with lambda expression (i.e. () => {}).
            // Alt + Up Key or Down Key => to move a line of code up or down
            CalculateAndPrint(12, 12, (int x, int y) => 
            { 
                return x + y; 
            });
            CalculateAndPrint(12, 12, (x, y) => 
            { 
                return x + y; 
            });
            CalculateAndPrint(12, 12, (x, y) => x + y);
            CalculateAndPrint(12, 12, (x, y) => x - y);
            CalculateAndPrint(12, 12, (x, y) => x * y);
            CalculateAndPrint(12, 12, (x, y) => x / y);

            // Delegates work very well with generic functions.
            CombineAndPrint(12, 12, (x, y) => x * y);
            CombineAndPrint("A", "B", (x, y) => x + y);
            CombineAndPrint(true, true, (x, y) => x && y);
        }

        static void CalculateAndPrint(int x, int y, MathOperation f)
        {
            var result = f(x, y);
            Console.WriteLine(result);
        }

        // Delegates work very well with generic functions.
        static void CombineAndPrint<T>(T x, T y, Combine<T> f)
        {
            var result = f(x, y);
            Console.WriteLine(result);
        }

        /// <summary>
        /// Step 1: Create common set of functions 
        /// Both methods the Add and Subtract fulfill the contract of th MathOperation delegate
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static int Add(int x, int y)
        {
            return x + y;
        }

        static int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}
