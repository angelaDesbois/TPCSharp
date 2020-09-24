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

        private List<int> ingredient = null;
        public override bool IsValid(object value)
        {
            //    bool result = false;
            //    this.ingredient = value as List<int>;
            //    List<Pizza> listPizza = FakeDB.Instance.ListePizza ;

            //    foreach (var pizza in listPizza)
            //    {
            //        if (ingredient.Count() == pizza.Ingredients.Count() )
            //        {
            //           foreach (var ingredientPizza  in pizza.Ingredients)
            //            {
            //                foreach (var selectIngredientId in ingredient)
            //                {
            //                    if (selectIngredientId == ingredientPizza.Id)
            //                    {
            //                        result = false;
            //                    }
            //                    else
            //                    {
            //                        result = true;
            //                        return result;
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            result = true;
            //        }
            //    }

            //    return result;
            //}
            bool result = true;

            if (value is List<int>)
            {
                var maList = value as List<int>;

                if (FakeDB.Instance.ListePizza.Any(x => x.Ingredients.Select(y => y.Id).OrderBy(z => z).SequenceEqual(maList.OrderBy(z => z))))
                {
                    result = false;
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