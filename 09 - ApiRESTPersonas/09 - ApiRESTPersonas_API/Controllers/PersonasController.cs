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
    }
}
