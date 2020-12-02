using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace TPANUAL.Clases.DAO
{
    public class OperacionDeEgresoDAO
    {
        private OperacionDeEgresoDAO() { }

        public static List<OperacionDeEgreso> obtenerEgresos(Usuario _usuario)
        {
            using (var contexto = new DB_Context())
            {
                var operacionesDeEgreso = contexto.operacionDeEgreso
                    .Where(oe => oe.ID_Organizacion == _usuario.ID_organizacion)
                    .Include(oe => oe.MedioDePago)
                    .Include(oe => oe.DocumentosComerciales)
                    .Include(oe => oe.IngresoAsociado)
                    .Include(oe => oe.Compra.Items
                        .Select(i => i.Categorias
                            .Select(c => c.Criterio)
                            )
                        )
                    .Include(oe => oe.Compra.Presupuestos
                        .Select(p => p.Items
                            .Select(i => i.Categorias
                                .Select(c => c.Criterio)
                                )
                            )
                        )
                    .Include(oe => oe.Compra.Revisores)
                    .Include(oe => oe.Compra.Bandeja)
                    .Include(oe => oe.Compra.Persona)
                    .Include(oe => oe.Compra.Entidad)
                    .ToList();

                return operacionesDeEgreso;
            }
        }

        public static OperacionDeEgreso obtenerEgreso(int _ID)
        {
            using (var contexto = new DB_Context()) 
            {
                return contexto.operacionDeEgreso
                    .Where(oe => oe.ID_OperacionDeEgreso == _ID)
                    .Include(oe => oe.Compra.Revisores)
                    .FirstOrDefault();
            }
        }

        public static void guardar(OperacionDeEgreso _oe)
        {
            var contexto = new DB_Context();

            // Guardo revisores y los saco de la compra para 
            // agregarlos después
            var revisores = _oe.Compra.Revisores;
            _oe.Compra.Revisores = null;

            contexto.operacionDeEgreso.Add(_oe);
            contexto.SaveChanges();

            // Agrego revisores a la compra
            foreach(Usuario u in revisores)
                OperacionDeEgresoDAO.agregarRevisorCompra(_oe.Compra.ID_Compra, u.ID_Usuario);

            Logger.getInstance.update("Se agregó una operacion de egreso a la base de datos" + _oe.ID_OperacionDeEgreso.ToString());
            //Junto con la operacion de egreso, se agregan todas las entidades asociadas a la misma
        }


        public static void agregarRevisorCompra(int _ID_Compra, int _ID_Usuario) 
        {
            using (var contexto = new DB_Context())
            {
                Compra c = contexto.compra.Find(_ID_Compra);
                Usuario u = contexto.usuario.Find(_ID_Usuario);

                c.agregarRevisor(u);

                contexto.SaveChanges();
                Logger.getInstance.update("Se modifica una compra agregando un revisor." + " ID Compra:" +_ID_Compra.ToString());
            }
        }
        
        public static void sacarRevisorCompra(int _ID_Compra, int _ID_Usuario)
        {
            using (var contexto = new DB_Context())
            {
                Compra c = contexto.compra.Find(_ID_Compra);
                Usuario u = contexto.usuario.Find(_ID_Usuario);

                c.sacarRevisor(u);

                contexto.Database.ExecuteSqlCommand(
                        "delete from usuariosxcompra where ID_Compra = {0} and ID_Usuario = {1};",
                        _ID_Compra,
                        _ID_Usuario
                        );

                contexto.SaveChanges();

                Logger.getInstance.update("Se modifica una compra quitando un revisor." + " ID Compra:" + _ID_Compra.ToString());
            }
        }
    }
}
