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
                API_MercadoLibre ml = new API_MercadoLibre();
                ml.persistir(contexto);

                //creo usuario Pedro
                Usuario pedro = new Usuario("pedritoelmejor", "pepito");
                contexto.usuario.Add(pedro);
                //var cantUsuarios = contexto.usuario.ToArray();
                //Console.WriteLine($"Existen {cantUsuarios.Length} usuario(s).");

                //creo usuario Jose
                //Usuario jose = new Usuario("Ppass11wordd", "elJosu");

                //Usuario buscado = contexto.usuario.Find(11);

                //Console.WriteLine(buscado.NombreUsuario);

                Direccion direcJuancito = new Direccion("Saavedra 353", "2", 1, contexto.ciudad.Find("TUxNQ1RESmFkODcz"));

                //creo Entidad
                EntidadBase entidadBase = new EntidadBase("entidadBase", null, direcJuancito);
                contexto.tipoentidad.Add(entidadBase);

                //creo Organizacion
                Servicios actividadServicio = new Servicios();
                List<Usuario> usuariosDeOrg = new List<Usuario> { pedro };

                //contexto.usuario.AddRange(usuariosDeOrg);


                Empresa zapatuya = new Empresa(actividadServicio, 1, false, "zapaTuya", 8400000, entidadBase, usuariosDeOrg);
             
                contexto.empresas.Add(zapatuya);

                //creo Criterios
                Criterio barrios = new Criterio("barrio", null);
                Criterio clientes = new Criterio("cliente", barrios);

                //creo Categorias
                Categoria palermo = new Categoria("palermo", barrios);
                Categoria almagro = new Categoria("almagro", barrios);

                Categoria clienteA = new Categoria("clienteA", clientes);
                Categoria clienteB = new Categoria("clienteB", clientes);

                //creo proveedor Juan
                List<Categoria> categoriasJuan = new List<Categoria> { clienteA };
                Item zapatillaJuan = new Item("zapato", "airmax", 300, categoriasJuan);
                zapatillaJuan.insertarCategoria(almagro);
                PersonaProveedora juan = new PersonaProveedora(direcJuancito, "32492832", "Juan");
                contexto.proveedor.Add(juan);
                //creo proveedor Roberto
                //Item zapatillaroberto = new Item("zapatillas", "superzapas", 400, categoriasJuan);
                //PersonaProveedora roberto = new PersonaProveedora("Mitre 231", "23892734", "Roberto");


                //creo atributos de compra
                List<Usuario> usuariosRevisores = new List<Usuario> { pedro };
                Item itemCompra = new Item("zapatillas", "rositas", 2109381, categoriasJuan);
                List<Item> itemsCompra = new List<Item> { itemCompra };

                //creo items de proveedores
                List<Item> itemsJuan = new List<Item> { zapatillaJuan };
                //List<Item> itemsRobert = new List<Item> { zapatillaRoberto };

                //creo criterioDeSeleccion
                MenorValor criterio = new MenorValor();

                //creo Compra
                Compra compra = new Compra(1, criterio, itemsCompra, usuariosRevisores, juan, null);
                //compra.agregarRevisor(pedro);
                contexto.tipoegreso.Add(compra);

                //creo presupuesto Juan
                Presupuesto presJuan = new Presupuesto(juan, null, itemsJuan, compra, "presupuesto de juancito");
                // //creo presupuesto Robert
                // Presupuesto presRobert = new Presupuesto(roberto, itemsRobert, compra, "asidjal");

                compra.agregarPresupuesto(presJuan);


                // //creo MedioDePago
                MedioDePago medio = new MedioDePago("AR", "2", "tarjeta");

                // //creo Operacion de Egreso
                OperacionDeEgreso operacionDeEgreso = new OperacionDeEgreso(compra, medio, null);

                zapatuya.agregarOperacionDeEgreso(operacionDeEgreso);

                // //creo Scheduler
                // Scheduler sched = Scheduler.getInstance();
                // sched.run();
                // jobComplejo(sched, zapatuya);

                // jose.verMensajes(compra);

                // ValidadorDeContraseña.getInstanceValidadorContra.validarContraseña(jose.Constraseña);
                // ValidadorDeContraseña.getInstanceValidadorContra.mostrarMsjValidador(jose.Constraseña);

                // compra.agregarPresupuesto(presJuan);

                // Console.ReadLine();

                // jose.verMensajes(compra);

                // sched.stop();
                contexto.SaveChanges();
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
            