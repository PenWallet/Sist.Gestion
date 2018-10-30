using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _05___EsMiPrimer_Clicker.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(bool esMiPrimeraVez = true, int contador = 0)
        {
            /*if(esMiPrimeraVez.HasValue && (bool)!esMiPrimeraVez)
                Response.Write("Hola de nuevo");
            else
                Response.Write("Hola por primera vez");*/

            contador++;

            ViewData["esMiPrimeraVez"] = esMiPrimeraVez;
            ViewData["contador"] = contador;
            return View();
        }
    }
}