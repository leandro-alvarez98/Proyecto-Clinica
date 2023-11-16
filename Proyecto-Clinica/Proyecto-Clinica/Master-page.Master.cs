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
        public Usuario Usuario_Actual;
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario_Actual = new Usuario();
            Usuario_Actual = (Usuario)Session["Usuario"];
        }
    }
}