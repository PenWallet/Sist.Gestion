using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.Listados;

namespace BL.Listados
{
    public static class ClsListadoCampeones_BL
    {
        /// <summary>
        /// Función que devuelve un listado con todos los campeones que haya en la base de datos
        /// 
        /// En caso de no haber campeones en la base de datos, se devuelve una lista vacía
        /// </summary>
        /// <returns>List<ClsCampeon></returns>
        public static List<ClsCampeon> obtenerListaCampeones_BL()
        {
            List<ClsCampeon> lista = ClsListadoCampeones_DAL.obtenerListaCampeones_DAL();

            return lista;
        }
    }
}
