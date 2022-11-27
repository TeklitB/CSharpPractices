using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDeleteBehaviors.Domain.Model
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<OrderDetail> OrderDetails { get;set; }
    }
}
