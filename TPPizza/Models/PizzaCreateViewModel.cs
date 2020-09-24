using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPPizza.Validation;

namespace TPPizza.Models
{
    public class PizzaCreateViewModel
    {
        [MyValidation2]
        public Pizza Pizza { get; set; }
       
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Pate> Pates { get; set; } = new List<Pate>();

        [MyValidation]
        [ValidationPizzaIngredient]
        public List<int> IdIngredients { get; set; } 
        public int? IdPates { get; set; }
    }
}