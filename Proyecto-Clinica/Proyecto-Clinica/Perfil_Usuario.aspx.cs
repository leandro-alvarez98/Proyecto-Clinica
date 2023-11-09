using Conexion_Clinica;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class Perfil_Usuario : System.Web.UI.Page
    {
        public Usuario Usuario_Actual = null;
        Paciente paciente_actual = null;
        Medico Medico_actual = null;
        Clinica clinica;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cargar_Componentes();
            }
        }
        private void Cargar_Componentes()
        {
            clinica = new Clinica();
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            clinica = clinicaConexion.Listar();

            Usuario_Actual = new Usuario();
            Usuario_Actual = (Usuario)Session["Usuario"];

            if (Usuario_Actual.Tipo == "Médico")
            {
                Medico_actual = new Medico();
                Medico_actual = Cargar_Médico_Clinica();
                Cargar_label_Medico();
            }
            else if (Usuario_Actual.Tipo == "Paciente")
            {
                paciente_actual = new Paciente();
                paciente_actual = Cargar_Paciente_Clinica();
                Cargar_label_Paciente();
            }                 
        }

        private Medico Cargar_Médico_Clinica()
        {
            foreach (Medico medico in clinica.Medicos)
            {
                if (medico.Id_Usuario == Usuario_Actual.Id)
                {
                    return medico;
                }
            }
            return new Medico();
        }
        private Paciente Cargar_Paciente_Clinica()
        {
            foreach (Paciente paciente in clinica.Pacientes)
            {
                if (paciente.Id_Usuario == Usuario_Actual.Id)
                {
                    return paciente;
                }
            }
            return new Paciente();
        }
        
        //Labels del usuario
        public void Cargar_label_Paciente()
        {
            string apellido = paciente_actual.Apellido;
            string nombre = paciente_actual.Nombre;
            string mail = paciente_actual.Mail;
            string telefono = paciente_actual.Telefono;
            string direccion = paciente_actual.Direccion;
            DateTime fecha_nacimiento = paciente_actual.Fecha_Nacimiento;

            apellidoLbl.Text = "Apellido : " + apellido;
            nombrelbl.Text = "Nombre : " + nombre;
            emailLbl.Text = "Mail : " + mail;
            telefonoLbl.Text = "Telefono : " + telefono;
            direccionLbl.Text = "Dirrecion :" + direccion;
            fechaNacimientoLbl.Text = "Fecha de nacimiento : " + fecha_nacimiento;
        }
        public void Cargar_label_Medico()
        {
            string apellido = Medico_actual.Apellido;
            string nombre = Medico_actual.Nombre;
            string mail = Medico_actual.Mail;
            string telefono = Medico_actual.Telefono;
            string direccion = Medico_actual.Direccion;
            DateTime fecha_nacimiento = Medico_actual.Fecha_Nacimiento;

            apellidoLbl.Text = "Apellido : " + apellido;
            nombrelbl.Text = "Nombre : " + nombre;
            emailLbl.Text = "Mail : " + mail;
            telefonoLbl.Text = "Telefono : " + telefono;
            direccionLbl.Text = "Dirrecion :" + direccion;
            fechaNacimientoLbl.Text = "Fecha de nacimiento : " + fecha_nacimiento;
        }
     
    }
}