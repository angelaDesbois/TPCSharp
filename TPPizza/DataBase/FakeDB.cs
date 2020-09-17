using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPPizza.DataBase
{
    public class FakeDB
    {
        private static readonly Lazy<FakeDB> lazy =
         new Lazy<FakeDB>(() => new FakeDB());

        /// <summary>
        /// FakeDb singleton access.
        /// </summary>
        public static FakeDB Instance { get { return lazy.Value; } }

        private FakeDB()
        {
            this.ListeIngredient = IngredientsDisponibles;
            this.ListePate = PatesDisponibles;
            this.ListePizza = new List<Pizza>();

        }


       
        public List<Ingredient> ListeIngredient { get; private set; }
        public List<Pate> ListePate { get; private set; }
        public List<Pizza> ListePizza { get; private set; }
        public  List<Ingredient> IngredientsDisponibles => new List<Ingredient>
        {
            new Ingredient{Id=1,Nom="Mozzarella"},
            new Ingredient{Id=2,Nom="Jambon"},
            new Ingredient{Id=3,Nom="Tomate"},
            new Ingredient{Id=4,Nom="Oignon"},
            new Ingredient{Id=5,Nom="Cheddar"},
            new Ingredient{Id=6,Nom="Saumon"},
            new Ingredient{Id=7,Nom="Champignon"},
            new Ingredient{Id=8,Nom="Poulet"},
            new Ingredient{Id=8,Nom="Chorizo"}
        };

        public  List<Pate> PatesDisponibles => new List<Pate>
        {
            new Pate{ Id=1,Nom="Pate fine, base crême"},
            new Pate{ Id=2,Nom="Pate fine, base tomate"},
            new Pate{ Id=3,Nom="Pate épaisse, base crême"},
            new Pate{ Id=4,Nom="Pate épaisse, base tomate"}
        };
    }

   
    }
