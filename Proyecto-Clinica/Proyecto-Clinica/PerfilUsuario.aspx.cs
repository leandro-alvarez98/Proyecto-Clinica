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
        private void cargar_componentes()
        {
            Master_page master = (Master_page)this.Master;
            master.Mostrar_menu_lateral();

            Usuario_Actual = new Usuario();
            Usuario_Actual = (Usuario)Session["Usuario"];

        }
        protected void Page_Load(object sender, EventArgs e)
        {           
            cargar_componentes();
        }
    }
}