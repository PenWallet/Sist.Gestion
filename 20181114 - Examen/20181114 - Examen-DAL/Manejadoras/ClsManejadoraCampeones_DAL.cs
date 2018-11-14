using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Conexion;
using Entidades;

namespace DAL.Manejadoras
{
    public static class ClsManejadoraCampeones_DAL
    {
        /// <summary>
        /// Función que busca en la base de datos un campeón por la ID y devuelve
        /// un ClsCampeon con sus datos
        /// </summary>
        /// <param name="id">La ID del campeón a buscar en la base de datos</param>
        /// <returns>ClsCampeon</returns>
        public static ClsCampeon CampeonPorID_DAL(int id)
        {
            //Variables
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestConexion = new clsMyConnection();
            ClsCampeon c1 = null;


            try
            {
                //Obtener conexión abierta
                conexion = gestConexion.getConnection();

                //Definir los parámetros del comando
                miComando.CommandText = "SELECT * FROM Personajes WHERE idPersonaje = @id";

                //Añadimos el parámetro id
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                //Definir la conexión del comando
                miComando.Connection = conexion;

                //Ejecutamos
                miLector = miComando.ExecuteReader();

                //Comprobar si el lector tiene la fila, si afirmativo, se lee y se obtiene la clase persona
                if (miLector.HasRows)
                {
                    //Leemos la fila
                    miLector.Read();
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
                }

            }
            catch (SqlException e) { throw e; }
            finally
            {
                gestConexion.closeConnection(ref conexion);
                miLector.Close();
            }

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
        public static int ActualizarCampeon_DAL(ClsCampeon c)
        {
            //Variables
            SqlConnection conexion = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestConexion = new clsMyConnection();
            int filas = 0;

            try
            {
                //Obtener conexión abierta
                conexion = gestConexion.getConnection();

                //Definir los parámetros del comando
                miComando.CommandText = "UPDATE Personajes SET " +
                    "nombre = @nombre, alias = @alias, vida = @vida, " +
                    "regeneracion = @regeneracion, danno = @danno, armadura = @armadura, " +
                    "velAtaque = @velAtaque, resistencia = @resistencia, velMovimiento = @velMovimiento, idCategoria = @idCategoria " +
                    "WHERE idPersonaje = @id";

                //Creamos los parámetros
                miComando.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = c.ID;
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = c.nombre;
                miComando.Parameters.Add("@alias", System.Data.SqlDbType.VarChar).Value = c.alias;
                miComando.Parameters.Add("@vida", System.Data.SqlDbType.Float).Value = c.vida;
                miComando.Parameters.Add("@regeneracion", System.Data.SqlDbType.Float).Value = c.regeneracion;
                miComando.Parameters.Add("@danno", System.Data.SqlDbType.Float).Value = c.danno;
                miComando.Parameters.Add("@armadura", System.Data.SqlDbType.Float).Value = c.armadura;
                miComando.Parameters.Add("@velAtaque", System.Data.SqlDbType.Float).Value = c.velAtaque;
                miComando.Parameters.Add("@resistencia", System.Data.SqlDbType.Float).Value = c.resistencia;
                miComando.Parameters.Add("@velMovimiento", System.Data.SqlDbType.Float).Value = c.velMovimiento;
                miComando.Parameters.Add("@idCategoria", System.Data.SqlDbType.Int).Value = c.IDCategoria;

                //Definir la conexión del comando
                miComando.Connection = conexion;

                //Ejecutamos
                filas = miComando.ExecuteNonQuery();


            }
            catch (SqlException e) { throw e; }
            finally
            {
                gestConexion.closeConnection(ref conexion);
            }

            return filas;
        }
    }
}
