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

            Compra compra = (Compra)context.JobDetail.JobDataMap.Get("compra");
            await compra.validarCompra();

        }


    }
}
