using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld_WebForms.Entidades
{
    /* Nombre de la clase: ClsPersona
     * Atributos:
     *  Nombre: String, consultable, modificable
     *  Apellido: String, consultable, modificable
     * Métodos:
     *  Ninguno
     */ 
    public class clsPersona
    {
        #region "Atributos"
        //private string _nombre;
        //private string _apellido;
        #endregion

        #region "Constructores"
        public clsPersona(string n, string a)
        {
            nombre = n;
            apellido = a;
        }

        public clsPersona()
        {
            nombre = "Aitor";
            apellido = "Tortilla";
        }
        #endregion

        #region "Propiedades publicas"
        //Para cuando no queremos validar
        public string nombre { get; set; }
        public string apellido { get; set; }
        #endregion

    }
}
