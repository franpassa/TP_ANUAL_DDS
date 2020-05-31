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
            Producto zapatillaJuan = new Producto(5, "airmax", "1", 10); 
            List<Producto> productosJuan = new List<Producto> {zapatillaJuan};
            Proveedor juan = new Proveedor("Alvear 276", productosJuan);

            //creo proveedor Roberto
            Producto zapatillaRoberto = new Producto(9, "superzapas", "1", 7);
            List<Producto> productosRoberto = new List<Producto> {zapatillaRoberto};
            Proveedor roberto = new Proveedor("Mitre 231",productosRoberto);

            //creo usuario Pedro
            Usuario pedro = new Usuario("pedritoelmejor", "pepito");

            //creo usuario Jose
            Usuario jose = new Usuario("josesito", "elJosu");

            //creo Organizacion
            Servicios actividadServicio = new Servicios();
            Empresa empresa = new Empresa();

            Organizacion zapaTuya = new Organizacion("zapaTuya", actividadServicio, 20, 249872, false, );

            //creo Operacion de Egreso

            //creo Compra
            Producto zapatilla = new Producto(3, "laquequiero", "1", 0);
            List<Producto> productosRequeridos = new List<Producto> {zapatilla};

            List<Usuario> usuariosRevisores = new List<Usuario>{ jose };
            Compra compra = new Compra(criterio, usuariosRevisores, productosRequeridos, true, 2);

            compra.agregarPresupuesto(juan.crearPresupuesto(compra));
            compra.agregarPresupuesto(roberto.crearPresupuesto(compra));

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
