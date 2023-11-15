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


        protected void btnEnviarMail_Click(object sender, EventArgs e)
        {
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

        protected void btnBuscarMailUsuario_Click(object sender, EventArgs e)
        {
            // por ahora buscamos por telefono
            string dni = txtDNI.Text.Trim();

            AccesoDatos datos = new AccesoDatos();

            string query = "SELECT U.NOMBRE_USUARIO, P.MAIL " +
               "FROM PACIENTES P " +
               "INNER JOIN USUARIOS U ON P.ID_USUARIO = U.ID_USUARIO " +
               "WHERE P.DNI = @dni " +
               "UNION ALL " +
               "SELECT U.NOMBRE_USUARIO, M.MAIL " +
               "FROM MEDICOS M " +
               "INNER JOIN USUARIOS U ON M.ID_USUARIO = U.ID_USUARIO " +
               "WHERE M.DNI = @dni " +
               "UNION ALL " +
               "SELECT U.NOMBRE_USUARIO, R.MAIL " +
               "FROM RECEPCIONISTA R " +
               "INNER JOIN USUARIOS U ON R.ID_USUARIO = U.ID_USUARIO " +
               "WHERE R.DNI = @dni " +
               "UNION ALL " +
               "SELECT U.NOMBRE_USUARIO, A.MAIL " +
               "FROM ADMINISTRADOR A " +
               "INNER JOIN USUARIOS U ON A.ID_USUARIO = U.ID_USUARIO " +
               "WHERE A.DNI = @dni";

            datos.setConsulta(query);

            datos.setParametro("@dni", dni);

            try
            {
                datos.ejecutarLectura();

                if (datos.Lector.HasRows)
                {
                    datos.Lector.Read();

                    string nombreUsuario = datos.Lector["NOMBRE_USUARIO"].ToString();
                    string email = datos.Lector["MAIL"].ToString();

                    lblMostrarMailUsuario.Text = "Su mail es: " + email;
                    lblMostrarNombreUsuario.Text = "Su nombre de usuario es: " + nombreUsuario;
                }
                else
                {
                    lblMostrarMailUsuario.Text = "No se encontraron resultados para el DNI ingresado.";

                }
            }
            catch (Exception ex)
            {
                lblMostrarMailUsuario.Text = "Error al ejecutar la consulta: " + ex.Message;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}