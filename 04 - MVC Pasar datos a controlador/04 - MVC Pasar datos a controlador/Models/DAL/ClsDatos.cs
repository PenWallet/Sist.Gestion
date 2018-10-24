using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _04___MVC_Pasar_datos_a_controlador.Models.Entidades;

namespace _04___MVC_Pasar_datos_a_controlador.Models.DAL
{
    public static class ClsDatos
    {
        public static string obtenerNombreDepartamentoPorId(int id)
        {
            List <ClsDepartamento> lista = ClsListadoDepartamentos.rellenar();
            ClsDepartamento dep = lista.Find(x => x.idDepartamento == id);

            return dep.nombreDepartamento;
        }
    }
}