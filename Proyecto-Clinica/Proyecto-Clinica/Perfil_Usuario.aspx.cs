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
using Dominio;

namespace Proyecto_Clinica
{
    public partial class Perfil_Usuario : System.Web.UI.Page
    {
        Clinica clinica;
        public Usuario Usuario_Actual;
        Paciente paciente_actual;
        Medico Medico_actual;
        Recepcionista Recepcionista_actual;
        Administrador Administrador_actual;

        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_Componentes();
        }
        private void Cargar_Componentes()
        {
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            clinica = clinicaConexion.Listar();
            Usuario_Actual = (Usuario)Session["Usuario"];
            Cargar_Datos_Usuario();
            Cargar_labels();

            if (Usuario_Actual.Imagen != "NoImagen")
                imgPerfil.ImageUrl = "~/img/" + Usuario_Actual.Imagen;
            else
                imgPerfil.ImageUrl = "https://cdn-icons-png.flaticon.com/512/5987/5987424.png";
        }
        private void Cargar_Datos_Usuario()
        {
            switch (Usuario_Actual.Tipo)
            {
                case "Médico":
                    Medico_actual = new Medico();
                    Medico_actual = Cargar_Médico_Clinica();
                    if(Medico_actual.Id != -1)
                    {
                        Usuario_Actual.Nombre = Medico_actual.Nombre;
                        Usuario_Actual.Apellido = Medico_actual.Apellido;
                        Usuario_Actual.Dni = int.Parse(Medico_actual.Dni);
                        Usuario_Actual.Telefono = Medico_actual.Telefono;
                        Usuario_Actual.Direccion= Medico_actual.Direccion;
                        Usuario_Actual.Fecha_Nacimiento = Medico_actual.Fecha_Nacimiento;
                        Usuario_Actual.Mail = Medico_actual.Mail;
                    }
                    break;

                case "Paciente":
                    paciente_actual = new Paciente();
                    paciente_actual = Cargar_Paciente_Clinica();
                    if(paciente_actual.Id != -1)
                    {
                        Usuario_Actual.Nombre = paciente_actual.Nombre;
                        Usuario_Actual.Apellido = paciente_actual.Apellido;
                        Usuario_Actual.Dni = int.Parse(paciente_actual.Dni);
                        Usuario_Actual.Telefono = paciente_actual.Telefono;
                        Usuario_Actual.Direccion = paciente_actual.Direccion;
                        Usuario_Actual.Fecha_Nacimiento = paciente_actual.Fecha_Nacimiento;
                        Usuario_Actual.Mail = paciente_actual.Mail;
                    }
                    break;

                case "Administrador":
                    Administrador_actual = new Administrador();
                    Administrador_actual = Cargar_Administracion_Clinica();
                    if(Administrador_actual.Id != -1)
                    {
                        Usuario_Actual.Nombre = Administrador_actual.Nombre;
                        Usuario_Actual.Apellido = Administrador_actual.Apellido;
                        Usuario_Actual.Dni = int.Parse(Administrador_actual.Dni);
                        Usuario_Actual.Telefono = Administrador_actual.Telefono;
                        Usuario_Actual.Direccion = Administrador_actual.Direccion;
                        Usuario_Actual.Fecha_Nacimiento = Administrador_actual.Fecha_Nacimiento;
                        Usuario_Actual.Mail = Administrador_actual.Mail;
                    }    
                    break;

                case "Recepcionista":
                    Recepcionista_actual = new Recepcionista();
                    Recepcionista_actual = Cargar_Recepcionista_Clinica();
                    if(Recepcionista_actual.Id != -1)
                    {
                        Usuario_Actual.Nombre = Recepcionista_actual.Nombre;
                        Usuario_Actual.Apellido = Recepcionista_actual.Apellido;
                        Usuario_Actual.Dni = int.Parse(Recepcionista_actual.Dni);
                        Usuario_Actual.Telefono = Recepcionista_actual.Telefono;
                        Usuario_Actual.Direccion = Recepcionista_actual.Direccion;
                        Usuario_Actual.Fecha_Nacimiento = Recepcionista_actual.Fecha_Nacimiento;
                        Usuario_Actual.Mail = Recepcionista_actual.Mail;
                    }
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
        public void Cargar_labels()
        {
            dniLbl.Text = Usuario_Actual.Dni.ToString();
            apellidoLbl.Text = Usuario_Actual.Apellido;
            nombrelbl.Text = Usuario_Actual.Nombre;
            emailLbl.Text = Usuario_Actual.Mail;
            telefonoLbl.Text = Usuario_Actual.Telefono;
            direccionLbl.Text = Usuario_Actual.Direccion;
            fechaNacimientoLbl.Text = Usuario_Actual.Fecha_Nacimiento.ToString("d/M/yyyy");
        }
        public void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancelar.Visible = false;
            OcultarControlesEdicion();
            Visibilidad_labels(true);
            Cargar_labels();
        }
        public void btnEditar_Click(object sender, EventArgs e)
        {
            //oculta botones de defecto
            btnEditarDatos.Visible = false;
            btnCambioContraseña.Visible = false;

            //Habilitar TextBox para la edición
            Visibilidad_Texbox(true);

            // Oculta los Label originales
            Visibilidad_labels(false);

            // Mostrar botón de guardar
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;

            txtDniEdit.Text = Usuario_Actual.Dni.ToString();
            txtNombreEdit.Text = Usuario_Actual.Nombre;
            txtApellidoEdit.Text = Usuario_Actual.Apellido;
            txtMailEdit.Text = Usuario_Actual.Mail;
            txtTelefonoEdit.Text = Usuario_Actual.Telefono;
            txtDireccionEdit.Text = Usuario_Actual.Direccion;
            txtFechaNacimientoEdit.Text = Usuario_Actual.Fecha_Nacimiento.ToString("d/M/yyyy");
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
            btnCambioContraseña.Visible = true;
        }
        public void btnGuardar_Click(object sender, EventArgs e)
        {
            if(Usuario_Actual.Nombre == null)
            {
                InsertarDatosEnBBDD();
            }
            else
            {
                ActualizarDatosEnBBDD();
            }
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

            AccesoDatos datos = new AccesoDatos();
            try
            {
                switch (Usuario_Actual.Tipo)
                {
                    case "Paciente":
                        datos.setConsulta("INSERT INTO PACIENTES (ID_USUARIO, DNI, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO) VALUES (@IDUSUARIO, @NOMBRE, @APELLIDO, @TELEFONO, @DIRECCION, @FECHANACIMIENTO, @MAIL, 1)");
                        break;
                    case "Médico":
                        datos.setConsulta("INSERT INTO MEDICOS (ID_USUARIO, DNI, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO) VALUES (@IDUSUARIO, @NOMBRE, @APELLIDO, @TELEFONO, @DIRECCION, @FECHANACIMIENTO, @MAIL, 1)");
                        break;
                    case "Administrador":
                        datos.setConsulta("INSERT INTO ADMINISTRADOR (ID_USUARIO, DNI, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO) VALUES (@IDUSUARIO, @NOMBRE, @APELLIDO, @TELEFONO, @DIRECCION, @FECHANACIMIENTO, @MAIL, 1");
                        break;
                    case "Recepcionista":
                        datos.setConsulta("INSERT INTO RECEPCIONISTA (ID_USUARIO, DNI, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO) VALUES (@IDUSUARIO, @NOMBRE, @APELLIDO, @TELEFONO, @DIRECCION, @FECHANACIMIENTO, @MAIL, 1)");
                        break;
                }
                datos.setParametro("@DNI", nuevoDni);
                datos.setParametro("@NOMBRE", nuevoNombre);
                datos.setParametro("@APELLIDO", nuevoApellido);
                datos.setParametro("@MAIL", nuevoMail);
                datos.setParametro("@TELEFONO", nuevoTelefono);
                datos.setParametro("@DIRECCION", nuevaDireccion);
                datos.setParametro("@FECHANACIMIENTO", nuevaFechaNacimiento);
                datos.setParametro("@IDUSUARIO", Usuario_Actual.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        private void ActualizarDatosEnBBDD()
        {
            try
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
                switch (Usuario_Actual?.Tipo)
                {
                    case "Paciente":
                        if (Usuario_Actual != null)
                        {
                            Paciente pacienteActualizado = new Paciente
                            {
                                Id_Usuario = Usuario_Actual.Id,
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
                        break;

                    case "Medico":
                        if (Usuario_Actual != null)
                        {
                            Medico medicoActualizado = new Medico
                            {
                                Id_Usuario = Usuario_Actual.Id,
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
                                Id_Usuario = Usuario_Actual.Id,
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
                                Id_Usuario = Usuario_Actual.Id,
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
        protected void btn_CambiarImagen_Click(object sender, EventArgs e)
        {
            if(!Imagen_Cambiada())
            {
                lbl_Error_Imagen.Visible = true;
            }
        }
        private bool Imagen_Cambiada()
        {
            try
            {
                //Escritura de imagen
                string ruta = Server.MapPath("./img/");

                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + Usuario_Actual.Id + ".jpg");

                Usuario_Actual.Imagen = "perfil-" + Usuario_Actual.Id + ".jpg";

                UsuarioConexion usuarioConexion = new UsuarioConexion();
                usuarioConexion.actualizarImagen(Usuario_Actual);

                //Lectura de imagen
                Image img = (Image)Master.FindControl("imgPerfil");
                img.ImageUrl = "~/img/" + Usuario_Actual.Imagen;
                imgPerfil.ImageUrl = "~/img/" + Usuario_Actual.Imagen;

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
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
    }
}