using EFCore.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Domain.DataAccess
{
    public class CookbookDbContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishIngredient> Ingredients { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CookbookDbContext(DbContextOptions<CookbookDbContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            : base(options)
        {

        }
    }
}
