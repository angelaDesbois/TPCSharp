using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPPizza.DataBase;
using TPPizza.Models;

namespace TPPizza.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDB.Instance.ListePizza);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            PizzaCreateViewModel vm = new PizzaCreateViewModel();
            vm.Pizza = FakeDB.Instance.ListePizza.FirstOrDefault(x => x.Id == id);
            return View(vm);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaCreateViewModel vm = new PizzaCreateViewModel();
            vm.Ingredients = FakeDB.Instance.ListeIngredient;
            vm.Pates = FakeDB.Instance.ListePate;
            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaCreateViewModel vm)
        {
            try
            {
                if (ModelState.IsValid) { 
                vm.Pizza.Pate = FakeDB.Instance.ListePate.FirstOrDefault(x => x.Id == vm.IdPates);

                vm.Pizza.Ingredients = FakeDB.Instance.ListeIngredient.Where(x => vm.IdIngredients.Contains(x.Id)).ToList();

                FakeDB.Instance.ListePizza.Add(vm.Pizza);

                vm.Pizza.Id = FakeDB.Instance.ListePizza.Count == 0 ? 1 : FakeDB.Instance.ListePizza.Max(x=> x.Id)+1;

                return RedirectToAction("Index");
                }
                else
                {
                    vm.Ingredients = FakeDB.Instance.ListeIngredient;
                    vm.Pates = FakeDB.Instance.ListePate;
                    return View(vm);

                }
            }
            catch
            {
                vm.Pates = FakeDB.Instance.ListePate;
                return View(vm);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaCreateViewModel vm = new PizzaCreateViewModel();

            vm.Ingredients = FakeDB.Instance.ListeIngredient;
            vm.Pates = FakeDB.Instance.ListePate;

            vm.Pizza = FakeDB.Instance.ListePizza.FirstOrDefault(x => x.Id == id);

            if (vm.Pizza.Pate != null)
            {
                vm.IdPates = vm.Pizza.Pate.Id;
            }

            if (vm.Pizza.Ingredients.Any())
            {
                vm.IdIngredients = vm.Pizza.Ingredients.Select(x => x.Id).ToList();
            }

            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaCreateViewModel vm)
        {
            try
            {
                Pizza pizza = FakeDB.Instance.ListePizza.FirstOrDefault(x => x.Id == vm.Pizza.Id);
                pizza.Nom = vm.Pizza.Nom;
                pizza.Pate = FakeDB.Instance.ListePate.FirstOrDefault(x => x.Id == vm.IdPates);
                pizza.Ingredients = FakeDB.Instance.ListeIngredient.Where(x => vm.IdIngredients.Contains(x.Id)).ToList();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            PizzaCreateViewModel vm = new PizzaCreateViewModel();
            vm.Pizza = FakeDB.Instance.ListePizza.FirstOrDefault(x => x.Id == id);
            return View(vm);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
               Pizza pizza = FakeDB.Instance.ListePizza.FirstOrDefault(x => x.Id == id);
                FakeDB.Instance.ListePizza.Remove(pizza);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
