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
    public class ClsManejadoraDepartamento_BL
    {
        public static ClsDepartamento DepartamentoPorID_BL(int id)
        {
            ClsDepartamento d1 = ClsManejadoraDepartamento_DAL.DepartamentoPorID_DAL(id);

            return d1;
        }
    }
}
