using System;
using System.Collections.Generic;
using System.Text;
using Quartz;
using Quartz.Impl;
using System.Threading.Tasks;
using TPANUAL.Jobs;
using System.Linq;


namespace TPANUAL
{
    class Program
    {
        static void Main(string[] args) {
            
            //creo usuario Pedro
            Usuario pedro = new Usuario("pedritoelmejor", "pepito");

            //creo usuario Jose
            Usuario jose = new Usuario("Ppass11wordd", "elJosu");

            //creo Entidad
            EntidadBase entidadBase = new EntidadBase("entidadBase", null);

            //creo Organizacion
            Servicios actividadServicio = new Servicios();
            List<Usuario> usuariosDeOrg = new List<Usuario> { jose, pedro };
            Empresa zapatuya = new Empresa(actividadServicio, 1, false, "zapaTuya", 8400000, entidadBase, usuariosDeOrg);

            //creo Criterios
            Criterio barrios = new Criterio("barrio", null);
            Criterio clientes = new Criterio("cliente", barrios);

            //creo Categorias
            Categoria palermo = new Categoria("palermo", barrios);
            Categoria almagro = new Categoria("almagro", barrios);

            Categoria clienteA = new Categoria("clienteA", clientes);
            Categoria clienteB = new Categoria("clienteB", clientes);

            //creo proveedor Juan
            List<Categoria> categoriasJuan = new List<Categoria> {clienteA};
            Item zapatillaJuan = new Item("zapato", "airmax", 300, categoriasJuan);
            zapatillaJuan.insertarCategoria(almagro);
            PersonaProveedora juan = new PersonaProveedora("Alvear 276", "32492832", "Juan");
            

            //creo proveedor Roberto
            Item zapatillaRoberto = new Item("zapatillas", "superzapas", 400, categoriasJuan);
            PersonaProveedora roberto = new PersonaProveedora("Mitre 231", "23892734", "Roberto");


            //creo atributos de compra
            List<Usuario> usuariosRevisores = new List<Usuario> { jose };
            Item itemCompra = new Item("zapatillas", "rositas", 2109381, categoriasJuan);
            List<Item> itemsCompra = new List<Item> { itemCompra };

            //creo items de proveedores
            List<Item> itemsJuan = new List<Item> {zapatillaJuan};
            List<Item> itemsRobert = new List<Item> { zapatillaRoberto };
            
            //creo criterioDeSeleccion
            MenorValor criterio = new MenorValor();

            //creo Compra
            Compra compra = new Compra(2, criterio, itemsJuan, roberto, usuariosRevisores);
            //compra.agregarRevisor(pedro);

            //creo presupuesto Juan
            Presupuesto presJuan = new Presupuesto(juan, itemsJuan, compra, "asodlks");

            //creo presupuesto Robert
            Presupuesto presRobert = new Presupuesto(roberto, itemsRobert, compra, "asidjal");

            compra.agregarPresupuesto(presRobert);


            //creo MedioDePago
            MedioDePago medio = new MedioDePago("98213", "2", "tarjeta");

            //creo Operacion de Egreso
            OperacionDeEgreso operacionDeEgreso = new OperacionDeEgreso(compra, medio, null);

           zapatuya.agregarOperacionDeEgreso(operacionDeEgreso);

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
            