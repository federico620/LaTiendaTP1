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
    
    public partial class PuntoDeVentaSet
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public int Sucursal_Id { get; set; }
    
        public virtual SucursalSet SucursalSet { get; set; }
    }
}
