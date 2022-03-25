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
    public class ClienteSetsController : Controller
    {
        private LaTiendaEntities db = new LaTiendaEntities();

        // GET: ClienteSets
        public ActionResult Index()
        {
            var clienteSet = db.ClienteSet.Include(c => c.CondicionTributaria);
            return View(clienteSet.ToList());
        }

        // GET: ClienteSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteSet clienteSet = db.ClienteSet.Find(id);
            if (clienteSet == null)
            {
                return HttpNotFound();
            }
            return View(clienteSet);
        }

        // GET: ClienteSets/Create
        public ActionResult Create()
        {
            ViewBag.CondicionTributariaId = new SelectList(db.CondicionTributariaSet, "Id", "Id");
            return View();
        }

        // POST: ClienteSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Documento,Domicilio,TipoDocumento,CondicionTributariaId")] ClienteSet clienteSet)
        {
            if (ModelState.IsValid)
            {
                db.ClienteSet.Add(clienteSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CondicionTributariaId = new SelectList(db.CondicionTributariaSet, "Id", "Id", clienteSet.CondicionTributariaId);
            return View(clienteSet);
        }

        // GET: ClienteSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteSet clienteSet = db.ClienteSet.Find(id);
            if (clienteSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.CondicionTributariaId = new SelectList(db.CondicionTributariaSet, "Id", "Id", clienteSet.CondicionTributariaId);
            return View(clienteSet);
        }

        // POST: ClienteSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Documento,Domicilio,TipoDocumento,CondicionTributariaId")] ClienteSet clienteSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clienteSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CondicionTributariaId = new SelectList(db.CondicionTributariaSet, "Id", "Id", clienteSet.CondicionTributariaId);
            return View(clienteSet);
        }

        // GET: ClienteSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteSet clienteSet = db.ClienteSet.Find(id);
            if (clienteSet == null)
            {
                return HttpNotFound();
            }
            return View(clienteSet);
        }

        // POST: ClienteSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClienteSet clienteSet = db.ClienteSet.Find(id);
            db.ClienteSet.Remove(clienteSet);
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
