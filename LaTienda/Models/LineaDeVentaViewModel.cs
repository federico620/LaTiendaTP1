using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaTienda.Models
{
    public class LineaDeVentaViewModel
    {
        public int Id { get; set; }
        public long Cantidad { get; set; }
        public double PrecioDeVenta { get; set; }

        public StockViewModel StockViewModel { get; set; }

        public static LineaDeVentaViewModel FromModel(LineaDeVentaSet lineaDeVentaSet)
        {
            return new LineaDeVentaViewModel
            {
                Id = lineaDeVentaSet.Id,
                Cantidad = lineaDeVentaSet.Cantidad,
                PrecioDeVenta = lineaDeVentaSet.PrecioDeVenta,
                StockViewModel = StockViewModel.FromModel(lineaDeVentaSet.StockSet),
            };
        }
    }
}