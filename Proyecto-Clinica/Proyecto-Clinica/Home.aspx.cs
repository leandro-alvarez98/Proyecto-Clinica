using Conexion_Clinica;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Clinica
{
    public partial class Home : System.Web.UI.Page
    {
        Clinica clinica = new Clinica();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Turnos.Visible = false;

            cargar_componentes();

        }
        public void cargar_componentes()
        {
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            clinica = clinicaConexion.listar();

            //Se carga la drop down list de especialidades
            DdlEspecialidad.DataSource = clinica.especialidades;
            //Se muestra la drop down list de especialidades
            DdlEspecialidad.DataBind();
        }
        public void DdlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica la selección en el DropDownList.
            if (DdlEspecialidad.SelectedValue == "Turnos")
            {
                // Muestra el div "turnos" si se selecciona "Turnos".
                Turno.Visible = true;
            }
            else
            {
                // Oculta el div "turnos" si se selecciona otra opción.
                Turno.Visible = false;
            }
        }
    }
}