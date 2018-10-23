using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _04___MVC_Pasar_datos_a_controlador.Models;

namespace _04___MVC_Pasar_datos_a_controlador.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Primera petición que se hace al entrar en Home/Editar
        /// </summary>
        /// <returns></returns>
        public ActionResult Editar()
        {
            ClsPersona p1 = new ClsPersona(1, "Oscar", "Funes", new DateTime(1999, 8, 12), "c/Falsa", "342342342");

            return View(p1);
        }

        /// <summary>
        /// Action que se llama al pulsar el botón de input y coge todos los datos modificados de persona
        /// </summary>
        /// <param name="p1"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Editar(ClsPersona p1)
        {
            TempData["persona"] = p1;
            return RedirectToAction("PersonaModificada");
        }

        public ActionResult PersonaModificada(ClsPersona p1)
        {
            ClsPersona p2 = (ClsPersona)TempData["persona"];
            return View(p2);
        }



    }
}