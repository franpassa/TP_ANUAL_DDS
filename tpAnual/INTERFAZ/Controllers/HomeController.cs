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
            return View();
        }

        [HttpGet]
        public ActionResult FormSesion(String _usuario, String _contraseña)
        {
            using (DB_Context contexto = new DB_Context())
            {
                Usuario uLoggeado = Usuario.iniciarSesion(_usuario, _contraseña);

                if ( uLoggeado != null)
                {
                    // Aparentemente no se puede hacer "Session["UsuarioLoggeado"] = uLoggeado;" :(
                    Session["NombreUsuarioLoggeado"] = uLoggeado.NombreUsuario;
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
            return View();
        }

        public ActionResult Ingresos()
        {
            return View();
        }

        public ActionResult Organizaciones()
        {
            return View();
        }

        public ActionResult Presupuestos()
        {
            return View();
        }

        public ActionResult Proveedores()
        {
            return View();
        }
    }
}