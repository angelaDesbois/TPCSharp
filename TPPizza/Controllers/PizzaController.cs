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
            vm.Pizza = FakeDB.Instance.ListePizza.FirstOrDefault(x => x.Id == vm.IdPates);
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
                vm.Pizza.Pate = FakeDB.Instance.ListePate.FirstOrDefault(x => x.Id == vm.IdPates);

                vm.Pizza.Ingredients = FakeDB.Instance.ListeIngredient.Where(x => vm.IdIngredients.Contains(x.Id)).ToList();

                FakeDB.Instance.ListePizza.Add(vm.Pizza);

                vm.Pizza.Id = FakeDB.Instance.ListePizza.Count == 0 ? 1 : FakeDB.Instance.ListePizza.Max(x=> x.Id)+1;

                return RedirectToAction("Index");
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
            return View();
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
