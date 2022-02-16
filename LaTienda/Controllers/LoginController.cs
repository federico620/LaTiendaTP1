using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaTienda.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            LaTiendaEntities db = new LaTiendaEntities();
            ViewBag.PuntoDeVenta_Id = new SelectList(db.PuntoDeVentaSet, "Id", "Codigo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioSet objUser)
        {
            if (ModelState.IsValid)
            {
                LaTiendaEntities db = new LaTiendaEntities();
                {
                    var obj = db.UsuarioSet.Where(a => a.UsuarioNick.Equals(objUser.UsuarioNick) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.Nombre.ToString();
                        obj.PuntoDeVenta = objUser.PuntoDeVenta;
                        
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return View("index");
            }
        }
    }
}