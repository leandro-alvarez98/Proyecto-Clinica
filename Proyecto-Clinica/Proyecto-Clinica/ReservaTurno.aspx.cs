﻿using Conexion_Clinica;
using Dominio;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class ReservaTurno : System.Web.UI.Page
    {

        Clinica clinica;
        Usuario usuario;
        List<Medico> medicos_disponibles;
        public List<Turno> Turnos_Disponibles;
        int ID_Especialidad_Seleccionada;

        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_componentes();
        }
        public void Cargar_componentes()
        {
            clinica = new Clinica();
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            clinica = clinicaConexion.Listar();
            usuario = new Usuario();
            usuario = (Usuario)Session["Usuario"];
            medicos_disponibles = new List<Medico>();
            Turnos_Disponibles = new List<Turno>();

            //DROP_DOWN_LIST ESPECIALIDADES
            if (!IsPostBack) { 
                Cargar_DDL_Especialidades();
            }
            
        }
        protected void Buscar_Turno_Click(object sender, EventArgs e)
        {
            Cargar_Turnos_Disponibles();
        }
        private void Cargar_Turnos_Disponibles()
        {
            DateTime Fecha_Seleccionada = new DateTime();
            TimeSpan Hora_Seleccionada = new TimeSpan();
            TimeSpan Hora_Default = new TimeSpan(8, 0, 0);

            bool HoraIngresada = true;

            ID_Especialidad_Seleccionada = int.Parse(DDL_especialidades.SelectedValue);

            bool HoraValida = false, FechaValida = false;

            // Hace un casteo de la fecha seleccionada para que sea datetime
            if (DateTime.TryParse(txtFechaSeleccionada.Text, out DateTime fecha_turnos))
            {
                //Comprueba que la fecha seleccionada sea correcta
                if (!(fecha_turnos < DateTime.Now.Date))
                {
                    FechaValida = true;
                    Fecha_Seleccionada = fecha_turnos;
                }

                if (TimeSpan.TryParse(txt_HoraSeleccionada.Text, out TimeSpan horaSeleccionada))
                {

                    TimeSpan horaActual = DateTime.Now.TimeOfDay;
                    DateTime fechaActual = DateTime.Now.Date;

                    if ((horaSeleccionada > horaActual && Fecha_Seleccionada == fechaActual) || (Fecha_Seleccionada > fechaActual))
                    {
                        HoraValida = true;
                        Hora_Seleccionada = horaSeleccionada;
                    }
                }
                else
                {
                    HoraIngresada = false;

                    HoraValida = true;
                }

                if (HoraValida && FechaValida)
                {
                    // CREA UNA LISTA DE MEDICOS EN BASE A LA ESPECIALIDAD
                    Medicos_segun_Especialidad(ID_Especialidad_Seleccionada);

                    // LLENA ESA LISTA DE MEDICOS CON SUS RESPECTIVOS HORARIOS DISPONIBLES
                    if (HoraIngresada)
                    {
                        Obtener_Disponibilidad(Fecha_Seleccionada, Hora_Seleccionada);
                    }
                    else
                    {
                        if (Fecha_Seleccionada.Date > DateTime.Now.Date)
                        {
                            Obtener_Disponibilidad(Fecha_Seleccionada, Hora_Default);
                        }
                        else
                        {
                            Obtener_Disponibilidad(Fecha_Seleccionada, DateTime.Now.TimeOfDay);
                        }
                    }

                    // CARGAR TURNOS DISPONIBLES
                    Cargar_Lista_Turnos();

                    // LISTAR TURNOS EN LA GRILLA
                    Grilla_turnos_disponibles.DataSource = Turnos_Disponibles;
                    Grilla_turnos_disponibles.DataBind();
                }
                else if (!HoraValida)
                {
                    lbl_HoraInvalida.Visible = true;
                }
                else if (!FechaValida)
                {
                    lbl_FechaInvalida.Visible = true;
                }
            }
        }
        private void Cargar_Lista_Turnos()
        {
            foreach (Medico medico in medicos_disponibles)
            {
                foreach(Turno turno in medico.Turnos)
                {
                    Turnos_Disponibles.Add(turno);
                }
            }
        }
        public void Medicos_segun_Especialidad(int ID_Especialidad)
        {
            foreach (Medico medico in clinica.Medicos)
            {
                foreach (Especialidad especialidad in medico.Especialidades)
                {
                    if (especialidad.Id == ID_Especialidad)
                    {
                        medicos_disponibles.Add(medico);
                    }
                }
            }
        }
        private void Obtener_Disponibilidad(DateTime Fecha, TimeSpan Hora)
        {
            foreach (Medico medico in medicos_disponibles)
            {
                AccesoDatos datos = new AccesoDatos();
                medico.Turnos = new List<Turno>();

                try
                {
                    datos.setConsulta("SELECT \r\n\tH.ID_HORARIO AS IDHORARIO, \r\n\tH.HORA AS HORA,\r\n\tISNULL(T.ID_TURNO, 0) AS IDTURNO,\r\n\t@IDMedico AS IDMEDICO,\r\n\tISNULL(T.ESTADO, 'Disponible') AS ESTADO\r\nFROM  HORARIOS H \r\nJOIN  MEDICOXJORNADA MJ ON H.ID_JORNADA = MJ.ID_JORNADA AND MJ.ID_MEDICO = @IDMedico\r\nLEFT JOIN  TURNOS T ON H.ID_HORARIO = T.ID_HORARIO AND T.FECHA = @FechaConsulta AND T.ID_MEDICO = @IDMedico\r\nWHERE T.ESTADO IS  NULL AND H.HORA >= @HORA\r\nORDER BY  H.HORA");
                    datos.setParametro("@IDMedico", medico.Id);
                    datos.setParametro("@FechaConsulta", Fecha);
                    datos.setParametro("@HORA", Hora);
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Turno turno = new Turno
                        {
                            Id = (int)datos.Lector["IDTURNO"],
                            Id_Medico = (int)datos.Lector["IDMEDICO"],
                            Id_Horario = (int)datos.Lector["IDHORARIO"],
                            Fecha = Fecha,
                            Horario = (TimeSpan)datos.Lector["HORA"],
                            Estado = (String)datos.Lector["ESTADO"],
                            Nombre_Medico = medico.Nombre,
                            Apellido_Medico = medico.Apellido
                        };
                        medico.Turnos.Add(turno);
                    }
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
        public void Cargar_DDL_Especialidades()
        {
            List<Especialidad> especialidades;
            especialidades = clinica.Especialidades;

            DDL_especialidades.DataTextField = "TIPO";
            DDL_especialidades.DataValueField = "Id";
            DDL_especialidades.DataSource = especialidades;
            DDL_especialidades.DataBind();
        }
        protected void Grilla_turnos_disponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Turno turno_seleccionado = new Turno();
            string fecha = txtFechaSeleccionada.Text;
            string hora = Grilla_turnos_disponibles.SelectedRow.Cells[1].Text;
            string apellidoMedico = Grilla_turnos_disponibles.SelectedRow.Cells[2].Text;
            string nombreMedico = Grilla_turnos_disponibles.SelectedRow.Cells[3].Text;
            string idMedico = Grilla_turnos_disponibles.SelectedRow.Cells[5].Text;
            

            
            turno_seleccionado.Fecha = DateTime.Parse(fecha);
            turno_seleccionado.Horario = TimeSpan.Parse(hora);
            turno_seleccionado.Id_Horario = Get_IDHorario(TimeSpan.Parse(hora));
            turno_seleccionado.Apellido_Medico = apellidoMedico;
            turno_seleccionado.Nombre_Medico = nombreMedico;
            turno_seleccionado.Id_Medico = int.Parse(idMedico);
            turno_seleccionado.Id_Especialidad = int.Parse(DDL_especialidades.SelectedValue);

            if (usuario.Tipo == "Paciente")
            {

                Paciente paciente = Buscar_Paciente();
                if (Paciente_Disponible(paciente.Id, turno_seleccionado))
                {
                    turno_seleccionado.Id_Paciente = paciente.Id;
                    turno_seleccionado.Dni_paciente = paciente.Dni;
                    turno_seleccionado.Nombre_Paciente = paciente.Nombre;
                    turno_seleccionado.Apellido_Paciente = paciente.Apellido;
                    Session["Turno"] = turno_seleccionado;
                    Response.Redirect("Confirmar_turno.aspx");
                }
                else
                {
                    // El paciente no está disponible
                }
            }
            else
            {
                Session["Turno"] = turno_seleccionado;
                Response.Redirect("Seleccionar_paciente.aspx");
            }
        }
        private int Get_IDHorario(TimeSpan Hora)
        {
            foreach(Horario horario in clinica.Horarios)
            {
                if(horario.Hora == Hora)
                {
                    return horario.Id_Horario;
                }
            }
            return 0;
        }
        private Paciente Buscar_Paciente()
        {
            foreach (Paciente paciente1 in clinica.Pacientes)
            {
                if (paciente1.Id_Usuario == usuario.Id)
                {
                    return paciente1;
                }
            }
            return new Paciente();
        }
        private bool Paciente_Disponible(int ID_paciente, Turno turno_seleccionado)
        {
            foreach (Turno turno in clinica.Turnos)
            {
                if (turno.Id_Paciente == ID_paciente)
                {
                    if (turno.Fecha == turno_seleccionado.Fecha && turno.Horario == turno_seleccionado.Horario)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}