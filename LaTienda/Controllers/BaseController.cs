using LaTienda.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaTienda.Controllers
{
    public abstract class BaseController : Controller
    {
        protected string Action => HttpContext.Request.RequestContext.RouteData.Values["action"].ToString();
        protected new virtual CustomPrincipal User => HttpContext.User as CustomPrincipal;
        protected string Controller => HttpContext.Request.RequestContext.RouteData.Values["controller"].ToString();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var controller = Controller;
            if (controller != "Login")
            {
                ViewBag.RolVista = User.Roles[0];
            }
        }
    }
}