using System;
using System.Collections.Generic;

namespace LambdasAndCollections
{
    internal class Program
    {
        /// <summary>
        /// Step 1: Record instead of class for demonstration purposes.
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="HeroName"></param>
        /// <param name="CanFly"></param>
        record Hero(string FirstName, string LastName, string HeroName, bool CanFly);

        delegate bool Filter<T>(T hero);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var heroes = new List<Hero>
            {
                new("Wad", "Wilson", "DeadPool", false),
                new(string.Empty, string.Empty, "HomeLander", true),
                new("Bruce", "Wayne", "Batman", false),
                new("Marya", "Anderson", "Stormfront", true)
            };

            var result = FilterItems(heroes, h => h.CanFly);
            var herosWhoCanFly = string.Join(", ", result);
            Console.WriteLine(herosWhoCanFly);

            var hasNoLastname = FilterItems(heroes, h => string.IsNullOrEmpty(h.LastName));
            var herosWithoutLastName = string.Join(", ", hasNoLastname);
            Console.WriteLine(herosWithoutLastName);

            var names = FilterItems(new[] { "Homelander", "The Deep", "Stormfron" }, h => h.StartsWith("H"));
            var namesStartsWithH = string.Join(", ", names);
            Console.WriteLine(namesStartsWithH);

            var evenNumbers = FilterItems(new[] {1, 2, 3, 4, 5}, n => n % 2 == 0);
            var even = string.Join(", ", evenNumbers);
            Console.WriteLine(even);
        }

        //static List<Hero> FilterHeros(List<Hero> heroes, Filter f)
        //{
        //    var result = new List<Hero>();
        //    foreach (var hero in heroes)
        //    {
        //        if (f(hero))
        //            result.Add(hero);
        //    }
        //    return result;
        //}

        //// Step 2: Use IEnumerable for collection that will not be manipulated.
        //static IEnumerable<Hero> FilterHeros(IEnumerable<Hero> heroes, Filter f)
        //{
        //    var result = new List<Hero>();
        //    foreach (var hero in heroes)
        //    {
        //        if (f(hero))
        //            result.Add(hero);
        //    }
        //    return result;
        //}

        //// Step 3: Use IEnumerable for collection that will not be manipulated.
        //static IEnumerable<Hero> FilterHeros(IEnumerable<Hero> heroes, Filter f)
        //{
        //    foreach (var hero in heroes)
        //    {
        //        if (f(hero))
        //            yield return hero;
        //    }
        //}

        // Step 4 : Make it more generic
        static IEnumerable<T> FilterItems<T>(IEnumerable<T> items, Filter<T> f)
        {
            foreach (var item in items)
            {
                if (f(item))
                    yield return item;
            }
        }

        //// Step 5 : Use built-in predicate functions
        //static IEnumerable<T> FilterItems<T>(IEnumerable<T> items, Func<T, bool> f)
        //{
        //    foreach (var item in items)
        //    {
        //        if (f(item))
        //            yield return item;
        //    }
        //}
    }
}
