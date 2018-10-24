using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _04___MVC_Pasar_datos_a_controlador.Models.Entidades;
using _04___MVC_Pasar_datos_a_controlador.Models.DAL;

namespace _04___MVC_Pasar_datos_a_controlador.Models.ViewModels
{
    public class ClsPersonaConListadoDepartamentos : ClsPersona
    {
        #region "Constructor por defecto"
        public ClsPersonaConListadoDepartamentos()
        {
            this.listaDepartamentos = ClsListadoDepartamentos.rellenar();
        }
        #endregion

        #region "Constructor con parámetros"
        public ClsPersonaConListadoDepartamentos(int idPersona, string nombre, string apellidos, DateTime fechaNac, 
                                                string direccion, string telefono, int idDepartamento) : base(idPersona, nombre,
                                                    apellidos, fechaNac, direccion, telefono, idDepartamento)
                
        {
            this.listaDepartamentos = ClsListadoDepartamentos.rellenar();
        }
        #endregion

        public List<ClsDepartamento> listaDepartamentos { get; set; }
  
    }
}