using System;
using System.Collections.Generic;
using TPANUAL;

namespace Vinculador_Ingresos_Egresos
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new DB_Context())
            {                   
                Empresa empresa = contexto.empresas.Find(1);

                // Creo condiciones
                List<Condicion> condiciones = new List<Condicion>() { new PeriodoDeAceptabilidad(20) };

                // Creo el vinculador con sus parametros
                Vinculador vinculador = new Vinculador(condiciones);

                CriterioVinculador criterio = new Orden_Valor_PrimeroEgreso();
                criterio.Vinculador = vinculador;

                vinculador.cambiarCriterio( criterio );

                vinculador.vincular(contexto, empresa); 
            }
        }
    }
}
