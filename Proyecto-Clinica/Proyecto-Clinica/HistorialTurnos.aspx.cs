using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto_Clinica.Dominio;

namespace Proyecto_Clinica
{
    public partial class HistorialTurnos : System.Web.UI.Page
    {
        //crear evento btn_ingresar_Click
        //crear evento btn_ingresar_Click
        public void cargar_componentes()
        {
            //hace aparecer el menu lateral
            Master_page master = (Master_page)this.Master;
            master.Mostrar_menu_lateral();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_componentes();
        }


    }
}