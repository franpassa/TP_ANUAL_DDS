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

        public async Task ValidarCompra(Compra compra)
        {
            await Task.Delay(1);

            compra.Bandeja.Clear();

            if (compra.esConPresupuesto())
            {
                if ((compra.Presupuestos).Count == compra.CantidadDePresupuestosRequeridos) // PUNTO A
                {
                    compra.agregarMensaje("Cantidad de presupuestos correcta.");
                }
                else
                {
                    compra.agregarMensaje("Cantidad de presupuestos incorrecta.");
                }

                if (compra.itemsElegidosEstanEnPresupuestos()) // PUNTO B
                {
                    compra.agregarMensaje("Compra realizada en base a la lista de presupuestos.");

                    if (compra.Criterio.cumpleCriterio(compra)) // PUNTO C
                    {
                        compra.agregarMensaje("Presupuesto elegido en base al criterio.");
                    }
                    else
                    {
                        compra.agregarMensaje("Presupuesto no elegido en base al criterio.");
                    }
                }
                else
                {
                    compra.agregarMensaje("Compra no realizada en base a la lista de presupuestos.");
                }
                
                }
            }
        }

        // END VALIDADOR COMPRA
    }
