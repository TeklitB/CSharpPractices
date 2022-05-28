using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closures
{
    public interface Product
    {
        public int Id { get; }
        public string Name { get; }
        public int CategoryId { get; }
        public bool IsActive { get; }
    }
}
