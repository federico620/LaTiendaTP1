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
    public class LineaDeVentaSetsController : Controller
    {
        private LaTiendaEntities db = new LaTiendaEntities();

        // GET: LineaDeVentaSets
        public ActionResult Index()
        {
            var lineaDeVentaSet = db.LineaDeVentaSet.Include(l => l.StockSet).Include(l => l.VentaSet);
            return View(lineaDeVentaSet.ToList());
        }

        // GET: LineaDeVentaSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaDeVentaSet lineaDeVentaSet = db.LineaDeVentaSet.Find(id);
            if (lineaDeVentaSet == null)
            {
                return HttpNotFound();
            }
            return View(lineaDeVentaSet);
        }

        // GET: LineaDeVentaSets/Create
        public ActionResult Create()
        {
            ViewBag.StockSet_Id = new SelectList(db.StockSet, "Id", "Cantidad");
            ViewBag.Venta_Id = new SelectList(db.VentaSet, "Id", "Id");
            return View();
        }

        // POST: LineaDeVentaSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cantidad,PrecioDeVenta,StockSet_Id,Venta_Id")] LineaDeVentaSet lineaDeVentaSet)
        {
            if (ModelState.IsValid)
            {
                db.LineaDeVentaSet.Add(lineaDeVentaSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StockSet_Id = new SelectList(db.StockSet, "Id", "Cantidad", lineaDeVentaSet.StockSet_Id);
            ViewBag.Venta_Id = new SelectList(db.VentaSet, "Id", "Id", lineaDeVentaSet.Venta_Id);
            return View(lineaDeVentaSet);
        }

        // GET: LineaDeVentaSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaDeVentaSet lineaDeVentaSet = db.LineaDeVentaSet.Find(id);
            if (lineaDeVentaSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.StockSet_Id = new SelectList(db.StockSet, "Id", "Cantidad", lineaDeVentaSet.StockSet_Id);
            ViewBag.Venta_Id = new SelectList(db.VentaSet, "Id", "Id", lineaDeVentaSet.Venta_Id);
            return View(lineaDeVentaSet);
        }

        // POST: LineaDeVentaSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cantidad,PrecioDeVenta,StockSet_Id,Venta_Id")] LineaDeVentaSet lineaDeVentaSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lineaDeVentaSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StockSet_Id = new SelectList(db.StockSet, "Id", "Cantidad", lineaDeVentaSet.StockSet_Id);
            ViewBag.Venta_Id = new SelectList(db.VentaSet, "Id", "Id", lineaDeVentaSet.Venta_Id);
            return View(lineaDeVentaSet);
        }

        // GET: LineaDeVentaSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaDeVentaSet lineaDeVentaSet = db.LineaDeVentaSet.Find(id);
            if (lineaDeVentaSet == null)
            {
                return HttpNotFound();
            }
            return View(lineaDeVentaSet);
        }

        // POST: LineaDeVentaSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LineaDeVentaSet lineaDeVentaSet = db.LineaDeVentaSet.Find(id);
            db.LineaDeVentaSet.Remove(lineaDeVentaSet);
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
