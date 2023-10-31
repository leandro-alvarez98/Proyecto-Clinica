﻿using System;
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
            if(!IsPostBack)
            {
                // Limpia la ddl
                ddlRegistrarTipo.Items.Clear();
                // Agrega los tipos de usuario
                ddlRegistrarTipo.Items.Add(new ListItem("Administrador/a", "Administrador"));
                ddlRegistrarTipo.Items.Add(new ListItem("Recepcionista", "Recepcionista"));
                ddlRegistrarTipo.Items.Add(new ListItem("Médico/a", "Médico"));
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            bool usuarioValido = false;

            //Comprueba que los campos pasen las condiciones
            if(txtRegistrarUsuario != null && txtRegistrarUsuario.Text != "" && txtRegistrarContrasena.Text != "" && txtRegistrarContrasena.Text == txtRegistrarContrasena2.Text)
            {
                usuarioValido = true;
            }
            //Si las pasa, se crea un usuario nuevo y se lo ingresa en la BBDD
            if(usuarioValido)
            {
                Usuario nuevo_usuario = new Usuario();
                nuevo_usuario.Nombre = txtRegistrarUsuario.Text;
                nuevo_usuario.Contraseña = txtRegistrarContrasena.Text;
                nuevo_usuario.Tipo = ddlRegistrarTipo.SelectedValue;
                InsertarEnBBDD(nuevo_usuario);
            }
        }

        protected void InsertarEnBBDD(Usuario usuario)
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