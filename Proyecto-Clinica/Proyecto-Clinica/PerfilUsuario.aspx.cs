using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto_Clinica.Dominio;
using Conexion_Clinica;
using System.Collections;
using System.Windows.Forms;


namespace Proyecto_Clinica
{
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        Usuario Usuario_Actual;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Cargar_Componentes();
            }
        }
        private void Cargar_Componentes()
        {
            Master_page master = (Master_page)this.Master;
            master.Mostrar_menu_lateral();

            if (Usuario_Actual != null)
            {
                return;
            }
            Usuario_Actual = new Usuario();

            Usuario_Actual = (Usuario)Session["Usuario"];
        }
    }
}