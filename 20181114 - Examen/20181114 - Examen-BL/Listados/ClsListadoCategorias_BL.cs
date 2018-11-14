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
    public static class ClsListadoCategorias_BL
    {
        /// <summary>
        /// Función que devuelve un listado con todas las categorías que haya en la base de datos
        /// 
        /// En caso de no haber categorías en la base de datos, se devuelve una lista vacía
        /// </summary>
        /// <returns>List<ClsCategoria></returns>
        public static List<ClsCategoria> obtenerListaCategorias_BL()
        {
            List<ClsCategoria> lista = ClsListadoCategorias_DAL.obtenerListaCategorias_DAL();

            return lista;
        }
    }
}
