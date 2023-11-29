using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class EmailService
    {
        SmtpClient ServerEmail = new SmtpClient();
        MailMessage Correo = new MailMessage();
        //NECESITAMOS CREAR UN MAIL PARA DARLE USO
        private string miEmail = "fanculeannash@gmail.com";
        private string miContraseña = "fpqxtloemcfldqso";
        private string miAlias = "EQUIPO 18";
        //private string[] miAdjuntos;
        private MailMessage miCorreo;

        //aca vamos a cargar el array de archivos a enviar (pdf, jpg, etc)
        private void AdjuntarArchivos()
        {

        }
        //cambio de contraseña
        public void cuerpoCorreo(string correo)
        {
            miCorreo = new MailMessage
            {
                From = new MailAddress(miEmail, miAlias, System.Text.Encoding.UTF8)
            };
            miCorreo.To.Add(correo);
            miCorreo.Subject = ("Recuperar contaseña");
            miCorreo.IsBodyHtml = true;
            string enlaceRecuperarContraseña = "https://localhost:44348/MailContrase%C3%B1a.aspx";
            miCorreo.Body = "Hola! Usted solicitó recuperar su contraseña. Haga clic <a href='" + enlaceRecuperarContraseña + "'>aquí</a> para restablecerla.";
            miCorreo.Priority = MailPriority.High;
        }
        //envio de turno confirmado
        //hay que generar o pasarle los numeros de turnos que se generen
        public void cuerpoCorreo(Turno turno_a_reservar, string correo)
        {
            miCorreo = new MailMessage
            {
                From = new MailAddress(miEmail, miAlias)
            };
            miCorreo.To.Add(correo);
            miCorreo.Subject = "Confirmacion de turno";
            miCorreo.IsBodyHtml = true;
            miCorreo.Body = $"{turno_a_reservar.Nombre_Paciente} {turno_a_reservar.Apellido_Paciente} le brindamos la informacion sobre su turno: <br/>Numero de turno: {turno_a_reservar.Id}<br/>Hora: {turno_a_reservar.Fecha}<br/>Hora: {turno_a_reservar.Horario}<br/>Medico: {turno_a_reservar.Nombre_Medico} {turno_a_reservar.Apellido_Medico}";
            miCorreo.Priority = MailPriority.High;
        }
         

        public void enviarCorreo()
        {

            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    UseDefaultCredentials = false,
                    Port = 25,
                    Host = "smtp.gmail.com",
                    Credentials = new System.Net.NetworkCredential(miEmail, miContraseña)
                };
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
                { return true; };
                smtp.EnableSsl = true;
                smtp.Send(miCorreo);
                //MessageBox.Show("Enviado");

            }
            catch (Exception)
            {

                throw;
            }

        }



        
    }
}
