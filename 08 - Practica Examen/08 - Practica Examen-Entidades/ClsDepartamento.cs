using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase departamento con los siguientes atributos:
    ///     id: int, consultable
    ///     nombre: string, consultable, modificable
    /// </summary>

    public class ClsDepartamento
    {
        #region Atributos
        public int id { get; set;  }
        public string nombre { get; set; }
        #endregion

        #region Constructores
        public ClsDepartamento(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public ClsDepartamento()
        {
            this.id = 0;
            this.nombre = "";
        }
        #endregion
    }
}
