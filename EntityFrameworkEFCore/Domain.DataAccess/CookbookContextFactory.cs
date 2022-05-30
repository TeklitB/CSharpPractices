using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EFCore.Domain.DataAccess
{
    public class CookbookContextFactory : IDesignTimeDbContextFactory<CookbookDbContext>
    {
        public CookbookDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder<CookbookDbContext>();
            optionsBuilder
                 // Uncomment the following line if you want to print generated
                 // SQL statements on the console.
                 .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .UseSqlServer(configuration["ConnectionStrings:DbConnection"]);

            return new CookbookDbContext(optionsBuilder.Options);
        }
    }
}
