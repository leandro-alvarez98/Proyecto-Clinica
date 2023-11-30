using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Conexion_Clinica;
using Proyecto_Clinica.Dominio;

namespace Proyecto_Clinica
{
    public partial class AltaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_AceptarAltaUsuario_Click(object sender, EventArgs e)
        {
            bool usuarioValido = false;

            //Comprueba que los campos pasen las condiciones
            if (txtRegistrarUsuario != null && txtRegistrarUsuario.Text != "" && txtRegistrarContrasena.Text != "" && txtRegistrarContrasena.Text == txtRegistrarContrasena2.Text)
            {
                usuarioValido = true;
            }
            //Si las pasa, se crea un usuario nuevo y se lo ingresa en la BBDD
            if (usuarioValido)
            {
                UsuarioConexion usuarioConexion = new UsuarioConexion();

                Usuario nuevo_usuario = new Usuario
                {
                    Nombre = txtRegistrarUsuario.Text,
                    Contraseña = txtRegistrarContrasena.Text,
                    Tipo = "Paciente"
                };
                usuarioConexion.InsertarUsuarioEnBBDD(nuevo_usuario);

                Session["Usuario"] = nuevo_usuario;
                Response.Redirect("Perfil_Usuario.aspx");
            }
            else
            {
                lbl_Error_Registro.Visible = true;
            }
        }
    }
}