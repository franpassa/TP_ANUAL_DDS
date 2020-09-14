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
        //public DbSet<Organizacion> organizacion { get; set; }

        // El string "dbConn" es el nombre del connection string definido en App.config
        public DB_Context() : base("db_tpanual")
        {
            // Deshabilita la inicializacion mágica del ORM
            Database.SetInitializer<DB_Context>(null);

        }
    }

}
