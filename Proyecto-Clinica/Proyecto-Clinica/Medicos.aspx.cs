using Conexion_Clinica;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

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

            if (!IsPostBack)
            { // solo se puede cargar una vez sino tira error
                repeaterMedicos.DataSource = lista_Medicos;
                repeaterMedicos.DataBind();
            }
            
        }
        protected void btnEditarDatos_Click(object sender, EventArgs e)
        {
            //guardo el id del medico para asi poder utilizarlo en la proxima pagina
            //string id_medico = ((System.Web.UI.WebControls.Button)sender).CommandArgument;
            //int Id_Medico = int.Parse(id_medico);

            Session["Medico"] = Cargar_Médico_Clinica(1);
            Response.Redirect("Editar_medicos.aspx");
        }
        protected void btn_Nueva_Especialidad_Click(object sender, EventArgs e)
        {
            try
            {
                String Nueva_Especialidad = txt_Nueva_Especialidad.Text;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
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

        private Medico Cargar_Médico_Clinica(int medico_id)
        {
            foreach (Medico medico in clinica.Medicos)
            {
                if (medico.Id == medico_id)
                {
                    return medico;
                }
            }
            return new Medico();
        }
    }
}