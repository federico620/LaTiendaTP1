using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaTienda.Models
{
    public class ColorViewModel
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public static ColorViewModel FromView(ColorSet colorSet)
        {
            return new ColorViewModel
            {
                Id = colorSet.Id,
                Descripcion = colorSet.Descripcion,
            };
        }
    }
}