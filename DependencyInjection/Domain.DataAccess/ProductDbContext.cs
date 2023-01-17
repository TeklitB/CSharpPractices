using DependencyInjection.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DependencyInjection.Domain.DataAccess
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        { }

        public DbSet<Price> Prices { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
