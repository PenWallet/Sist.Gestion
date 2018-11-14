using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using BL.Listados;
using BL.Manejadoras;

namespace Models.ViewModels
{
    /// <summary>
    /// ViewModel que contiene lo necesario para mostrar la vista del Index
    /// 
    /// Necesitaremos una lista de Campeones para mostrarlos en el primer DropDownView de selección de campeón
    /// También un listado de Categorías para, a la hora de modificar el campeón, que el usuario pueda elegirlo por nombre y no por ID
    /// Además, un entero que será la ID del campeón seleccionado
    /// También la ruta de la imagen, que será el nombre del campeón acabado en .png
    /// Por último, también guardaremos un ClsCampeón, que será el campeón que el usuario haya elegido en el DropDownView
    /// </summary>
    public class IndexViewModel
    {
        #region Atributos
        public List<ClsCampeon> listadoCampeones { get; set; }
        public List<ClsCategoria> listadoCategorias { get; set; }
        public ClsCampeon campeonElegido { get; set; }
        public int IDCampeonElegido { get; set; }
        public string rutaImagen { get; set; }
        #endregion

        #region Constructores
        public IndexViewModel()
        {
            listadoCampeones = ClsListadoCampeones_BL.obtenerListaCampeones_BL();
            listadoCategorias = ClsListadoCategorias_BL.obtenerListaCategorias_BL();
            campeonElegido = new ClsCampeon();
            IDCampeonElegido = 0;
            rutaImagen = "";
        }

        public IndexViewModel(int idCampeon)
        {
            listadoCampeones = ClsListadoCampeones_BL.obtenerListaCampeones_BL();
            listadoCategorias = ClsListadoCategorias_BL.obtenerListaCategorias_BL();
            campeonElegido = ClsManejadoraCampeones_BL.CampeonPorID_BL(idCampeon);
            IDCampeonElegido = idCampeon;
            rutaImagen = campeonElegido.nombre + ".png";
        }
        #endregion
    }
}