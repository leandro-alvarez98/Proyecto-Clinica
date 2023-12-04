using Conexion_Clinica;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class Detalle_turno : System.Web.UI.Page
    {

        Turno turno_actual;
        Clinica clinica;
        TurnoConexion turnoConexion;
        Usuario usuario_actual;
        public List<Turno> Turnos_Disponibles;
        List<Medico> medicos_disponibles;
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_componentes();
        }
        public void Cargar_componentes()
        {
            ClinicaConexion conexion = new ClinicaConexion();
            clinica = conexion.Listar();

            Turnos_Disponibles = new List<Turno>();
            medicos_disponibles = new List<Medico>();
            turno_actual = new Turno();
            turno_actual = (Turno)Session["Turno"];
            usuario_actual = (Usuario)Session["Usuario"];
            turnoConexion = new TurnoConexion();
            if (usuario_actual.Tipo != "Médico")
            {
                DGV_turnos_disponibles.Visible = true;
                Lbl.Visible= true;
                txt_FechaSeleccionada.Visible = true;
                txt_HoraSeleccionada.Visible=true;
                lbl_Hora.Visible = true;
                Btn_BuscarTurnosDisponibles.Visible=true;
            }

            Cargar_labels();
            Cargar_botones();

        }
        protected void Btn_agregar_obs_Click(object sender, EventArgs e)
        {
            //oculta y muestra nuevos los botones
            Btn_agregar_obs.Visible = false;
            Btn_aceptar.Visible = true;
            Btn_cancelar.Visible = true;

            //oculta las la observacion actual 
            P_observacion.Visible = false;
            Txt_Observacion.Visible = true;
            Txt_Observacion.Value = P_observacion.InnerText;
        }
        protected void Btn_aceptar_Click(object sender, EventArgs e)
        {
            turnoConexion = new TurnoConexion();

            string Observacion = Txt_Observacion.Value.ToString();

            //actualiza observacion
            turnoConexion.Actualizar_Observacion_x_ID(Observacion, turno_actual.Id);

            //Recarga  la observacion  desde la BBDD           
            turno_actual.Obs_medico = turnoConexion.Listar_Observacion_x_ID(turno_actual.Id);

            //actualiza el texto de la observacion
            P_observacion.InnerText = turno_actual.Obs_medico;
           
            //muestra los campos por defecto
            Btn_agregar_obs.Visible = true;
            P_observacion.Visible = true;

            //oculta lo que ya no se usa
            Btn_aceptar.Visible = false;
            Btn_cancelar.Visible=false;
            Txt_Observacion.Visible = false;
        }      
        protected void Btn_cancelar_Click(object sender, EventArgs e)
        {
            //oculta y muestra botones correspondientes
            Btn_cancelar.Visible = false;
            Btn_aceptar.Visible = false;
            Txt_Observacion.Visible=false;

            //muestra los campos por defecto
            Btn_agregar_obs.Visible = true;
            P_observacion.Visible = true;
            
            Cargar_labels();

        }
        public void Cargar_labels()
        {
            Lbl_nombre_paciente.Text = turno_actual.Nombre_Paciente;
            Lbl_nombre_medico.Text = turno_actual.Nombre_Medico;
            Lbl_Fecha.Text = turno_actual.Fecha.ToString("d/M/yyyy");
            Lbl_Horario.Text = turno_actual.Horario.ToString();
            Lbl_Id_Turno.Text = turno_actual.Id.ToString();
            Lbl_motivo_consulta.Text = turno_actual.Obs_paciente;
            P_observacion.InnerText = turno_actual.Obs_medico;
        }
        public void Cargar_botones()
        {
            switch (usuario_actual.Tipo)
            {
                case "Medico":
                    Btn_agregar_obs.Visible = true;
                    break;
                case "Recepcionista":
                    Btn_agregar_obs.Visible = false;
                    break;
                case "Administrador":
                    Btn_agregar_obs.Visible = false;
                    break;
            }
        }
        private void Cargar_Turnos_Disponibles()
        {
            DateTime Fecha_Seleccionada = new DateTime();
            TimeSpan Hora_Seleccionada = new TimeSpan();
            TimeSpan Hora_Default = new TimeSpan(8,0,0);

            bool HoraValida = false, FechaValida = false, HoraIngresada = true;

            // Hace un casteo de la fecha seleccionada para que sea datetime
            if (DateTime.TryParse(txt_FechaSeleccionada.Text, out DateTime fecha_turnos))
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
                else // NO SE INGRESA HORA
                {
                   
                    HoraIngresada = false;
                    HoraValida = true;
                }

                if (HoraValida && FechaValida)
                {
                    // CREA UNA LISTA DE MEDICOS EN BASE A LA ESPECIALIDAD
                    Medicos_segun_Especialidad(turno_actual.Id_Especialidad);

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
                    DGV_turnos_disponibles.DataSource = Turnos_Disponibles;
                    DGV_turnos_disponibles.DataBind();
                }
                else if (!HoraValida)
                {
                    lblMensajeErrorHora.Text = "Formato de hora no válido. Por favor, ingresa una hora válida.";
                }
                else if (!FechaValida)
                {
                    lblMensajeError.Text = "La fecha ingresada no es válida. Por favor, selecciona una fecha válida.";
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
        private void Cargar_Lista_Turnos()
        {
            foreach (Medico medico in medicos_disponibles)
            {
                foreach (Turno turno in medico.Turnos)
                {
                    Turnos_Disponibles.Add(turno);
                }
            }
        }
        protected void Btn_BuscarTurnosDisponibles_Click(object sender, EventArgs e)
        {
            Cargar_Turnos_Disponibles();
        }
        protected void DGV_turnos_disponibles_SelectedIndexChanged(object sender, EventArgs e)
        {

            string script = @"
                $(document).ready(function () {
                    $('#Modal_Modificar_Turno').modal('show');
                });
            ";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);

        }

        protected void Btn_aceptar_Modificar_turno_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = DateTime.Parse(txt_FechaSeleccionada.Text);
            TimeSpan horaSeleccionada = TimeSpan.Parse(DGV_turnos_disponibles.SelectedRow.Cells[1].Text);
            int IDMedico = int.Parse(DGV_turnos_disponibles.SelectedRow.Cells[5].Text);

            Turno turno;
            turno = turno_actual;
            turno.Id_Medico = IDMedico;
            turno.Nombre_Medico = DGV_turnos_disponibles.SelectedRow.Cells[3].Text;
            turno.Apellido_Medico = DGV_turnos_disponibles.SelectedRow.Cells[2].Text;
            turno.Fecha = fechaSeleccionada;
            turno.Id = turno_actual.Id;
            HorarioConexion horarioConexion = new HorarioConexion();
            turno.Id_Horario = horarioConexion.GetIdHorario(horaSeleccionada);

            if (!turnoConexion.Modificar_Turno(turno))
            {
                lblMensajeError.Text = "Error al modificar el turno";
                lblMensajeError.Visible = true;
            }
            else
            {
                Response.Redirect("Detalle_turno.aspx");
                Session["Turno"] = turno;
            }
        }
    }
}