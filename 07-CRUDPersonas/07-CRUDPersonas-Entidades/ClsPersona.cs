using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class ClsPersona
    {
        #region Constructor por defecto
        public ClsPersona()
        {

        }
        #endregion

        #region Constructor con parámetros
        public ClsPersona(int id, string nombre, string apellidos, DateTime fechaNac, string direccion, string telefono, int idDepartamento)
        {
            this.idPersona = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac;
            this.direccion = direccion;
            this.telefono = telefono;
            this.idDepartamento = idDepartamento;
        }
        #endregion

        #region "Atributos"
        [Required(ErrorMessage = "Campo requerido >:(")]
        [Display(Name = "ID del Departamento")]
        public int idDepartamento { get; set; }

        //[HiddenInput(DisplayValue = false)]
        public int idPersona { get; set; }

        [Required(ErrorMessage = "Campo requerido >:(")]
        [Display(Name ="Nombre")]               
        public string nombre { get; set; }

        [Required(ErrorMessage = "Campo requerido >:(")]
        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true),
         Required(ErrorMessage = "Campo requerido >:(")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime fechaNac { get; set; }

        [Required(ErrorMessage = "Campo requerido >:(")]
        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [RegularExpression(@"^[679]\d{8}", ErrorMessage = "Teléfono no válido"),
         Required(ErrorMessage = "Campo requerido >:(")]
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }
        #endregion


    }
}