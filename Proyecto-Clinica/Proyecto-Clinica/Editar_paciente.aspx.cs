using Conexion_Clinica;
using Dominio;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class Editar_paciente : System.Web.UI.Page
    {
        public Paciente Paciente_actual;
        public Clinica Clinica;
       
        protected void Page_Load(object sender, EventArgs e)
        {
              ClinicaConexion clinicaConexion = new ClinicaConexion();
            Clinica = clinicaConexion.Listar();

            int Id_Paciente_Seleccionado = ((Paciente)Session["Paciente"]).Id;
            Paciente_actual = Cargar_Paciente_Clinica(Id_Paciente_Seleccionado);

            if (!IsPostBack)
            {
              
                if (Paciente_actual != null)
                {
                    Cargar_Datos_Usuario();
                    
                }
            }

        }
        
        private void Cargar_Datos_Usuario()
        {
            if (Paciente_actual != null)
            {
                nombrelbl.Text = Paciente_actual.Nombre;
                apellidoLbl.Text = Paciente_actual.Apellido;
                dniLbl.Text = Paciente_actual.Dni.ToString();
                emailLbl.Text = Paciente_actual.Mail;
                telefonoLbl.Text = Paciente_actual.Telefono;
                direccionLbl.Text = Paciente_actual.Direccion;
                fechaNacimientoLbl.Text = Paciente_actual.Fecha_Nacimiento.ToString("yyyy-MM-dd");
            }
        }


        private Paciente Cargar_Paciente_Clinica(int paciente_id)
        {
            foreach (Paciente paciente in Clinica.Pacientes)
            {
                if (paciente.Id == paciente_id)
                {
                    return paciente;
                }
            }
            return new Paciente();
        }
        public void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Paciente_actual.Nombre == null)
            {
                InsertarDatosEnBBDD();
            }
            else
            {
                ActualizarDatosEnBBDD();
            }
        }
        public void btnEditar_Click(object sender, EventArgs e)
        {
            ////oculta botones de defecto
            //btnEditarDatos.Visible = false;

            ////Habilitar TextBox para la edición
            //Visibilidad_Texbox(true);

            //// Oculta los Label originales
            //Visibilidad_labels(false);

            //// Mostrar botón de guardar
            //btnGuardar.Visible = true;
            //btnCancelar.Visible = true;

            //txtDniEdit.Text = Paciente_actual.Dni.ToString();
            //txtNombreEdit.Text = Paciente_actual.Nombre;
            //txtApellidoEdit.Text = Paciente_actual.Apellido;
            //txtMailEdit.Text = Paciente_actual.Mail;
            //txtTelefonoEdit.Text = Paciente_actual.Telefono;
            //txtDireccionEdit.Text = Paciente_actual.Direccion;
            //txtFechaNacimientoEdit.Text = Paciente_actual.Fecha_Nacimiento.ToString("d/M/yyyy");
            // Activa la edición de los controles necesarios
            txtNombreEdit.Visible = true;
            txtApellidoEdit.Visible = true;
            txtDniEdit.Visible = true;
            txtMailEdit.Visible = true;
            txtTelefonoEdit.Visible = true;
            txtDireccionEdit.Visible = true;
            txtFechaNacimientoEdit.Visible = true;

            // Asigna los valores actuales a los controles de edición
            txtNombreEdit.Text = Paciente_actual.Nombre;
            txtApellidoEdit.Text = Paciente_actual.Apellido;
            txtDniEdit.Text = Paciente_actual.Dni;
            txtMailEdit.Text = Paciente_actual.Mail;
            txtTelefonoEdit.Text = Paciente_actual.Telefono;
            txtDireccionEdit.Text = Paciente_actual.Direccion;
            txtFechaNacimientoEdit.Text = Paciente_actual.Fecha_Nacimiento.ToString("yyyy-MM-dd");

            // Oculta los controles de visualización
            nombrelbl.Visible = false;
            apellidoLbl.Visible = false;
            dniLbl.Visible = false;
            emailLbl.Visible = false;
            telefonoLbl.Visible = false;
            direccionLbl.Visible = false;
            fechaNacimientoLbl.Visible = false;

            // Muestra los botones de Guardar y Cancelar
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;

            // Oculta el botón de Editar
            btnEditarDatos.Visible = false;
        }
        public void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancelar.Visible = false;
            OcultarControlesEdicion();
            Visibilidad_labels(true);
            Cargar_labels();
        }
        public void Cargar_labels()
        {
            dniLbl.Text = Paciente_actual.Dni.ToString();
            apellidoLbl.Text = Paciente_actual.Apellido;
            nombrelbl.Text = Paciente_actual.Nombre;
            emailLbl.Text = Paciente_actual.Mail;
            telefonoLbl.Text = Paciente_actual.Telefono;
            direccionLbl.Text = Paciente_actual.Direccion;
            fechaNacimientoLbl.Text = Paciente_actual.Fecha_Nacimiento.ToString("d/M/yyyy");
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
            Visibilidad_Texbox(false);

            //Ocultar botón de guardar
            btnGuardar.Visible = false;
            btnEditarDatos.Visible = true;
        }
        private void ActualizarDatosEnBBDD()
        {

            // guardamos los valores editados de los TextBox
            string nuevoNombre = txtNombreEdit.Text;
            string nuevoApellido = txtApellidoEdit.Text;
            string nuevoDni = txtDniEdit.Text;
            string nuevoMail = txtMailEdit.Text;
            string nuevoTelefono = txtTelefonoEdit.Text;
            string nuevaDireccion = txtDireccionEdit.Text;
            DateTime nuevaFechaNacimiento = DateTime.Parse(txtFechaNacimientoEdit.Text);


            // Actualizar los datos del paciente

            if (Paciente_actual != null)
            {
                Paciente pacienteActualizado = new Paciente
                {
                    Id_Usuario = Paciente_actual.Id,
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

                // Oculta el TextBox y botón de guardar
                OcultarControlesEdicion();
                // Redirecciona a la misma página para refrescar los datos
                Response.Redirect(Request.RawUrl);
            }

        }
        public void Visibilidad_labels(bool valor)
        {
            dniLbl.Visible = valor;
            nombrelbl.Visible = valor;
            apellidoLbl.Visible = valor;
            emailLbl.Visible = valor;
            telefonoLbl.Visible = valor;
            direccionLbl.Visible = valor;
            fechaNacimientoLbl.Visible = valor;
        }
        public void Visibilidad_Texbox(bool valor)
        {
            txtDniEdit.Visible = valor;
            txtNombreEdit.Visible = valor;
            txtApellidoEdit.Visible = valor;
            txtMailEdit.Visible = valor;
            txtTelefonoEdit.Visible = valor;
            txtDireccionEdit.Visible = valor;
            txtFechaNacimientoEdit.Visible = valor;
        }
        private void InsertarDatosEnBBDD()
        {
            string nuevoDni = txtDniEdit.Text;
            string nuevoNombre = txtNombreEdit.Text;
            string nuevoApellido = txtApellidoEdit.Text;
            string nuevoMail = txtMailEdit.Text;
            string nuevoTelefono = txtTelefonoEdit.Text;
            string nuevaDireccion = txtDireccionEdit.Text;
            DateTime nuevaFechaNacimiento = DateTime.Parse(txtFechaNacimientoEdit.Text);

            UsuarioConexion usuarioConexion = new UsuarioConexion();
            Paciente_actual.Dni = nuevoDni;
            Paciente_actual.Nombre = nuevoNombre;
            Paciente_actual.Apellido = nuevoApellido;
            Paciente_actual.Mail = nuevoMail;
            Paciente_actual.Direccion = nuevaDireccion;
            Paciente_actual.Fecha_Nacimiento = nuevaFechaNacimiento;
            usuarioConexion.ActualizarPaciente(Paciente_actual);
        }
    }
}