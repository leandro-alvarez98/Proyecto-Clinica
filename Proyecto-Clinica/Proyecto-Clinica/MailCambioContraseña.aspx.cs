using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            emailService.enviarEmail();
            try
            {
                emailService.enviarEmail();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}