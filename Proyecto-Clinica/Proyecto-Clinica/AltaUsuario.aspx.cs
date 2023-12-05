using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Conexion_Clinica;
using Proyecto_Clinica.Dominio;

namespace Proyecto_Clinica
{
    public partial class AltaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public bool EsNumero(string valor)
        {
            // Intentar convertir el valor a un número
            return double.TryParse(valor, out _);
        }
    

    protected void btn_AceptarAltaUsuario_Click(object sender, EventArgs e)
        {
            

            
            bool usuarioValido = false;
            
            //Comprueba que los campos pasen las condiciones
            if (txtRegistrarUsuario != null && txtRegistrarUsuario.Text != "" && txtRegistrarContrasena.Text != "" && txtRegistrarContrasena.Text == txtRegistrarContrasena2.Text)
            {
                if (EsNumero(txtDniEdit.Text) && EsNumero(txtTelefonoEdit.Text) && DateTime.Parse(txtFechaNacimientoEdit.Text) <= DateTime.Now && DateTime.Parse(txtFechaNacimientoEdit.Text).Year >= 1900)
                {
                    usuarioValido = true;
                }
            }
            //Si las pasa, se crea un usuario nuevo y se lo ingresa en la BBDD
            if (usuarioValido)
            {
                UsuarioConexion usuarioConexion = new UsuarioConexion();

                Usuario nuevo_usuario = new Usuario
                {
                    Username = txtRegistrarUsuario.Text,
                    Contraseña = txtRegistrarContrasena.Text,
                    Tipo = "Paciente"
                };
                usuarioConexion.InsertarUsuarioEnBBDD(nuevo_usuario);

                Paciente paciente = new Paciente();
                paciente.Id_Usuario = usuarioConexion.Get_ID_Usuario(nuevo_usuario);
                paciente.Nombre = txtNombreEdit.Text;
                paciente.Dni = txtDniEdit.Text;
                paciente.Apellido = txtApellidoEdit.Text;
                paciente.Mail = txtMailEdit.Text;
                paciente.Telefono = txtTelefonoEdit.Text;
                paciente.Direccion = txtDireccionEdit.Text;
                paciente.Fecha_Nacimiento = DateTime.Parse(txtFechaNacimientoEdit.Text);

                PacienteConexion pacienteConexion = new PacienteConexion();
                pacienteConexion.InsertarPaciente(paciente);

                Response.Redirect("Default.aspx");
            }
            else
            {
                lbl_Error_Registro.Visible = true;
            }
        }
    }
}