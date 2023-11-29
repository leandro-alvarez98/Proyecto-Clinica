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
        protected void Page_Load(object sender, EventArgs e)
        {
            Medico_actual = (Medico)Session["Medico"];
            lista_Medicos.Clear();
            lista_Medicos.Add(Medico_actual);

            if (!IsPostBack)
            {

                repeaterMedicos.DataSource = lista_Medicos;
                repeaterMedicos.DataBind();

            }
        }
    }
}