using Conexion_Clinica;
using Dominio;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class Confirmar_turno : System.Web.UI.Page
    {
        Turno turno_a_reservar;
        Usuario usuario_actual;
        EmailService email_service;
        Paciente paciente_actual;
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_componentes();
        }
        public void Cargar_componentes()
        {
            TurnoConexion turnoConexion = new TurnoConexion();
            usuario_actual = (Usuario)Session["Usuario"];

            turno_a_reservar = (Turno)Session["Turno"];
            List<Turno> turno = new List<Turno>();
            turno.Add(turno_a_reservar);
            PacienteConexion pacienteConexion = new PacienteConexion();

            paciente_actual = pacienteConexion.getPaciente(turno_a_reservar.Id_Paciente);

            DGVTurno_a_confirmar.DataSource = turno;
            DGVTurno_a_confirmar.DataBind();
        }
        
        protected void Confirmar_turno_Click(object sender, EventArgs e)
        {
            turno_a_reservar.Obs_paciente = Txt_observacion_paciente.Text;
            turno_a_reservar.Obs_medico = "";
            TurnoConexion turnoConexion = new TurnoConexion();
            turnoConexion.Insertar_Turno(turno_a_reservar);

            turno_a_reservar.Id = turnoConexion.GetMaxID();
            lbl_TurnoIngresado.Visible = true;

            if (paciente_actual.Mail != null)
            {
                btn_Confirmar_Turno.Visible = false;
                email_service = new EmailService();
                email_service.cuerpoCorreo(turno_a_reservar, paciente_actual.Mail);
                email_service.enviarCorreo();
                lbl_TurnoMailEnviado.Visible = true;
            }
            else
            {
                lbl_TurnoIngresado.Text = "Error: No se encontro el mail del paciente.";
                lbl_TurnoIngresado.Visible = true;
            }
             btn_Aceptar.Visible = true;
        }
        protected void Aceptar_Click(object sender, EventArgs e) {

            Response.Redirect("Home.aspx");
        }
        private void BuscarMailPaciente() {

            if (usuario_actual != null)
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setConsulta("SELECT MAIL FROM PACIENTES WHERE ID_PACIENTE = @ID");
                    datos.setParametro("@ID", usuario_actual.Id);

                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {                

                        paciente_actual.Mail = datos.Lector["MAIL"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    lbl_TurnoIngresado.Text = "Error al obtener el correo del paciente: " + ex.Message;
                    lbl_TurnoIngresado.Visible = true;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }
            else
            {
                lbl_TurnoIngresado.Text = "Error: No se encontraron datos del paciente.";
                lbl_TurnoIngresado.Visible = true;
            }
            

        }
    }
}