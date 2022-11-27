using EFCoreDeleteBehaviors.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDeleteBehaviors.Domain.DataAccess
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {

        }

        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        /// <summary>
        /// ModelBuilder used to configure data model
        /// E.g. You can configure data model properties using the Fluent API instead of annotation based.
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderHeader>()
                .HasMany(x => x.OrderDetails)
                .WithOne(x => x.OrderHeader)
                .HasForeignKey(x => x.OrderHeaderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderDetail>().Property(p => p.Product).HasMaxLength(250);
            builder.Entity<OrderHeader>().Property(p => p.Description).HasMaxLength(250);
        }
    }
}
