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
        Recepcionista Recepcionista_actual;
        Administrador Administrador_actual;
        Clinica clinica;

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

            switch (Usuario_Actual.Tipo)
            {
                case "Médico":
                    Medico_actual = new Medico();
                    Medico_actual = Cargar_Médico_Clinica();
                    Cargar_label_Medico();
                    break;

                case "Paciente":
                    paciente_actual = new Paciente();
                    paciente_actual = Cargar_Paciente_Clinica();
                    Cargar_label_Paciente();
                    break;

                case "Administrador":
                    Administrador_actual = new Administrador();
                    Administrador_actual = Cargar_Administracion_Clinica();
                    Cargar_label_Administracion();
                    break;

                case "Recepcionista":
                    Recepcionista_actual   = new Recepcionista();
                    Recepcionista_actual = Cargar_Recepcionista_Clinica();
                    Cargar_label_Recepcionista();
                    break;
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
        private Administrador Cargar_Administracion_Clinica() 
        {
            foreach (Administrador administrador in clinica.Administracion)
            {
                if (administrador.Id_Usuario == Usuario_Actual.Id) {
                    return administrador;
                }

            }
            return new Administrador();
        }

        private Recepcionista Cargar_Recepcionista_Clinica() {
            foreach (Recepcionista recepcionista in clinica.Recepcionistas)
            {
                if (recepcionista.Id_Usuario == Usuario_Actual.Id) {
                    return recepcionista;
                }

            }
            return new Recepcionista(); 
        }

        //Labels del usuario
        public void Cargar_label_Paciente()
        {
            string dni = paciente_actual.Dni;
            string apellido = paciente_actual.Apellido;
            string nombre = paciente_actual.Nombre;
            string mail = paciente_actual.Mail;
            string telefono = paciente_actual.Telefono;
            string direccion = paciente_actual.Direccion;
            DateTime fecha_nacimiento = paciente_actual.Fecha_Nacimiento;

            dniLbl.Text = dni;
            apellidoLbl.Text = apellido;
            nombrelbl.Text = nombre;
            emailLbl.Text = mail;
            telefonoLbl.Text = telefono;
            direccionLbl.Text = direccion;
            fechaNacimientoLbl.Text = fecha_nacimiento.ToString();
        }
        public void Cargar_label_Medico()
        {
            string dni = Medico_actual.Dni;
            string apellido = Medico_actual.Apellido;
            string nombre = Medico_actual.Nombre;
            string mail = Medico_actual.Mail;
            string telefono = Medico_actual.Telefono;
            string direccion = Medico_actual.Direccion;
            DateTime fecha_nacimiento = Medico_actual.Fecha_Nacimiento;

            dniLbl.Text = dni;
            apellidoLbl.Text = apellido;
            nombrelbl.Text = nombre;
            emailLbl.Text = mail;
            telefonoLbl.Text = telefono;
            direccionLbl.Text = direccion;
            fechaNacimientoLbl.Text = fecha_nacimiento.ToString();
        }
        public void Cargar_label_Recepcionista()
        {
            string dni = Recepcionista_actual.Dni;
            string apellido = Recepcionista_actual.Apellido;
            string nombre = Recepcionista_actual.Nombre;
            string mail = Recepcionista_actual.Mail;
            string telefono = Recepcionista_actual.Telefono;
            string direccion = Recepcionista_actual.Direccion;
            DateTime fecha_nacimiento = Recepcionista_actual.Fecha_Nacimiento;

            dniLbl.Text = dni;
            apellidoLbl.Text = apellido;
            nombrelbl.Text = nombre;
            emailLbl.Text = mail;
            telefonoLbl.Text = telefono;
            direccionLbl.Text = direccion;
            fechaNacimientoLbl.Text = fecha_nacimiento.ToString();
        }
        public void Cargar_label_Administracion()
        {
            string dni = Administrador_actual.Dni;
            string apellido = Administrador_actual.Apellido;
            string nombre = Administrador_actual.Nombre;
            string mail = Administrador_actual.Mail;
            string telefono = Administrador_actual.Telefono;
            string direccion = Administrador_actual.Direccion;
            DateTime fecha_nacimiento = Administrador_actual.Fecha_Nacimiento;

            dniLbl.Text = dni;
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
            txtDniEdit.Visible = true;
            txtNombreEdit.Visible = true;
            txtApellidoEdit.Visible = true;
            txtMailEdit.Visible = true;
            txtTelefonoEdit.Visible = true;
            txtDireccionEdit.Visible = true;
            txtFechaNacimientoEdit.Visible = true;

            // Oculta los Label originales
            dniLbl.Visible = false; 
            nombrelbl.Visible = false;
            apellidoLbl.Visible = false;
            emailLbl.Visible = false;
            telefonoLbl.Visible = false;
            direccionLbl.Visible = false;
            fechaNacimientoLbl.Visible = false;

            // Mostrar botón de guardar
            btnGuardar.Visible = true;

            // Llenar TextBox con datos actuales
            switch (Usuario_Actual.Tipo)
            {
                case "Médico":
                    Medico_actual = new Medico();
                    Medico_actual = Cargar_Médico_Clinica();
                    txtDniEdit.Text = Medico_actual.Dni;
                    txtNombreEdit.Text = Medico_actual.Nombre;
                    txtApellidoEdit.Text = Medico_actual.Apellido;
                    txtMailEdit.Text = Medico_actual.Mail;
                    txtTelefonoEdit.Text = Medico_actual.Telefono;
                    txtDireccionEdit.Text = Medico_actual.Direccion;
                    txtFechaNacimientoEdit.Text = Medico_actual.Fecha_Nacimiento.ToString();
                    break;

                case "Paciente":
                    paciente_actual = new Paciente();
                    paciente_actual = Cargar_Paciente_Clinica();
                    txtDniEdit.Text = paciente_actual.Dni;
                    txtNombreEdit.Text = paciente_actual.Nombre;
                    txtApellidoEdit.Text = paciente_actual.Apellido;
                    txtMailEdit.Text = paciente_actual.Mail;
                    txtTelefonoEdit.Text = paciente_actual.Telefono;
                    txtDireccionEdit.Text = paciente_actual.Direccion;
                    txtFechaNacimientoEdit.Text = paciente_actual.Fecha_Nacimiento.ToString();
                    break;

                // Puedes agregar más casos según sea necesario
                case "Administrador":
                    Administrador_actual = new Administrador();
                    Administrador_actual = Cargar_Administracion_Clinica();
                    txtDniEdit.Text = Administrador_actual.Dni;
                    txtNombreEdit.Text = Administrador_actual.Nombre;
                    txtApellidoEdit.Text = Administrador_actual.Apellido;
                    txtMailEdit.Text = Administrador_actual.Mail;
                    txtTelefonoEdit.Text = Administrador_actual.Telefono;
                    txtDireccionEdit.Text = Administrador_actual.Direccion;
                    txtFechaNacimientoEdit.Text = Administrador_actual.Fecha_Nacimiento.ToString();
                    break;


                case "Recepcionista":
                    Recepcionista_actual = new Recepcionista();
                    Recepcionista_actual = Cargar_Recepcionista_Clinica();
                    txtDniEdit.Text = Recepcionista_actual.Dni;
                    txtNombreEdit.Text = Recepcionista_actual.Nombre;
                    txtApellidoEdit.Text = Recepcionista_actual.Apellido;
                    txtMailEdit.Text = Recepcionista_actual.Mail;
                    txtTelefonoEdit.Text = Recepcionista_actual.Telefono;
                    txtDireccionEdit.Text = Recepcionista_actual.Direccion;
                    txtFechaNacimientoEdit.Text = Recepcionista_actual.Fecha_Nacimiento.ToString();
                    break;
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
                string nuevoDni = txtDniEdit.Text;
                string nuevoNombre = txtNombreEdit.Text;
                string nuevoApellido = txtApellidoEdit.Text;
                string nuevoMail = txtMailEdit.Text;
                string nuevoTelefono = txtTelefonoEdit.Text;
                string nuevaDireccion = txtDireccionEdit.Text;
                DateTime nuevaFechaNacimiento = DateTime.Parse(txtFechaNacimientoEdit.Text);

                // Actualizar los datos del paciente
                switch (Usuario_Actual?.Tipo)
                {
                    case "Paciente":
                        if (Usuario_Actual != null)
                        {
                            Paciente pacienteActualizado = new Paciente
                            {
                                Id = Usuario_Actual.Id,
                                Dni = nuevoDni,

                                Nombre = nuevoNombre,
                                Apellido = nuevoApellido,
                                Mail = nuevoMail,
                                Telefono = nuevoTelefono,
                                Direccion = nuevaDireccion,
                                Fecha_Nacimiento = nuevaFechaNacimiento
                            };

                            UsuarioConexion conexionPaciente = new UsuarioConexion();
                            conexionPaciente.ActualizarPaciente(pacienteActualizado);

                            // Recarga los datos del paciente después de la actualización
                            paciente_actual = Cargar_Paciente_Clinica();
                            Cargar_label_Paciente();
                            // Oculta el TextBox y botón de guardar
                            OcultarControlesEdicion();
                            // Redirecciona a la misma página para refrescar los datos
                            Response.Redirect(Request.RawUrl);
                        }
                        break;

                    case "Medico":
                        if (Usuario_Actual != null)
                        {
                            Medico medicoActualizado = new Medico
                            {
                                Id = Usuario_Actual.Id,
                                Dni = nuevoDni,

                                Nombre = nuevoNombre,
                                Apellido = nuevoApellido,
                                Mail = nuevoMail,
                                Telefono = nuevoTelefono,
                                Direccion = nuevaDireccion,
                                Fecha_Nacimiento = nuevaFechaNacimiento
                            };

                            UsuarioConexion conexionMedico = new UsuarioConexion();
                            conexionMedico.ActualizarMedico(medicoActualizado);

                            // Recarga los datos del médico después de la actualización
                            Medico_actual = Cargar_Médico_Clinica();
                            Cargar_label_Medico();
                            // Oculta el TextBox y botón de guardar
                            OcultarControlesEdicion();
                            // Redirecciona a la misma página para refrescar los datos
                            Response.Redirect(Request.RawUrl);
                        }
                        break;


                    case "Recepcionista":
                        if (Usuario_Actual != null)
                        {
                            Recepcionista recepcionistaActualizado = new Recepcionista
                            {
                                Id = Usuario_Actual.Id,
                                Dni = nuevoDni,
                                Nombre = nuevoNombre,
                                Apellido = nuevoApellido,
                                Mail = nuevoMail,
                                Telefono = nuevoTelefono,
                                Direccion = nuevaDireccion,
                                Fecha_Nacimiento = nuevaFechaNacimiento
                            };

                            UsuarioConexion conexionRecepcionista = new UsuarioConexion();
                            
                            conexionRecepcionista.ActualizarRecepcionista(recepcionistaActualizado);

                            // Recarga los datos del médico después de la actualización
                            Recepcionista_actual = Cargar_Recepcionista_Clinica();
                            Cargar_label_Recepcionista();
                            // Oculta el TextBox y botón de guardar
                            OcultarControlesEdicion();
                            // Redirecciona a la misma página para refrescar los datos
                            Response.Redirect(Request.RawUrl);
                        }
                        break;

                    case "Administrador":
                        if (Usuario_Actual != null)
                        {
                            Administrador administradorActualizado = new Administrador
                            {
                                Id = Usuario_Actual.Id,
                                Dni = nuevoDni,
                                Nombre = nuevoNombre,
                                Apellido = nuevoApellido,
                                Mail = nuevoMail,
                                Telefono = nuevoTelefono,
                                Direccion = nuevaDireccion,
                                Fecha_Nacimiento = nuevaFechaNacimiento
                            };

                            UsuarioConexion conexionAdministrador = new UsuarioConexion();

                            conexionAdministrador.ActualizarAdministracion(administradorActualizado);

                            // Recarga los datos del médico después de la actualización
                            Administrador_actual = Cargar_Administracion_Clinica();
                            Cargar_label_Administracion();
                            // Oculta el TextBox y botón de guardar
                            OcultarControlesEdicion();
                            // Redirecciona a la misma página para refrescar los datos
                            Response.Redirect(Request.RawUrl);
                        }
                        
                        break;
                }

            }
            catch (Exception ex)
            {

               MessageBox.Show("Error al actualizar los datos: " + ex.Message);
                throw ex;
            }
        }

    }
}