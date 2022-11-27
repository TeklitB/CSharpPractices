using EFCoreDeleteBehaviors.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDeleteBehaviors.Domain.DataAccess.Repository
{
    public class Repository
    {
        private OrderDbContext _context;
        public Repository() 
        {
            var factory = new OrderDbContextFactory();
            _context = factory.CreateDbContext(new string[] { });
        }
        public async Task AddData()
        {
            var orderHeader = new OrderHeader { Description = "Foo Bar" };
            var detail1 = new OrderDetail { Product = "Foo", Qty = 1, OrderHeader = orderHeader};
            var detail2 = new OrderDetail { Product = "Bar", Qty = 2, OrderHeader = orderHeader };
            _context.OrderDetails.AddRange(detail1, detail2);
            await _context.SaveChangesAsync();

            // Throws System.InvalidOperation Exception due to Forign key constraint
            _context.OrderHeaders.Remove(orderHeader);
            await _context.SaveChangesAsync();
        }
    }
}
