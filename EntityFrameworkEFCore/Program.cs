using EFCore.Domain.DataAccess.Repository;
using EFCore.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dishRepository = new DishRepository();

            //Console.WriteLine("Hello Entity Framework (EF Core)!");

            //var breakfast = "Sandwitch";
            //Console.WriteLine($"Add {breakfast} for breakfast.");

            //var sandwitch = new Dish
            //{
            //    Title = "Sandwitch",
            //    Notes = "Sandwitch is so delicious.",
            //    Stars = 3
            //};


            //dishRepository.AddDishes(sandwitch);

            //Console.WriteLine($"Added {breakfast} successfully!");

            // Experiment tracking EF Core object's state
            //dishRepository.ExperimentEntityStatues();

            //dishRepository.ChangeTracking();

            //dishRepository.AttachEntities();
            dishRepository.NoTrackingEntities();
        }
    }
}
