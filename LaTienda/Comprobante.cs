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
    
    public partial class Comprobante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comprobante()
        {
            this.VentaSet = new HashSet<VentaSet>();
        }
    
        public int Id { get; set; }
        public LaTienda.Enums.Operacion Operacion { get; set; }
        public int TipoComprobanteId { get; set; }
    
        public virtual CondicionTributaria CondicionTributaria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VentaSet> VentaSet { get; set; }
        public virtual TipoComprobante TipoComprobante { get; set; }
    }
}
