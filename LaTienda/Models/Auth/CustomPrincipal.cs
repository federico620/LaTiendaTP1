﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace LaTienda.Models.Auth
{
    public class CustomPrincipal : IPrincipal
    {
        #region Identity Properties

        public int Id { get; set; }
        public string Nombre { get; set; }
        public long Legajo { get; set; }
        //public string Email { get; set; }
        public string[] Roles { get; set; }
        #endregion

        public IIdentity Identity
        {
            get; private set;
        }

        public bool IsInRole(string role)
        {
            if (Roles.Any(r => role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CustomPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }
    }
}