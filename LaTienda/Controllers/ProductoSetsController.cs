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
    public class ProductoSetsController : Controller
    {
        private LaTiendaEntities db = new LaTiendaEntities();

        // GET: ProductoSets
        public ActionResult Index()
        {
            var productoSet = db.ProductoSet.Include(p => p.MarcaSet).Include(p => p.RubroSet);
            return View(productoSet.ToList());
        }

        // GET: ProductoSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoSet productoSet = db.ProductoSet.Find(id);
            if (productoSet == null)
            {
                return HttpNotFound();
            }
            return View(productoSet);
        }

        // GET: ProductoSets/Create
        public ActionResult Create()
        {
            ViewBag.Marca_Id = new SelectList(db.MarcaSet, "Id", "Descripcion");
            ViewBag.Rubro_Id = new SelectList(db.RubroSet, "Id", "Descripcion");
            return View();
        }

        // POST: ProductoSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Descripcion,Costo,MargenDeGanancia,PorcentajeIva,Rubro_Id,Marca_Id")] ProductoSet productoSet)
        {
            if (ModelState.IsValid)
            {
                productoSet.RealizarCalculos();
                db.ProductoSet.Add(productoSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Marca_Id = new SelectList(db.MarcaSet, "Id", "Descripcion", productoSet.Marca_Id);
            ViewBag.Rubro_Id = new SelectList(db.RubroSet, "Id", "Descripcion", productoSet.Rubro_Id);
            return View(productoSet);
        }

        // GET: ProductoSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoSet productoSet = db.ProductoSet.Find(id);
            if (productoSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Marca_Id = new SelectList(db.MarcaSet, "Id", "Descripcion", productoSet.Marca_Id);
            ViewBag.Rubro_Id = new SelectList(db.RubroSet, "Id", "Descripcion", productoSet.Rubro_Id);
            return View(productoSet);
        }

        // POST: ProductoSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Descripcion,Costo,MargenDeGanancia,PorcentajeIva,Rubro_Id,Marca_Id")] ProductoSet productoSet)
        {
            if (ModelState.IsValid)
            {
                productoSet.RealizarCalculos();
                db.Entry(productoSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Marca_Id = new SelectList(db.MarcaSet, "Id", "Descripcion", productoSet.Marca_Id);
            ViewBag.Rubro_Id = new SelectList(db.RubroSet, "Id", "Descripcion", productoSet.Rubro_Id);
            return View(productoSet);
        }

        // GET: ProductoSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoSet productoSet = db.ProductoSet.Find(id);
            if (productoSet == null)
            {
                return HttpNotFound();
            }
            return View(productoSet);
        }

        // POST: ProductoSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoSet productoSet = db.ProductoSet.Find(id);
            db.ProductoSet.Remove(productoSet);
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
