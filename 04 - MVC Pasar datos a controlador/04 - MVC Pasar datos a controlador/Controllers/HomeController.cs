using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _04___MVC_Pasar_datos_a_controlador.Models.ViewModels;

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
            ClsPersonaConListadoDepartamentos p1 = new ClsPersonaConListadoDepartamentos(1, "Oscar", "Funes", new DateTime(1999, 8, 12), "c/Falsa", "342342342", 0);

            return View(p1);
        }

        /// <summary>
        /// Action que se llama al pulsar el botón de input y coge todos los datos modificados de persona
        /// </summary>
        /// <param name="p1"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Editar(ClsPersonaConListadoDepartamentos p1)
        {
            ClsPersonaConNombreDepartamento p2 = new ClsPersonaConNombreDepartamento(p1.idPersona, p1.nombre,
                                                                p1.apellidos, p1.fechaNac, p1.direccion, p1.telefono, p1.idDepartamento);
            return View("PersonaModificada", p2);
            //TempData["persona"] = p1;
            //return RedirectToAction("PersonaModificada");
        }

        public ActionResult PersonaModificada(ClsPersonaConNombreDepartamento p1)
        {
            return View(p1);
           /* ClsPersona p2 = (ClsPersona)TempData["persona"];
            return View(p2);*/
        }



    }
}