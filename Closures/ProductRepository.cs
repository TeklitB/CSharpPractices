using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closures
{
    //// Interface created without taking into consideration of HOF
    //interface IProductRepository
    //{
    //    int Create(Product product);
    //    bool Update(Product product);
    //    bool Delete(int id);
    //    Product GetById(int id);
    //    IEnumerable<Product> GetAll();
    //    IEnumerable<Product> GetByCategoryId(int categoryId);
    //    IEnumerable<Product> GetActive();
    //    // etc...
    //}

    // Interface created to use HOF
    interface IProductRepository
    {
        // create, update, delete omitted

        IEnumerable<Product> Get(Func<Product, bool> filter = null);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>(); // data source

        public IEnumerable<Product> Get(Func<Product, bool> filter = null)
        {
            // typically you might use the LINQ Where method here
            // but using the foreach to be clear what is happening

            if (filter is null) return _products;

            var filteredList = new List<Product>();
            foreach (var product in _products)
            {
                if (filter(product))
                {
                    filteredList.Add(product);
                }
            }

            return filteredList;
        }
    }
}
