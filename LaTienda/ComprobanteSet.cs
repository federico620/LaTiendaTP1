//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LaTienda
{
    using System;
    using System.Collections.Generic;
    
    public partial class ComprobanteSet
    {
        public int Id { get; set; }
        public string CAE { get; set; }
        public System.DateTime Fecha { get; set; }
        public System.DateTime FechaVen { get; set; }
        public LaTienda.Enums.TipoComprobante Concepto { get; set; }
        public LaTienda.Enums.TipoComprobante TipoComprobante { get; set; }
    
        public virtual VentaSet VentaSet { get; set; }
    }
}