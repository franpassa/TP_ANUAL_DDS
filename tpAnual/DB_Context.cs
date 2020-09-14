using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_MercadoLibre;

namespace TPANUAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DB_Context : DbContext
    {
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Organizacion> organizacion { get; set; }
        public DbSet<Compra> compra { get; set; }
        public DbSet<Presupuesto> presupuesto { get; set; }
        public DbSet<EntidadJuridica> entidadJuridica { get; set; }
        public DbSet<EntidadJuridicaProveedora> entidadJuridicaProveedora { get; set; }
        public DbSet<Direccion> direccion { get; set; }
        public DbSet<EntidadBase> entidadBase { get; set; }
        public DbSet<Ciudad> ciudad { get; set; }



        // El string "dbConn" es el nombre del connection string definido en App.config
        public DB_Context() : base("db_tpanual")
        {
            // Deshabilita la inicializacion mágica del ORM
            Database.SetInitializer<DB_Context>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Student>()
            //            .HasMany<Course>(s => s.Courses)
            //            .WithMany(c => c.Students)
            //            .Map(cs =>
            //            {
            //                cs.MapLeftKey("StudentRefId");
            //                cs.MapRightKey("CourseRefId");
            //                cs.ToTable("StudentCourse");
            //            });

            modelBuilder.Entity<Compra>()
                .HasMany<Usuario>(c => c.Revisores)
                .WithMany(u => u.ComprasRevisables)
                .Map(cs =>
                {
                    cs.MapLeftKey("ID_Compra");
                    cs.MapRightKey("ID_Usuario");
                    cs.ToTable("usuariosxcompra");
                });

        }
    }

}
