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
        public Usuario Usuario_Actual;
        Paciente paciente_actual;
        Medico Medico_actual;
        Clinica clinica;
        UsuarioConexion conexion = new UsuarioConexion();





        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_Componentes();


            if (!IsPostBack)
            {
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

            apellidoLbl.Text = apellido;
            nombrelbl.Text = nombre;
            emailLbl.Text = mail;
            telefonoLbl.Text = telefono;
            direccionLbl.Text = direccion;
            fechaNacimientoLbl.Text = fecha_nacimiento.ToString();
        }
        public void Cargar_label_Medico()
        {
            string apellido = Medico_actual.Apellido;
            string nombre = Medico_actual.Nombre;
            string mail = Medico_actual.Mail;
            string telefono = Medico_actual.Telefono;
            string direccion = Medico_actual.Direccion;
            DateTime fecha_nacimiento = Medico_actual.Fecha_Nacimiento;

            apellidoLbl.Text = apellido;
            nombrelbl.Text = nombre;
            emailLbl.Text = mail;
            telefonoLbl.Text = telefono;
            direccionLbl.Text = direccion;
            fechaNacimientoLbl.Text = fecha_nacimiento.ToString();
        }


        public void btnCancelar_Click(object sender, EventArgs e)
        {



        }
        public void btnEditar_Click(object sender, EventArgs e)
        {
            btnEditarDatos.Visible = false;
            btnCambioContraseña.Visible = false;

            //Habilitar TextBox para la edición
            txtNombreEdit.Visible = true;
            txtApellidoEdit.Visible = true;
            txtMailEdit.Visible = true;
            txtTelefonoEdit.Visible = true;
            txtDireccionEdit.Visible = true;
            txtFechaNacimientoEdit.Visible = true;

            // Oculta los Label originales
            nombrelbl.Visible = false;
            apellidoLbl.Visible = false;
            emailLbl.Visible = false;
            telefonoLbl.Visible = false;
            direccionLbl.Visible = false;
            fechaNacimientoLbl.Visible = false;

            // Mostrar botón de guardar
            btnGuardar.Visible = true;

            // Llenar TextBox con datos actuales

            if (Usuario_Actual.Tipo == "Médico")
            {
                Medico_actual = new Medico();
                Medico_actual = Cargar_Médico_Clinica();
                txtNombreEdit.Text = Medico_actual.Nombre;
                txtApellidoEdit.Text = Medico_actual.Apellido;
                txtMailEdit.Text = Medico_actual.Mail;
                txtTelefonoEdit.Text = Medico_actual.Telefono;
                txtDireccionEdit.Text = Medico_actual.Direccion;
                txtFechaNacimientoEdit.Text = Medico_actual.Fecha_Nacimiento.ToString();

            }
            else if (Usuario_Actual.Tipo == "Paciente")
            {
                paciente_actual = new Paciente();
                paciente_actual = Cargar_Paciente_Clinica();
                txtNombreEdit.Text = paciente_actual.Nombre;
                txtApellidoEdit.Text = paciente_actual.Apellido;
                txtMailEdit.Text = paciente_actual.Mail;
                txtTelefonoEdit.Text = paciente_actual.Telefono;
                txtDireccionEdit.Text = paciente_actual.Direccion;
                txtFechaNacimientoEdit.Text = paciente_actual.Fecha_Nacimiento.ToString();
            }
        }




        public void ocultarTxtEditables()
        {
            //esto para ocultar directamente los txtEdit
            txtNombreEdit.Visible = false;
            txtApellidoEdit.Visible = false;
            txtMailEdit.Visible = false;
            txtTelefonoEdit.Visible = false;
            txtDireccionEdit.Visible = false;
            txtFechaNacimientoEdit.Visible = false;
            btnGuardar.Visible = false;

        }

        private void OcultarControlesEdicion()
        {
            //ocultar TextBox y boton de guardar
            txtNombreEdit.Visible = false;
            txtApellidoEdit.Visible = false;
            txtMailEdit.Visible = false;
            txtTelefonoEdit.Visible = false;
            txtDireccionEdit.Visible = false;
            txtFechaNacimientoEdit.Visible = false;

            // mostrar los Label originales
            //nombrelbl.Visible = true;
            //apellidoLbl.Visible = true;
            //emailLbl.Visible = true;
            //telefonoLbl.Visible = true;
            //direccionLbl.Visible = true;
            //fechaNacimientoLbl.Visible = true;

            //Ocultar botón de guardar
            btnGuardar.Visible = false;
            btnEditarDatos.Visible = true;
            btnCambioContraseña.Visible = true;
        }
        public void btnGuardar_Click(object sender, EventArgs e)
        {
            

            try
            {
                // guardamos los valores editados de los TextBox
                string nuevoNombre = txtNombreEdit.Text;
                string nuevoApellido = txtApellidoEdit.Text;
                string nuevoMail = txtMailEdit.Text;
                string nuevoTelefono = txtTelefonoEdit.Text;
                string nuevaDireccion = txtDireccionEdit.Text;
                DateTime nuevaFechaNacimiento = DateTime.Parse(txtFechaNacimientoEdit.Text);

                // Actualizar los datos del paciente
                if (Usuario_Actual != null && Usuario_Actual.Tipo == "Paciente")
                {
                    Paciente pacienteActualizado = new Paciente
                    {
                        Id = Usuario_Actual.Id,
                        Nombre = nuevoNombre,
                        Apellido = nuevoApellido,
                        Mail = nuevoMail,
                        Telefono = nuevoTelefono,
                        Direccion = nuevaDireccion,
                        Fecha_Nacimiento = nuevaFechaNacimiento
                    };

                    UsuarioConexion conexion = new UsuarioConexion();
                    conexion.ActualizarPaciente(pacienteActualizado);

                    //recarga los datos del paciente despues de la actualizacion
                    paciente_actual = Cargar_Paciente_Clinica();
                    Cargar_label_Paciente();
                    // oculta el TextBox y boton de guardar
                    OcultarControlesEdicion();
                    // redirecciona a la misma pagina para refrescar los datoss
                    Response.Redirect(Request.RawUrl);

                }
                //actualiza los datos del medico
                else if (Usuario_Actual != null && Usuario_Actual.Tipo == "Médico")
                {
                    Medico medicoActualizado = new Medico
                    {
                        Id = Usuario_Actual.Id,
                        Nombre = nuevoNombre,
                        Apellido = nuevoApellido,
                        Mail = nuevoMail,
                        Telefono = nuevoTelefono,
                        Direccion = nuevaDireccion,
                        Fecha_Nacimiento = nuevaFechaNacimiento
                    };

                    UsuarioConexion conexion = new UsuarioConexion();
                    conexion.ActualizarMedico(medicoActualizado);

                    // Recargar los datos del médico despues de la actualización
                    Medico_actual = Cargar_Médico_Clinica();
                    Cargar_label_Medico();

                    // oculta el TextBox y boton de guardar
                    OcultarControlesEdicion();
                    // redirecciona a la misma pagina para refrescar los datoss
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al actualizar los datos: " + ex.Message);

            }



        }

    }
}