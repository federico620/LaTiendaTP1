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
    public class StockSetsController : Controller
    {
        private LaTiendaEntities db = new LaTiendaEntities();

        // GET: StockSets
        public ActionResult Index()
        {
            var stockSet = db.StockSet.Include(s => s.ColorSet).Include(s => s.ProductoSet).Include(s => s.SucursalSet).Include(s => s.TalleSet);
            return View(stockSet.ToList());
        }

        // GET: StockSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockSet stockSet = db.StockSet.Find(id);
            if (stockSet == null)
            {
                return HttpNotFound();
            }
            return View(stockSet);
        }

        // GET: StockSets/Create
        public ActionResult Create()
        {
            ViewBag.Color_Id = new SelectList(db.ColorSet, "Id", "Descripcion");
            ViewBag.Producto_Id = new SelectList(db.ProductoSet, "Id", "Descripcion");
            ViewBag.SucursalId = new SelectList(db.SucursalSet, "Id", "Descripcion");
            ViewBag.Talle_Id = new SelectList(db.TalleSet, "Id", "Descripcion");
            return View();
        }

        // POST: StockSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cantidad,Color_Id,Talle_Id,Producto_Id,SucursalId")] StockSet stockSet)
        {
            if (ModelState.IsValid)
            {
                db.StockSet.Add(stockSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Color_Id = new SelectList(db.ColorSet, "Id", "Descripcion", stockSet.Color_Id);
            ViewBag.Producto_Id = new SelectList(db.ProductoSet, "Id", "Descripcion", stockSet.Producto_Id);
            ViewBag.SucursalId = new SelectList(db.SucursalSet, "Id", "Descripcion", stockSet.SucursalId);
            ViewBag.Talle_Id = new SelectList(db.TalleSet, "Id", "Descripcion", stockSet.Talle_Id);
            return View(stockSet);
        }

        // GET: StockSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockSet stockSet = db.StockSet.Find(id);
            if (stockSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Color_Id = new SelectList(db.ColorSet, "Id", "Descripcion", stockSet.Color_Id);
            ViewBag.Producto_Id = new SelectList(db.ProductoSet, "Id", "Descripcion", stockSet.Producto_Id);
            ViewBag.SucursalId = new SelectList(db.SucursalSet, "Id", "Descripcion", stockSet.SucursalId);
            ViewBag.Talle_Id = new SelectList(db.TalleSet, "Id", "Descripcion", stockSet.Talle_Id);
            return View(stockSet);
        }

        // POST: StockSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cantidad,Color_Id,Talle_Id,Producto_Id,SucursalId")] StockSet stockSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Color_Id = new SelectList(db.ColorSet, "Id", "Descripcion", stockSet.Color_Id);
            ViewBag.Producto_Id = new SelectList(db.ProductoSet, "Id", "Descripcion", stockSet.Producto_Id);
            ViewBag.SucursalId = new SelectList(db.SucursalSet, "Id", "Descripcion", stockSet.SucursalId);
            ViewBag.Talle_Id = new SelectList(db.TalleSet, "Id", "Descripcion", stockSet.Talle_Id);
            return View(stockSet);
        }

        // GET: StockSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockSet stockSet = db.StockSet.Find(id);
            if (stockSet == null)
            {
                return HttpNotFound();
            }
            return View(stockSet);
        }

        // POST: StockSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockSet stockSet = db.StockSet.Find(id);
            db.StockSet.Remove(stockSet);
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
