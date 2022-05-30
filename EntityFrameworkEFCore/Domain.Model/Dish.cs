using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Model
{
    public class Dish
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Notes { get; set; }
        public int? Stars { get; set; }
        public List<DishIngredient> Ingredients { get; set; }
    }
}
