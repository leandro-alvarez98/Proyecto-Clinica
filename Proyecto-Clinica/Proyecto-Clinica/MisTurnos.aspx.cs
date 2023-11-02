using Conexion_Clinica;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Medico medicoActual;
        Paciente pacienteActual;
        List<Turno> misTurnos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                misTurnos = new List<Turno>();

                if(((Proyecto_Clinica.Dominio.Usuario)Session["Usuario"]).Tipo == "Médico")
                {
                    medicoActual = new Medico();

                    Cargar_Médico();
                    Cargar_TurnosMedicos();
                }
                else if(((Proyecto_Clinica.Dominio.Usuario)Session["Usuario"]).Tipo == "Paciente")
                {
                    pacienteActual = new Paciente();
                    Cargar_Paciente();
                    Cargar_TurnosPaciente();
                }

                dgv_Turnos.DataSource = misTurnos;
                dgv_Turnos.DataBind();
            }
        }


        private void Cargar_Paciente()
        {
            int IdUsuario = ((Usuario)Session["Usuario"]).Id;

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID_PACIENTE, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO FROM PACIENTES WHERE ID_USUARIO = @IDUSUARIO");
                datos.setParametro("@IDUSUARIO", IdUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    pacienteActual.Id = (int)datos.Lector["ID_PACIENTE"];

                    pacienteActual.Nombre = (String)datos.Lector["NOMBRE"];

                    pacienteActual.Apellido = (String)datos.Lector["APELLIDO"];

                    pacienteActual.Telefono = (String)datos.Lector["TELEFONO"];

                    pacienteActual.Direccion = (String)datos.Lector["DIRECCION"];

                    pacienteActual.Fecha_Nacimiento = (DateTime)datos.Lector["FECHA_NACIMIENTO"];

                    pacienteActual.Mail = (String)datos.Lector["MAIL"];

                    pacienteActual.Estado = (bool)datos.Lector["ESTADO"]; 
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
        private void Cargar_TurnosPaciente()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT T.ID_TURNO AS ID, M.NOMBRE + ', ' + m.APELLIDO AS MAPENOM, p.NOMBRE + ', ' + p.APELLIDO AS PAPENOM, t.FECHA AS FECHA, t.HORA_INICIO AS HORAINICIO, t.HORA_FIN AS HORAFIN, t.ESTADO AS ESTADO FROM PACIENTES P INNER JOIN TURNOS T ON T.ID_PACIENTE = P.ID_PACIENTE INNER JOIN MEDICOS M ON M.ID_MEDICO = T.ID_MEDICO WHERE P.ID_PACIENTE = @IDPACIENTE");
                datos.setParametro("@IDPACIENTE", pacienteActual.Id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno turno = new Turno();
                    turno.Id = (int)datos.Lector["ID"];
                    turno.Medico = (String)datos.Lector["MAPENOM"];
                    turno.Paciente = (String)datos.Lector["PAPENOM"];
                    turno.Fecha = (DateTime)datos.Lector["FECHA"];
                    turno.HoraInicio = (TimeSpan)datos.Lector["HORAINICIO"];
                    turno.HoraFin = (TimeSpan)datos.Lector["HORAFIN"];
                    turno.Estado = (String)datos.Lector["ESTADO"];

                    misTurnos.Add(turno);
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

        private void Cargar_Médico()
        {
            int IdUsuario = ((Usuario)Session["Usuario"]).Id;

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("Select ID_MEDICO, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO FROM MEDICOS WHERE ID_USUARIO = @IDUSUARIO");
                datos.setParametro("@IDUSUARIO", IdUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    medicoActual.Id = (int)datos.Lector["ID_MEDICO"];

                    medicoActual.Nombre = (String)datos.Lector["NOMBRE"];

                    medicoActual.Apellido = (String)datos.Lector["APELLIDO"];

                    medicoActual.Telefono = (String)datos.Lector["TELEFONO"];

                    medicoActual.Direccion = (String)datos.Lector["DIRECCION"];

                    medicoActual.FechaNacimiento = (DateTime)datos.Lector["FECHA_NACIMIENTO"];

                    medicoActual.Mail = (String)datos.Lector["MAIL"];

                    medicoActual.Estado = (bool)datos.Lector["ESTADO"];
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
        private void Cargar_TurnosMedicos()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID_TURNO, M.NOMBRE AS MNOMBRE ,P.NOMBRE AS PNOMBRE, FECHA, HORA_INICIO, HORA_FIN, T.ESTADO AS ESTADO FROM TURNOS T INNER JOIN MEDICOS M ON M.ID_MEDICO = T.ID_MEDICO INNER JOIN PACIENTES P ON P.ID_PACIENTE = T.ID_PACIENTE WHERE @IDMEDICO = T.ID_MEDICO");
                datos.setParametro("@IDMEDICO", medicoActual.Id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno turno = new Turno();
                    turno.Id = (int)datos.Lector["ID_TURNO"];
                    turno.Medico = (String)datos.Lector["MNOMBRE"];
                    turno.Paciente = (String)datos.Lector["PNOMBRE"];
                    turno.Fecha = (DateTime)datos.Lector["FECHA"];
                    turno.HoraInicio = (TimeSpan)datos.Lector["HORA_INICIO"];
                    turno.HoraFin = (TimeSpan)datos.Lector["HORA_FIN"];
                    turno.Estado = (String)datos.Lector["ESTADO"];

                    misTurnos.Add(turno);
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