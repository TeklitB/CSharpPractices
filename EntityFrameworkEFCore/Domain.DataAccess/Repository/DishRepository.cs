using EFCore.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.Domain.DataAccess.Repository
{
    public class DishRepository
    {
        public DishRepository() { }

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

        /// <summary>
        /// This method is to experiment forcefully changing the entity state
        /// </summary>
        public void AttachEntities()
        {
            var factory = new CookbookContextFactory();
            using var dbContext = factory.CreateDbContext(new[] { "create" });
            var dish = new Dish { Title = "Foo", Notes = "Bar" };
            dbContext.Add(dish);

            dbContext.SaveChanges();

            // EF: Forget the dish object.
            dbContext.Entry(dish).State = EntityState.Detached;
            var state = dbContext.Entry(dish).State;

            // Takes an object which is not part of the EF change tracker
            // and add it to the change tracker.
            dbContext.Dishes.Update(dish);
            dbContext.SaveChanges();
        }

        public void NoTrackingEntities()
        {
            var factory = new CookbookContextFactory();
            using var dbContext = factory.CreateDbContext(new[] { "create" });
            var dish = new Dish { Title = "Foo", Notes = "Bar" };
            dbContext.Add(dish);
            dbContext.SaveChanges();

            // SELECT * FROM Dishes
            // It puts the objects into the change tracker
            var dishes = dbContext.Dishes.ToList();
            var dishesState = dbContext.Entry(dishes[0]).State; // State << Unchanged >>
            
            // Do not put the objects into the change tracker
            // IF make changes on these objects, nothing will happen as they are not tracked.
            // Used in readonly senario, that you do not want to write anything back to the database.
            var notTrackedDishes = dbContext.Dishes.AsNoTracking().ToList();
            var notTrackedDishesState = dbContext.Entry(notTrackedDishes[0]).State; // State << Detached >>

            notTrackedDishes[0].Notes = "Mushroom";
            // If you want to apply the change
            //dbContext.Dishes.Update(notTrackedDishes[0]);
            //dbContext.SaveChanges();

            var updatedDishes = dbContext.Dishes.AsNoTracking().ToList();
        }

        public void ExecuteRawSql()
        {
            var factory = new CookbookContextFactory();
            using var dbContext = factory.CreateDbContext(new[] { "create" });
            var dishes1 = dbContext.Dishes
                .FromSqlRaw("SELECT * FROM Dishes")
                .ToList();

            var filter = "%z";
            var dishes2 = dbContext.Dishes
                .FromSqlInterpolated($"SELECT * FROM Dishes WHERE Notes LIKE {filter}")
                .ToList();

            // SQL Injection
            // This is a BAD practice. Because it is volunerable to sql inject attack.
            // Example when var search = "%z; DELET FROM Dishes", it generates the following sql query.
            //  SELECT * FROM Dishes WHERE Notes LIKE '%z; DELET FROM Dishes'
            //var search = "%z; DELET FROM Dishes";
            //var dishes3 = dbContext.Dishes
            //    .FromSqlRaw("SELECT * FROM Dishes WHERE Notes LIKE '" + search + "'")
            //    .ToList();

            dbContext.Database.ExecuteSqlRaw("Delete FROM Dishes");
        }

        public void Transactions()
        {
            var factory = new CookbookContextFactory();
            using var dbContext = factory.CreateDbContext(new[] { "create" });
            var dish = new Dish { Title = "Foo", Notes = "Bar" };
            using var transaction = dbContext.Database.BeginTransaction();
            try
            {
                dbContext.Add(dish);
                dbContext.SaveChanges();

                dbContext.Database.ExecuteSqlRaw("SELECT 1/0 as Bad");
                transaction.Commit();
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
