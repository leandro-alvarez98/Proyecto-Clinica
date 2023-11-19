using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Conexion_Clinica;
using Dominio;
using Proyecto_Clinica.Dominio;

namespace Proyecto_Clinica
{
    public partial class MailCambioContraseña : System.Web.UI.Page
    {
        public Clinica clinica;
        protected void Page_Load(object sender, EventArgs e)
        {
            clinica = new Clinica();
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            clinica = clinicaConexion.Listar();

        }


        protected void btnEnviarMail_Click(object sender, EventArgs e)
        {
            //bool correoVerificado = false;
            EmailService emailService = new EmailService();
            emailService.cuerpoCorreo(txtIngresarMail.Text);

            try
            {
                // Verificar si el correo electrónico existe en la base de datos
                bool correoEncontrado = VerificarCorreoEnBaseDeDatos(txtIngresarMail.Text);

                if (correoEncontrado)
                {
                    //correoVerificado = true;
                    emailService.enviarCorreo();
                    lblMensaje.Text = "Correo enviado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "No se encontró el correo en la base de datos.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al verificar el correo: " + ex.Message;
            }
        }

        // Método para verificar si el correo existe en la base de datos
        private bool VerificarCorreoEnBaseDeDatos(string correo)
        {
            AccesoDatos datos = new AccesoDatos();

            // Query para verificar si el correo existe en alguna tabla de usuarios
            string query = "SELECT 1 FROM ( " +
                           "SELECT ID_USUARIO FROM PACIENTES WHERE MAIL = @correo " +
                           "UNION ALL " +
                           "SELECT ID_USUARIO FROM MEDICOS WHERE MAIL = @correo " +
                           "UNION ALL " +
                           "SELECT ID_USUARIO FROM RECEPCIONISTA WHERE MAIL = @correo " +
                           "UNION ALL " +
                           "SELECT ID_USUARIO FROM ADMINISTRADOR WHERE MAIL = @correo " +
                           ") AS Usuarios";

            datos.setConsulta(query);
            datos.setParametro("@correo", correo);

            try
            {
                datos.ejecutarLectura();

                // Utilizamos un bucle while para leer las filas resultantes
                while (datos.Lector.Read())
                {
                    // Si hay al menos una fila, el correo existe en alguna tabla de usuarios
                    return true;
                }

                // No se encontraron filas, el correo no existe en ninguna tabla de usuarios
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //protected void btnEnviarMail_Click(object sender, EventArgs e)
        //{
        //    bool correoVerificado = false;
        //    EmailService emailService = new EmailService();
        //    emailService.cuerpoCorreo(txtIngresarMail.Text);

        //    try
        //    {
        //        foreach (Usuario usuario in clinica.Usuarios)
        //        {
        //            if (string.Equals(usuario.Mail, txtIngresarMail.Text, StringComparison.OrdinalIgnoreCase))
        //            {
        //                correoVerificado = true;
        //                break;
        //            }
        //        }

        //        if (correoVerificado)
        //        {
        //            emailService.enviarCorreo();
        //            lblMensaje.Text = "Correo enviado correctamente.";
        //        }
        //        else
        //        {
        //            lblMensaje.Text = "No se encontró el correo.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMensaje.Text = "Error al verificar el correo: " + ex.Message;
        //    }

        //}

        protected void btnBuscarMailUsuario_Click(object sender, EventArgs e)
        {

            string dni = txtDNI.Text.Trim();

            AccesoDatos datos = new AccesoDatos();
            //esto se puede optimizar
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