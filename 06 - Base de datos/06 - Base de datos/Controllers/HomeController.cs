using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;

namespace _06___Base_de_datos.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionName ("Index")]
        public ActionResult IndexPost()
        {
            SqlConnection miConexion = new SqlConnection();
            List<ClsPersona> listadoPersonas = new List<ClsPersona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            ClsPersona p1;

            try
            {
                miConexion.ConnectionString = "server=pennypersonas.database.windows.net;database=PersonasDB;uid=PenWallet;pwd=Puton#123;";
                miConexion.Open();

                ViewData["Estado"] = miConexion.State;
            }
            catch (SqlException e) { ViewData["Estado"] = e.StackTrace; ; }
            finally { miConexion.Close(); }


            return View();
        }

        public ActionResult ListadoPersonas()
        {
            SqlConnection miConexion = new SqlConnection();
            List<ClsPersona> listadoPersonas = new List<ClsPersona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            ClsPersona p1;

            try
            {
                miConexion.ConnectionString = "server=pennypersonas.database.windows.net;database=PersonasDB;uid=PenWallet;pwd=Puton#123;";
                miConexion.Open();

                miComando.CommandText = "SELECT * FROM Personas";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        p1 = new ClsPersona();
                        p1.idPersona = (int)miLector["IDPersona"];
                        p1.nombre = (string)miLector["nombrePersona"];
                        p1.apellidos = (string)miLector["apellidosPersona"];
                        p1.fechaNac = (DateTime)miLector["fechaNacimiento"];
                        p1.direccion = (string)miLector["direccion"];
                        p1.telefono = (string)miLector["telefono"];
                        p1.idDepartamento = (int)miLector["IDDepartamento"];
                        listadoPersonas.Add(p1);
                    }
                }
                miLector.Close();
                miConexion.Close();
            
            }
            catch (SqlException e) {  ; }
            finally { miConexion.Close(); }


            return View(listadoPersonas);
        }
    }
}