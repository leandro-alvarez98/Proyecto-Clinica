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
            usuario_actual = (Usuario)Session["Usuario"];
            List<Turno> turno = new List<Turno>();
            turno_a_reservar = (Turno)Session["Turno"];
            turno.Add(turno_a_reservar);
           
            DGVTurno_a_confirmar.DataSource = turno;
            DGVTurno_a_confirmar.DataBind();
        }
        
        protected void Confirmar_turno_Click(object sender, EventArgs e)
        {
            turno_a_reservar.Obs_paciente = Txt_observacion_paciente.Text;
            turno_a_reservar.Obs_medico = "";
            Insertar_Turno();
            
            lbl_TurnoIngresado.Visible = true;
            // armamos el envio por mail

            if (paciente_actual.Mail != null)
            {
                btn_Confirmar_Turno.Visible = false;
                BuscarMailPaciente();
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
        private void Insertar_Turno()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO TURNOS (ID_MEDICO, ID_PACIENTE, ID_HORARIO, FECHA,OBS_PACIENTE,OBS_MEDICO, ESTADO) VALUES(@IDMEDICO, @IDPACIENTE, @IDHORA, @FECHA,@OBS_PACIENTE,@OBS_MEDICO, @ESTADO)");
                datos.setParametro("@IDMEDICO", turno_a_reservar.Id_Medico);
                datos.setParametro("@IDPACIENTE", turno_a_reservar.Id_Paciente);
                datos.setParametro("@IDHORA", turno_a_reservar.Id_Horario);
                datos.setParametro("@FECHA", turno_a_reservar.Fecha);
                datos.setParametro("@OBS_PACIENTE",turno_a_reservar.Obs_paciente);
                datos.setParametro("@OBS_MEDICO", turno_a_reservar.Obs_medico);
                datos.setParametro("@ESTADO", "Reservado");
                datos.ejecutarAccion();
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