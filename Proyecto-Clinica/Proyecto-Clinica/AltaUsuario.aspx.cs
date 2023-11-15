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
            if (!IsPostBack)
            {
                // Limpia la ddl
                ddlRegistrarTipo.Items.Clear();
                // Agrega los tipos de usuario
                ddlRegistrarTipo.Items.Add(new ListItem("Administrador/a", "Administrador"));
                ddlRegistrarTipo.Items.Add(new ListItem("Recepcionista", "Recepcionista"));
                ddlRegistrarTipo.Items.Add(new ListItem("Médico/a", "Médico"));
                ddlRegistrarTipo.Items.Add(new ListItem("Paciente", "Paciente"));
            }
        }
        protected void btn_AceptarAltaUsuario_Click(object sender, EventArgs e)
        {
            bool usuarioValido = false;

            //Comprueba que los campos pasen las condiciones
            if (txtRegistrarUsuario != null && txtRegistrarUsuario.Text != "" && txtRegistrarContrasena.Text != "" && txtRegistrarContrasena.Text == txtRegistrarContrasena2.Text)
            {
                usuarioValido = true;
            }
            //Si las pasa, se crea un usuario nuevo y se lo ingresa en la BBDD
            if (usuarioValido)
            {
                Usuario nuevo_usuario = new Usuario
                {
                    Nombre = txtRegistrarUsuario.Text,
                    Contraseña = txtRegistrarContrasena.Text,
                    Tipo = ddlRegistrarTipo.SelectedValue
                };
                InsertarUsuarioEnBBDD(nuevo_usuario);
                InsertarInformacionEnBBDD(nuevo_usuario);

                Session["Usuario"] = nuevo_usuario;
                Response.Redirect("AltaUsuario.aspx");
            }
        }

        private void InsertarInformacionEnBBDD(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                switch (usuario.Tipo)
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
                datos.setParametro("@IDUSUARIO", usuario.Id);
                datos.setParametro("@DNI", usuario.Dni);
                datos.setParametro("@NOMBRE", usuario.Nombre);
                datos.setParametro("@APELLIDO", usuario.Apellido);
                datos.setParametro("@TELEFONO", usuario.Telefono);
                datos.setParametro("@DIRECCION", usuario.Direccion);
                datos.setParametro("@FECHANACIMIENTO", usuario.Fecha_Nacimiento);
                datos.setParametro("@MAIL", usuario.Mail);

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

        protected void InsertarUsuarioEnBBDD(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO USUARIOS (NOMBRE_USUARIO, CONTRASENA, TIPO) VALUES(@Nombre, @Contrasena, @Tipo)");
                datos.setParametro("@Nombre", usuario.Nombre);
                datos.setParametro("@Contrasena", usuario.Contraseña);
                datos.setParametro("@Tipo", usuario.Tipo);
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
    }
}