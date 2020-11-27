using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPANUAL;
using TPANUAL.Clases.DAO;


namespace INTERFAZ.Controllers
{
    public class EgresosController : Controller
    {
        [HttpPost]
        public ActionResult FormRegistroCompra(
            string _fechaCompra,
            string _IdProveedor,
            string _cantPresReq, 
            string[] _UsuariosRevisores,
            string _IdMedioDePago,
            string _tipoPago,
            string _numero,
            string _IdPais,
            string _IdDocumentoComercial,
            string _TipoDeDocumento,
            string[] _ItemsNombres,
            string[] _ItemsDescripciones,
            string[] _ItemsCategorias,
            string[] _ItemsCriterios,
            string[] _ItemsValoresTotales
            )
        {
            // Convierto los items del form en una lista
            List<Item> n_items = new List<Item>() { };
            for(int i=0; i < _ItemsNombres.Length; i++)
            {
                n_items.Add(new Item(
                    _ItemsNombres[i],
                    _ItemsDescripciones[i],
                    float.Parse(_ItemsValoresTotales[i]),
                    null
                    ));
            }

            // Convierto los usuarios del form en una lista
            List<Usuario> n_usuariosRevisores = new List<Usuario>() { };
            foreach(string IdUsuario in _UsuariosRevisores)
            {
                n_usuariosRevisores.Add(UsuarioDAO.obtenerUsuario(int.Parse(IdUsuario)));
            }

            //Operación de egreso
            MedioDePago n_medioDePago = new MedioDePago();
            List<DocumentoComercial> n_documentosComerciales = new List<DocumentoComercial>() { };
            OperacionDeEgreso n_operacionDeEgreso = new OperacionDeEgreso();

            //Compra
            List<Presupuesto> n_presupuestos = new List<Presupuesto>() { } ;
            Compra n_compra = new Compra();
            return RedirectToAction("Egresos", "Home");
        }

        [HttpPost]
        public ActionResult FormRevisor(string _serRevisor, string _noSerRevisor, string _ID_Compra, string _ID_Usuario)
        {
            if (_serRevisor != null)
            {
                OperacionDeEgresoDAO.agregarRevisorCompra(int.Parse(_ID_Compra), int.Parse(_ID_Usuario));
                return RedirectToAction("Egresos", "Home");
            }
            else
            {
                OperacionDeEgresoDAO.sacarRevisorCompra(int.Parse(_ID_Compra), int.Parse(_ID_Usuario));
                return RedirectToAction("Egresos", "Home");
            }
        }
    }
}