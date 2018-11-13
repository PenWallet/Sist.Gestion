using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Conexion;
using DAL.Listados;
using Entidades;

namespace BL.Listados
{
    public class ClsListadoDepartamentos_BL
    {
        /// <summary>
        /// Función que devuelve un List de ClsDepartamento
        /// 
        /// Devuelve una lista vacía si no hay datos en la base de datos; en caso contrario, lista con los departamentos
        /// de la base de datos
        /// </summary>
        /// <returns>List<ClsDepartamento></returns>
        public static List<ClsDepartamento> listadoCompletoDepartamentos_BL()
        {
            List<ClsDepartamento> lista = ClsListadoDepartamentos_DAL.listadoCompletoDepartamentos_DAL();

            return lista;
        }
    }
}
