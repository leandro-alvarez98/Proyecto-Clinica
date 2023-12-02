using Conexion_Clinica;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Clinica
{
    public partial class Usuarios : System.Web.UI.Page
    {
        public List<Usuario> lista_usuario_x_nombre;

        Clinica Clinica;
        Usuario usuario_actual;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            Clinica = clinicaConexion.Listar();
            usuario_actual = (Usuario)Session["Usuario"];

            usuario_actual = Cargar_Datos_Usuario(usuario_actual);

            repeaterUsuarios.DataSource = Clinica.Usuarios;
            repeaterUsuarios.DataBind();
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
        protected void btn_ActualizarTipo_Click(object sender, EventArgs e)
        {
            Usuario usuario_Seleccionado = (Usuario)Session["UsuarioSeleccionado"];
            string tipoSeleccionado = rblTipos.SelectedValue;

            if (usuario_Seleccionado.Tipo == "Médico" || usuario_Seleccionado.Tipo == "Paciente")
                Baja_Logica_Turnos(usuario_Seleccionado);

            if (usuario_Seleccionado.Tipo == "Médico")
            {
                Medico medico = Cargar_Médico_Clinica(usuario_Seleccionado.Id);
                EspecialidadesConexion especialidadesConexion = new EspecialidadesConexion();

                especialidadesConexion.EliminarEspecialidadxMedico(medico.Id);
            }

            UsuarioConexion usuarioConexion = new UsuarioConexion();

            usuarioConexion.EliminarDatos(usuario_Seleccionado);

            usuario_Seleccionado.Tipo = tipoSeleccionado;

            usuarioConexion.Actualizar_Usuario(usuario_Seleccionado);

            switch (tipoSeleccionado)
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
            Response.Redirect("Usuarios.aspx");
        }

        private void Baja_Logica_Turnos(Usuario usuario_Seleccionado)
        {
            TurnoConexion turnoConexion = new TurnoConexion();

            Paciente paciente = Cargar_Paciente_Clinica(usuario_Seleccionado.Id);

            Medico medico = Cargar_Médico_Clinica(usuario_Seleccionado.Id);

            switch (usuario_Seleccionado.Tipo)
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
                        if (turno.Id_Medico == paciente.Id)
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

            Usuario usuario_Seleccionado = GetUsuario(idUsuarioSeleccionado);

            usuario_Seleccionado = Cargar_Datos_Usuario(usuario_Seleccionado);

            Session["UsuarioSeleccionado"] = usuario_Seleccionado;

            string script = @"
                $(document).ready(function () {
                    $('#mod_ElegirTipo').modal('show');
                });
            ";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
        }
        private Usuario GetUsuario(int id)
        {
            foreach (Usuario usuario in Clinica.Usuarios)
            {
                if (usuario.Id == id)
                    return usuario;
            }
            return new Usuario();
        }

        protected void Btn_buscar_usuario_Click(object sender, EventArgs e)
        {
            lista_usuario_x_nombre = new List<Usuario>();
            string nombre_usuario = Txt_usuario.Text;
            Cargar_usuario_buscado(nombre_usuario);

            //limpia el listado actual
            repeaterUsuarios.DataSource = null;
            repeaterUsuarios.DataBind();
            //muestra el usuario
            repeaterUsuarios.DataSource = lista_usuario_x_nombre;
            repeaterUsuarios.DataBind();
            if (lista_usuario_x_nombre.Count() == 0)
            {
                Lbl_sin_usuarios.Visible = true;
            }
            else
            {
                Lbl_sin_usuarios.Visible = false;
            }

        }



        public void Cargar_usuario_buscado(string nombre_usuario)
        {
            foreach (Usuario usuario in Clinica.Usuarios)
            {
                if (usuario.Username == nombre_usuario)
                {
                    lista_usuario_x_nombre.Add(usuario);
                }
            }
        }

        protected void Btn_limpiar_Click(object sender, EventArgs e)
        {
            //limpia la grilla actual
            repeaterUsuarios.DataSource = null;
            repeaterUsuarios.DataBind();
            //cargar la nueva grilla de datos 
            repeaterUsuarios.DataSource = Clinica.Usuarios;
            repeaterUsuarios.DataBind();
            if (Clinica.Usuarios.Count() != 0)
            {
                Lbl_sin_usuarios.Visible = false;
            }
        }
    }
}