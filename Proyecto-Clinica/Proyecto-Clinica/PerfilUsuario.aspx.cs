using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto_Clinica.Dominio;
using Conexion_Clinica;
using System.Collections;
using System.Windows.Forms;


namespace Proyecto_Clinica
{
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        Usuario Usuario_Actual = null;     
            
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Cargar_Componentes();
            }
        }
        private void Cargar_Componentes()
        {
            Master_page master = (Master_page)this.Master;
            master.Mostrar_menu_lateral();

            if (Usuario_Actual == null)
            {
                Usuario_Actual = new Usuario();

                Usuario_Actual = (Usuario)Session["Usuario"];

                Cargar_label_usuario();

                Cargar_Datos_Complementarios();
             
                return;
            }
        
        }
        private void Cargar_label_usuario()
        {
            string apellido = Usuario_Actual.Apellido;
            string nombre = Usuario_Actual.Nombre;
            string mail = Usuario_Actual.Mail;
            string telefono = Usuario_Actual.Telefono;
            string direccion = Usuario_Actual.Direccion;
            DateTime fecha_nacimiento = Usuario_Actual.Fecha_Nacimiento;
            int id = Usuario_Actual.Id;

            //nombrelbl.Text = "Apellido : " + apellido;
            //nombrelbl.Text = "Nombre : " + nombre;
            //nombrelbl.Text = "Mail : " + mail;
            //nombrelbl.Text = "Telefono : " + telefono;
            //direccionLabel.Text = "Dirrecion :" + direccion;
            //nombrelbl.Text = "Fecha de nacimiento : " + fecha_nacimiento;

        }
        public void Cargar_Datos_Complementarios()
        {

        }
    }
   
}