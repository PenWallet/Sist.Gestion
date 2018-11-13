using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using BL.Listados;


namespace UI.ViewModels
{
    public class IndexViewModel
    {
        #region Atributos
        public List<ClsPersona> listaPersonasPorDepartamento { get; set; }
        public List<ClsDepartamento> listaDepartamentos { get; set; }
        public int idDepartamento { get; set; }
        #endregion

        #region Constructores
        public IndexViewModel(List<ClsPersona> lPersonas, int idDep)
        {
            listaPersonasPorDepartamento = lPersonas;
            listaDepartamentos = ClsListadoDepartamentos_BL.listadoCompletoDepartamentos_BL();
            idDepartamento = idDep;
        }

        public IndexViewModel()
        {
            listaPersonasPorDepartamento = new List<ClsPersona>();
            listaDepartamentos = ClsListadoDepartamentos_BL.listadoCompletoDepartamentos_BL();
            idDepartamento = 0;
        }
        #endregion  

    }
}