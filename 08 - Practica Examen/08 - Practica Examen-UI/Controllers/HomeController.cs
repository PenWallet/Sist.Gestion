using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.ViewModels;
using BL.Listados;
using BL.Manejadoras;
using Entidades;

namespace _08___Practica_Examen_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int id = 0)
        {
            IndexViewModel vm = new IndexViewModel();

            if(id != 0)
            {
                vm.idDepartamento = id;
                vm.listaPersonasPorDepartamento = ClsListadoPersonas_BL.listadoPersonasPorDepartamento_BL(id);
            }
                

            return View(vm);
        }

        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost(IndexViewModel vm)
        {
            vm.listaPersonasPorDepartamento = ClsListadoPersonas_BL.listadoPersonasPorDepartamento_BL(vm.idDepartamento);

            return View(vm);
        }

        public ActionResult CambiarTelefono(int? id)
        {
            ClsPersona p = new ClsPersona();
            if(id != null)
                p = ClsManejadoraPersona_BL.PersonaPorID_BL((int)id);
            ClsDepartamento d = ClsManejadoraDepartamento_BL.DepartamentoPorID_BL(p.idDepartamento);

            EditarTelefonoViewModel etvm = new EditarTelefonoViewModel(p, d.nombre);

            return View(etvm);
        }
        
        [HttpPost, ActionName("CambiarTelefono")]
        public ActionResult CambiarTelefonoPost(EditarTelefonoViewModel etvm)
        {
            int filas = ClsManejadoraPersona_BL.ActualizarTelefonoPersona_BL(etvm.persona.id, etvm.persona.telefono);
            if (filas == 1)
                ViewData["Estado"] = "¡Se ha actualizado correctamente la persona!";
            else if (filas == 0)
                ViewData["Estado"] = "No se ha actualizado correctamente";
            else
                ViewData["Estado"] = "WTF";

            return View(etvm);
        }
    }
}