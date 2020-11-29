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
            string _IdOrg,
            string _fechaCompra,
            string _cantPresReq, 
            string[] _UsuariosRevisores,
            string _tipoPago,
            string _numero,
            string _IdPais,
            string _IdPersona,
            string _IdEntidadJuridica,
            string[] _IdDocumentoComercial,
            string[] _TipoDeDocumento,
            string[] _ItemsNombres,
            string[] _ItemsDescripciones,
            string[] _ItemsCategoriasCriterios,
            string[] _ItemsValoresTotales
            )
        {
            List<Item> n_items = new List<Item>() { };
            for(int i = 0; i < _ItemsNombres.Length; i++)
            {
                // Parseo el texto de Categoria, Criterio.
                var categorias_criterios = new Dictionary<String, List<String>> { };
                string categoria, criterio;

                foreach (String dupla in _ItemsCategoriasCriterios[i].Replace(" ", string.Empty).Split('.'))
                {
                    if (dupla.Count() > 0)
                    {
                        categoria = dupla.Split(',')[0];
                        criterio = dupla.Split(',')[1];

                        if (!categorias_criterios.ContainsKey(categoria))
                            categorias_criterios.Add(categoria, new List<string> { });

                        if (!categorias_criterios[categoria].Contains(criterio))
                            categorias_criterios[categoria].Add(criterio);
                    }
                }

                var categorias = new List<Categoria> { };

                foreach (var kvp in categorias_criterios)
                {
                    foreach(var value in kvp.Value)
                    {
                        categorias.Add(
                            new Categoria(kvp.Key, 
                                new Criterio(value, null)));
                    }
                }

                n_items.Add(
                new Item(
                        _ItemsNombres[i],
                        _ItemsDescripciones[i],
                        float.Parse(_ItemsValoresTotales[i]),
                        categorias
                    )
                );
            }


            //Operación de egreso
            MedioDePago n_medioDePago = new MedioDePago(_IdPais, _numero, _tipoPago);

            var n_documentosComerciales = new List<DocumentoComercial>() { };
            for(int i=0; i < _IdDocumentoComercial.Length; i++)
            {
                n_documentosComerciales.Add(
                    new DocumentoComercial(int.Parse(_IdDocumentoComercial[i]), _TipoDeDocumento[i])
                    );
            }

            var n_usuarios = new List<Usuario> { };

            foreach(string IdUsuario in _UsuariosRevisores)
            {
                n_usuarios.Add(UsuarioDAO.obtenerUsuario(int.Parse(IdUsuario)));
            }

            PersonaProveedora n_personaProveedora = null;
            EntidadJuridicaProveedora n_entidadJuridicaProveedora = null;

            if(_IdPersona.Length != 0)
            {
                n_personaProveedora = PersonaProveedoraDAO.obtenerPersonaProveedora(int.Parse(_IdPersona));
            }
            else
            {
                n_entidadJuridicaProveedora = EntidadJuridicaProveedoraDAO.obtenerEntidadJuridicaProveedora(int.Parse(_IdEntidadJuridica));
            }

            CriterioCompra n_criterio = new MenorValor();

            Compra n_compra = new Compra(
                int.Parse(_cantPresReq),
                n_criterio,
                n_items,
                n_usuarios,
                n_personaProveedora,
                n_entidadJuridicaProveedora
                );

            OperacionDeEgreso n_oe = new OperacionDeEgreso(
                n_compra,
                n_medioDePago,
                n_documentosComerciales,
                DateTime.Parse(_fechaCompra)
                );

            n_oe.ID_Organizacion = int.Parse(_IdOrg);

            OperacionDeEgresoDAO.guardar(n_oe);

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