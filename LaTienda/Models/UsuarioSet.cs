using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaTienda
{
    public partial class UsuarioSet
    {

        public virtual PuntoDeVentaSet PuntoDeVenta { get; set; }
    }
}