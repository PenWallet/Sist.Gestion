using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using BL.Listados;


namespace UI.ViewModels
{
    public class EditarTelefonoViewModel
    {
        #region Atributos
        public ClsPersona persona { get; set; }
        public string nombreDepartamento { get; set; }
        #endregion

        #region Constructores
        public EditarTelefonoViewModel(ClsPersona p, string nombreDepartamento)
        {
            this.persona = p;
            this.nombreDepartamento = nombreDepartamento;
        }

        public EditarTelefonoViewModel()
        {
            this.persona = new ClsPersona();
            this.nombreDepartamento = "";
        }
        #endregion  

    }
}