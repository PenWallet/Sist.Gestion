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
    public class ClsListadoPersonas_BL
    {
        /// <summary>
        /// Función que devuelve un List de ClsPersona
        /// 
        /// Devuelve una lista vacía si no hay datos en la base de datos; en caso contrario, lista con las personas
        /// de la base de datos
        /// </summary>
        /// <returns>List<ClsPersona></returns>
        public static List<ClsPersona> listadoCompletoPersonas_BL()
        {
            List<ClsPersona> lista = ClsListadoPersonas_DAL.listadoCompletoPersonas_DAL();

            return lista;
        }

        /// <summary>
        /// Función que devuelve un List de ClsPersona donde todas pertenecen al mismo departamento
        /// 
        /// Devuelve una lista vacía si no hay datos en la base de datos.
        /// </summary>
        /// <param name="idDepartamento">ID del departamento</param>
        /// <returns></returns>
        public static List<ClsPersona> listadoPersonasPorDepartamento_BL(int idDepartamento)
        {
            List<ClsPersona> lista = ClsListadoPersonas_DAL.listadoPersonasPorDepartamento_DAL(idDepartamento);

            return lista;
        }
    }
}
