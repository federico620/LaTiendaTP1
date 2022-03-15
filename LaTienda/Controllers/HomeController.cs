using LaTienda.Models.Auth;
using System.Web.Mvc;

namespace LaTienda.Controllers
{
    [CustomAuthorize(Roles = "Vendedor")]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        { 
            return View();
        }
    }
}