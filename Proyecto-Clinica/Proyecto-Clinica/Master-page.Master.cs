﻿using Conexion_Clinica;
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
            if (!Seguridad.SesionActiva(Session["Usuario"]))
                Response.Redirect("Default.aspx", false);
            else
            {
                Usuario_Actual = (Usuario)Session["Usuario"];
            }
        }
    }
}