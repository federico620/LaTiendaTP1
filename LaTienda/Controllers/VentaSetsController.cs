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
    public class VentaSetsController : Controller
    {
        private LaTiendaEntities db = new LaTiendaEntities();

        // GET: VentaSets
        public ActionResult Index()
        {
            var ventaSet = db.VentaSet.Include(v => v.ClienteSet).Include(v => v.UsuarioSet);
            return View(ventaSet.ToList());
        }

        // GET: VentaSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaSet ventaSet = db.VentaSet.Find(id);
            if (ventaSet == null)
            {
                return HttpNotFound();
            }
            return View(ventaSet);
        }

        // GET: VentaSets/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_Id = new SelectList(db.ClienteSet, "Id", "Nombre");
            
            return View();
        }

        // POST: VentaSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Total,Cliente_Id")] VentaSet ventaSet)
        {
            if (ModelState.IsValid)
            {
                var usuario = db.UsuarioSet.Find(Session["UserID"]);
                ventaSet.UsuarioSet = usuario;
                ventaSet.Usuario_Id = usuario.Id;
                db.VentaSet.Add(ventaSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente_Id = new SelectList(db.ClienteSet, "Id", "Nombre", ventaSet.Cliente_Id);
            
            return View(ventaSet);
        }

        // GET: VentaSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaSet ventaSet = db.VentaSet.Find(id);
            if (ventaSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_Id = new SelectList(db.ClienteSet, "Id", "Nombre", ventaSet.Cliente_Id);
            ViewBag.Usuario_Id = new SelectList(db.UsuarioSet, "Id", "Nombre", ventaSet.Usuario_Id);
            return View(ventaSet);
        }

        // POST: VentaSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Total,Comprobante_Id,Cliente_Id,Usuario_Id")] VentaSet ventaSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventaSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente_Id = new SelectList(db.ClienteSet, "Id", "Nombre", ventaSet.Cliente_Id);
            ViewBag.Usuario_Id = new SelectList(db.UsuarioSet, "Id", "Nombre", ventaSet.Usuario_Id);
            return View(ventaSet);
        }

        // GET: VentaSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaSet ventaSet = db.VentaSet.Find(id);
            if (ventaSet == null)
            {
                return HttpNotFound();
            }
            return View(ventaSet);
        }

        // POST: VentaSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VentaSet ventaSet = db.VentaSet.Include(x => x.LineaDeVentaSet).Include(x => x.ClienteSet).FirstOrDefault(x => x.Id.Equals(id));
            
            var lvs = ventaSet.LineaDeVentaSet.ToList();
            foreach (var lv in lvs)
            {
                db.LineaDeVentaSet.Remove(lv);
            }
            db.VentaSet.Remove(ventaSet);
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
