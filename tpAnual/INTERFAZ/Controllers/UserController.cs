using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPANUAL;
using TPANUAL.Clases.DAO;

namespace INTERFAZ.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public ActionResult FormSesion(String _usuario, String _contraseña, String _IniciarSesion, String _Registrarse)
        {
            if (_IniciarSesion != null) // Si hizo click en iniciar sesión
            {
                Usuario uLoggeado = UsuarioDAO.iniciarSesion(_usuario, _contraseña);

                if (uLoggeado != null)
                {
                    Session["Usuario"] = uLoggeado;
                    return RedirectToAction("Egresos", "Home");
                }
                else
                {
                    Session["erroresFormSesion"] = new List<String> { "Nombre de usuario y/o contraseña incorrectos" };
                    return RedirectToAction("Index", "Home");
                }
            }
            else // Si hizo click en registrarse
            {
                Usuario uRegistrado = UsuarioDAO.registrarse(_usuario, _contraseña);

                if(uRegistrado != null)
                {
                    Session["Usuario"] = uRegistrado;
                    return RedirectToAction("Egresos", "Home");
                }
                else
                {
                    List<String> errores = ValidadorDeContraseña.getInstanceValidadorContra().mostrarMsjValidadorLista(_contraseña);
                    Session["erroresFormSesion"] = errores;
                    Session["_usuario"] = _usuario;
                    Session["_contraseña"] = _contraseña;
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}