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
    public class ColorSetsController : Controller
    {
        private LaTiendaEntities db = new LaTiendaEntities();

        // GET: ColorSets
        public ViewResult Index(string searchString)
        {


            if (!String.IsNullOrEmpty(searchString))
            {
                var colores = db.ColorSet.Where(s => s.Codigo.ToString().Contains(searchString));
                return View(colores.ToList());
            }
            else
            {
                return View(db.ColorSet.ToList());
            }
        }

        // GET: ColorSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorSet colorSet = db.ColorSet.Find(id);
            if (colorSet == null)
            {
                return HttpNotFound();
            }
            return View(colorSet);
        }

        // GET: ColorSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColorSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Descripcion")] ColorSet colorSet)
        {
            if (ModelState.IsValid)
            {
                db.ColorSet.Add(colorSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colorSet);
        }

        // GET: ColorSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorSet colorSet = db.ColorSet.Find(id);
            if (colorSet == null)
            {
                return HttpNotFound();
            }
            return View(colorSet);
        }

        // POST: ColorSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Descripcion")] ColorSet colorSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colorSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colorSet);
        }

        // GET: ColorSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorSet colorSet = db.ColorSet.Find(id);
            if (colorSet == null)
            {
                return HttpNotFound();
            }
            return View(colorSet);
        }

        // POST: ColorSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ColorSet colorSet = db.ColorSet.Find(id);
            db.ColorSet.Remove(colorSet);
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
