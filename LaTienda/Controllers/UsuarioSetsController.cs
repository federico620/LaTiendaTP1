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
    public class UsuarioSetsController : Controller
    {
        private LaTiendaEntities db = new LaTiendaEntities();

        // GET: UsuarioSets
        public ActionResult Index()
        {
            var usuarioSet = db.UsuarioSet.Include(u => u.SucursalSet);
            return View(usuarioSet.ToList());
        }

        // GET: UsuarioSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioSet usuarioSet = db.UsuarioSet.Find(id);
            if (usuarioSet == null)
            {
                return HttpNotFound();
            }
            return View(usuarioSet);
        }

        // GET: UsuarioSets/Create
        public ActionResult Create()
        {
            ViewBag.Sucursal_Id = new SelectList(db.SucursalSet, "Id", "Descripcion");
            return View();
        }

        // POST: UsuarioSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Legajo,UsuarioNick,Password,RolUsuario1,Sucursal_Id")] UsuarioSet usuarioSet)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioSet.Add(usuarioSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sucursal_Id = new SelectList(db.SucursalSet, "Id", "Descripcion", usuarioSet.Sucursal_Id);
            return View(usuarioSet);
        }

        // GET: UsuarioSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioSet usuarioSet = db.UsuarioSet.Find(id);
            if (usuarioSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sucursal_Id = new SelectList(db.SucursalSet, "Id", "Descripcion", usuarioSet.Sucursal_Id);
            return View(usuarioSet);
        }

        // POST: UsuarioSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Legajo,UsuarioNick,Password,RolUsuario1,Sucursal_Id")] UsuarioSet usuarioSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sucursal_Id = new SelectList(db.SucursalSet, "Id", "Descripcion", usuarioSet.Sucursal_Id);
            return View(usuarioSet);
        }

        // GET: UsuarioSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioSet usuarioSet = db.UsuarioSet.Find(id);
            if (usuarioSet == null)
            {
                return HttpNotFound();
            }
            return View(usuarioSet);
        }

        // POST: UsuarioSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioSet usuarioSet = db.UsuarioSet.Find(id);
            db.UsuarioSet.Remove(usuarioSet);
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
