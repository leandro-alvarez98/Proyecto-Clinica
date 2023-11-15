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
    public partial class Confirmar_turno : System.Web.UI.Page
    {
        Turno turno_a_reservar;
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_componentes();
        }
        public void Cargar_componentes()
        {

            List<Turno> turno = new List<Turno>();
            turno_a_reservar = (Turno)Session["Turno"];
            turno.Add(turno_a_reservar);
           
            Turno_a_confirmar.DataSource = turno;
            Turno_a_confirmar.DataBind();
        }

        protected void Confirmar_turno_Click(object sender, EventArgs e)
        {
            //insert en la base de datos
        }
    }
}