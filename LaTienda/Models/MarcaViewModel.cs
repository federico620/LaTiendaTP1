using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaTienda.Models
{
    public class MarcaViewModel
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public static MarcaViewModel FromView(MarcaSet marcaSet)
        {
            return new MarcaViewModel
            {
                Id = marcaSet.Id,
                Descripcion = marcaSet.Descripcion,
            };
        }
    }
}