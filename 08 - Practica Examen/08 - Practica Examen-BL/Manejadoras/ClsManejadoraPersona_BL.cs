using DAL.Conexion;
using DAL.Manejadoras;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Manejadoras
{
    public class ClsManejadoraPersona_BL
    {
        public static ClsPersona PersonaPorID_BL(int id)
        {
            ClsPersona p1 = ClsManejadoraPersona_DAL.PersonaPorID_DAL(id);

            return p1;
        }

        public static int ActualizarTelefonoPersona_BL(int idPersona, string telefono)
        {
            int filas = ClsManejadoraPersona_DAL.ActualizarTelefonoPersona_DAL(idPersona, telefono);

            return filas;
        }
    }
}
