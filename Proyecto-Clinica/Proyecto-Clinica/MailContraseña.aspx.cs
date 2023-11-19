using Conexion_Clinica;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class MailContraseña : System.Web.UI.Page
    {
        
        public Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_Componentes();
        }
        private void Cargar_Componentes()
        {
            usuario = new Usuario();
            usuario = (Usuario)Session["Usuario"];
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            String Contraseña = txtNuevaContraseña.Text;
            String Confirmacion = txtConfirmarContraseña.Text;
            if ( Contraseña.Length != 0 && Contraseña != null && Contraseña.Equals(Confirmacion))
            {

                Cambiar_Contraseña(Contraseña);
                usuario.Contraseña = Contraseña;

                // cerramos la sesion del usuario
                Session.Clear();
                Session.Abandon();

                // redirigimos a la pagina de inicio de sesion para que se logeé nuevamente
                Response.Redirect("Default.aspx");
            }

        }
        private void Cambiar_Contraseña(String Nueva_Contraseña)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE Usuarios SET CONTRASENA = @CONTRASENIA WHERE ID_USUARIO = @IDUSUARIO");
                datos.setParametro("@CONTRASENIA", Nueva_Contraseña);
                datos.setParametro("@IDUSUARIO", usuario.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}