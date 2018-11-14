using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.Manejadoras;

namespace BL.Manejadoras
{
    public static class ClsManejadoraCampeones_BL
    {
        /// <summary>
        /// Función que busca en la base de datos un campeón por la ID y devuelve
        /// un ClsCampeon con sus datos
        /// </summary>
        /// <param name="id">La ID del campeón a buscar en la base de datos</param>
        /// <returns>ClsCampeon</returns>
        public static ClsCampeon CampeonPorID_BL(int id)
        {
            ClsCampeon c1 = ClsManejadoraCampeones_DAL.CampeonPorID_DAL(id);

            return c1;
        }

        /// <summary>
        /// Función que actualiza un campeón en la base de datos
        /// 
        /// Devuelve el número de filas que se han afectado. El número ideal tras una actualización
        /// sería de 1 fila, indicando que el campeón que se ha querido cambiar ha sido el único
        /// en actualizarse
        /// </summary>
        /// <param name="c">El campeón a cambiar</param>
        /// <returns>Int</returns>
        public static int ActualizarCampeon_BL(ClsCampeon c)
        {
            int filas = ClsManejadoraCampeones_DAL.ActualizarCampeon_DAL(c);

            return filas;
        }
    }
}
