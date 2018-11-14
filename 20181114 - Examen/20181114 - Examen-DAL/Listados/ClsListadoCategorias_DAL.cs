using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Conexion;
using Entidades;

namespace DAL.Listados
{
    public static class ClsListadoCategorias_DAL
    {
        /// <summary>
        /// Función que devuelve un listado con todas las categorías que haya en la base de datos
        /// 
        /// En caso de no haber categorías en la base de datos, se devuelve una lista vacía
        /// </summary>
        /// <returns>List<ClsCategoria></returns>
        public static List<ClsCategoria> obtenerListaCategorias_DAL()
        {
            //Variables
            List<ClsCategoria> lista = new List<ClsCategoria>();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestConexion = new clsMyConnection();
            ClsCategoria c1;


            try
            {
                //Obtener conexión abierta
                conexion = gestConexion.getConnection();

                //Definir los parámetros del comando
                miComando.CommandText = "SELECT * FROM Categorias";

                //Definir la conexión del comando
                miComando.Connection = conexion;

                //Ejecutamos
                miLector = miComando.ExecuteReader();

                //Comprobar si el lector tiene filas, si afirmativo, recorrerlo
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        c1 = new ClsCategoria();
                        //Definir los atributos del objeto
                        c1.ID = (int)miLector["idCategoria"];
                        c1.nombre = (string)miLector["nombreCategoria"];

                        //Añadir objeto a la lista
                        lista.Add(c1);
                    }
                }


            }
            catch (SqlException e) { throw e; }
            finally
            {
                //Cerramos las conexiones
                gestConexion.closeConnection(ref conexion);
                miLector.Close();
            }

            return lista;

        }
    }
}
