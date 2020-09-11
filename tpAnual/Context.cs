using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MySql.Data.EntityFramework;
using TPANUAL;

namespace Bibliotecas
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class Context : DbContext
    {
        public DbSet<Organizacion> Organizaciones { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<EntidadBase> EntidadesBase { get; set; }

        public DbSet<EntidadJuridica> EntidadesJuridicas { get; set; }

        public Context() : base("ContextDB")
        {
            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
        }
    }
}
