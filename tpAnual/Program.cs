using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using Quartz;
using TPANUAL.Clases.DAO;
using TPANUAL.Jobs;

namespace TPANUAL
{
    class Program
    {
        static void Main(string[] args) 
        {
            using (var contexto = new DB_Context())
            {

                //API_MercadoLibre ml = API_MercadoLibre.getInstance();
                //ml.persistir(contexto);

                ////creo usuario Pedro
                //Usuario pedro = new Usuario("pedritoelmejor", "pepito");
                //Usuario scarlet = new Usuario("DAMNSCARLE77", "scarlet");
                //Usuario daniel = new Usuario("imTheKarateKid", "danielSan");
                //Usuario megan = new Usuario("iHateDrake&Josh", "megan");
                //Usuario juan = new Usuario("JuanManoDura22", "juancho");
                //Usuario dillon = new Usuario("theBestDJInTheWorld", "dillon");
                //Usuario nola = new Usuario("noLoSonieeeee131313", "nola");
                //Usuario beto = new Usuario("Alberto7Gonzalez", "el_beto");
                //Usuario daphne = new Usuario("123tengoUnNombreReCheto", "daphne");
                //Usuario matias = new Usuario("AguanteArmenia", "hayastantsi");
                //Usuario nacho = new Usuario("teCarreoElTp", "nachoElCrack");
                //Usuario giu = new Usuario("AguanteElRockNacional12", "GNVP");
                //Usuario fran = new Usuario("HuracanPasion", "franquito");

                //contexto.usuario.Add(pedro);
                //contexto.usuario.Add(scarlet);
                //contexto.usuario.Add(daniel);
                //contexto.usuario.Add(megan);
                //contexto.usuario.Add(juan);
                //contexto.usuario.Add(dillon);
                //contexto.usuario.Add(nola);
                //contexto.usuario.Add(beto);
                //contexto.usuario.Add(daphne);
                //contexto.usuario.Add(matias);
                //contexto.usuario.Add(nacho);
                //contexto.usuario.Add(giu);
                //contexto.usuario.Add(fran);



                //Direccion direcPedrito = new Direccion("Saavedra 353", "2", 1, contexto.ciudad.Find("TUxBQ0NBUGZlZG1sYQ"));// capital  federal capital federal
                //Direccion direcJuancito = new Direccion("Mariano moreno 241", " ", 0, contexto.ciudad.Find("TUxBQ1NPQjVkNGVi"));// sobremonte cordoba
                //Direccion direcBetito = new Direccion("Masferrer 1022", "c", 2, contexto.ciudad.Find("TUxBQ0ZPUjNmZWYz")); // fformosa formosa
                //Direccion direcMatute = new Direccion("Fray Luis Beltran Este 343", "1", 4, contexto.ciudad.Find("TUxBQ01BTDZjYjM4")); // malargue mendoza
                //Direccion direcNachito = new Direccion("Av. Domuyo S/N", " ", 0, contexto.ciudad.Find("TUxBQ01JTjhhZGE5")); // minas neuquen Q8353
                //Direccion direcGiulsita = new Direccion("Perito Moreno Nº 3560", " ", 0, contexto.ciudad.Find("TUxBQ0VMQjM5MDg4MA")); // el bolson rio negro
                //Direccion direcFranquito = new Direccion("Bv. Villada 2005", " ", 0, contexto.ciudad.Find("TUxBQ0NBUzQwOWFl")); // caseros santa fe XR6J+MC
                //Direccion direcMirna = new Direccion("Bv. Villada 2005", " ", 0, contexto.ciudad.Find("TUxBQ0NBUzQwOWFl")); // caseros santa fe XR6J+MC
                //Direccion direcIsma = new Direccion("sarmiento 640", " 3", 2, contexto.ciudad.Find("TUxBQ0xBWjE1MzFk")); // la paz catamrca
                //Direccion direcKronk = new Direccion("9 de julio 1622", " ", 0, contexto.ciudad.Find("TUxBQ0ZVVGFsZXVmdQ")); // futaleufu chubut
                //Direccion direcCuzco = new Direccion("Belgrano 536", " ", 0, contexto.ciudad.Find("TUxBQ1RJTGM5NTAx")); // tilcara jujuy

                ////creo Entidad
                //EntidadBase entidadBase = new EntidadBase("entidadBase", null, direcPedrito);
                //EntidadBase entidadBase2 = new EntidadBase("entidadBase2", null, direcJuancito);
                //EntidadBase entidadBase3 = new EntidadBase("entidadBase3", null, direcBetito);
                //EntidadBase entidadBase4 = new EntidadBase("entidadBase4", null, direcMatute);
                //EntidadBase entidadBase5 = new EntidadBase("entidadBase5", null, direcNachito);
                //EntidadBase entidadBase6 = new EntidadBase("entidadBase6", null, direcGiulsita);
                //EntidadBase entidadBase7 = new EntidadBase("entidadBase7", null, direcFranquito);


                //contexto.tipoentidad.Add(entidadBase);
                //contexto.tipoentidad.Add(entidadBase2);
                //contexto.tipoentidad.Add(entidadBase3);
                //contexto.tipoentidad.Add(entidadBase4);
                //contexto.tipoentidad.Add(entidadBase5);
                //contexto.tipoentidad.Add(entidadBase6);
                //contexto.tipoentidad.Add(entidadBase7);

                ////creo Organizacion
                //Servicios actividadServicio = new Servicios();
                //List<Usuario> usuariosDeOrg = new List<Usuario> { pedro, scarlet, daniel };
                //Empresa zapatuya = new Empresa(actividadServicio, 1, false, "zapaTuya", 8400000, entidadBase, usuariosDeOrg);

                //Agropecuario actividadAgropecuario = new Agropecuario();
                //List<Usuario> usuariosAgropecuario = new List<Usuario> { juan, megan };
                //Empresa superSoja = new Empresa(actividadAgropecuario, 5, false, "superSoja", 12340000, entidadBase2, usuariosAgropecuario);

                //Comercio actividadComercio = new Comercio();
                //List<Usuario> usuariosDeComercio = new List<Usuario> { beto, dillon, nola };
                //Empresa tiendaCTM = new Empresa(actividadComercio, 32, false, "tiendaCTM", 1502002300, entidadBase3, usuariosDeComercio);

                //IndustriaYMineria actividadIYM = new IndustriaYMineria();
                //List<Usuario> usuariosDeMineria = new List<Usuario> { matias };
                //Empresa MinMining = new Empresa(actividadIYM, 122, false, "MinMining", 1673990500, entidadBase4, usuariosDeMineria);

                //Construccion actividadConstruccion = new Construccion();
                //List<Usuario> usuariosDeConstruccion = new List<Usuario> { nacho, daphne };
                //Empresa DunMaker = new Empresa(actividadConstruccion, 299, false, "DunMaker", 721230000, entidadBase5, usuariosDeConstruccion);

                ////guardo organizacion
                //contexto.empresas.Add(zapatuya);
                //contexto.empresas.Add(superSoja);
                //contexto.empresas.Add(tiendaCTM);
                //contexto.empresas.Add(MinMining);
                //contexto.empresas.Add(DunMaker);

                ////creo Criterios
                //Criterio barrios = new Criterio("barrio", null);
                //Criterio clientes = new Criterio("cliente", barrios);
                //Criterio ropa = new Criterio("ropa", null);
                //Criterio calzado = new Criterio("Calzado", ropa);
                //Criterio magia = new Criterio("magia", null);
                //Criterio pociones = new Criterio("pociones", magia);
                //Criterio comida = new Criterio("Comida", null);
                //Criterio comidaCaliente = new Criterio("Comida Caliente", comida);
                //Criterio comidaCalienteParaLlevar = new Criterio("Comida Caliente Para Llevar", comidaCaliente);
                //Criterio Alguno = new Criterio("Alguno", null);

                //List<Criterio> listcrit = new List<Criterio> { barrios, clientes, ropa, calzado, magia, pociones, comida, comidaCaliente, comidaCalienteParaLlevar };
                //contexto.criterio.AddRange(listcrit);

                ////creo Categorias
                //Categoria almagro = new Categoria("almagro", barrios);
                //Categoria clienteA = new Categoria("clienteA", clientes);
                //Categoria calzadoTipoA = new Categoria("Calzado Tipo A", calzado);
                //Categoria calzadoTipoB = new Categoria("Calzado Tipo B", calzado);
                //Categoria calzadoModerno = new Categoria("Calzado Moderno", calzado);
                //Categoria magiaNegra = new Categoria("Magia Negra", magia);
                //Categoria pocionesYHechizos = new Categoria("posiones y hechizos", pociones);
                //Categoria guiso = new Categoria("Guisos", comidaCalienteParaLlevar);
                //Categoria fideos = new Categoria("Fideos", comidaCaliente);
                //Categoria alguna = new Categoria("Alguna", Alguno);

                //List<Categoria> listcat = new List<Categoria> { almagro, clienteA, calzadoTipoA, calzadoTipoB, calzadoModerno, magiaNegra, pocionesYHechizos, guiso, fideos, alguna };
                //contexto.categoria.AddRange(listcat);

                ////creo proveedor Mirna
                //PersonaProveedora mirna = new PersonaProveedora(direcMirna, "23098213", "Mirna");

                //List<Categoria> categoriasMirnaTrabajo = new List<Categoria> { calzadoTipoA, calzadoTipoB };
                //List<Categoria> categoriasMirnaModerno = new List<Categoria> { calzadoModerno };
                ////Item BotaDeTrabajo1 = new Item("melman", "Bota de trabajo", 300, categoriasMirnaTrabajo);
                ////Item BotaDeTrabajo2 = new Item("gloria", "Bota de trabajo Super", 400, categoriasMirnaTrabajo);
                ////Item AirmaxSuperPro = new Item("airmaxSuperPro", "la super tilla ", 500, categoriasMirnaModerno);
                ////Item AirmaxBatmanEdition = new Item("airmaxBatmanEdition", "super tilla version batman", 600, categoriasMirnaModerno);

                ////BotaDeTrabajo1.insertarCategoria(calzadoTipoA);
                ////BotaDeTrabajo2.insertarCategoria(calzadoTipoB);
                ////AirmaxSuperPro.insertarCategoria(calzadoModerno);
                ////AirmaxBatmanEdition.insertarCategoria(calzadoModerno);



                ////creo proveedor Isma
                //PersonaProveedora isma = new PersonaProveedora(direcIsma, "21439203", "Isma");

                //List<Categoria> categoriaIsma = new List<Categoria> { pocionesYHechizos, magiaNegra };
                ////Item pataDeConejo = new Item("PataBlanca", "patas de conejo", 12332, categoriaIsma);
                ////Item venenoMagico = new Item("shotDeTequila", "veneno para matar ", 1200, categoriaIsma);
                ////Item posimaDelInfierno = new Item("aguaMagica", "pocion magica", 666, categoriaIsma);

                ////pataDeConejo.insertarCategoria(magiaNegra);
                ////venenoMagico.insertarCategoria(pocionesYHechizos);
                ////posimaDelInfierno.insertarCategoria(pocionesYHechizos);

                ////creo proveedor Isma
                //PersonaProveedora kronk = new PersonaProveedora(direcKronk, "34245231", "Kronk");

                //List<Categoria> categoriakronk = new List<Categoria> { guiso, fideos };
                ////Item fideosDeEspinaja = new Item("Espinaja", "Fideos De Espinaca", 100, categoriakronk);
                ////Item guisoDeMondongo = new Item("Mondongo", "Guiso De Mondongo ", 200, categoriakronk);


                ////fideosDeEspinaja.insertarCategoria(fideos);
                ////guisoDeMondongo.insertarCategoria(guiso);

                //PersonaProveedora cuzco = new PersonaProveedora(direcCuzco, "10239726", "Cuzco");
                //List<Categoria> categoriaCuzco = new List<Categoria> { alguna };
                ////Item alguno = new Item("alguno", "ya me aburri", 123123, categoriaCuzco);

                ////guardo el proveedor
                //contexto.personaProveedora.Add(mirna);
                //contexto.personaProveedora.Add(isma);
                //contexto.personaProveedora.Add(kronk);
                //contexto.personaProveedora.Add(cuzco);



                ///*OPERACION DE EGRESO 1*/

                ////creo atributos de compra 1
                //List<Usuario> usuariosRevisoresCompra1 = new List<Usuario> { pedro, scarlet, daniel };
                //Item item1Compra1 = new Item("zapatillas", "rositas", 126312, categoriasMirnaModerno);
                //Item item2Compra1 = new Item("zapatillas", "azules", 126312, categoriasMirnaModerno);
                //Item item3Compra1 = new Item("zapatillas", "verdes", 126312, categoriasMirnaModerno);
                //Item item4Compra1 = new Item("zapatillas", "marrones", 126312, categoriasMirnaModerno);
                //List<Item> itemsCompra1 = new List<Item> { item1Compra1, item2Compra1, item3Compra1, item4Compra1 };

                ////creo atributos de compra 2
                //List<Usuario> usuariosRevisoresCompra2 = new List<Usuario> { megan, juan, dillon };
                //Item item1Compra2 = new Item("pataDeConejo", "Patas De Conejo", 20320, categoriaIsma);
                //List<Item> itemsCompra2 = new List<Item> { item1Compra2, item1Compra2, item1Compra2, item1Compra2 };

                ////creo atributos de compra 3
                //List<Usuario> usuariosRevisoresCompra3 = new List<Usuario> { matias, nacho, giu, fran };
                //Item item1Compra3 = new Item("guiso 1", "guiso de mariscos", 100, categoriakronk);
                //Item item2Compra3 = new Item("guiso 2", "guiso de lentejas", 200, categoriakronk);
                //Item item3Compra3 = new Item("fideos 1", "fuciles con salsa rosa", 300, categoriakronk);
                //Item item4Compra3 = new Item("fideos 2", "spaguettis con bolognesa", 300, categoriakronk);
                //List<Item> itemsCompra3 = new List<Item> { item1Compra3, item1Compra3, item1Compra3, item2Compra3, item3Compra3, item3Compra3, item3Compra3, item4Compra3 };

                //contexto.item.AddRange(itemsCompra1.Concat(itemsCompra2.Concat(itemsCompra3)));

                ////creo criterioDeSeleccion
                //MenorValor criterio = new MenorValor();

                ////creo Compras
                //Compra compra1 = new Compra(1, criterio, itemsCompra1, usuariosRevisoresCompra1, mirna, null);
                //Compra compra2 = new Compra(2, criterio, itemsCompra2, usuariosRevisoresCompra2, isma, null);
                //Compra compra3 = new Compra(3, criterio, itemsCompra3, usuariosRevisoresCompra3, kronk, null);

                //List<Compra> listcom = new List<Compra> { compra1, compra2, compra3 };
                //contexto.compra.AddRange(listcom);

                ////creo MediosDePago
                //MedioDePago medio1 = new MedioDePago("AR", "1", "cash");
                //MedioDePago medio2 = new MedioDePago("AR", "2", "debito");
                //MedioDePago medio3 = new MedioDePago("AR", "3", "credito");

                //List<MedioDePago> listmed = new List<MedioDePago> { medio1, medio2, medio3 };
                //contexto.mediodepago.AddRange(listmed);

                ////creo Operacion de Egreso
                //OperacionDeEgreso operacionDeEgreso1 = new OperacionDeEgreso(compra1, medio1, null, DateTime.Now);
                //OperacionDeEgreso operacionDeEgreso2 = new OperacionDeEgreso(compra2, medio2, null, DateTime.Now);
                //OperacionDeEgreso operacionDeEgreso3 = new OperacionDeEgreso(compra3, medio3, null, DateTime.Now);

                //operacionDeEgreso1.valorTotal();
                //operacionDeEgreso2.valorTotal();
                //operacionDeEgreso3.valorTotal();

                //List<OperacionDeEgreso> listoe = new List<OperacionDeEgreso> { operacionDeEgreso1, operacionDeEgreso2, operacionDeEgreso3 };
                //contexto.operacionDeEgreso.AddRange(listoe);

                ////agrego a empresa todas las operaciones de egresos
                //zapatuya.agregarOperacionDeEgreso(operacionDeEgreso1);
                //superSoja.agregarOperacionDeEgreso(operacionDeEgreso2);
                //MinMining.agregarOperacionDeEgreso(operacionDeEgreso3);


                ///*CREO Y AGREGO OPERACIONES DE INGRESO*/

                //OperacionDeIngreso op1 = new OperacionDeIngreso("Prestamo", null, 7824, DateTime.Now);
                //OperacionDeIngreso op2 = new OperacionDeIngreso("Prestamo", null, 23734, DateTime.Now);
                //OperacionDeIngreso op3 = new OperacionDeIngreso("Prestamo", null, 127623, DateTime.Now);
                //OperacionDeIngreso op4 = new OperacionDeIngreso("Prestamo", null, 1273, DateTime.Now);
                //OperacionDeIngreso op5 = new OperacionDeIngreso("Prestamo", null, 12673, DateTime.Now);
                //OperacionDeIngreso op6 = new OperacionDeIngreso("Prestamo", null, 27, DateTime.Now);
                //OperacionDeIngreso op7 = new OperacionDeIngreso("Prestamo", null, 1632, DateTime.Now);
                //OperacionDeIngreso op8 = new OperacionDeIngreso("Prestamo", null, 1554, DateTime.Now);
                //OperacionDeIngreso op9 = new OperacionDeIngreso("Prestamo", null, 16327, DateTime.Now);
                //OperacionDeIngreso op10 = new OperacionDeIngreso("Prestamo", null, 1563, DateTime.Now);

                //List<OperacionDeIngreso> opingr = new List<OperacionDeIngreso> { op1, op2, op3, op4, op5, op6, op7, op8, op9, op10 };
                //contexto.operacionDeIngreso.AddRange(opingr);

                //foreach (OperacionDeIngreso operacion in opingr)
                //{
                //    zapatuya.agregarOperacionDeIngreso(operacion);
                //}

                //contexto.SaveChanges();

                //EntidadJuridicaProveedora ejp = new EntidadJuridicaProveedora(contexto.direccion.Find(1), "ejp", "1212837192837", "ejpRazonSocial");

                //contexto.entidadJuridicaProveedora.Add(ejp);

                //contexto.SaveChanges();

                //var persona = EntidadJuridicaProveedoraDAO.obtenerEntidadJuridicaProveedora(1);

                //Console.WriteLine(persona.RazonSocial);
                //Console.WriteLine(persona.CUIT);
                //Console.WriteLine(persona.CodigoInscripcion);
                //Console.WriteLine(persona.ID_Proveedor);
                //Console.WriteLine(persona.ID_Direccion);

                //var per = PersonaProveedoraDAO.obtenerPersonaProveedora(1);

                //Console.WriteLine(per.ID_Proveedor);
                //Console.WriteLine(per.ID_Direccion);
                //Console.WriteLine(per.DNI);
                //Console.WriteLine(per.Nombre);

                //Console.ReadLine();


                //API_MercadoLibre ml = API_MercadoLibre.getInstance();
                //ml.persistir(contexto);

                //creo usuario Pedro
                //Usuario pedro = new Usuario("pedritoelmejor", "pepito");
                //contexto.usuario.Add(pedro);

                //Direccion direcJuancito = new Direccion("Saavedra 353", "2", 1, contexto.ciudad.Find("TUxNQ1RESmFkODcz"));
                //Direccion direcJuancito2 = new Direccion("Saavedra adfijas", "5", 2, contexto.ciudad.Find("TU5JQ01OSUdyYVVwSg"));

                ////creo Entidad
                //EntidadBase entidadBase = new EntidadBase("entidadBase", null, direcJuancito);


                //EntidadBase entidadBase2 = new EntidadBase("entidadBase", null, direcJuancito2);

                //List<EntidadBase> listte = new List<EntidadBase>() { entidadBase, entidadBase2 };

                //contexto.tipoentidad.AddRange(listte);

                ////creo Organizacion
                //Servicios actividadServicio = new Servicios();
                //List<Usuario> usuariosDeOrg = new List<Usuario> { pedro };

                //Empresa zapatuya = new Empresa(actividadServicio, 1, false, "zapaTuya", 8400000, entidadBase, usuariosDeOrg);


                //Usuario juan = new Usuario("juanasldk", "juan");


                //List<Usuario> usuariosDeOrg2 = new List<Usuario> { juan };
                // Empresa alksdj = new Empresa(actividadServicio, 213, false, "aalksjd", 298371298, entidadBase2, usuariosDeOrg2);

                //List<Empresa> listEmp = new List<Empresa>() { zapatuya, alksdj };
                ////guardo organizacion
                //contexto.empresas.AddRange(listEmp);
                //contexto.empresas.Add(alksdj);

                //var org = OrganizacionDAO.obtenerOrganizacion(pedro); //breakpoint acá con el debugger y ves que tiene adentro

                ////creo Criterios
                //Criterio barrios = new Criterio("barrio", null);
                //Criterio clientes = new Criterio("cliente", barrios);

                ////creo Categorias
                //Categoria almagro = new Categoria("almagro", barrios);

                //Categoria clienteA = new Categoria("clienteA", clientes);

                ////creo proveedor Juan
                //List<Categoria> categoriasJuan = new List<Categoria> { clienteA };
                //Item zapatillaJuan = new Item("zapato", "airmax", 300, categoriasJuan);
                //zapatillaJuan.insertarCategoria(almagro);
                //PersonaProveedora juan = new PersonaProveedora(direcJuancito, "32492832", "Juan");

                ////guardo el proveedor
                //contexto.proveedor.Add(juan);

                ///*OPERACION DE EGRESO 1*/

                ////creo atributos de compra
                //List<Usuario> usuariosRevisores = new List<Usuario> { pedro };
                //Item itemCompra1 = new Item("zapatillas", "rositas", 126312, categoriasJuan);
                //List<Item> itemsCompra1 = new List<Item> { itemCompra1 };

                ////creo criterioDeSeleccion
                //MenorValor criterio = new MenorValor();

                ////creo Compra
                //Compra compra1 = new Compra(1, criterio, itemsCompra1, usuariosRevisores, juan, null);

                ////creo MedioDePago
                //MedioDePago medio = new MedioDePago("AR", "2", "tarjeta");

                ////creo Operacion de Egreso
                //OperacionDeEgreso operacionDeEgreso1 = new OperacionDeEgreso(compra1, medio, null, DateTime.Now);
                //operacionDeEgreso1.valorTotal();

                ///*OPERACION DE EGRESO 2*/

                //Item itemCompra2 = new Item("zapatillas", "rositas", 1263, categoriasJuan);
                //List<Item> itemsCompra2 = new List<Item> { itemCompra2 };

                ////creo Compra
                //Compra compra2 = new Compra(1, criterio, itemsCompra2, usuariosRevisores, juan, null);

                ////creo Operacion de Egreso
                //OperacionDeEgreso operacionDeEgreso2 = new OperacionDeEgreso(compra2, medio, null, DateTime.Now);
                //operacionDeEgreso2.valorTotal();

                ///*OPERACION DE EGRESO 3*/

                //Item itemCompra3 = new Item("zapatillas", "rositas", 4365, categoriasJuan);
                //List<Item> itemsCompra3 = new List<Item> { itemCompra3 };

                ////creo Compra
                //Compra compra3 = new Compra(1, criterio, itemsCompra3, usuariosRevisores, juan, null);

                ////creo Operacion de Egreso
                //OperacionDeEgreso operacionDeEgreso3 = new OperacionDeEgreso(compra3, medio, null, DateTime.Now);
                //operacionDeEgreso3.valorTotal();

                ///*OPERACION DE EGRESO 4*/

                //Item itemCompra4 = new Item("zapatillas", "rositas", 126, categoriasJuan);
                //List<Item> itemsCompra4 = new List<Item> { itemCompra4 };

                ////creo Compra
                //Compra compra4 = new Compra(1, criterio, itemsCompra4, usuariosRevisores, juan, null);

                ////creo Operacion de Egreso
                //OperacionDeEgreso operacionDeEgreso4 = new OperacionDeEgreso(compra4, medio, null, DateTime.Now);
                //operacionDeEgreso4.valorTotal();

                ////OPERACION DE EGRESO 5

                //Item itemCompra5 = new Item("zapatillas", "rositas", 1248, categoriasJuan);
                //List<Item> itemsCompra5 = new List<Item> { itemCompra5 };

                ////creo Compra
                //Compra compra5 = new Compra(1, criterio, itemsCompra5, usuariosRevisores, juan, null);

                ////creo Operacion de Egreso
                //OperacionDeEgreso operacionDeEgreso5 = new OperacionDeEgreso(compra5, medio, null, DateTime.Now);
                //operacionDeEgreso5.valorTotal();

                ///*OPERACION DE EGRESO 6*/

                //Item itemCompra6 = new Item("zapatillas", "rositas", 12687, categoriasJuan);
                //List<Item> itemsCompra6 = new List<Item> { itemCompra6 };

                ////creo Compra
                //Compra compra6 = new Compra(1, criterio, itemsCompra6, usuariosRevisores, juan, null);

                ////creo Operacion de Egreso
                //OperacionDeEgreso operacionDeEgreso6 = new OperacionDeEgreso(compra6, medio, null, DateTime.Now);
                //operacionDeEgreso6.valorTotal();

                ///*OPERACION DE EGRESO 7*/

                //Item itemCompra7 = new Item("zapatillas", "rositas", 16348, categoriasJuan);
                //List<Item> itemsCompra7 = new List<Item> { itemCompra7 };

                ////creo Compra
                //Compra compra7 = new Compra(1, criterio, itemsCompra7, usuariosRevisores, juan, null);

                ////creo Operacion de Egreso
                //OperacionDeEgreso operacionDeEgreso7 = new OperacionDeEgreso(compra7, medio, null, DateTime.Now);
                //operacionDeEgreso7.valorTotal();

                ////OPERACION DE EGRESO 8

                //Item itemCompra8 = new Item("zapatillas", "rositas", 1267, categoriasJuan);
                //List<Item> itemsCompra8 = new List<Item> { itemCompra8 };

                ////creo Compra
                //Compra compra8 = new Compra(1, criterio, itemsCompra8, usuariosRevisores, juan, null);

                ////creo Operacion de Egreso
                //OperacionDeEgreso operacionDeEgreso8 = new OperacionDeEgreso(compra8, medio, null, DateTime.Now);
                //operacionDeEgreso8.valorTotal();

                ///*OPERACION DE EGRESO 9*/

                //Item itemCompra9 = new Item("zapatillas", "rositas", 13, categoriasJuan);
                //List<Item> itemsCompra9 = new List<Item> { itemCompra9 };

                ////creo Compra
                //Compra compra9 = new Compra(1, criterio, itemsCompra9, usuariosRevisores, juan, null);

                ////creo Operacion de Egreso
                //OperacionDeEgreso operacionDeEgreso9 = new OperacionDeEgreso(compra9, medio, null, DateTime.Now);
                //operacionDeEgreso9.valorTotal();

                ///*OPERACION DE EGRESO 10*/

                //Item itemCompra10 = new Item("zapatillas", "rositas", 48, categoriasJuan);
                //List<Item> itemsCompra10 = new List<Item> { itemCompra10 };

                ////creo Compra
                //Compra compra10 = new Compra(1, criterio, itemsCompra10, usuariosRevisores, juan, null);

                ////creo Operacion de Egreso
                //OperacionDeEgreso operacionDeEgreso10 = new OperacionDeEgreso(compra10, medio, null, DateTime.Now);
                //operacionDeEgreso10.valorTotal();

                ////agrego a empresa todas las operaciones de egresos
                //zapatuya.agregarOperacionDeEgreso(operacionDeEgreso1);
                //zapatuya.agregarOperacionDeEgreso(operacionDeEgreso2);
                //zapatuya.agregarOperacionDeEgreso(operacionDeEgreso3);
                //zapatuya.agregarOperacionDeEgreso(operacionDeEgreso4);
                //zapatuya.agregarOperacionDeEgreso(operacionDeEgreso5);
                //zapatuya.agregarOperacionDeEgreso(operacionDeEgreso6);
                //zapatuya.agregarOperacionDeEgreso(operacionDeEgreso7);
                //zapatuya.agregarOperacionDeEgreso(operacionDeEgreso8);
                //zapatuya.agregarOperacionDeEgreso(operacionDeEgreso9);
                //zapatuya.agregarOperacionDeEgreso(operacionDeEgreso10);

                ///*CREO Y AGREGO OPERACIONES DE INGRESO*/
                //List<OperacionDeIngreso> opingr = new List<OperacionDeIngreso>()
                //{
                //    new OperacionDeIngreso("Prestamo", null, 7824  , DateTime.Now),
                //    new OperacionDeIngreso("Prestamo", null, 23734 , DateTime.Now),
                //    new OperacionDeIngreso("Prestamo", null, 127623, DateTime.Now),
                //    new OperacionDeIngreso("Prestamo", null, 1273  , DateTime.Now),
                //    new OperacionDeIngreso("Prestamo", null, 12673 , DateTime.Now),
                //    new OperacionDeIngreso("Prestamo", null, 27    , DateTime.Now),
                //    new OperacionDeIngreso("Prestamo", null, 1632  , DateTime.Now),
                //    new OperacionDeIngreso("Prestamo", null, 1554  , DateTime.Now),
                //    new OperacionDeIngreso("Prestamo", null, 16327 , DateTime.Now),
                //    new OperacionDeIngreso("Prestamo", null, 1563  , DateTime.Now)
                //};

                //foreach (OperacionDeIngreso operacion in opingr)
                //{
                //    zapatuya.agregarOperacionDeIngreso(operacion);
                //}


                ////guardo los cambios en la base de datos
                //contexto.SaveChanges();


                ///*

                ////creo Scheduler

                //Scheduler sched = Scheduler.getInstance();
                //sched.run();
                //jobComplejo(sched, zapatuya);

                //jose.verMensajes(compra);

                //ValidadorDeContraseña.getInstanceValidadorContra.validarContraseña(jose.Constraseña);
                //ValidadorDeContraseña.getInstanceValidadorContra.mostrarMsjValidador(jose.Constraseña);

                //compra.agregarPresupuesto(presJuan);

                //Console.ReadLine();

                //jose.verMensajes(compra);

                //sched.stop();
                //*/
            }
        }

        /*
         * Crea x cantidad de objetos con valores aleatorios. Ejemplo:
         * List<Usuario> usuarios = crear<Usuario>(20); // Crea una lista de 20 usuarios
         * 
         * Si se necesita solo 1 objeto aleatorio, se puede hacer así:
         * Usuario u = crear<Usuario>(1)[0];
         */
        static List<T> crear<T>(int cantidad)
        {
            var lista = new List<dynamic> { };

            using (var contexto = new DB_Context())
            {
                for (int i = 0; i < cantidad; i++)
                {
                    Random random = new Random();
                    var actividades = new List<Actividad> { new Servicios(), new Agropecuario(), new Comercio(), new IndustriaYMineria(), new Construccion() };

                    if (typeof(Usuario) == typeof(T))
                        lista.Add(new Usuario("Usuario-" + i.ToString(), "Contraseña-" + i.ToString()));

                    if (typeof(Mensaje) == typeof(T))
                        lista.Add(new Mensaje("Texto-" + i.ToString()));

                    if (typeof(Criterio) == typeof(T))
                        lista.Add(new Criterio("NombreCriterio-" + i.ToString(), null));

                    if (typeof(Categoria) == typeof(T))
                        lista.Add(new Categoria("NombreCategoria-" + i.ToString(), null));

                    if (typeof(Item) == typeof(T))
                        lista.Add(new Item("Nombre-" + i.ToString(), "Descripcion-" + i.ToString(), random.Next(50, 6000), crear<Categoria>(random.Next(1, 5))));

                    if (typeof(MedioDePago) == typeof(T))
                        lista.Add(new MedioDePago("AR", random.Next(0, 10).ToString(), "TipoDePago-" + i.ToString()));

                    if (typeof(DocumentoComercial) == typeof(T))
                        lista.Add(new DocumentoComercial(random.Next(0, 10), "TipoDocumento-" + i.ToString()));

                    if (typeof(PersonaProveedora) == typeof(T))
                        lista.Add(new PersonaProveedora(crear<Direccion>(1)[0], random.Next(00000000, 99999999).ToString(), "Nombre-" + i.ToString()));

                    if (typeof(EntidadJuridicaProveedora) == typeof(T))
                        lista.Add(new EntidadJuridicaProveedora(crear<Direccion>(1)[0], "CodigoInscripcion-" + i.ToString(), "CUIT-" + i.ToString(), "RazonSocial-" + i.ToString()));

                    if (typeof(OperacionDeEgreso) == typeof(T))
                        lista.Add(new OperacionDeEgreso(crear<Compra>(1)[0], crear<MedioDePago>(1)[0], crear<DocumentoComercial>(random.Next(1, 5)), DateTime.Now));

                    if (typeof(OperacionDeIngreso) == typeof(T))
                        lista.Add(new OperacionDeIngreso("Descripcion-" + i.ToString(), null, random.Next(10, 100000), DateTime.Now));

                    if(typeof(Presupuesto) == typeof(T))
                    {
                        lista.Add(new Presupuesto(null, null, crear<Item>(random.Next(0,20)), null, "Detalle-" + i.ToString(), crear<DocumentoComercial>(random.Next(0,5))));
                    }

                    if (typeof(Direccion) == typeof(T))
                    {
                        //Direccion d = new Direccion("Calle-" + i.ToString(), i.ToString(), i, contexto.ciudad.Find("TG9uZHJlc0dC"));
                        //d.ID_Direccion = i;
                        lista.Add(new Direccion("Calle-" + i.ToString(), i.ToString(), i, null));
                    }

                    if (typeof(Compra) == typeof(T))
                    {
                        PersonaProveedora pp = null;
                        EntidadJuridicaProveedora ejp = null;

                        if (random.Next(0, 2) == 0)
                            pp = crear<PersonaProveedora>(1)[0];
                        else
                            ejp = crear<EntidadJuridicaProveedora>(1)[0];

                        lista.Add(new Compra(random.Next(0, 6), new MenorValor(), crear<Item>(random.Next(0, 20)), null, pp, ejp));
                    }

                    // Está comentado porque crea todas las orgs con el mismo nombre
                    //if (typeof(Organizacion) == typeof(T))
                    //    if (random.Next(0, 2) == 0)
                    //        lista.Add(crear<Empresa>(1)[0]);
                    //    else
                    //        lista.Add(crear<OSC>(1)[0]);

                    if (typeof(Empresa) == typeof(T))
                    {
                        lista.Add(
                            new Empresa(
                                actividades[random.Next(0, 5)],
                                random.Next(0, 50),
                                random.Next(0, 1) == 0,
                                "NombreEmpresa-" + i.ToString(),
                                random.Next(1000, 100000),
                                crear<EntidadBase>(1)[0],
                                crear<Usuario>(random.Next(0, 10)))
                            );
                    }

                    if (typeof(OSC) == typeof(T))
                    {
                        lista.Add(new OSC(
                                actividades[random.Next(0, 4)],
                                random.Next(0, 50),
                                "NombreOSC-" + i.ToString(),
                                random.Next(1000, 100000),
                                crear<EntidadJuridica>(1)[0],
                                crear<Usuario>(random.Next(0, 10)))
                            );
                    }

                    if (typeof(TipoEntidad) == typeof(T))
                    {
                        if (random.Next(0, 2) == 0)
                            lista.Add(crear<EntidadBase>(1));
                        else
                            lista.Add(crear<EntidadJuridica>(1));
                    }

                    if (typeof(EntidadBase) == typeof(T))
                    {
                        //EntidadJuridica ej = null;

                        //if (random.Next(0, 9) > 7)
                        //    ej = crear<EntidadJuridica>(1)[0];

                        lista.Add(new EntidadBase("Descripción-" + i.ToString(), null, crear<Direccion>(1)[0]));
                    }

                    if (typeof(EntidadJuridica) == typeof(T))
                    {
                        var eb = new List<EntidadBase> { };

                        if (random.Next(0, 10) > 7)
                            eb = crear<EntidadBase>(random.Next(0, 3));

                        lista.Add(new EntidadJuridica(eb, "CodigoInscripción-" + i.ToString(), "CUIT-" + i.ToString(), crear<Direccion>(1)[0], "RazonSocial-" + i.ToString()));
                    }
                }
            }

            return lista.Cast<T>().ToList();
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
            