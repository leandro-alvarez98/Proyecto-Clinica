using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Clinica
{
    public partial class Master_page : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Mostrar_menu_lateral()
        {
            menu_lateral.Visible = true;
        }
        public void Mostrar_Icono()
        {
            btn_nav_con_redireccion.Visible = true;
            btn_nav_sin_redireccion.Visible = false;
        }
        
    }
}