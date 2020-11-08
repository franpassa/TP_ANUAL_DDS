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