﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicios_18_20.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ConectaDBEntities : DbContext
    {
        public ConectaDBEntities()
            : base("name=ConectaDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<espacio> espacios { get; set; }
        public virtual DbSet<foto> fotoes { get; set; }
        public virtual DbSet<municipio> municipios { get; set; }
        public virtual DbSet<tipoEspacio> tipoEspacios { get; set; }
    }
}
