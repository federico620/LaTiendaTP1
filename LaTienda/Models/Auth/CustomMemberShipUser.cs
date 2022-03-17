using System;
//using CustomAuthenticationMVC.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace LaTienda.Models.Auth
{
    public class CustomMembershipUser : MembershipUser
    {
        #region User Properties

        public int Id { get; set; }
        public string Nombre { get; set; }
        public long Legajo { get; set; }
        public LaTienda.Enums.RolEnum RolUsuario1 { get; set; }
        

        #endregion

        public CustomMembershipUser(UsuarioSet user) : base("CustomMembership", user.UsuarioNick, user.Id, string.Empty, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            Id = user.Id;
            Nombre = user.Nombre;
            Legajo = user.Legajo;
            RolUsuario1 = user.RolUsuario1;
        }
    }
}