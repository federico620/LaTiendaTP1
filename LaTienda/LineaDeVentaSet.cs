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
    
    public partial class LineaDeVentaSet
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public double PrecioDeVenta { get; set; }
        public int StockSet_Id { get; set; }
        public int Venta_Id { get; set; }
    
        public virtual StockSet StockSet { get; set; }
        public virtual VentaSet VentaSet { get; set; }
    }
}
