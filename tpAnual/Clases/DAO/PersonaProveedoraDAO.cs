using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.SqlClient;

namespace TPANUAL.Clases.DAO
{
    public class PersonaProveedoraDAO
    {
        private PersonaProveedoraDAO() { }

        public static PersonaProveedora obtenerPersonaProveedora(string _dni) //no busca por id (PK) -> busca por el dni
        {
            using var contexto = new DB_Context();
            var prov = (PersonaProveedora)contexto.proveedor.Where(p => p.Numero_identificatorio == _dni).FirstOrDefault();
            var direc = contexto.direccion.Find(prov.ID_Direccion);
            PersonaProveedora personaProveedora = new PersonaProveedora(direc, prov.Numero_identificatorio, prov.Nombre);
            return personaProveedora;
        }
    }
}
