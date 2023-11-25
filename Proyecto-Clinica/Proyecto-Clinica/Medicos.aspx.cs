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
    }
}