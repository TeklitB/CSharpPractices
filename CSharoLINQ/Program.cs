using System;

namespace CSharoLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Car Data!");

            var fileName = @"data.json";
            var carData = new CarData();
            var cars = carData.DeserializeCarDat(fileName).Result;
            carData.DisplayCars(cars);
        }
    }
}
