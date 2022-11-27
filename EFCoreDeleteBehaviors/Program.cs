using EFCoreDeleteBehaviors.Domain.DataAccess.Repository;

namespace EFCoreDeleteBehaviors
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var repository = new Repository();
            await repository.AddData();
        }
    }
}