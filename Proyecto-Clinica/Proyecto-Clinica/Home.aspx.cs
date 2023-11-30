using Conexion_Clinica;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class Home : System.Web.UI.Page
    {
        Clinica Clinica;
        Usuario usuario_actual;
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_Componentes();
        }
        public void Cargar_Componentes()
        {
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            Clinica = clinicaConexion.Listar();
            Session["Clinica"] = Clinica;
            usuario_actual = (Usuario)Session["Usuario"];
            usuario_actual = Cargar_Datos_Usuario(usuario_actual);
            Session["Usuario"] = usuario_actual;
        }

        private Usuario Cargar_Datos_Usuario(Usuario usuario)
        {
            switch (usuario.Tipo)
            {
                case "Médico":
                    Medico Medico_actual = Cargar_Médico_Clinica(usuario.Id);
                    if (Medico_actual.Id != -1)
                    {
                        usuario.Nombre = Medico_actual.Nombre;
                        usuario.Apellido = Medico_actual.Apellido;
                        usuario.Dni = int.Parse(Medico_actual.Dni);
                        usuario.Telefono = Medico_actual.Telefono;
                        usuario.Direccion = Medico_actual.Direccion;
                        usuario.Fecha_Nacimiento = Medico_actual.Fecha_Nacimiento;
                        usuario.Mail = Medico_actual.Mail;
                    }
                    break;

                case "Paciente":
                    Paciente paciente_actual = Cargar_Paciente_Clinica(usuario.Id);
                    if (paciente_actual.Id != -1)
                    {
                        usuario.Nombre = paciente_actual.Nombre;
                        usuario.Apellido = paciente_actual.Apellido;
                        usuario.Dni = int.Parse(paciente_actual.Dni);
                        usuario.Telefono = paciente_actual.Telefono;
                        usuario.Direccion = paciente_actual.Direccion;
                        usuario.Fecha_Nacimiento = paciente_actual.Fecha_Nacimiento;
                        usuario.Mail = paciente_actual.Mail;
                    }
                    break;

                case "Administrador":
                    Administrador Administrador_actual = Cargar_Administracion_Clinica(usuario.Id);
                    if (Administrador_actual.Id != -1)
                    {
                        usuario.Nombre = Administrador_actual.Nombre;
                        usuario.Apellido = Administrador_actual.Apellido;
                        usuario.Dni = int.Parse(Administrador_actual.Dni);
                        usuario.Telefono = Administrador_actual.Telefono;
                        usuario.Direccion = Administrador_actual.Direccion;
                        usuario.Fecha_Nacimiento = Administrador_actual.Fecha_Nacimiento;
                        usuario.Mail = Administrador_actual.Mail;
                    }
                    break;

                case "Recepcionista":
                    Recepcionista Recepcionista_actual = Cargar_Recepcionista_Clinica(usuario.Id);
                    if (Recepcionista_actual.Id != -1)
                    {
                        usuario.Nombre = Recepcionista_actual.Nombre;
                        usuario.Apellido = Recepcionista_actual.Apellido;
                        usuario.Dni = int.Parse(Recepcionista_actual.Dni);
                        usuario.Telefono = Recepcionista_actual.Telefono;
                        usuario.Direccion = Recepcionista_actual.Direccion;
                        usuario.Fecha_Nacimiento = Recepcionista_actual.Fecha_Nacimiento;
                        usuario.Mail = Recepcionista_actual.Mail;
                    }
                    break;
            }
            return usuario;
        }
        private Medico Cargar_Médico_Clinica(int IDUsuario)
        {
            foreach (Medico medico in Clinica.Medicos)
            {
                if (medico.Id_Usuario == IDUsuario)
                {
                    return medico;
                }
            }
            return new Medico();
        }
        private Paciente Cargar_Paciente_Clinica(int IDUsuario)
        {
            foreach (Paciente paciente in Clinica.Pacientes)
            {
                if (paciente.Id_Usuario == IDUsuario)
                {
                    return paciente;
                }
            }
            return new Paciente();
        }
        private Administrador Cargar_Administracion_Clinica(int IDUsuario)
        {
            foreach (Administrador administrador in Clinica.Administracion)
            {
                if (administrador.Id_Usuario == IDUsuario)
                {
                    return administrador;
                }
            }
            return new Administrador();
        }
        private Recepcionista Cargar_Recepcionista_Clinica(int IDUsuario)
        {
            foreach (Recepcionista recepcionista in Clinica.Recepcionistas)
            {
                if (recepcionista.Id_Usuario == IDUsuario)
                {
                    return recepcionista;
                }
            }
            return new Recepcionista();
        }
    }
}