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
            IndexViewModel vm;
            try
            {
                vm = new IndexViewModel();
            }
            catch (Exception) { vm = null; ViewData["Mensaje"] = "¡Error al intentar abrir la conexión con la base de datos!"; }
            
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(IndexViewModel vm, string valorBoton)
        {
            int filas;

            //Si el botón pulsado es Editar
            if(valorBoton.Equals("Editar")/*vm.IDCampeonElegido != vm.campeonElegido.ID*/)
            {
                try
                {
                    //Busca el campeón por la ID nueva, para poder mostrarlo y cambiar sus datos
                    vm.campeonElegido = ClsManejadoraCampeones_BL.CampeonPorID_BL(vm.IDCampeonElegido);
                    vm.rutaImagen = vm.campeonElegido.nombre + ".png";
                }
                catch (Exception) { vm = null; ViewData["Mensaje"] = "¡Error al conectar a la base de datos para cambiar el campeón!"; }
            }
            else //Si no, solo puede ser Guardar
            {
                try
                {
                    filas = ClsManejadoraCampeones_BL.ActualizarCampeon_BL(vm.campeonElegido);
                    if (filas == 0) //Si no se ha actualizado nada (bad)
                        ViewData["Mensaje"] = "Error al actualizar el campeón. Consulte su invocador más cercano";
                    else if (filas == 1) //Si se ha actualizado solo 1 fila (good)
                        ViewData["Mensaje"] = "Se ha actualizado correctamente";
                    else //Si se han actualizado más de 1 filas (very bad)
                        ViewData["Mensaje"] = $"Se han actualizado {filas} filas. WTF";
                }
                catch (Exception) { vm = null; ViewData["Mensaje"] = "¡Error al conectar a la base de datos para actualizar el campeón!"; }
            }

            return View(vm);
        }
    }
}