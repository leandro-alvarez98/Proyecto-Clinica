using Conexion_Clinica;
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
        List<Turno> Turnos_Disponibles;
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
            List<Especialidad> especialidades = new List<Especialidad>();
            especialidades = clinica.Especialidades;
            DDL_especialidades.DataTextField = "TIPO";
            DDL_especialidades.DataValueField = "Id";
            DDL_especialidades.DataSource = especialidades;
            DDL_especialidades.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Cargar_Turnos_Disponibles();
            // Mostrar para cada médico, su disponibilidad.
        }

        private void Cargar_Turnos_Disponibles()
        {
            String ID_Especialidad_Seleccionada = DDL_especialidades.SelectedValue;
            DateTime Fecha_Seleccionada = Calendario.SelectedDate;
            // CREA UNA LISTA DE MEDICOS EN BASE A LA ESPECIALIDAD
            Medicos_segun_Especialidad(ID_Especialidad_Seleccionada);
            // LLENA ESA LISTA DE MEDICOS CON SUS RESPECTIVOS HORARIOS DISPONIBLES
            Obtener_Disponibilidad(Fecha_Seleccionada);
            // CARGAR TURNOS DISPONIBLES
            Cargar_Lista_Turnos(ID_Especialidad_Seleccionada, Fecha_Seleccionada);
            // LISTAR TURNOS EN LA GRILLA
            Grilla_turnos_disponibles.DataSource = Turnos_Disponibles;
            Grilla_turnos_disponibles.DataBind();
        }
        private void Cargar_Lista_Turnos(string ID_Especialidad, DateTime Fecha)
        {
                foreach(Medico medico in medicos_disponibles)
                {
                    foreach(TimeSpan Horario in medico.Disponibilidad)
                    {
                        Turno turno = new Turno();
                        turno.Id_Medico = medico.Id;
                        turno.Horario = Horario;
                        turno.Fecha = Fecha;
                        turno.Estado = "Disponible";
                        turno.Nombre_Medico = medico.Nombre;
                        turno.Apellido_Medico = medico.Apellido;
                        turno.Nombre_Paciente = "nada";
                        turno.Apellido_Paciente = "nada";
                        Turnos_Disponibles.Add(turno);
                    }
                }
            
        }
        public void Medicos_segun_Especialidad(String ID_Especialidad)
        {
            foreach (Medico medico in clinica.Medicos)
            {
                foreach (Especialidad especialidad in medico.Especialidades)
                {
                    if (especialidad.Id.ToString() == ID_Especialidad)
                    {
                        medicos_disponibles.Add(medico);
                    }
                }
            }
        }
        private void Obtener_Disponibilidad(DateTime Fecha)
        {
            foreach(Medico medico in medicos_disponibles)
            {
                AccesoDatos datos = new AccesoDatos();
                medico.Disponibilidad = new List<TimeSpan>();
                try
                {
                    datos.setConsulta("SELECT H.HORA AS HORA, ID_TURNO, ESTADO FROM HORARIOS H CROSS JOIN (SELECT DISTINCT FECHA FROM TURNOS WHERE ID_MEDICO = @IDMedico AND FECHA = @FechaConsulta) D LEFT JOIN TURNOS T ON H.ID_HORARIO = T.ID_HORARIO AND T.FECHA = D.FECHA AND T.ID_MEDICO = @IDMedico WHERE ID_TURNO IS NULL ORDER BY H.HORA");
                    datos.setParametro("@IDMedico", medico.Id);
                    datos.setParametro("@FechaConsulta", Fecha);
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        TimeSpan Horario = (TimeSpan)datos.Lector["HORA"];
                        medico.Disponibilidad.Add(Horario);
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
    }
}