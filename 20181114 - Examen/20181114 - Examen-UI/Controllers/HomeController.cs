using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.ViewModels;
using BL.Manejadoras;

namespace _20181114___Examen_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel();
            
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(IndexViewModel vm)
        {
            int filas;

            //Si la ID que se ha elegido en el DropDownList no es la misma que la que está
            //guardada en el campeón elegido, entonces es que se ha cambiado el personaje en el DropDownList
            if(vm.IDCampeonElegido != vm.campeonElegido.ID)
            {
                //Busca el campeón por la ID nueva, para poder mostrarlo y cambiar sus datos
                vm.campeonElegido = ClsManejadoraCampeones_BL.CampeonPorID_BL(vm.IDCampeonElegido);
                vm.rutaImagen = vm.campeonElegido.nombre + ".png";
            }
            else //Si son iguales, entonces es que se ha pulsado en Guardar y no en Editar
            {
                filas = ClsManejadoraCampeones_BL.ActualizarCampeon_BL(vm.campeonElegido);
                if (filas == 0) //Si no se ha actualizado nada (bad)
                    ViewData["Mensaje"] = "Error al actualizar el campeón. Consulte su invocador más cercano";
                else if(filas == 1) //Si se ha actualizado solo 1 fila (good)
                    ViewData["Mensaje"] = "Se ha actualizado correctamente";
                else //Si se han actualizado más de 1 filas (very bad)
                    ViewData["Mensaje"] = $"Se han actualizado {filas} filas. WTF";
            }

            return View(vm);
        }
    }
}