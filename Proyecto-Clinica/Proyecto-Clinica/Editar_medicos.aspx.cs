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
    public partial class Editar_medicos : System.Web.UI.Page
    {
        public List<Medico> lista_Medicos = new List<Medico>();
        public Medico Medico_actual;
        Clinica Clinica;
        protected void Page_Load(object sender, EventArgs e)
        {
            Medico_actual = (Medico)Session["Medico"];
            lista_Medicos.Clear();
            lista_Medicos.Add(Medico_actual);
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            Clinica = clinicaConexion.Listar();

            if (!IsPostBack)
            {

                repeaterMedicos.DataSource = lista_Medicos;
                repeaterMedicos.DataBind();

            }
        }
        //MODAL ESPECIALIDADES
        protected void btn_ActualizarEspecialidad_Click(object sender, EventArgs e)
        {

        }
        //
        protected void btn_SeleccionarMedicoEspecialidad_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int idMedicoSeleccionado = int.Parse(btn.CommandArgument);

            Medico medico_Seleccionado = GetMedico(idMedicoSeleccionado);

            Session["MedicoSeleccionado"] = medico_Seleccionado;

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
            rbl_Jornada.DataBind();

            Button btn = (Button)sender;

            int idMedicoSeleccionado = int.Parse(btn.CommandArgument);

            Medico medico_Seleccionado = GetMedico(idMedicoSeleccionado);

            Session["MedicoSeleccionado"] = medico_Seleccionado;

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
    }
}