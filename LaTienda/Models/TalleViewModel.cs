using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaTienda.Models
{
    public class TalleViewModel
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public static TalleViewModel FromView(TalleSet talleSet)
        {
            return new TalleViewModel
            {
                Id = talleSet.Id,
                Descripcion = talleSet.Descripcion,
            };
        }
    }
}