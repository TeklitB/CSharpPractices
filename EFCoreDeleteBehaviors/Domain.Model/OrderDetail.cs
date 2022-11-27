using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDeleteBehaviors.Domain.Model
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Qty { get; set; }
        public OrderHeader OrderHeader { get; set; }
        public int OrderHeaderId { get; set; }
    }
}
