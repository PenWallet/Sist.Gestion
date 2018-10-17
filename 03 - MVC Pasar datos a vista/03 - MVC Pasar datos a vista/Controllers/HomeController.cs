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
        public ActionResult Index()
        {
            //Declaración de variables
            ClsPersona person = new ClsPersona();

            //Asignamos los valores al objeto Persona
            person.nombre = "Federico";
            person.apellidos = "Garcia Lorca";
            person.idPersona = 1;
            person.fechaNac = new DateTime(1999, 08, 12);
            person.direccion = "c/ Falsa 123";
            person.telefono = "999666999";

            //Enviamos con el ViewData el saludo
            ViewData["Saludo"] = saludo();
            //Y con el ViewBag la fecha de hoy en formato largo
            ViewBag.Fecha = queDiaEs();

            //Finalmente, devolvemos a la vista la clase Persona
            return View(person);
        }

        public ActionResult ListadoPersona()
        {
            ClsListadoPersona objListadoPersona = new ClsListadoPersona();
            List<ClsPersona> lista = objListadoPersona.ListadoPersonas();

            return View(lista);
        }

        /// <summary>
        /// Procedimiento que devuelve un string dependiendo de qué hora es
        /// </summary>
        /// <returns>String con el saludo correspondiente</returns>
        public string saludo()
        {
            //Declaración de variables
            string s;
            int hora = DateTime.Now.Hour;

            //Dependiendo de la hora que sea, se le asigna a 's' un valor diferente
            if (hora >= 7 && hora <= 12)
                s = "¡Buenos días!";
            else if (hora >= 13 && hora <= 20)
                s = "¡Buenas tardes!";
            else
                s = "¡Buenas noches!";

            //Se devuelve el saludo
            return s;
        }

        /// <summary>
        /// Procedimiento que devuelve un string con la fecha actual
        /// </summary>
        /// <returns>String con la fecha actual en formato largo</returns>
        public string queDiaEs()
        {
            //Declaración de variables
            DateTime fechaDT = DateTime.Now;

            //Devolvemos la fecha en modo largo
            return fechaDT.ToLongDateString();
        }
    }
}