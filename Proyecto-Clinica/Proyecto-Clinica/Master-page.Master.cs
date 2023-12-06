using Conexion_Clinica;
using Dominio;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class Master_page : System.Web.UI.MasterPage
    {
        public Usuario Usuario_Actual;
        public Clinica clinica = new Clinica();
        protected void Page_Load(object sender, EventArgs e)
        {
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            clinica = clinicaConexion.Listar();
            if (!Seguridad.SesionActiva(Session["Usuario"]))
            {
                Session.Abandon();
                Response.Redirect("Default.aspx", false);
            }
            else
            {
                Usuario_Actual = (Usuario)Session["Usuario"];

                if (Usuario_Actual.Imagen != "https://cdn-icons-png.flaticon.com/512/5987/5987424.png")
                    imgPerfil.ImageUrl = "~/img/" + Usuario_Actual.Imagen;
                else
                    imgPerfil.ImageUrl = "https://cdn-icons-png.flaticon.com/512/5987/5987424.png";
            }

            if (Usuario_Actual.Tipo == "Administrador" || Usuario_Actual.Tipo == "Recepcionista")
            {
                Btn_alta_medico.Visible = true;
                Btn_alta_paciente.Visible = true;
                Btn_alta_especialidad.Visible = true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx", false);
        }

        //-----MODAL ALTA MEDICO---
        protected void Btn_alta_medico_Click(object sender, EventArgs e)
        {
            string script = @"
                $(document).ready(function () {
                    $('#mod_AltaMedico').modal('show');
                });
            ";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
        }
        protected void Btn_AltaMedicoConfirmar_Click(object sender, EventArgs e)
        {
            bool nombreValido = true, apellidoValido = true, telefonoValido = true, emailValido = true, direccionValido = true, fechaNacimientoValido = true, dniValido = true;
            try
            {
                if (!Validaciones.EsNumero(txtDniEdit.Text))
                {
                    lblErrorDniMedico.Visible = true;
                    dniValido = false;
                }
                if (!Validaciones.EsNumero(txtTelefonoEdit.Text))
                {
                    lblErrorTelefonoMedico.Visible = true;
                    telefonoValido = false;
                }
                if (Validaciones.ContieneNumeros(txtNombreEdit.Text))
                {
                    lblErrorNombreMedico.Visible = true;
                    nombreValido = false;
                }
                if (Validaciones.ContieneNumeros(txtApellidoEdit.Text))
                {
                    lblErrorApellidoMedico.Visible = true;
                    apellidoValido = false;
                }

                if (!Validaciones.EsFormatoCorreoElectronico(txtMailEdit.Text))
                {
                    lblErrorMailMedico.Visible = true;
                    emailValido = false;
                }

                if (nombreValido && apellidoValido && telefonoValido && emailValido && direccionValido && fechaNacimientoValido && dniValido)
                {

                    Medico medico = new Medico();


                    //INSERTAR NUEVO USUARIO CON MEDICO 
                    MedicoConexion medicoConexion = new MedicoConexion();
                    UsuarioConexion usuarioConexion = new UsuarioConexion();



                    //medico.Dni = txtDniPaciente.Text;
                    medico.Dni = txtDniEdit.Text;
                    
                    Usuario nuevo_usuario = new Usuario
                    {
                        Username = medico.Dni,
                        Contraseña = medico.Dni,
                        Tipo = "Médico"
                    };


                    usuarioConexion.InsertarUsuarioEnBBDD(nuevo_usuario);

                    medico.Id_Usuario = usuarioConexion.buscarIdUsuarioPorDNI(medico.Dni);

                    medico.Nombre = txtNombreEdit.Text;
                    medico.Apellido = txtApellidoEdit.Text;
                    medico.Telefono = txtTelefonoEdit.Text;
                    medico.Direccion = txtDireccionEdit.Text;
                    medico.Fecha_Nacimiento = DateTime.Parse(txtFechaNacimientoEdit.Text);
                    medico.Mail = txtMailEdit.Text;
                    
                    


                    //MedicoConexion medicoConexion = new MedicoConexion();
                    //medicoConexion.InsertarMedicoSinUsuario(medico);

                    if (medico.Id_Usuario != 0)
                    {
                        medicoConexion.InsertarMedico(medico);


                    }
                    else
                    {
                        //lblError_CrearPaciente.Visible = true;
                        // lblCargada_Correctamente.Visible = false;
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //-----MODAL ALTA PACIENTE---
        protected void Btn_alta_paciente_Click(object sender, EventArgs e)
        {
            string script = @"
                $(document).ready(function () {
                    $('#mod_AltaPaciente').modal('show');
                });
            ";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
        }
        protected void Btn_AltaPacienteConfirmar_Click(object sender, EventArgs e)
        {
            bool nombreValido = true, apellidoValido = true, telefonoValido = true, emailValido = true, direccionValido = true, fechaNacimientoValido = true, dniValido = true;
            try
            {
                if (!Validaciones.EsNumero(txtDniPaciente.Text))
                {
                    lblErrorDni.Visible = true;
                    dniValido = false;
                }
                if (!Validaciones.EsNumero(txtTelefonoPaciente.Text))
                {
                    lblErrorTelefono.Visible = true;
                    telefonoValido = false;
                }
                if (Validaciones.ContieneNumeros(txtNombresPaciente.Text))
                {
                    lblErrorNombre.Visible = true;
                    nombreValido = false;
                }
                if (Validaciones.ContieneNumeros(txtApellidosPaciente.Text))
                {
                    lblErrorApellido.Visible = true;
                    apellidoValido = false;
                }
                if (!Validaciones.EsFormatoCorreoElectronico(txtEmailPaciente.Text))
                {
                    lblErrorMail.Visible = true;
                    emailValido = false;
                }

                if (nombreValido && apellidoValido && telefonoValido && emailValido && direccionValido && fechaNacimientoValido && dniValido)
                {

                    Paciente paciente = new Paciente();

                    //INSERTAR NUEVO USUARIO CON PACIENTE 
                    PacienteConexion pacienteConexion = new PacienteConexion();
                    UsuarioConexion usuarioConexion = new UsuarioConexion();

                    paciente.Dni = txtDniPaciente.Text;
                    Usuario nuevo_usuario = new Usuario
                    {
                        Username = paciente.Dni,
                        Contraseña = paciente.Dni,
                        Tipo = "Paciente"
                    };

                    usuarioConexion.InsertarUsuarioEnBBDD(nuevo_usuario);

                    paciente.Id_Usuario = usuarioConexion.buscarIdUsuarioPorDNI(paciente.Dni);
                    
                    paciente.Nombre = txtNombresPaciente.Text;
                    paciente.Apellido = txtApellidosPaciente.Text;
                    paciente.Telefono = txtTelefonoPaciente.Text;
                    paciente.Direccion = TxtDireccionPaciente.Text;
                    paciente.Fecha_Nacimiento = DateTime.Parse(txtFechaNacimientoPaciente.Text);
                    paciente.Mail = txtEmailPaciente.Text;

                    EmailService emailService = new EmailService();
                    emailService.cuerpoCorreo(nuevo_usuario, txtEmailPaciente.Text);

                    if (paciente.Id_Usuario != 0)
                    {
                        pacienteConexion.InsertarPaciente(paciente);
                        emailService.enviarCorreo();
                        //lblMensaje.Text = "Correo enviado correctamente.";

                    }
                    else
                    {
                        //lblError_CrearPaciente.Visible = true;
                       // lblCargada_Correctamente.Visible = false;
                    }

                }


            }
            catch (Exception)
            {

                throw;
            }



        }


        //--MODAL ALTA ESPECIALIDAD
        protected void Btn_alta_especialidad_Click(object sender, EventArgs e)
        {
            string script = @"
                $(document).ready(function () {
                    $('#ALTA_ESPECIALIDAD').modal('show');
                });
            ";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
        }
        protected void btn_Nueva_Especialidad_Click(object sender, EventArgs e)
        {
            try
            {
                String Nueva_Especialidad = txt_Nueva_Especialidad.Text;
                bool Existe = Comprobar_Especialidad(Nueva_Especialidad);

                if (Nueva_Especialidad != null && Nueva_Especialidad.Length > 5 && !Existe) // puse mayor a 5 por tirar xd
                {
                    EspecialidadesConexion especialidadesConexion = new EspecialidadesConexion();
                    especialidadesConexion.Insertar_Especialidad_En_BBDD(Nueva_Especialidad);
                    lblCargada_Correctamente.Visible = true;
                    lblError_Especialidad.Visible = false;
                    

                }
                else
                {
                    lblError_Especialidad.Visible = true;
                    lblCargada_Correctamente.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

        }
        private bool Comprobar_Especialidad(string nueva_Especialidad)
        {
            foreach (Especialidad especialidad in clinica.Especialidades)
            {
                if (especialidad.Tipo == nueva_Especialidad)
                {
                    return true;
                }
            }
            return false;
        }
    }
}