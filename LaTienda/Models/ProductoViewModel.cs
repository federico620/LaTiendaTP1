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

        public MarcaSet MarcaSet { get; set; }

        public RubroSet RubroSet { get; set; }

        public static ProductoViewModel FromModel(ProductoSet productoSet)
        {
            return new ProductoViewModel
            {
                Id = productoSet.Id,
                Descripcion = productoSet.Descripcion,
                Codigo = productoSet.Codigo,
                //TODO: REFACTORIZAR A VIEWMODELS
                //TODO: MarcaViewModel = MarcaViewModel.FromModel(productoSet.MarcaSet)
                MarcaSet = productoSet.MarcaSet,
                RubroSet = productoSet.RubroSet,
            };
        }
    }
}