﻿using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Model
{
    public class DishIngredient
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasure { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Amount { get; set; }
        public Dish Dish { get; set; }
        public int DishId { get; set; }
    }
}
