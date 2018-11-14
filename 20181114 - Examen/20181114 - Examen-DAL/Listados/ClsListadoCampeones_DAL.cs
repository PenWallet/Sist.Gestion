using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL.Conexion;

namespace DAL.Listados
{
    public static class ClsListadoCampeones_DAL
    {
        /// <summary>
        /// Función que devuelve un listado con todos los campeones que haya en la base de datos
        /// 
        /// En caso de no haber campeones en la base de datos, se devuelve una lista vacía
        /// </summary>
        /// <returns>List<ClsCampeon></returns>
        public static List<ClsCampeon> obtenerListaCampeones_DAL()
        {
            //Variables
            List<ClsCampeon> lista = new List<ClsCampeon>();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestConexion = new clsMyConnection();
            ClsCampeon c1;


            try
            {
                //Obtener conexión abierta
                conexion = gestConexion.getConnection();

                //Definir los parámetros del comando
                miComando.CommandText = "SELECT * FROM Personajes";

                //Definir la conexión del comando
                miComando.Connection = conexion;

                //Ejecutamos
                miLector = miComando.ExecuteReader();

                //Comprobar si el lector tiene filas, si afirmativo, recorrerlo
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        c1 = new ClsCampeon();
                        //Definir los atributos del objeto
                        c1.ID = (int)miLector["idPersonaje"];
                        c1.nombre = (string)miLector["nombre"];
                        c1.alias = (string)miLector["alias"];
                        c1.vida = (double)miLector["vida"];
                        c1.regeneracion = (double)miLector["regeneracion"];
                        c1.danno = (double)miLector["danno"];
                        c1.armadura = (double)miLector["armadura"];
                        c1.velAtaque = (double)miLector["velAtaque"];
                        c1.resistencia = (double)miLector["resistencia"];
                        c1.velMovimiento = (double)miLector["velMovimiento"];
                        c1.IDCategoria = (int)miLector["idCategoria"];

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
