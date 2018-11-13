using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase persona con los siguientes atributos:
    ///     id: int, consultable
    ///     idDepartamento: int, consultable, modificable
    ///     Nombre: String, consultable, modificable
    ///     Apellidos: String, consultable, modificable
    ///     Teléfono: String, consultable, modificable
    ///     
    /// </summary>

    public class ClsPersona
    {
        #region Atributos
        public int id { get; }
        public int idDepartamento { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        #endregion

        #region Constructores
        public ClsPersona(int id, int idDep, string nombre, string apellidos, string telefono)
        {
            this.id = id;
            this.idDepartamento = idDep;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
        }
        #endregion
    }
}
