using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Conexion_Clinica;
using Dominio;

namespace Proyecto_Clinica
{
    public partial class MailCambioContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void btnEnviarMail_Click(object sender, EventArgs e) {
            EmailService emailService = new EmailService();
            emailService.enviarEmail(txtIngresarMail.Text);
            try
            {
                emailService.enviarEmail();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnBuscarMailUsuario_Click (object sender, EventArgs e)
        {
            // por ahora esta la busqueda con el TELEFONO
            string telefono = txtDNI.Text.Trim();

            
            AccesoDatos datos = new AccesoDatos();

            //la query esta incompleta
            string query = "SELECT U.NOMBRE_USUARIO, P.MAIL " +
                           "FROM PACIENTES P " +
                           "INNER JOIN USUARIOS U ON P.ID_USUARIO = U.ID_USUARIO " +
                           "WHERE P.TELEFONO = @telefono";

            datos.setConsulta(query);

            datos.setParametro("@telefono", telefono);

            try
            {
                datos.ejecutarLectura();

                if (datos.Lector.HasRows)
                {
                    datos.Lector.Read();

                    string nombreUsuario = datos.Lector["NOMBRE_USUARIO"].ToString();
                    string email = datos.Lector["MAIL"].ToString();

                    lblMostrarMailUsuario.Text = "Su mail o usuario es: " + email;
                }
                else
                {
                    lblMostrarMailUsuario.Text = "No se encontraron resultados para el telefono ingresado.";
                }
            }
            catch (Exception ex)
            {
                lblMostrarMailUsuario.Text = "Error al ejecutar la consulta: " + ex.Message;
            }
            finally
            {
                // Cerrar la conexión después de usarla
                datos.cerrarConexion();
            }
        }
    }
}