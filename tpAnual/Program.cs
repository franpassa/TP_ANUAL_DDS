using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;

using Quartz;
using TPANUAL.Jobs;

namespace TPANUAL
{
    class Program
    {
        static void Main(string[] args) {
            using (var contexto = new DB_Context())
            {
                API_MercadoLibre ml = API_MercadoLibre.getInstance();
                ml.persistir(contexto);
            
                //creo usuario Pedro
                Usuario pedro = new Usuario("pedritoelmejor", "pepito");
                contexto.usuario.Add(pedro);

                Direccion direcJuancito = new Direccion("Saavedra 353", "2", 1, contexto.ciudad.Find("TUxNQ1RESmFkODcz"));

                //creo Entidad
                EntidadBase entidadBase = new EntidadBase("entidadBase", null, direcJuancito);
                contexto.tipoentidad.Add(entidadBase);

                //creo Organizacion
                Servicios actividadServicio = new Servicios();
                List<Usuario> usuariosDeOrg = new List<Usuario> { pedro };

                Empresa zapatuya = new Empresa(actividadServicio, 1, false, "zapaTuya", 8400000, entidadBase, usuariosDeOrg);
             
                //guardo organizacion
                contexto.empresas.Add(zapatuya);

                //creo Criterios
                Criterio barrios = new Criterio("barrio", null);
                Criterio clientes = new Criterio("cliente", barrios);

                //creo Categorias
                Categoria almagro = new Categoria("almagro", barrios);

                Categoria clienteA = new Categoria("clienteA", clientes);

                //creo proveedor Juan
                List<Categoria> categoriasJuan = new List<Categoria> { clienteA };
                Item zapatillaJuan = new Item("zapato", "airmax", 300, categoriasJuan);
                zapatillaJuan.insertarCategoria(almagro);
                PersonaProveedora juan = new PersonaProveedora(direcJuancito, "32492832", "Juan");

                //guardo el proveedor
                contexto.proveedor.Add(juan);      

                /*OPERACION DE EGRESO 1*/
                
                //creo atributos de compra
                List<Usuario> usuariosRevisores = new List<Usuario> { pedro };
                Item itemCompra1 = new Item("zapatillas", "rositas", 126312, categoriasJuan);
                List<Item> itemsCompra1 = new List<Item> { itemCompra1 };

                //creo criterioDeSeleccion
                MenorValor criterio = new MenorValor();

                //creo Compra
                Compra compra1 = new Compra(1, criterio, itemsCompra1, usuariosRevisores, juan, null);

                //creo MedioDePago
                MedioDePago medio = new MedioDePago("AR", "2", "tarjeta");

                //creo Operacion de Egreso
                OperacionDeEgreso operacionDeEgreso1 = new OperacionDeEgreso(compra1, medio, null, DateTime.Now);
                operacionDeEgreso1.valorTotal();

                /*OPERACION DE EGRESO 2*/

                Item itemCompra2 = new Item("zapatillas", "rositas", 1263, categoriasJuan);
                List<Item> itemsCompra2 = new List<Item> { itemCompra2 };

                //creo Compra
                Compra compra2 = new Compra(1, criterio, itemsCompra2, usuariosRevisores, juan, null);

                //creo Operacion de Egreso
                OperacionDeEgreso operacionDeEgreso2 = new OperacionDeEgreso(compra2, medio, null, DateTime.Now);
                operacionDeEgreso2.valorTotal();

                /*OPERACION DE EGRESO 3*/

                Item itemCompra3 = new Item("zapatillas", "rositas", 4365, categoriasJuan);
                List<Item> itemsCompra3 = new List<Item> { itemCompra3 };

                //creo Compra
                Compra compra3 = new Compra(1, criterio, itemsCompra3, usuariosRevisores, juan, null);

                //creo Operacion de Egreso
                OperacionDeEgreso operacionDeEgreso3 = new OperacionDeEgreso(compra3, medio, null, DateTime.Now);
                operacionDeEgreso3.valorTotal();

                /*OPERACION DE EGRESO 4*/

                Item itemCompra4 = new Item("zapatillas", "rositas", 126, categoriasJuan);
                List<Item> itemsCompra4 = new List<Item> { itemCompra4 };

                //creo Compra
                Compra compra4 = new Compra(1, criterio, itemsCompra4, usuariosRevisores, juan, null);

                //creo Operacion de Egreso
                OperacionDeEgreso operacionDeEgreso4 = new OperacionDeEgreso(compra4, medio, null, DateTime.Now);
                operacionDeEgreso4.valorTotal();

                //OPERACION DE EGRESO 5

                Item itemCompra5 = new Item("zapatillas", "rositas", 1248, categoriasJuan);
                List<Item> itemsCompra5 = new List<Item> { itemCompra5};

                //creo Compra
                Compra compra5 = new Compra(1, criterio, itemsCompra5, usuariosRevisores, juan, null);

                //creo Operacion de Egreso
                OperacionDeEgreso operacionDeEgreso5 = new OperacionDeEgreso(compra5, medio, null, DateTime.Now);
                operacionDeEgreso5.valorTotal();

                /*OPERACION DE EGRESO 6*/

                Item itemCompra6 = new Item("zapatillas", "rositas", 12687, categoriasJuan);
                List<Item> itemsCompra6 = new List<Item> { itemCompra6 };

                //creo Compra
                Compra compra6 = new Compra(1, criterio, itemsCompra6, usuariosRevisores, juan, null);

                //creo Operacion de Egreso
                OperacionDeEgreso operacionDeEgreso6 = new OperacionDeEgreso(compra6, medio, null, DateTime.Now);
                operacionDeEgreso6.valorTotal();

                /*OPERACION DE EGRESO 7*/

                Item itemCompra7 = new Item("zapatillas", "rositas", 16348, categoriasJuan);
                List<Item> itemsCompra7 = new List<Item> { itemCompra7 };

                //creo Compra
                Compra compra7 = new Compra(1, criterio, itemsCompra7, usuariosRevisores, juan, null);

                //creo Operacion de Egreso
                OperacionDeEgreso operacionDeEgreso7 = new OperacionDeEgreso(compra7, medio, null, DateTime.Now);
                operacionDeEgreso7.valorTotal();

                //OPERACION DE EGRESO 8

                Item itemCompra8 = new Item("zapatillas", "rositas", 1267, categoriasJuan);
                List<Item> itemsCompra8 = new List<Item> { itemCompra8 };

                //creo Compra
                Compra compra8 = new Compra(1, criterio, itemsCompra8, usuariosRevisores, juan, null);

                //creo Operacion de Egreso
                OperacionDeEgreso operacionDeEgreso8 = new OperacionDeEgreso(compra8, medio, null, DateTime.Now);
                operacionDeEgreso8.valorTotal();

                /*OPERACION DE EGRESO 9*/

                Item itemCompra9 = new Item("zapatillas", "rositas", 13, categoriasJuan);
                List<Item> itemsCompra9 = new List<Item> { itemCompra9 };

                //creo Compra
                Compra compra9 = new Compra(1, criterio, itemsCompra9, usuariosRevisores, juan, null);

                //creo Operacion de Egreso
                OperacionDeEgreso operacionDeEgreso9 = new OperacionDeEgreso(compra9, medio, null, DateTime.Now);
                operacionDeEgreso9.valorTotal();

                /*OPERACION DE EGRESO 10*/

                Item itemCompra10 = new Item("zapatillas", "rositas", 48, categoriasJuan);
                List<Item> itemsCompra10 = new List<Item> { itemCompra10 };

                //creo Compra
                Compra compra10 = new Compra(1, criterio, itemsCompra10, usuariosRevisores, juan, null);

                //creo Operacion de Egreso
                OperacionDeEgreso operacionDeEgreso10 = new OperacionDeEgreso(compra10, medio, null, DateTime.Now);
                operacionDeEgreso10.valorTotal();

                //agrego a empresa todas las operaciones de egresos
                zapatuya.agregarOperacionDeEgreso(operacionDeEgreso1);
                zapatuya.agregarOperacionDeEgreso(operacionDeEgreso2);
                zapatuya.agregarOperacionDeEgreso(operacionDeEgreso3);
                zapatuya.agregarOperacionDeEgreso(operacionDeEgreso4);
                zapatuya.agregarOperacionDeEgreso(operacionDeEgreso5);
                zapatuya.agregarOperacionDeEgreso(operacionDeEgreso6);
                zapatuya.agregarOperacionDeEgreso(operacionDeEgreso7);
                zapatuya.agregarOperacionDeEgreso(operacionDeEgreso8);
                zapatuya.agregarOperacionDeEgreso(operacionDeEgreso9);
                zapatuya.agregarOperacionDeEgreso(operacionDeEgreso10);

                /*CREO Y AGREGO OPERACIONES DE INGRESO*/
                List<OperacionDeIngreso> opingr = new List<OperacionDeIngreso>()
                {
                    new OperacionDeIngreso("Prestamo", null, 7824  , DateTime.Now),
                    new OperacionDeIngreso("Prestamo", null, 23734 , DateTime.Now),
                    new OperacionDeIngreso("Prestamo", null, 127623, DateTime.Now),
                    new OperacionDeIngreso("Prestamo", null, 1273  , DateTime.Now),
                    new OperacionDeIngreso("Prestamo", null, 12673 , DateTime.Now),
                    new OperacionDeIngreso("Prestamo", null, 27    , DateTime.Now),
                    new OperacionDeIngreso("Prestamo", null, 1632  , DateTime.Now),
                    new OperacionDeIngreso("Prestamo", null, 1554  , DateTime.Now),
                    new OperacionDeIngreso("Prestamo", null, 16327 , DateTime.Now),
                    new OperacionDeIngreso("Prestamo", null, 1563  , DateTime.Now)
                };

                foreach(OperacionDeIngreso operacion in opingr)
                {
                    zapatuya.agregarOperacionDeIngreso(operacion);
                }

                //guardo los cambios en la base de datos
                contexto.SaveChanges();

                /*
                
                //creo Scheduler

                Scheduler sched = Scheduler.getInstance();
                sched.run();
                jobComplejo(sched, zapatuya);

                jose.verMensajes(compra);

                ValidadorDeContraseña.getInstanceValidadorContra.validarContraseña(jose.Constraseña);
                ValidadorDeContraseña.getInstanceValidadorContra.mostrarMsjValidador(jose.Constraseña);

                compra.agregarPresupuesto(presJuan);

                Console.ReadLine();

                jose.verMensajes(compra);

                sched.stop();
                */
            }
        }
        
        private static void jobComplejo(Scheduler sched, Organizacion organizacion) {

            // Guardo el objeto dentro un objeto diccionario para que pueda accederlo desde el job
            JobDataMap jobData = new JobDataMap();

            jobData.Add("organizacion", organizacion);

            IJobDetail jobComp = JobBuilder.Create<JobCompra>()
                .WithIdentity("trabajoCompra", "grupoCompras")
                // Aca le asigno meto el diccionario dentro del job
                .UsingJobData(jobData)
                .Build();

            ITrigger triggerComp = TriggerBuilder.Create()
                  .WithIdentity("triggerCompra", "grupoCompras")
                  .StartNow()
                  // Este trigger se va a ejecutar cada 5 segundos
                  .WithSimpleSchedule(x => x.RepeatForever()
                      .WithIntervalInSeconds(5)
                      .RepeatForever())
                  .Build();

            // Asocio el job con el trigger
            sched.agregarTask(jobComp, triggerComp);

            // Pauso el hilo por 3 segundos

            System.Threading.Thread.Sleep(6000);

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
            