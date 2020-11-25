using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace INTERFAZ.Controllers
{
    public class OrganizacionController : Controller
    {
        [HttpPost]
        public ActionResult FormVinculacion(String _vincular, String _desvincular)
        {
            if (_vincular != null)
            {
                return RedirectToAction("Organizacion", "Home");
            }
            else
            {
                return RedirectToAction("Organizacion", "Home");
            }
        }
    }
}