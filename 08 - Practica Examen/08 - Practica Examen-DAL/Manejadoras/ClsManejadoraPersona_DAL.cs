using DAL.Conexion;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manejadoras
{
    public class ClsManejadoraPersona_DAL
    {
        public static ClsPersona PersonaPorID_DAL(int id)
        {
            //Variables
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            SqlCommand miComando = new SqlCommand();
            SqlParameter param;
            clsMyConnection gestConexion = new clsMyConnection();
            ClsPersona p1 = null;


            try //Try no obligatorio porque está controlado en la clase clsMyConnection
            {
                //Obtener conexión abierta
                conexion = gestConexion.getConnection();

                //Definir los parámetros del comando
                miComando.CommandText = "SELECT * FROM Personas WHERE ID = @id";

                //Creamos los parámetros
                param = new SqlParameter();
                param.ParameterName = "@id";
                param.SqlDbType = System.Data.SqlDbType.Int;
                param.Value = id;
                miComando.Parameters.Add(param);

                //Otra forma:
                //miComando.Parameters.Add("@nombre", System.Data.SqlDbType.Int).Value = id;

                //Definir la conexión del comando
                miComando.Connection = conexion;

                //Ejecutamos
                miLector = miComando.ExecuteReader();

                //Comprobar si el lector tiene la fila, si afirmativo, se lee y se obtiene la clase persona
                if (miLector.HasRows)
                {
                    //Leemos la fila
                    miLector.Read();
                    p1 = new ClsPersona();

                    //Definir los atributos del objeto
                    p1.id = (int)miLector["ID"];
                    p1.idDepartamento = (int)miLector["IDDepartamento"];
                    p1.nombre = (string)miLector["nombre"];
                    p1.apellidos = (string)miLector["apellidos"];
                    p1.telefono = (string)miLector["telefono"];
                }

            }
            catch (SqlException e) { throw e; }
            finally
            {
                gestConexion.closeConnection(ref conexion);
                miLector.Close();
            }

            return p1;
        }

        public static int ActualizarTelefonoPersona_DAL(int idPersona, string telefono)
        {
            //Variables
            SqlConnection conexion = null;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection gestConexion = new clsMyConnection();
            int filas = 0;


            try //Try no obligatorio porque está controlado en la clase clsMyConnection
            {
                //Obtener conexión abierta
                conexion = gestConexion.getConnection();

                //Definir los parámetros del comando
                miComando.CommandText = "UPDATE Personas SET telefono = @telefono WHERE ID = @id";

                //Creamos los parámetros
                miComando.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = idPersona;
                miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = telefono;

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
