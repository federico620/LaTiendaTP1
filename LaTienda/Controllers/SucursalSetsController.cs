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
    public class SucursalSetsController : Controller
    {
        private LaTiendaEntities db = new LaTiendaEntities();

        // GET: SucursalSets
        public ActionResult Index()
        {
            return View(db.SucursalSet.ToList());
        }

        // GET: SucursalSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalSet sucursalSet = db.SucursalSet.Find(id);
            if (sucursalSet == null)
            {
                return HttpNotFound();
            }
            return View(sucursalSet);
        }

        // GET: SucursalSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SucursalSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Numero,Descripcion,Sign,Cuit,TipoDocumento")] SucursalSet sucursalSet)
        {
            if (ModelState.IsValid)
            {
                db.SucursalSet.Add(sucursalSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sucursalSet);
        }

        // GET: SucursalSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalSet sucursalSet = db.SucursalSet.Find(id);
            if (sucursalSet == null)
            {
                return HttpNotFound();
            }
            return View(sucursalSet);
        }

        // POST: SucursalSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Numero,Descripcion,Sign,Cuit,TipoDocumento")] SucursalSet sucursalSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursalSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sucursalSet);
        }

        // GET: SucursalSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalSet sucursalSet = db.SucursalSet.Find(id);
            if (sucursalSet == null)
            {
                return HttpNotFound();
            }
            return View(sucursalSet);
        }

        // POST: SucursalSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SucursalSet sucursalSet = db.SucursalSet.Find(id);
            db.SucursalSet.Remove(sucursalSet);
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
