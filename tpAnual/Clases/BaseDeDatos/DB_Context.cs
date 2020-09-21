using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace TPANUAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DB_Context : DbContext
    {
        public DbSet<Ciudad> ciudad { get; set; }
        public DbSet<TipoEntidad> tipoentidad { get; set; }
        public DbSet<Direccion> direccion { get; set; }
        public DbSet<DocumentoComercial> documentoComercial { get; set; }
        public DbSet<TipoEgreso> tipoegreso { get; set; }
        public DbSet<Item> item { get; set; }
        public DbSet<MedioDePago> mediodepago { get; set; }
        public DbSet<Moneda> moneda { get; set; }
        public DbSet<OperacionDeEgreso> operacionDeEgreso { get; set; }
        public DbSet<OperacionDeIngreso> operacionDeIngreso { get; set; }
        public DbSet<Empresa> empresas { get; set; }
        public DbSet<OSC> oscs { get; set; }
        public DbSet<Pais> pais { get; set; }
        public DbSet<Proveedor> proveedor { get; set; }
        public DbSet<Presupuesto> presupuesto { get; set; }
        public DbSet<Provincia> provincia { get; set; }
        public DbSet<Usuario> usuario { get; set; }

        // El string "dbConn" es el nombre del connection string definido en App.config
        public DB_Context() : base("db_tpanual")
        {
            // Deshabilita la inicializacion mágica del ORM
            Database.SetInitializer<DB_Context>(new CreateDatabaseIfNotExists<DB_Context>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organizacion>().ToTable("organizacion");

            modelBuilder.Entity<PersonaProveedora>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("personaproveedora");
            });

            modelBuilder.Entity<EntidadJuridicaProveedora>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("entidadjuridicaproveedora");
            });

            modelBuilder.Entity<Compra>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("compra");
            });

            modelBuilder.Entity<EntidadBase>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("entidadbase");
            });

            modelBuilder.Entity<EntidadJuridica>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("entidadjuridica");
            });

            modelBuilder.Entity<Compra>()
                .HasMany<Usuario>(c => c.Revisores)
                .WithMany(u => u.ComprasRevisables)
                .Map(cs =>
                {
                    cs.MapLeftKey("ID_Compra");
                    cs.MapRightKey("ID_Usuario");
                    cs.ToTable("usuariosxcompra");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
