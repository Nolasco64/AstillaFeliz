﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ContextAstillitaFeliz : DbContext
    {
        public ContextAstillitaFeliz()
            : base("name=ContextAstillitaFeliz")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Detalles_Compras> Detalles_Compras { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Orden_Compra> Orden_Compra { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Paqueteria> Paqueteria { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
    }
}
