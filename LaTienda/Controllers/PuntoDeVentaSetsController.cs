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
    public class PuntoDeVentaSetsController : Controller
    {
        private LaTiendaEntities db = new LaTiendaEntities();

        // GET: PuntoDeVentaSets
        public ActionResult Index()
        {
            var puntoDeVentaSet = db.PuntoDeVentaSet.Include(p => p.SucursalSet);
            return View(puntoDeVentaSet.ToList());
        }

        // GET: PuntoDeVentaSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuntoDeVentaSet puntoDeVentaSet = db.PuntoDeVentaSet.Find(id);
            if (puntoDeVentaSet == null)
            {
                return HttpNotFound();
            }
            return View(puntoDeVentaSet);
        }

        // GET: PuntoDeVentaSets/Create
        public ActionResult Create()
        {
            ViewBag.Sucursal_Id = new SelectList(db.SucursalSet, "Id", "Descripcion");
            return View();
        }

        // POST: PuntoDeVentaSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Sucursal_Id")] PuntoDeVentaSet puntoDeVentaSet)
        {
            if (ModelState.IsValid)
            {
                db.PuntoDeVentaSet.Add(puntoDeVentaSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sucursal_Id = new SelectList(db.SucursalSet, "Id", "Descripcion", puntoDeVentaSet.Sucursal_Id);
            return View(puntoDeVentaSet);
        }

        // GET: PuntoDeVentaSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuntoDeVentaSet puntoDeVentaSet = db.PuntoDeVentaSet.Find(id);
            if (puntoDeVentaSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sucursal_Id = new SelectList(db.SucursalSet, "Id", "Descripcion", puntoDeVentaSet.Sucursal_Id);
            return View(puntoDeVentaSet);
        }

        // POST: PuntoDeVentaSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Sucursal_Id")] PuntoDeVentaSet puntoDeVentaSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puntoDeVentaSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sucursal_Id = new SelectList(db.SucursalSet, "Id", "Descripcion", puntoDeVentaSet.Sucursal_Id);
            return View(puntoDeVentaSet);
        }

        // GET: PuntoDeVentaSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuntoDeVentaSet puntoDeVentaSet = db.PuntoDeVentaSet.Find(id);
            if (puntoDeVentaSet == null)
            {
                return HttpNotFound();
            }
            return View(puntoDeVentaSet);
        }

        // POST: PuntoDeVentaSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PuntoDeVentaSet puntoDeVentaSet = db.PuntoDeVentaSet.Find(id);
            db.PuntoDeVentaSet.Remove(puntoDeVentaSet);
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
