using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaTienda;
using LaTienda.Models.Auth;

namespace LaTienda.Controllers
{
    [CustomAuthorize(Roles = "Administrativo")]
    public class TalleSetsController : Controller
    {
        private LaTiendaEntities db = new LaTiendaEntities();

        // GET: TalleSets
        public ActionResult Index()
        {
            return View(db.TalleSet.ToList());
        }

        // GET: TalleSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalleSet talleSet = db.TalleSet.Find(id);
            if (talleSet == null)
            {
                return HttpNotFound();
            }
            return View(talleSet);
        }

        // GET: TalleSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TalleSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Descripcion")] TalleSet talleSet)
        {
            if (ModelState.IsValid)
            {
                db.TalleSet.Add(talleSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(talleSet);
        }

        // GET: TalleSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalleSet talleSet = db.TalleSet.Find(id);
            if (talleSet == null)
            {
                return HttpNotFound();
            }
            return View(talleSet);
        }

        // POST: TalleSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Descripcion")] TalleSet talleSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talleSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(talleSet);
        }

        // GET: TalleSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalleSet talleSet = db.TalleSet.Find(id);
            if (talleSet == null)
            {
                return HttpNotFound();
            }
            return View(talleSet);
        }

        // POST: TalleSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TalleSet talleSet = db.TalleSet.Find(id);
            db.TalleSet.Remove(talleSet);
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
