using EFCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domain.DataAccess.Repository
{
    public class DishRepository
    {
        public void AddDishes(Dish dish)
        {
            var args = new[] { "create" };
            var factory = new CookbookContextFactory();
            using var dbContext = factory.CreateDbContext(args);           

            dbContext.Dishes.Add(dish);
            dbContext.SaveChanges();
        }

        public void UpdateDish(int id)
        {
            var args = new[] { "create" };
            var factory = new CookbookContextFactory();
            using var dbContext = factory.CreateDbContext(args);

            var dish = dbContext.Dishes.Where(x => x.Id == id).First();
            dish.Stars = 5;
            if (dish != null)
                dbContext.SaveChanges();
        }

        public void DeleteDish(int id)
        {
            var args = new[] { "create" };
            var factory = new CookbookContextFactory();
            using var dbContext = factory.CreateDbContext(args);

            var dish = dbContext.Dishes.Where(x => x.Id == id).First();
            if (dish != null)
                dbContext.Dishes.Remove(dish);
        }

        public Dish GetDish(int id)
        {
            var args = new[] { "create" };
            var factory = new CookbookContextFactory();
            using var dbContext = factory.CreateDbContext(args);

            return dbContext.Dishes.Single(x => x.Id == id);
        }

        public List<Dish> GetDishes(string title)
        {
            var args = new[] { "create" };
            var factory = new CookbookContextFactory();
            using var dbContext = factory.CreateDbContext(args);

            return dbContext.Dishes.Where(x => x.Title == title).ToList();
        }

        /// <summary>
        /// This methods used to track the state of the EF Core objects created.
        /// Entity States: Detached, Added, Unchanged, Modified, Deleted
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public void ExperimentEntityStatues()
        {
            var factory = new CookbookContextFactory();
            using var dbContext = factory.CreateDbContext(new[] { "create" });
            var dish = new Dish { Title = "Foo", Notes = "Bar" };

            // This shows the state of the object
            // State = Microsoft.EntityFrameworkCore.EntityState.Detached means the object has not come from db. 
            // It is a new object.
            var state = dbContext.Entry(dish).State; // << Detached >>

            dbContext.Add(dish);

            state = dbContext.Entry(dish).State; // << Added >>

            dbContext.SaveChanges();

            state = dbContext.Entry(dish).State; // << Unchanged >>

            dish.Notes = "Mushroom";
            state = dbContext.Entry(dish).State; // << Modified >>

            dbContext.SaveChanges();
            state = dbContext.Entry(dish).State; // << Unchanged >>

            dbContext.Dishes.Remove(dish);
            state = dbContext.Entry(dish).State; // << Deleted >>

            dbContext.SaveChanges();
            state = dbContext.Entry(dish).State; // << Detached >>

            Console.WriteLine("Tracking state of objects done.");
        }

        public void ChangeTracking()
        {
            var factory = new CookbookContextFactory();
            using var dbContext = factory.CreateDbContext(new[] { "create" });
            var dish = new Dish { Title = "Foo", Notes = "Bar" };
            dbContext.Add(dish);

            dbContext.SaveChanges();

            dish.Notes = "Mushroom";

            var entry = dbContext.Entry(dish);
            var originalValue = entry.OriginalValues[nameof(dish.Notes)];
            // This dbcontext returns the data from its change tracker not from DB
            // Hence, dishFromDb.Notes = "Mushroom" even though the change is not saved to database.
            var dishFromDb = dbContext.Dishes.Single(d => d.Id == dish.Id);

            // Create new database context
            using var dbContext2 = factory.CreateDbContext(new[] { "create" });
            //This dbcontext has no any change tracked and it returns the original value from DB.
            // Hence, dishFromDb.Notes = "Bar"
            var dishFromDbByDbContext2 = dbContext2.Dishes.Single(d => d.Id == dish.Id);
        }
    }
}
