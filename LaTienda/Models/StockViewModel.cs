using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaTienda.Models
{
    public class StockViewModel
    {
        public int Id { get; set; }
        //TODO: CAMBIAR A INT
        public string Cantidad { get; set; }

        public static StockViewModel FromModel(StockSet stockSet)
        {
            return new StockViewModel
            {
                Id = stockSet.Id,
                Cantidad = stockSet.Cantidad,
            };
        }
    }
}