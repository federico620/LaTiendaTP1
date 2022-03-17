﻿using System;
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
    public class ComprobanteSetsController : Controller
    {
        private LaTiendaEntities db = new LaTiendaEntities();

        // GET: ComprobanteSets
        public ActionResult Index()
        {
            return View(db.ComprobanteSet.ToList());
        }

        // GET: ComprobanteSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComprobanteSet comprobanteSet = db.ComprobanteSet.Find(id);
            if (comprobanteSet == null)
            {
                return HttpNotFound();
            }
            return View(comprobanteSet);
        }

        // GET: ComprobanteSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComprobanteSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CAE,Fecha,FechaVen,Concepto,TipoComprobante")] ComprobanteSet comprobanteSet)
        {
            if (ModelState.IsValid)
            {
                db.ComprobanteSet.Add(comprobanteSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comprobanteSet);
        }

        // GET: ComprobanteSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComprobanteSet comprobanteSet = db.ComprobanteSet.Find(id);
            if (comprobanteSet == null)
            {
                return HttpNotFound();
            }
            return View(comprobanteSet);
        }

        // POST: ComprobanteSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CAE,Fecha,FechaVen,Concepto,TipoComprobante")] ComprobanteSet comprobanteSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comprobanteSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comprobanteSet);
        }

        // GET: ComprobanteSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComprobanteSet comprobanteSet = db.ComprobanteSet.Find(id);
            if (comprobanteSet == null)
            {
                return HttpNotFound();
            }
            return View(comprobanteSet);
        }

        // POST: ComprobanteSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComprobanteSet comprobanteSet = db.ComprobanteSet.Find(id);
            db.ComprobanteSet.Remove(comprobanteSet);
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
