using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.Listados;
using Entidades;
using BL.Manejadoras;

namespace _07_CRUDPersonas_UI.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Listado()
        {
            List<ClsPersona> lista = null;
            //Try porque abre una conexión con la BBDD
            try
            {
                lista = ClsListadoPersonas_BL.listadoCompletoPersonas_BL();
            }
            catch (Exception e)
            { 
                //TODO Mostrar error en la vista
            }
            

            return View(lista);
        }

        public ActionResult Delete(int id)
        {
            ClsPersona p1 = new ClsPersona();

            try
            {
                p1 = ClsManejadoraPersona_BL.PersonaPorID_BL(id);
            }
            catch (Exception e) { ViewData["Error"] = "Error no controlado"; }

            return View(p1);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            int filas;
            List<ClsPersona> lista = null;
            try
            {
                filas = ClsManejadoraPersona_BL.BorrarPorID_BL(id);
                ViewData["InfoEstado"] = "Se han actualizado "+filas+" filas";

                //Volvemos a sacar la lista de personas actualizada para pasársela a la vista Listado
                lista = ClsListadoPersonas_BL.listadoCompletoPersonas_BL();
            }
            catch (Exception e) { ViewData["InfoEstado"] = "No se pudo borrar"; }

            return View("Listado", lista);
        }

        public ActionResult Edit(int id)
        {
            ClsPersona p1 = new ClsPersona();

            try
            {
                p1 = ClsManejadoraPersona_BL.PersonaPorID_BL(id);
            }
            catch (Exception e) { ViewData["Error"] = "Error no controlado"; }

            return View(p1);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost(ClsPersona p1)
        {
            if(ModelState.IsValid)
            {
                int filas;
                List<ClsPersona> lista = null;
                try
                {
                    filas = ClsManejadoraPersona_BL.ActualizarPersona_BL(p1);
                    ViewData["InfoEstado"] = "Se han actualizado " + filas + " filas";

                    //Volvemos a sacar la lista de personas actualizada para pasársela a la vista Listado
                    lista = ClsListadoPersonas_BL.listadoCompletoPersonas_BL();
                }
                catch (Exception e) { ViewData["InfoEstado"] = "No se pudo actualizar"; }

                return View("Listado", lista);
            }
            else
            {
                return View(p1);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public ActionResult CreatePost(ClsPersona p1)
        {
            if(ModelState.IsValid)
            {
                int filas;
                List<ClsPersona> lista = null;
                try
                {
                    filas = ClsManejadoraPersona_BL.CrearPersona_BL(p1);
                    ViewData["InfoEstado"] = "Se han creado " + filas + " filas";

                    //Volvemos a sacar la lista de personas actualizada para pasársela a la vista Listado
                    lista = ClsListadoPersonas_BL.listadoCompletoPersonas_BL();
                }
                catch (Exception e) { ViewData["InfoEstado"] = "No se pudo crear"; }

                return View("Listado", lista);
            }
            else
            {
                return View(p1);
            }
            
        }
    }
}