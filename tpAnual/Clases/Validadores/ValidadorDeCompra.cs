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

            compra.Bandeja.ListaDeMensajes.Clear();

            if (compra.esConPresupuesto())
            {
                if ((compra.Presupuestos).Count == compra.CantidadDePresupuestosRequeridos) // PUNTO A
                {
                    compra.Bandeja.agregarMensaje("Cantidad de presupuestos correcta.");
                }
                else
                {
                    compra.Bandeja.agregarMensaje("Cantidad de presupuestos incorrecta.");
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
                    }
                }
                else
                {
                    compra.Bandeja.agregarMensaje("Compra no realizada en base a la lista de presupuestos.");
                }
                
                }
            }
        }

        // END VALIDADOR COMPRA
    }
