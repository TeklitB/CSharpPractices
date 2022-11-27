using EFCoreRelationshipsAndInheritance.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationshipsAndInheritance.Domain.DataAccess
{
    public class BrickDbContext : DbContext
    {
        public BrickDbContext(DbContextOptions<BrickDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Brick> Bricks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<BrickAvailability> BrickAvailabilities { get; set; }

        /// <summary>
        /// ModelBuilder used to configure data model
        /// E.g. You can configure data model properties using the Fluent API instead of annotation based.
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Brick>().Property(p => p.Title).HasMaxLength(250);
            builder.Entity<Tag>().Property(p => p.Title).HasMaxLength(250);
            builder.Entity<Vendor>().Property(p => p.Name).HasMaxLength(250);
            builder.Entity<BrickAvailability>().Property(p => p.Price).HasPrecision(8, 2);

            builder.Entity<BasePlate>().HasBaseType<Brick>();
            builder.Entity<MinifigHead>().HasBaseType<Brick>();
        }
    }
}
