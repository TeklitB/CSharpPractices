using DependencyInjection.Domain.DataAccess;

namespace DependencyInjection.ProductManagement
{
    public class PriceManager
    {
        private readonly ProductDbContext context;

        public PriceManager(ProductDbContext context)
        {
            this.context = context;
        }

        public void ChangePrices(decimal percPriceChange)
        {
            foreach (var p in context.Prices)
            {
                p.ProductPrice *= percPriceChange;
            }
        }
    }
}
