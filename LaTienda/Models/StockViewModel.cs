using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaTienda.Models
{
    public class StockViewModel
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }

        public ColorViewModel ColorViewModel { get; set; }
        public TalleViewModel TalleViewModel { get; set; }

        public ProductoViewModel ProductoViewModel { get; set; }


        public static StockViewModel FromModel(StockSet stockSet)
        {
            return new StockViewModel
            {
                Id = stockSet.Id,
                Cantidad = stockSet.Cantidad,
                ColorViewModel = ColorViewModel.FromView(stockSet.ColorSet),
                TalleViewModel = TalleViewModel.FromView(stockSet.TalleSet),
                ProductoViewModel = ProductoViewModel.FromModel(stockSet.ProductoSet),
            };
        }
    }
}