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
    public partial class Medicos : System.Web.UI.Page
    {
        public Clinica clinica = new Clinica();
        public List<Medico> lista_Medicos = new List<Medico>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            clinica = clinicaConexion.Listar();
            lista_Medicos.Clear();

            lista_Medicos = clinica.Medicos;

            repeaterMedicos.DataSource = lista_Medicos;
            repeaterMedicos.DataBind();
        }

        protected void btnEditarDatos_Click(object sender, EventArgs e)
        {
            
        }

        protected void btn_Nueva_Especialidad_Click(object sender, EventArgs e)
        {
            String Nueva_Especialidad = txt_Nueva_Especialidad.Value;
            bool Existe = Comprobar_Especialidad(Nueva_Especialidad);

            if (Nueva_Especialidad != null && Nueva_Especialidad.Length > 5 && !Existe) // puse mayor a 5 por tirar xd
            {
                EspecialidadesConexion especialidadesConexion = new EspecialidadesConexion();
                especialidadesConexion.Insertar_Especialidad_En_BBDD(Nueva_Especialidad);
                lblCargada_Correctamente.Visible = true;
                lblError_Especialidad.Visible = false;
            }
            else
            {
                lblError_Especialidad.Visible = true;
                lblCargada_Correctamente.Visible = false;
            }
        }

        private bool Comprobar_Especialidad(string nueva_Especialidad)
        {
            foreach(Especialidad especialidad in clinica.Especialidades)
            {
                if(especialidad.Tipo == nueva_Especialidad)
                {
                    return true;
                }
            }
            return false;
        }
    }
}