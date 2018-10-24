using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _04___MVC_Pasar_datos_a_controlador.Models.Entidades;

namespace _04___MVC_Pasar_datos_a_controlador.Models.DAL
{
    public static class ClsListadoDepartamentos
    {
        public static List<ClsDepartamento> rellenar()
        {
            List<ClsDepartamento> listaDepartamentos = new List<ClsDepartamento>
            {
                new ClsDepartamento(1, "Informática"),
                new ClsDepartamento(2, "Mantenimiento"),
                new ClsDepartamento(3, "Seguridad"),
                new ClsDepartamento(4, "Administración")
            };

            return listaDepartamentos;
        }
    }
}