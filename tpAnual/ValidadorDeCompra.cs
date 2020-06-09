using System;
using System.Collections.Generic;
using System.Text;

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

        public bool validarCompra(Compra compra)
        {
            bool flag = true;

            if (compra.EsConPresupuesto)
            {
                if ((compra.Presupuestos).Count == compra.CantidadDePresupuestosRequeridos) // PUNTO A
                {
                    compra.Bandeja.agregarMensaje("Cantidad de presupuestos correcta.");

                }
                else
                {
                    compra.Bandeja.agregarMensaje("Cantidad de presupuestos incorrecta.");
                    flag = false;
                }

                if (compra.presupuestoElegidoEstaEnPresupuestos()) // PUNTO B
                {
                    compra.Bandeja.agregarMensaje("Compra realizada en base a la lista de presupuestos.");

                }
                else
                {
                    compra.Bandeja.agregarMensaje("Compra no realizada en base a la lista de presupuestos.");
                    flag = false;
                }

                if ((compra.Criterio.seleccionarPresupuesto(compra) == compra.PresupuestoElegido)) // PUNTO C
                {
                    compra.Bandeja.agregarMensaje("Presupuesto elegido en base al criterio.");

                }
                else
                {
                    compra.Bandeja.agregarMensaje("Presupuesto no elegido en base al criterio.");
                    flag = false;
                }

                return flag;
            }

            return true;
        }

        // END VALIDADOR COMPRA
    }
}
