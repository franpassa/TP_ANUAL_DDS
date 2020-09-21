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
                Empresa e = contexto.empresas.Find(1);

                // Creo el vinculador con sus parametros
                Vinculador v = new Vinculador(
                    new List<Condicion>() 
                    {
                        new PeriodoDeAceptabilidad(20) 
                    },
                    new Orden_Valor_PrimeroEgreso()
                    );

                v.vincular(contexto, e);         
            }
        }
    }
}
