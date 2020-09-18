﻿using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPPizza.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MyValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = false;
            List<Ingredient> ingredientSelected = (List<Ingredient>)value;
            if (ingredientSelected.Count < 2 || ingredientSelected.Count > 5)
            {
                result = true;

            }

            return result;
        }
        public override string FormatErrorMessage(string name)
        {
            name = "entre 2 et 5";
            return base.FormatErrorMessage(name);
        }
    }
   
}