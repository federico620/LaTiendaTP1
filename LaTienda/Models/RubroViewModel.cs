using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaTienda.Models
{
    public class RubroViewModel
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public static RubroViewModel FromView(RubroSet rubroSet)
        {
            return new RubroViewModel
            {
                Id = rubroSet.Id,
                Descripcion = rubroSet.Descripcion,
            };
        }
    }
}