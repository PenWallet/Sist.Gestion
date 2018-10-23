﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _04___MVC_Pasar_datos_a_controlador.Models
{
    public class ClsPersona
    {
        #region Constructor por defecto
        public ClsPersona()
        {

        }
        #endregion

        #region Constructor con parámetros
        public ClsPersona(int id, string nombre, string apellidos, DateTime fechaNac, string direccion, string telefono)
        {
            this.idPersona = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac;
            this.direccion = direccion;
            this.telefono = telefono;
        }
        #endregion

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