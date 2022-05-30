using EFCore.Domain.DataAccess.Repository;
using EFCore.Model;
using System;

namespace EFCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Entity Framework (EF Core)!");

            var breakfast = "Sandwitch";
            Console.WriteLine($"Add {breakfast} for breakfast.");

            var sandwitch = new Dish
            {
                Title = "Sandwitch",
                Notes = "Sandwitch is so delicious.",
                Stars = 3
            };

            var dishRepository = new DishRepository();
            dishRepository.AddDishes(sandwitch);

            Console.WriteLine($"Added {breakfast} successfully!");
        }
    }
}
