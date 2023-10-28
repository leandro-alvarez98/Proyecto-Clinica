using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto_Clinica.Dominio;
using Conexion_Clinica;
namespace Proyecto_Clinica
{
    public partial class Default : System.Web.UI.Page
    {
        Clinica clinica = new Clinica();
        public void cargar_componentes()
        {
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            clinica = clinicaConexion.listar();

            //Se cargan las grillas
            dgv_Pacientes.DataSource = clinica.pacientes;
            dgv_Medicos.DataSource = clinica.medicos;
            dgv_Turnos.DataSource = clinica.turnos;
            dgv_Usuarios.DataSource = clinica.usuarios;
            //Se muestran
            dgv_Pacientes.DataBind();
            dgv_Medicos.DataBind();
            dgv_Turnos.DataBind();
            dgv_Usuarios.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_componentes();
        }
    }
}