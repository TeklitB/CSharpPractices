using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closures
{
    public class MapperWithHOF
    {
        // definition
        public List<TOut> Map<TIn, TOut>(List<TIn> list, Func<TIn, TOut> mapper)
        {
            var newList = new List<TOut>();
            foreach (var item in list)
            {
                var newItem = mapper(item);
                newList.Add(newItem);
            }

            return newList;
        }
    }
}
