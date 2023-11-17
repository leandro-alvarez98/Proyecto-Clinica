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
        public List<Turno> Turnos_Disponibles;
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
            Cargar_DDL();
            
        }
        protected void Buscar_Turno_Click(object sender, EventArgs e)
        {
            Cargar_Turnos_Disponibles();
         
            // Mostrar para cada médico, su disponibilidad.
        }
        private void Cargar_Turnos_Disponibles()
        {
            
            String ID_Especialidad_Seleccionada = DDL_especialidades.SelectedValue;
            DateTime Fecha_Seleccionada = Calendario.SelectedDate;
            if (Fecha_Seleccionada> DateTime.Now)
            {
                // CREA UNA LISTA DE MEDICOS EN BASE A LA ESPECIALIDAD
                Medicos_segun_Especialidad(ID_Especialidad_Seleccionada);
                // LLENA ESA LISTA DE MEDICOS CON SUS RESPECTIVOS HORARIOS DISPONIBLES
                Obtener_Disponibilidad(Fecha_Seleccionada);

                // CARGAR TURNOS DISPONIBLES
                Cargar_Lista_Turnos();
                if (Turnos_Disponibles.Count() == 0)
                {
                    lblturnos.Text = "No hay Turnos Disponibles ";
                }
                else
                {
                    lblturnos.Text = "";
                }
                Lbl_fecha_valida.Visible = false;
            }
            else
            {
                Lbl_fecha_valida.Visible = true;
            }

            // LISTAR TURNOS EN LA GRILLA
            Grilla_turnos_disponibles.DataSource = Turnos_Disponibles;
            Grilla_turnos_disponibles.DataBind();
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
                medico.Turnos = new List<Turno>();

                try
                {
                    datos.setConsulta("SELECT   \r\n\t\t\tH.ID_HORARIO AS IDHORARIO,\r\n\t\t\tH.HORA AS HORA,ISNULL(T.ID_TURNO, 0) AS IDTURNO,\r\n\t\t\t@IDMedico AS IDMEDICO,\r\n\t\t\tISNULL(T.ESTADO, 'Disponible') AS ESTADO\r\n\t\tFROM  HORARIOS H \r\n\t\t\tJOIN  MEDICOXJORNADA MJ ON H.ID_JORNADA = MJ.ID_JORNADA AND MJ.ID_MEDICO = @IDMedico \r\n\t\t\tLEFT JOIN  TURNOS T ON H.ID_HORARIO = T.ID_HORARIO AND T.FECHA = @FechaConsulta AND T.ID_MEDICO = @IDMedico \r\n\t\t\tWHERE T.ESTADO IS  NULL\r\n\t\tORDER BY  H.HORA;");
                    datos.setParametro("@IDMedico", medico.Id);
                    datos.setParametro("@FechaConsulta", Fecha);
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
        public void Cargar_DDL()
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
            string fecha = Grilla_turnos_disponibles.SelectedRow.Cells[0].Text;
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

            if (usuario.Tipo == "Paciente")
            {
                
                Paciente paciente = Buscar_Paciente();
                turno_seleccionado.Id_Paciente = paciente.Id;
                turno_seleccionado.Dni_paciente = paciente.Dni;
                turno_seleccionado.Nombre_Paciente = paciente.Nombre;
                turno_seleccionado.Apellido_Paciente = paciente.Apellido;
                Session["Turno"] = turno_seleccionado;
                Response.Redirect("Confirmar_turno.aspx");
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
    }
}