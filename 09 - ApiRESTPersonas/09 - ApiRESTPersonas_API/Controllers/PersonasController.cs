using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entidades;
using BL.Listados;
using BL.Manejadoras;

namespace _09___ApiRESTPersonas_API.Controllers
{
    public class PersonasController : ApiController
    {
        /// <summary>
        /// Verbo Get parapeticiones de un listado completo de personas
        /// </summary>
        /// <returns>List<ClsPersona></returns>
        public List<ClsPersona> Get()
        {
            return ClsListadoPersonas_BL.listadoCompletoPersonas_BL();
        }

        /// <summary>
        /// Verbo Get para peticiones de una sola persona dada un ID
        /// </summary>
        /// <param name="id">ID de la personas</param>
        /// <returns>ClsPersona</returns>
        public ClsPersona Get(int id)
        {
            return ClsManejadoraPersona_BL.PersonaPorID_BL(id);
        }

        /// <summary>
        /// Verbo Post para agregar una persona a la base de datos
        /// Devuelve true si se ha creado correctamente, false en caso contrario
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>bool</returns>
        public bool Post([FromBody]ClsPersona persona)
        {
            return ClsManejadoraPersona_BL.CrearPersona_BL(persona) == 1 ? true : false;
        }

        /// <summary>
        /// Verbo Delete para borrar una persona de la base de datos dada una ID
        /// Devuelve true si se ha borrado correctamente, false en caso contrario
        /// </summary>
        /// <param name="id">ID de la persona a borrar</param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            return ClsManejadoraPersona_BL.BorrarPorID_BL(id) == 1 ? true : false;
        }

        /// <summary>
        /// Verbo Put para actualizar una persona de la base de datos
        /// Devuelve true si se ha actualizado correctamente, false en caso contrario
        /// </summary>
        /// <param name="persona">Persona con los datos actualizadas. La ID deber ser la misma</param>
        /// <returns>bool</returns>
        public bool Put([FromBody]ClsPersona persona)
        {
            return ClsManejadoraPersona_BL.ActualizarPersona_BL(persona) == 1 ? true : false;
        }
    }
}
