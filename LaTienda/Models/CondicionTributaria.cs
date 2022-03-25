using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaTienda
{
    public partial class CondicionTributaria
    {
        public Comprobante ObtenerComprobante(Enums.Operacion operacion)
        {
            return Comprobante.FirstOrDefault(x => x.Operacion == operacion);
        }
    }
}