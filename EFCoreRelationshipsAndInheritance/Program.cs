
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
// 1. Microsoft.EntityFrameworkCore
// 2. Microsoft.EntityFrameworkCore.Design
// 3. Microsoft.EntityFrameworkCore.SqlServer
// 4. Microsoft.Extensions.Configuration.Json
//      -> to read db connection string from file such as appsettings.json 
//      -> Specially usefull when we develop console application
// 5. Microsoft.Extensions.Logging.Console
