
using EFCoreRelationshipsAndInheritance.Domain.DataAccess.Repository;

namespace EFCoreRelationshipsAndInheritance
{
    public class Programm
    {
        static void Main(string[] args)
        {
            var repository = new Repository();
            repository.AddData().Wait();
        }
    }
}

// Note: Add Nugat Packages:
// 1. Microsoft.EntityFrameworkCore.Design
// 2. Microsoft.EntityFrameworkCore.SqlServer
// 3. Microsoft.Extensions.Configuration
//      -> to read db connection string from file such as appsettings.json 
//      -> Specially usefull when we develop console application
// 4. Microsoft.Extensions.Logging.Console
