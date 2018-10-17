using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _03___MVC_Pasar_datos_a_vista.Models;

namespace _03___MVC_Pasar_datos_a_vista.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ClsPersona person = new ClsPersona();
            person.nombre = "Federico";
            person.apellidos = "Garcia Lorca";
            person.idPersona = 1;
            person.fechaNac = new DateTime(1999, 08, 12);
            person.direccion = "c/ Falsa 123";
            person.telefono = "999666999";

            ViewData["Saludo"] = saludo();
            ViewBag.Fecha = queDiaEs();

            return View(person);
        }

        /// <summary>
        /// Procedimiento que devuelve un string dependiendo de qué hora es
        /// </summary>
        /// <returns></returns>
        public string saludo()
        {
            string s;

            if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour <= 12)
                s = "¡Buenos días!";
            else
                if (DateTime.Now.Hour >= 13 && DateTime.Now.Hour <= 20)
                s = "¡Buenas tardes!";
            else
                s = "¡Buenas noches!";

            return s;
        }

        /// <summary>
        /// Procedimiento que devuelve un string con la fecha actual
        /// </summary>
        /// <returns></returns>
        public string queDiaEs()
        {
            DateTime fechaDT = DateTime.Now;

            return fechaDT.ToLongDateString();
        }
    }
}