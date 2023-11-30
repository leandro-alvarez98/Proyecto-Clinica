using Conexion_Clinica;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Clinica
{
    public partial class Usuarios : System.Web.UI.Page
    {
        Clinica Clinica;
        Usuario usuario_actual;
        Usuario usuario_Seleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            Clinica = clinicaConexion.Listar();
            usuario_actual = (Usuario)Session["Usuario"];
            Cargar_Datos_Usuario();

            repeaterUsuarios.DataSource = Clinica.Usuarios;
            repeaterUsuarios.DataBind();
        }
        private void Cargar_Datos_Usuario()
        {
            switch (usuario_actual.Tipo)
            {
                case "Médico":
                    Medico Medico_actual = Cargar_Médico_Clinica(usuario_actual.Id);
                    if (Medico_actual.Id != -1)
                    {
                        usuario_actual.Nombre = Medico_actual.Nombre;
                        usuario_actual.Apellido = Medico_actual.Apellido;
                        usuario_actual.Dni = int.Parse(Medico_actual.Dni);
                        usuario_actual.Telefono = Medico_actual.Telefono;
                        usuario_actual.Direccion = Medico_actual.Direccion;
                        usuario_actual.Fecha_Nacimiento = Medico_actual.Fecha_Nacimiento;
                        usuario_actual.Mail = Medico_actual.Mail;
                    }
                    break;

                case "Paciente":
                    Paciente paciente_actual = Cargar_Paciente_Clinica(usuario_actual.Id);
                    if (paciente_actual.Id != -1)
                    {
                        usuario_actual.Nombre = paciente_actual.Nombre;
                        usuario_actual.Apellido = paciente_actual.Apellido;
                        usuario_actual.Dni = int.Parse(paciente_actual.Dni);
                        usuario_actual.Telefono = paciente_actual.Telefono;
                        usuario_actual.Direccion = paciente_actual.Direccion;
                        usuario_actual.Fecha_Nacimiento = paciente_actual.Fecha_Nacimiento;
                        usuario_actual.Mail = paciente_actual.Mail;
                    }
                    break;

                case "Administrador":
                    Administrador Administrador_actual = Cargar_Administracion_Clinica(usuario_actual.Id);
                    if (Administrador_actual.Id != -1)
                    {
                        usuario_actual.Nombre = Administrador_actual.Nombre;
                        usuario_actual.Apellido = Administrador_actual.Apellido;
                        usuario_actual.Dni = int.Parse(Administrador_actual.Dni);
                        usuario_actual.Telefono = Administrador_actual.Telefono;
                        usuario_actual.Direccion = Administrador_actual.Direccion;
                        usuario_actual.Fecha_Nacimiento = Administrador_actual.Fecha_Nacimiento;
                        usuario_actual.Mail = Administrador_actual.Mail;
                    }
                    break;

                case "Recepcionista":
                    Recepcionista Recepcionista_actual = Cargar_Recepcionista_Clinica(usuario_actual.Id);
                    if (Recepcionista_actual.Id != -1)
                    {
                        usuario_actual.Nombre = Recepcionista_actual.Nombre;
                        usuario_actual.Apellido = Recepcionista_actual.Apellido;
                        usuario_actual.Dni = int.Parse(Recepcionista_actual.Dni);
                        usuario_actual.Telefono = Recepcionista_actual.Telefono;
                        usuario_actual.Direccion = Recepcionista_actual.Direccion;
                        usuario_actual.Fecha_Nacimiento = Recepcionista_actual.Fecha_Nacimiento;
                        usuario_actual.Mail = Recepcionista_actual.Mail;
                    }
                    break;
            }
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
        protected void btn_ActualizarTipo_Click(object sender, EventArgs e)
        {
            string opcionSeleccionada = rblTipos.SelectedValue;

            if (usuario_Seleccionado.Tipo == "Médico" || usuario_Seleccionado.Tipo == "Paciente")
                Baja_Logica_Turnos(usuario_Seleccionado);

            if(usuario_Seleccionado.Tipo == "Médico")
            {
                Medico medico = Cargar_Médico_Clinica(usuario_Seleccionado.Id);

                EspecialidadesConexion especialidadesConexion = new EspecialidadesConexion();
                especialidadesConexion.EliminarEspecialidadxMedico(medico.Id);
            }

            UsuarioConexion usuarioConexion = new UsuarioConexion();

            usuarioConexion.EliminarDatos(usuario_Seleccionado);

            usuarioConexion.Actualizar_Usuario(usuario_Seleccionado);

            switch (opcionSeleccionada)
            {
                case "Administrador":
                    AdministradorConexion administradorConexion = new AdministradorConexion();
                    administradorConexion.InsertarAdministrador(usuario_Seleccionado);

                    break;
                case "Recepcionista":
                    RecepcionistaConexion recepcionistaConexion = new RecepcionistaConexion();
                    recepcionistaConexion.InsertarRecepcionista(usuario_Seleccionado);
                    break;
                case "Médico":
                    MedicoConexion medicoConexion = new MedicoConexion();
                    medicoConexion.InsertarMedico(usuario_Seleccionado);

                    break;
                case "Paciente":
                    PacienteConexion pacienteConexion = new PacienteConexion();
                    pacienteConexion.InsertarPaciente(usuario_Seleccionado);

                    break;
            }
        }

        private void Baja_Logica_Turnos(Usuario usuario_Seleccionado)
        {
            TurnoConexion turnoConexion = new TurnoConexion();

            Paciente paciente = Cargar_Paciente_Clinica(usuario_Seleccionado.Id);
            Medico medico = Cargar_Médico_Clinica(usuario_Seleccionado.Id);

            switch(usuario_actual.Tipo)
            {
                case "Médico":
                    foreach (Turno turno in Clinica.Turnos)
                    {
                        if (turno.Id_Medico == medico.Id)
                        {
                            turnoConexion.Cancelar_Turno(turno.Id);
                        }
                    }
                break;

                case "Paciente":
                    foreach (Turno turno in Clinica.Turnos)
                    {
                        if (turno.Id_Medico ==  paciente.Id)
                        {
                            turnoConexion.Cancelar_Turno(turno.Id);
                        }
                    }
                break;
            }
        }

        protected void btn_SeleccionarUsuario_Click(object sender, EventArgs e)
        {
                Button btn = (Button)sender;
                int idUsuarioSeleccionado = int.Parse(btn.CommandArgument);

                usuario_Seleccionado = GetUsuario(idUsuarioSeleccionado);

            string script = @"
        $(document).ready(function () {
            $('#mod_ElegirTipo').modal('show');
        });
    ";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
        }
        private Usuario GetUsuario(int id)
        {
            foreach(Usuario usuario in Clinica.Usuarios)
            {
                if(usuario.Id == id)
                    return usuario;
            }
            return new Usuario();
        }
    }
}