using System;
using System.Collections.Generic;
using System.Text;
using Quartz;
using Quartz.Impl;
using System.Threading.Tasks;
using TPANUAL.Jobs;

namespace TPANUAL
{
    class ValidadorDeCompra
    {
        private static ValidadorDeCompra instanceCompra = null;

        protected ValidadorDeCompra() { }

        public static ValidadorDeCompra getInstanceValidadorCompra
        {

            get
            {
                if (instanceCompra == null)
                {
                    instanceCompra = new ValidadorDeCompra();
                }

                return instanceCompra;
            }

        }

        //VALIDADOR DE COMPRA

<<<<<<< HEAD:tpAnual/Validadores/ValidadorDeCompra.cs
        public async Task ValidarCompra(Compra compra)
        {
            await Task.Delay(1);
=======
        public async void validarCompra(Compra compra)
        {
         
>>>>>>> 6a3e0f1547f779f4048325166cb48fefa91584fa:tpAnual/ValidadorDeCompra.cs

            if (compra.esConPresupuesto())
            {
                if ((compra.Presupuestos).Count == compra.CantidadDePresupuestosRequeridos) // PUNTO A
                {
                    compra.Bandeja.agregarMensaje("Cantidad de presupuestos correcta.");
                }
                else
                {
                    compra.Bandeja.agregarMensaje("Cantidad de presupuestos incorrecta.");
<<<<<<< HEAD:tpAnual/Validadores/ValidadorDeCompra.cs
=======
               
>>>>>>> 6a3e0f1547f779f4048325166cb48fefa91584fa:tpAnual/ValidadorDeCompra.cs
                }

                if (compra.itemsElegidosEstanEnPresupuestos()) // PUNTO B
                {
                    compra.Bandeja.agregarMensaje("Compra realizada en base a la lista de presupuestos.");

                    if (compra.Criterio.cumpleCriterio(compra)) // PUNTO C
                    {
                        compra.Bandeja.agregarMensaje("Presupuesto elegido en base al criterio.");
                    }
                    else
                    {
                        compra.Bandeja.agregarMensaje("Presupuesto no elegido en base al criterio.");
<<<<<<< HEAD:tpAnual/Validadores/ValidadorDeCompra.cs
=======
                        
>>>>>>> 6a3e0f1547f779f4048325166cb48fefa91584fa:tpAnual/ValidadorDeCompra.cs
                    }
                }
                else
                {
                    compra.Bandeja.agregarMensaje("Compra no realizada en base a la lista de presupuestos.");
<<<<<<< HEAD:tpAnual/Validadores/ValidadorDeCompra.cs
                }
=======
                  
                }

>>>>>>> 6a3e0f1547f779f4048325166cb48fefa91584fa:tpAnual/ValidadorDeCompra.cs
            }
        }

        // END VALIDADOR COMPRA
    }
}
