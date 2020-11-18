using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace TPANUAL.Clases.DAO
{
    public class OperacionDeEgresoDAO
    {
        private OperacionDeEgresoDAO() { }

        public static List<OperacionDeEgreso> obtenerEgresos(Usuario _usuario)
        {
            using (var contexto = new DB_Context())
            {
                var operacionesDeEgreso = contexto.operacionDeEgreso
                    .Where(oe => oe.ID_Organizacion == _usuario.ID_organizacion)
                    .Include(oe => oe.MedioDePago)
                    .Include(oe => oe.DocumentosComerciales)
                    .Include(oe => oe.IngresoAsociado)
                    .Include(oe => oe.Compra.Items)
                    .Include(oe => oe.Compra.Presupuestos)
                    .Include(oe => oe.Compra.Revisores)
                    .Include(oe => oe.Compra.Bandeja)
                    .Include(oe => oe.Compra.Persona)
                    .ToList();

                return operacionesDeEgreso;
            }
        }
    }
}
