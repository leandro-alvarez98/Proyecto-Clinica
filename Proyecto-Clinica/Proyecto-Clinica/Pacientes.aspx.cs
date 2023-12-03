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
    public partial class Pacientes : System.Web.UI.Page
    {
        public Clinica clinica;
        public List<Paciente> lista_Pacientes_x_dni;
        ClinicaConexion clinicaConexion;
        protected void Page_Load(object sender, EventArgs e)
        {
            clinica = new Clinica();
            lista_Pacientes_x_dni = new List<Paciente>();
            clinicaConexion = new ClinicaConexion();

            clinica = clinicaConexion.Listar();


            if (!IsPostBack)
            { // solo se puede cargar una vez sino tira error
                repeaterPacientes.DataSource = clinica.Pacientes;
                repeaterPacientes.DataBind();
            }
        }

        protected void btnEditarDatos_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_buscar_pacientes_Click(object sender, EventArgs e)
        {
            try
            {
                
                string dni_paciente = txt_dni.Text;
                Cargar_Pacientes_x_Dni(dni_paciente);

                //limpia la grilla actual
                repeaterPacientes.DataSource = null;
                repeaterPacientes.DataBind();
                //cargar la nueva grilla de datos 
                repeaterPacientes.DataSource = lista_Pacientes_x_dni;
                repeaterPacientes.DataBind();
                if (lista_Pacientes_x_dni.Count() == 0)
                {
                    Lbl_sin_pacientes.Visible = true;
                }
                else
                {
                    Lbl_sin_pacientes.Visible = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Btn_limpiar_Click(object sender, EventArgs e)
        {
            //limpia la grilla actual
            repeaterPacientes.DataSource = null;
            repeaterPacientes.DataBind();
            //cargar la nueva grilla de datos 
            repeaterPacientes.DataSource = clinica.Pacientes;
            repeaterPacientes.DataBind();
            if (clinica.Pacientes.Count() != 0)
            {
                Lbl_sin_pacientes.Visible = false;
            }
        }
        public void Cargar_Pacientes_x_Dni(string dni)
        {
            foreach (Paciente paciente in clinica.Pacientes)
            {
                if (paciente.Dni == dni)
                {
                    lista_Pacientes_x_dni.Add(paciente);
                }
            }
        }
    }
}