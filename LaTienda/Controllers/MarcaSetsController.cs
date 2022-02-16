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
    public class MarcaSetsController : Controller
    {
        private LaTiendaEntities db = new LaTiendaEntities();

        // GET: MarcaSets
        public ActionResult Index()
        {
            return View(db.MarcaSet.ToList());
        }

        // GET: MarcaSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaSet marcaSet = db.MarcaSet.Find(id);
            if (marcaSet == null)
            {
                return HttpNotFound();
            }
            return View(marcaSet);
        }

        // GET: MarcaSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarcaSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Descripcion")] MarcaSet marcaSet)
        {
            if (ModelState.IsValid)
            {
                db.MarcaSet.Add(marcaSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marcaSet);
        }

        // GET: MarcaSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaSet marcaSet = db.MarcaSet.Find(id);
            if (marcaSet == null)
            {
                return HttpNotFound();
            }
            return View(marcaSet);
        }

        // POST: MarcaSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Descripcion")] MarcaSet marcaSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marcaSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marcaSet);
        }

        // GET: MarcaSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaSet marcaSet = db.MarcaSet.Find(id);
            if (marcaSet == null)
            {
                return HttpNotFound();
            }
            return View(marcaSet);
        }

        // POST: MarcaSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MarcaSet marcaSet = db.MarcaSet.Find(id);
            db.MarcaSet.Remove(marcaSet);
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
