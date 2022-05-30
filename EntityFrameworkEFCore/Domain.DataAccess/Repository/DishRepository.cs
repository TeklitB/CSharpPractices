using EFCore.Model;
using System.Collections.Generic;
using System.Linq;

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
    }
}
