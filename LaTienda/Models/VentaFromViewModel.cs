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
        public int Id { get; set; }

        public double Total { get; set; }

        public DateTime Fecha { get; set; }
        public ProductoViewModel ProductoViewModel { get; set; }
        public StockViewModel StockViewModel { get; set; }
        public ClienteViewModel ClienteViewModel { get; set; }

        public List<LineaDeVentaViewModel> LineaDeVentaViewModels { get; set; } = new List<LineaDeVentaViewModel>();

        public static VentaFromViewModel FromModel(VentaSet ventaSet)
        {
            var lineaDeVentaViewModels = new List<LineaDeVentaViewModel>();
            foreach (var lv in ventaSet.LineaDeVentaSet)
            {
                lineaDeVentaViewModels.Add(LineaDeVentaViewModel.FromModel(lv));
            }
            var venta = new VentaFromViewModel
            {
                Id = ventaSet.Id,
                Total = ventaSet.Total,
                Fecha = ventaSet.Fecha,
                LineaDeVentaViewModels = lineaDeVentaViewModels,
            };

            if (ventaSet.ClienteSet != null) venta.ClienteViewModel = ClienteViewModel.FromModel(ventaSet.ClienteSet);
            return venta;
        }
    }
}