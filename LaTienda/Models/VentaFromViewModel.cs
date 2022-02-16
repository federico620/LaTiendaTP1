using LaTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaTienda
{
    public class VentaFromViewModel
    {
        public DateTime Fecha { get; set; }
        public ProductoViewModel ProductoViewModel { get; set; }
        public StockViewModel StockViewModel { get; set; }
        //TODO: ClienteViewModel ClienteViewModel { get; set; }
        public ClienteSet ClienteSet { get; set; }

        public VentaFromViewModel()
        {
            ClienteSet = new ClienteSet();
        }
    }
}