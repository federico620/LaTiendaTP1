using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaTienda
{
    public partial class StockSet
    {
        public void ActualizarStock(int cantidad)
        {
            this.Cantidad -= cantidad;
        }
    }
}