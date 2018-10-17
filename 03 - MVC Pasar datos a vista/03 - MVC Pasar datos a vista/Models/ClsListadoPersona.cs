using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _03___MVC_Pasar_datos_a_vista.Models;

namespace _03___MVC_Pasar_datos_a_vista.Models
{
    public class ClsListadoPersona
    {
        /// <summary>
        /// Función que devuelve una lista con varias personas
        /// </summary>
        /// <returns>List<ClsPersona></returns>
        public List<ClsPersona> ListadoPersonas()
        {
            List<ClsPersona> listado = new List<ClsPersona>();

            listado.Add(new ClsPersona(1, "Osquitarl", "Funesito", new DateTime(1999, 8, 12), "c/Nolose", "967287324"));
            listado.Add(new ClsPersona(2, "Tio", "Millonetis", new DateTime(1941, 1, 19), "Isla Paraíso", "564987321"));
            listado.Add(new ClsPersona(3, "Aitor", "Tilla", new DateTime(1990, 1, 1), "c/ Cocina", "123456788"));
            listado.Add(new ClsPersona(4, "Aitor", "Menta", new DateTime(2018, 10, 17), "c/ Frescor", "454187463"));
            listado.Add(new ClsPersona(5, "Fernando", "Galiana", new DateTime(1, 1, 1), "c/ ¯\\_(ツ)_/¯", "666666666"));

            return listado;
        }
    }
}