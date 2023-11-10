﻿using Conexion_Clinica;
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

            apellidoLbl.Text =  apellido;
            nombrelbl.Text =  nombre;
            emailLbl.Text =  mail;
            telefonoLbl.Text =  telefono;
            direccionLbl.Text =  direccion;
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
            nombrelbl.Text =   nombre;
            emailLbl.Text =   mail;
            telefonoLbl.Text =  telefono;
            direccionLbl.Text =  direccion;
            fechaNacimientoLbl.Text = fecha_nacimiento.ToString();
        }
        //-----------------------------------------------------------------
        //------ ME QUEDE PENSANDO EN RE ESTRUCTURAR ESTA LOGICA PARA TRABAJAR CON EL ID DEL USUARIO LOGEADO Y EN BASE A ESO EVALUAR SI ES MEDICO, PACIENTE, ETC, 
        //------ A LAS CATEGORIAS LAS RELACIONAMOS CON EL ID DE USUARIO CORRESPONDIENTE
        //-----------------------------------------------------------------


        public void btnCancelar_Click(object sender, EventArgs e)
        { 
                


        }
        public void btnEditar_Click(object sender, EventArgs e) 
        {
            btnEditarDatos.Visible= false;
            btnCambioContraseña.Visible= false;

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
                txtNombreEdit.Text =  Medico_actual.Nombre;
                txtApellidoEdit.Text =  Medico_actual.Apellido;
                txtMailEdit.Text = Medico_actual.Mail;
                txtTelefonoEdit.Text=   Medico_actual.Telefono;
                txtDireccionEdit.Text=  Medico_actual.Direccion;
                txtFechaNacimientoEdit.Text = Medico_actual.Fecha_Nacimiento.ToString();
                
            }
            else if (Usuario_Actual.Tipo == "Paciente")
            {
                paciente_actual = new Paciente();
                paciente_actual = Cargar_Paciente_Clinica();
                txtNombreEdit.Text =  paciente_actual.Nombre;
                txtApellidoEdit.Text =  paciente_actual.Apellido;
                txtMailEdit.Text =  paciente_actual.Mail;
                txtTelefonoEdit.Text =  paciente_actual.Telefono;
                txtDireccionEdit.Text =  paciente_actual.Direccion;
                txtFechaNacimientoEdit.Text = paciente_actual.Fecha_Nacimiento.ToString();
            }            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener los valores editados de los TextBox
            string nuevoNombre = txtNombreEdit.Text;
            string nuevoApellido = txtApellidoEdit.Text;
            string nuevoMail = txtMailEdit.Text;
            string nuevoTelefono = txtTelefonoEdit.Text;
            string nuevaDireccion = txtDireccionEdit.Text;
            DateTime nuevaFechaNacimiento = DateTime.Parse(txtFechaNacimientoEdit.Text);

            // Actualizar los datos del usuario
            if (Usuario_Actual.Tipo == "Paciente")
            {
                paciente_actual = new Paciente();
                
                paciente_actual.Nombre = nuevoNombre;
                paciente_actual.Apellido = nuevoApellido;
                paciente_actual.Mail = nuevoMail;
                paciente_actual.Telefono = nuevoTelefono;
                paciente_actual.Direccion = nuevaDireccion;
                paciente_actual.Fecha_Nacimiento = nuevaFechaNacimiento;
            }
            else if (Usuario_Actual.Tipo == "Médico")
            {
                Medico_actual = new Medico();
                
                Medico_actual.Nombre = nuevoNombre;
                Medico_actual.Apellido = nuevoApellido;
                Medico_actual.Mail = nuevoMail;
                Medico_actual.Telefono = nuevoTelefono;
                Medico_actual.Direccion = nuevaDireccion;
                Medico_actual.Fecha_Nacimiento = nuevaFechaNacimiento;
            }



            // Ocultar TextBox y botón de guardar
            txtNombreEdit.Visible = false;
            txtApellidoEdit.Visible = false;
            txtMailEdit.Visible = false;
            txtTelefonoEdit.Visible = false;
            txtDireccionEdit.Visible = false;
            txtFechaNacimientoEdit.Visible = false;
            btnGuardar.Visible = false;

            // Volver a cargar los Label con los datos actualizados
            Cargar_label_Paciente();
            Cargar_label_Medico();
        }

    }
}