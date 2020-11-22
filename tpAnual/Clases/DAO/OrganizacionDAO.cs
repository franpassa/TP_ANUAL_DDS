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
    public class OrganizacionDAO
    {
        private OrganizacionDAO() { }

        public static dynamic obtenerOrganizacion(Usuario _usuario)
        {
            using var contexto = new DB_Context();
            var tipoOrg = contexto.empresas.Find(_usuario.organizacionAsociada.ID_Organizacion);

            if (tipoOrg != null)
                return obtenerEmpresa(_usuario);
            else 
                return obtenerOSC(_usuario);
        }

        private static OSC obtenerOSC(Usuario _usuario)
        {
            using var contexto = new DB_Context();
            var osc = contexto.oscs
                .Where(osc => osc.ID_Organizacion == _usuario.organizacionAsociada.ID_Organizacion)
                .Include(osc => osc.Usuarios)
                .Include(osc => osc.OperacionesDeEgreso)
                .Include(osc => osc.OperacionesDeIngreso)
                .Include(osc => osc.ID_Organizacion)
                .FirstOrDefault();

            return osc;            
        }

        private static Empresa obtenerEmpresa(Usuario _usuario)
        {
            using var contexto = new DB_Context();
            var empresa = contexto.empresas
                .Where(e => e.ID_Organizacion == _usuario.organizacionAsociada.ID_Organizacion)
                .Include(e => e.Usuarios)
                .Include(e => e.OperacionesDeEgreso)
                .Include(e => e.OperacionesDeIngreso)
                .Include(e => e.ID_Organizacion)
                .FirstOrDefault();

            return empresa;
        }
    }
}
