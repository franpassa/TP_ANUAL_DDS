using System;
using System.Collections.Generic;
using System.Text;

namespace TPANUAL
{
    class Program
    {
        static void Main(string[] args)
        {
            MenorValor criterio = new MenorValor(); //creo criterioDeSeleccion

            //creo proveedor Juan
            Producto zapatillaJuan = new Producto(5, "1", "airmax", 10); 
            List<Producto> productosJuan = new List<Producto> {zapatillaJuan};
            PersonaProveedora juan = new PersonaProveedora("Alvear 276", productosJuan, "32492832", "Juan");

            //creo proveedor Roberto
            Producto zapatillaRoberto = new Producto(9, "1", "superzapas", 7);
            List<Producto> productosRoberto = new List<Producto> {zapatillaRoberto};
            PersonaProveedora roberto = new PersonaProveedora("Mitre 231", productosRoberto, "23892734", "Roberto");

            //creo usuario Pedro
            Usuario pedro = new Usuario("pedritoelmejor", "pepito");

            //creo usuario Jose
            Usuario jose = new Usuario("password12", "elJosu");

            //creo Entidad
            EntidadBase entidadBase = new EntidadBase("entidadBase", null);

            //creo TipoOrganizacion
            Empresa empresa = new Empresa();

            //creo Organizacion
            Servicios actividadServicio = new Servicios();
            List<Usuario> usuariosDeOrg = new List<Usuario> { jose, pedro };

            Organizacion zapaTuya = new Organizacion("zapaTuya", actividadServicio, 1, 8400000, false, entidadBase, empresa, usuariosDeOrg);

            //creo Compra
            Producto zapatilla = new Producto(3, "1", "laquequiero", 0);
            List<Producto> productosRequeridos = new List<Producto> {zapatilla};

            List<Usuario> usuariosRevisores = new List<Usuario>{ jose };

            Compra compra = new Compra(criterio, usuariosRevisores, productosRequeridos, true, 2);
            compra.agregarRevisor(pedro);

            Presupuesto presJuan = juan.crearPresupuesto(compra);
            Presupuesto presRobert = roberto.crearPresupuesto(compra);

            compra.agregarPresupuesto(presJuan);
            compra.agregarPresupuesto(presRobert);

            compra.PresupuestoElegido = presRobert;

            //creo MedioDePago
            MedioDePago medio = new MedioDePago("98213", "2", "tarjeta");

            //creo Operacion de Egreso
            OperacionDeEgreso operacionDeEgreso = new OperacionDeEgreso(compra, medio, null);

            //valido Compra
            if (compra.validarCompra())
            {
                Console.WriteLine("Compra correcta \n");
            } else
            {
                Console.WriteLine("Compra incorrecta \n");

            }
            pedro.verMensajes(compra);

            jose.validarContraseña();
            ValidadorDeContraseña.getInstanceValidadorContra.mostrarMsjValidador(jose.Constraseña);
            
            

            //Console.WriteLine(zapaTuya.TipoOrganizacion.Estructura.Nombre);

        }
    } 
}
// La organizacion "ZapaTuya" tiene a Pedro y Jose de empleados(usuarios) 
// Juan, el proveedor que tiene 5 zapatillas le vende a ZapaTuya 3 a 10$ cada una. 
// ZapaTuya tambien consigue presupuestos de Roberto.
// Roberto las vende a 7$ cada par
// Pedro tambien compra cordones a 2$, pero sin presupuesto.
// Pedro y Jose son revisores de la compra de 5 zapatillas.
// Pedro ve los mensajes de errores de la compra.

/*CREAR:
    ORGANIZACION
    EGRESO
    2 PROV
    PROD
    COMPRA
    2 USUARIO
    2 PRES
*/
