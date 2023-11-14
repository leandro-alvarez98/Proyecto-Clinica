using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class EmailService
    {         
        SmtpClient ServerEmail = new SmtpClient();          
        MailMessage Correo = new MailMessage();


        //DESPUES CREO Y AGREGO UN MAIL PARA YA DEJARLO FIJO PARA EL PROYECTO
        public EmailService() { 
            ServerEmail.Credentials = new NetworkCredential("MAIL", "CONTRASEÑA");
            ServerEmail.EnableSsl = true;
            ServerEmail.Port = 587;
            ServerEmail.Host = "smtp.gmail.com";
        }
        public void enviarEmail(string correo, string password)
        {
            Correo.From = new MailAddress("aca va el mail");
            Correo.To.Add(correo);
            Correo.Subject = ("Recuperar Contraseña");
            Correo.IsBodyHtml = true;
            Correo.Body = "Hola! Usted solicito recuperar su contraseña: ";
            Correo.Priority = MailPriority.Normal;
        }

        public void enviarEmail() {
            try
            {
                ServerEmail.Send(Correo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
