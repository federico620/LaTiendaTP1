using LaTienda.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaTienda.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        public long? Documento { get; set; }

        public string Nombre { get; set; }

        public string Domicilio { get; set; }

        public CondicionTributaria CondicionTributaria { get; set; }

        public static ClienteViewModel FromModel(ClienteSet clienteSet)
        {
            return new ClienteViewModel
            {
                Id = clienteSet.Id,
                Documento = clienteSet.Documento,
                Nombre = clienteSet.Nombre,
                Domicilio = clienteSet.Domicilio,
                CondicionTributaria = clienteSet.CondicionTributaria,
            };
        }
    }
}