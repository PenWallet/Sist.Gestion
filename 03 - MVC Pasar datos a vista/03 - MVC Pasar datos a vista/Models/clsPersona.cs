using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03___MVC_Pasar_datos_a_vista.Models
{
    public class ClsPersona
    {
        #region "Atributos"
        public int idPersona { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTime fechaNac { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        #endregion


    }
}