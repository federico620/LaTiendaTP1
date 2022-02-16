using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaTienda;

namespace LaTienda.Controllers
{
    public class RubroSetsController : Controller
    {
        private LaTiendaEntities db = new LaTiendaEntities();

        // GET: RubroSets
        public ActionResult Index()
        {
            return View(db.RubroSet.ToList());
        }

        // GET: RubroSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RubroSet rubroSet = db.RubroSet.Find(id);
            if (rubroSet == null)
            {
                return HttpNotFound();
            }
            return View(rubroSet);
        }

        // GET: RubroSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RubroSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Descripcion")] RubroSet rubroSet)
        {
            if (ModelState.IsValid)
            {
                db.RubroSet.Add(rubroSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rubroSet);
        }

        // GET: RubroSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RubroSet rubroSet = db.RubroSet.Find(id);
            if (rubroSet == null)
            {
                return HttpNotFound();
            }
            return View(rubroSet);
        }

        // POST: RubroSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Descripcion")] RubroSet rubroSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rubroSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rubroSet);
        }

        // GET: RubroSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RubroSet rubroSet = db.RubroSet.Find(id);
            if (rubroSet == null)
            {
                return HttpNotFound();
            }
            return View(rubroSet);
        }

        // POST: RubroSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RubroSet rubroSet = db.RubroSet.Find(id);
            db.RubroSet.Remove(rubroSet);
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
    }
}
