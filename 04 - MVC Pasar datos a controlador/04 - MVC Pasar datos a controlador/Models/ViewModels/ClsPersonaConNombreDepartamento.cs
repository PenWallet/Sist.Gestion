using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _04___MVC_Pasar_datos_a_controlador.Models.Entidades;
using _04___MVC_Pasar_datos_a_controlador.Models.DAL;

namespace _04___MVC_Pasar_datos_a_controlador.Models.ViewModels
{
    public class ClsPersonaConNombreDepartamento : ClsPersona
    {
        #region "Constructores"
        public ClsPersonaConNombreDepartamento()
        {

        }

        public ClsPersonaConNombreDepartamento(int idPersona, string nombre, string apellidos, DateTime fechaNac,
                                                string direccion, string telefono, int idDepartamento) : base(idPersona, nombre,
                                                    apellidos, fechaNac, direccion, telefono, idDepartamento)
        {
            nombreDepartamento = ClsDatos.obtenerNombreDepartamentoPorId(idDepartamento);
        }
        #endregion

        public string nombreDepartamento { get; set; }
    }
}