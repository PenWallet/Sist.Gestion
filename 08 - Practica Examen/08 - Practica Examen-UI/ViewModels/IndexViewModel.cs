using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;

namespace ViewModels
{
    public class IndexViewModel
    {
        #region Atributos
        public List<ClsPersona> listaPersonasPorDepartamento { get; set; }
        public List<ClsDepartamento> listaDepartamentos { get; set; }
        public int idDepartamento { get; set; }
        #endregion

        #region Constructores
        public IndexViewModel(List<ClsPersona> lPersonas, List<ClsDepartamento> lDepartamentos)
        {
            listaPersonasPorDepartamento = lPersonas;
            listaDepartamentos = lDepartamentos;
            idDepartamento = 0;
        }

        public IndexViewModel()
        {
            //listaDepartamentos = 
        }
        #endregion  

    }
}