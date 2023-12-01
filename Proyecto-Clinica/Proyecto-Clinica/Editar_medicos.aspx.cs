using Conexion_Clinica;
using Dominio;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Clinica
{
    public partial class Editar_medicos : System.Web.UI.Page
    {
        public Medico Medico_actual;
        public Clinica Clinica;
        List<Especialidad> lista_Especialidades; 

        protected void Page_Load(object sender, EventArgs e)
        {
            Medico_actual = (Medico)Session["Medico"];
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            Clinica = clinicaConexion.Listar();
            EspecialidadesConexion especialidadesConexion = new EspecialidadesConexion();
            Clinica.Especialidades = especialidadesConexion.Listar_2();
            lista_Especialidades = new List<Especialidad>();   
            //revisar el bucle 
            foreach (Especialidad especialidad in Clinica.Especialidades)
            {
                foreach (Especialidad esp in Medico_actual.Especialidades)
                {
                    if (especialidad.Id != esp.Id) {
                        lista_Especialidades.Add(especialidad);
                    }
                }
            }



            if (!IsPostBack)
            {
                repeaterJornadas.DataSource = Medico_actual.Jornadas;
                repeaterJornadas.DataBind();
                repeaterEspecialidades.DataSource = Medico_actual.Especialidades;
                repeaterEspecialidades.DataBind();
            }
        }
        //MODAL ESPECIALIDADES
        protected void btn_ActualizarEspecialidad_Click(object sender, EventArgs e)
        {

        }
        //
        protected void btn_SeleccionarMedicoEspecialidad_Click(object sender, EventArgs e)
        {
            
            rbl_Especialidades.DataSource = lista_Especialidades;
            rbl_Especialidades.DataTextField = "Tipo";
            rbl_Especialidades.DataValueField = "Id";
            rbl_Especialidades.DataBind();

            

            string script = @"
                $(document).ready(function () {
                    $('#mod_ElegirEspecialidad').modal('show');
                });
            ";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
        }
        //--------------------------------------------------------

        
        //MODAL JORNADA
        protected void btn_SeleccionarMedicoJornada_Click(object sender, EventArgs e)
        {
            rbl_Jornada.DataSource = Clinica.Jornadas; 
            rbl_Jornada.DataTextField = "Tipo";
            rbl_Jornada.DataValueField= "Id";
            rbl_Jornada.DataBind();

            

            string script = @"
                $(document).ready(function () {
                    $('#mod_ElegirJornada').modal('show');
                });
            ";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
        }

        protected void btn_ActualizarJornada_Click(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------
        private Medico GetMedico(int id)
        {
            foreach (Medico medico in Clinica.Medicos)
            {
                if (medico.Id == id)
                    return medico;
            }
            return new Medico();
        }

        protected void btn_EliminarEspecialidad_Click(object sender, EventArgs e)
        {

        }

        protected void btn_EliminarJornada_Click(object sender, EventArgs e)
        {

        }
    }
}