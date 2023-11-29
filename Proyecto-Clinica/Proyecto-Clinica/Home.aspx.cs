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
    public partial class Home : System.Web.UI.Page
    {
        Clinica clinica;
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_Componentes();
        }
        public void Cargar_Componentes()
        {
            clinica = new Clinica();
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            clinica = clinicaConexion.Listar();
            Session["Clinica"] = clinica; //Esto contiene toda la información en caso de ser necesaria para checkear algo
        }
    }
}