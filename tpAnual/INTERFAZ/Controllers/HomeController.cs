using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPANUAL;

namespace INTERFAZ.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult InicioSesión(String _usuario, String _contraseña)
        {
            using (DB_Context contexto = new DB_Context())
            {
                Usuario uLoggeado = Usuario.iniciarSesion(_usuario, _contraseña);

                if ( uLoggeado != null)
                {
                    // Aparentemente no se puede hacer "Session["UsuarioLoggeado"] = uLoggeado;" :(
                    Session["NombreUsuario"] = uLoggeado.NombreUsuario;
                    Session["IdUsuario"] = uLoggeado.ID_Usuario;
                    Session["IdOrgUsuario"] = uLoggeado.ID_Usuario;
                    return View("Egresos");
                }
                else
                {
                    ViewBag.errorInicioSesion = "Nombre de usuario y/o contraseña incorrectos";
                    return View("Index");
                }
            }
        }

        public ActionResult Egresos()
        {
            if (Session["NombreUsuario"] != null)
            {
                return View();
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Ingresos()
        {
            if (Session["NombreUsuario"] != null)
            {
                return View();
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Organizaciones()
        {
            if (Session["NombreUsuario"] != null)
            {
                return View();
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Presupuestos()
        {
            if (Session["NombreUsuario"] != null)
            {
                return View();
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Proveedores()
        {
            if (Session["NombreUsuario"] != null)
            {
                return View();
            }
            else
            {
                return View("Index");
            }
        }
    }
}