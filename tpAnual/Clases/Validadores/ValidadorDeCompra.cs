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

        public async Task ValidarCompra(OperacionDeEgreso ope)
        {
            await Task.Delay(1);

            ope.Compra.Bandeja.Clear();

            if (ope.ProyectoAsociado != null)        //si esta asociado a un proyecto, debe cumplir esos requerimientos
            {
                if(ope.ProyectoAsociado.Monto_Egresos > ope.ProyectoAsociado.Monto_Maximo_Presupuestos)   //si sobrepasa el monto maximo
                {
                    ope.Compra.agregarMensaje("La Operacion de Egreso necesita " + ope.ProyectoAsociado.Cant_presupuestos.ToString() + " presupuestos.");
                    
                    if ((ope.Compra.Presupuestos).Count == ope.ProyectoAsociado.Cant_presupuestos)    //cant presupuestos
                    {
                        ope.Compra.agregarMensaje("Cantidad de presupuestos correcta.");
                    }
                    else
                    {
                        ope.Compra.agregarMensaje("Cantidad de presupuestos incorrecta.");
                    }

                    if (ope.Compra.itemsElegidosEstanEnPresupuestos()) // PUNTO B
                    {
                        ope.Compra.agregarMensaje("Compra realizada en base a la lista de presupuestos.");

                        if (ope.Compra.Criterio.cumpleCriterio(ope.Compra)) // PUNTO C
                        {
                            ope.Compra.agregarMensaje("Presupuesto elegido en base al criterio.");
                        }
                        else
                        {
                            ope.Compra.agregarMensaje("Presupuesto no elegido en base al criterio.");
                        }
                    }
                    else
                    {
                        ope.Compra.agregarMensaje("Compra no realizada en base a la lista de presupuestos.");
                    }

                }
                else
                {
                    ope.Compra.agregarMensaje("La compra no necesita presupuestos.");
                }             

            }
            else
            {

                if (ope.Compra.esConPresupuesto())
                {
                    if ((ope.Compra.Presupuestos).Count == ope.Compra.CantidadDePresupuestosRequeridos) // PUNTO A
                    {
                        ope.Compra.agregarMensaje("Cantidad de presupuestos correcta.");
                    }
                    else
                    {
                        ope.Compra.agregarMensaje("Cantidad de presupuestos incorrecta.");
                    }

                    if (ope.Compra.itemsElegidosEstanEnPresupuestos()) // PUNTO B
                    {
                        ope.Compra.agregarMensaje("Compra realizada en base a la lista de presupuestos.");

                        if (ope.Compra.Criterio.cumpleCriterio(ope.Compra)) // PUNTO C
                        {
                            ope.Compra.agregarMensaje("Presupuesto elegido en base al criterio.");
                        }
                        else
                        {
                            ope.Compra.agregarMensaje("Presupuesto no elegido en base al criterio.");
                        }
                    }
                    else
                    {
                        ope.Compra.agregarMensaje("Compra no realizada en base a la lista de presupuestos.");
                    }

                }
            }

        }

        // END VALIDADOR COMPRA
    }
}
