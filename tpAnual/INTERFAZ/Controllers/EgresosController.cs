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
        public ActionResult FormRegistroCompra()
        {
            return RedirectToAction("Egresos", "Home");
        }
    }
}