using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaTienda.Models
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public long Codigo { get; set; }

        public double PrecioDeVenta { get; set; }

        public MarcaViewModel MarcaViewModel { get; set; }

        public RubroViewModel RubroViewModel { get; set; }

        public static ProductoViewModel FromModel(ProductoSet productoSet)
        {
            return new ProductoViewModel
            {
                Id = productoSet.Id,
                Descripcion = productoSet.Descripcion,
                Codigo = productoSet.Codigo,
                PrecioDeVenta = productoSet.PrecioDeVenta,
                
                MarcaViewModel = MarcaViewModel.FromView(productoSet.MarcaSet),
                RubroViewModel = RubroViewModel.FromView(productoSet.RubroSet),
            };
        }
    }
}