using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPANUAL.Jobs
{
    class JobCompra : IJob
    {

        public async Task Execute(IJobExecutionContext context)
        {
<<<<<<< HEAD
            
            Organizacion organizacion = (Organizacion)context.JobDetail.JobDataMap.Get("organizacion");

            foreach (OperacionDeEgreso operacion in organizacion.OperacionesDeEgreso)
            {
                await operacion.TipoEgreso.ValidarCompra();
            }

            Console.WriteLine("Corrio el scheduler");
        }
=======

            Compra compra = (Compra)context.JobDetail.JobDataMap.Get("compra");
            await compra.validarCompra();

        }


>>>>>>> 6a3e0f1547f779f4048325166cb48fefa91584fa
    }
}
