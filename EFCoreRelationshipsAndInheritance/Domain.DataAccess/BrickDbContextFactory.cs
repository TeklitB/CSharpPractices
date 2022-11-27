using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationshipsAndInheritance.Domain.DataAccess
{
    public class BrickDbContextFactory : IDesignTimeDbContextFactory<BrickDbContext>
    {
        public BrickDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var optionsBuilder = new DbContextOptionsBuilder<BrickDbContext>();
            optionsBuilder
                // Uncomment the following line if you want to print 
                // generated SQL statements on the console
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .UseSqlServer(configuration["ConnectionStrings:DbConnection"]);

            return new BrickDbContext(optionsBuilder.Options);
        }
    }
}
