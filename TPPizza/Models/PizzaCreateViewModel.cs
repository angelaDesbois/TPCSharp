using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPPizza.Models
{
    public class PizzaCreateViewModel
    {
        public Pizza Pizza { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Pate> Pates { get; set; }


        public List <int> IdIngredients { get; set; }
        public int IdPates { get; set; }
    }
}