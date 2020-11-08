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
                ViewBag.usuario = _usuario;
                ViewBag.contraseña = _contraseña;

                /*
                // Selecciono el usuario y la contraseña que me dan en la base de datos
                var usuarios = contexto.usuario
                    .SqlQuery("Select NombreUsuario from usuario where NombreUsuario = {0} and Contraseña = {1}", 
                    _usuario, _contraseña)
                    .ToList();
                */

                if (_usuario.Length == 5) // if(usuarios.Count() == 1)
                {
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