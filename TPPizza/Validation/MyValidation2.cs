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
    public class MyValidation2 : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = true;
            Pizza pizzaName = (Pizza)value;
            List<Pizza> listePizza = FakeDB.Instance.ListePizza;
            foreach( Pizza item in listePizza)
            {
                if(item.Nom.Equals(pizzaName.Nom))
                {
                    result = false;
                    return result;
                }
            }

            return result;
        }

        public override string FormatErrorMessage(string name)
        {
           
            return "nom unique, trouve un autre nom, cheater!";
        }
    }
}