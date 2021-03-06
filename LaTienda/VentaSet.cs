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
    
    public partial class VentaSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VentaSet()
        {
            this.LineaDeVentaSet = new HashSet<LineaDeVentaSet>();
        }
    
        public int Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string CAE { get; set; }
        public System.DateTime FechaVen { get; set; }
        public LaTienda.Enums.Concepto Concepto { get; set; }
        public Nullable<int> Usuario_Id { get; set; }
        public Nullable<int> Cliente_Id { get; set; }
        public int PuntoDeVentaSet_Id { get; set; }
    
        public virtual ClienteSet ClienteSet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineaDeVentaSet> LineaDeVentaSet { get; set; }
        public virtual UsuarioSet UsuarioSet { get; set; }
        public virtual PuntoDeVentaSet PuntoDeVentaSet { get; set; }
        public virtual Comprobante Comprobante { get; set; }
    }
}
