using LaTienda.Models.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace LaTienda
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies["Cookie1"];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                var serializeModel = JsonConvert.DeserializeObject<UsuarioSet>(authTicket.UserData);
                CustomPrincipal principal = new CustomPrincipal(authTicket.Name);
                principal.Id = serializeModel.Id;
                principal.Nombre = serializeModel.Nombre;
                principal.Legajo = serializeModel.Legajo;
                principal.Roles = new[] { serializeModel.RolUsuario1.ToString() };

                HttpContext.Current.User = principal;
            }
        }
    }
}
