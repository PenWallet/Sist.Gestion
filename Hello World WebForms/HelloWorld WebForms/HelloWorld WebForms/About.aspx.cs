using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld_WebForms.Entidades;
namespace HelloWorld_WebForms
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaludar_Click(object sender, EventArgs e)
        {
            clsPersona p1 = new clsPersona(txtNombre.Text, txtApellido.Text);
            lblResultado.Text = $"Hola {p1.nombre} {p1.apellido}";


            //string nombre = txtNombre.Text;
            //string nombre = Request.Form["ctl00$MainContent$txtNombre"]; //El nombre es este porque le asigna un valor que genera el código
            //lblResultado.Text = $"Hola {nombre}";
        }
    }
}