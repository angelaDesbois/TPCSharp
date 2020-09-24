using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using BOTP6;
using TPNinja.Data;
using TPNinja.Models;

namespace TPNinja.Controllers
{
    public class SamouraisController : Controller
    {
        private TPNinjaContext db = new TPNinjaContext();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
          
            VmSamourai vm = new VmSamourai();
            vm.artMartials = db.ArtMartials.ToList();
            this.getListeArmesDisposDb(vm);
            
           // vm.armes = db.Armes.ToList();
            return View(vm);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VmSamourai vm)
        {
            if (ModelState.IsValid)
            {
                vm.samourai.Arme = db.Armes.Find(vm.armesId);
                vm.samourai.artMartials = db.ArtMartials.Where(x => vm.artMatialIdSelected.Contains(x.Id)).ToList();
                db.Samourais.Add(vm.samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            this.getListeArmesDisposDb(vm);
            vm.artMartials = db.ArtMartials.ToList();

            return View(vm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {

            

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }

            VmSamourai vm = new VmSamourai();
            vm.samourai = samourai;
           // vm.armes = db.Armes.ToList();
            vm.artMartials = db.ArtMartials.ToList();
            this.getListeArmesDisposDb(vm);
            // vm.armesId = vm.samourai.Arme.Id;

            return View(vm);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VmSamourai vm)
        {
            
                 if (ModelState.IsValid)
                {
                    Samourai samourai = db.Samourais.FirstOrDefault(x => x.Id == vm.samourai.Id);


                    samourai.Nom = vm.samourai.Nom;
                    samourai.Force = vm.samourai.Force;
                // samourai.Arme = vm.samourai.Arme;


                    var a = samourai.Arme;
                    if(vm.armesId != null)
                {
                    samourai.Arme = db.Armes.Find(vm.armesId);

                }
                else
                {
                    samourai.Arme = null;
                }

                samourai.artMartials.Clear();
                foreach (var art in vm.artMatialIdSelected)
                {

                    ArtMartial artMartial = db.ArtMartials.Find(art);
                    samourai.artMartials.Add(artMartial);
                }

                db.Entry(samourai).State = EntityState.Modified;
                     db.SaveChanges();
                     return RedirectToAction("Index");
                }
            
          
                 return View(vm);
            
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private List<Arme> getListeArmesDisposDb(VmSamourai vm)
        {
            vm.armes = new List<Arme>();
            foreach (var arme in db.Armes.ToList())
            {
                if (db.Samourais.Where(x => x.Arme.Id == arme.Id).ToList().Count() == 0)
                {
                    vm.armes.Add(arme);
                }
            }
            return vm.armes;
        }
    }
}
