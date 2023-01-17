using DependencyInjection.Domain.DataAccess;
using DependencyInjection.Domain.Model;

namespace DependencyInjection.ProductManagement
{
    public class LogManager
    {
        private readonly ProductDbContext context;

        public LogManager(ProductDbContext context)
        {
            this.context = context;
        }

        public void AddLog(string user, string description)
        {
            context.Logs.Add(new Log
            {
                User = user,
                Description = description,
                LogDateTime = DateTime.UtcNow
            });
        }
    }
}
