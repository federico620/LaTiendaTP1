using LaTienda.Models.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LaTienda.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Login()
        {
            LaTiendaEntities db = new LaTiendaEntities();
            ViewBag.PuntoDeVenta_Id = new SelectList(db.PuntoDeVentaSet, "Id", "Codigo");
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioSet loginView, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(loginView.UsuarioNick, loginView.Password))
                {
                    var user = (CustomMembershipUser)Membership.GetUser(loginView.UsuarioNick, false);
                    if (user != null)
                    {
                        //CustomSerializeModel userModel = new Models.CustomSerializeModel()
                        //{
                        //    UserId = user.UserId,
                        //    FirstName = user.FirstName,
                        //    LastName = user.LastName,
                        //    RoleName = user.Roles.Select(r => r.RoleName).ToList()
                        //};

                        string userData = JsonConvert.SerializeObject(user);
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                            (
                            1, loginView.UsuarioNick, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData
                            );

                        string enTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie("Cookie1", enTicket);
                        Response.Cookies.Add(faCookie);
                    }

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
            }
            ModelState.AddModelError("", "Something Wrong : Username or Password invalid ^_^ ");
            return View(loginView);
        }

        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("Cookie1", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login", null);
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