using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Clinica
{
    public partial class Detalle_turno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_componentes();

        }
        public void Cargar_componentes()
        {
            List<Turno> turno = new List<Turno>();
            Turno turno1 = new Turno();

            turno1 = (Turno)Session["Turno"];
            turno.Add(turno1);
            Dgv_detalle_turno.DataSource = turno;
            Dgv_detalle_turno.DataBind();
        }
    }
}