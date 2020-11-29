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
    public class EntidadJuridicaProveedoraDAO
    {
        private EntidadJuridicaProveedoraDAO() { }

        public static EntidadJuridicaProveedora obtenerEntidadJuridicaProveedora(string _cuit) //no busca por id (PK) -> busca por el cuit 
        {
            using var contexto = new DB_Context();
            var prov = (EntidadJuridicaProveedora)contexto.proveedor.Where(p => p.Numero_identificatorio == _cuit).FirstOrDefault();
            var direc = contexto.direccion.Find(prov.ID_Direccion);
            EntidadJuridicaProveedora ejProveedora = new EntidadJuridicaProveedora(direc, prov.CodigoInscripcion, prov.Numero_identificatorio, prov.RazonSocial);
            return ejProveedora;
        }
    }
}
