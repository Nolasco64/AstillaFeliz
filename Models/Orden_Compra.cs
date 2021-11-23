//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AstillitaFeliz.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orden_Compra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orden_Compra()
        {
            this.Detalles_Compras = new HashSet<Detalles_Compras>();
        }
    
        public int id_orden { get; set; }
        public Nullable<int> id_cliente { get; set; }
        public Nullable<System.DateTime> fecha_envio { get; set; }
        public Nullable<System.DateTime> fecha_entrega { get; set; }
        public Nullable<int> id_paqueteria { get; set; }
        public string nombrepersona_envio { get; set; }
        public string callenum_envio { get; set; }
        public string ciudad_envio { get; set; }
        public string codigop_envio { get; set; }
        public Nullable<int> id_pago { get; set; }
        public string status_envio { get; set; }
        public string codigo_rastreo { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalles_Compras> Detalles_Compras { get; set; }
        public virtual Pago Pago { get; set; }
        public virtual Paqueteria Paqueteria { get; set; }
    }
}
