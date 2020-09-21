using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TPPizza.DataBase;

namespace TPPizza.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidationPizzaIngredient : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            bool result = true;
            List<int> ingredient = (List<int>)value;
            List<Pizza> listPizza = FakeDB.Instance.ListePizza ;
           
            foreach (int item in ingredient)
            {
                if ()
                {
                    result = false;
                    return result;
                }
            }

            return result;
        }

        public override string FormatErrorMessage(string name)
        {

            return "y a déjà une pizza avec ces ingredients, change de recette!";
        }
    }
}