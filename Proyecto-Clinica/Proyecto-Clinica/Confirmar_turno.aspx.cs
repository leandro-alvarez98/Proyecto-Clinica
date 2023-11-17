using Conexion_Clinica;
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
    public partial class Confirmar_turno : System.Web.UI.Page
    {
        Turno turno_a_reservar;
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_componentes();
        }
        public void Cargar_componentes()
        {

            List<Turno> turno = new List<Turno>();
            turno_a_reservar = (Turno)Session["Turno"];
            turno.Add(turno_a_reservar);
           
            DGVTurno_a_confirmar.DataSource = turno;
            DGVTurno_a_confirmar.DataBind();
        }

        protected void Confirmar_turno_Click(object sender, EventArgs e)
        {
            Insertar_Turno();
            lbl_TurnoIngresado.Visible = true;
        }
        private void Insertar_Turno()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO TURNOS (ID_MEDICO, ID_PACIENTE, ID_HORARIO, FECHA, ESTADO) VALUES(@IDMEDICO, @IDPACIENTE, @IDHORA, @FECHA, @ESTADO)");
                datos.setParametro("@IDMEDICO", turno_a_reservar.Id_Medico);
                datos.setParametro("@IDPACIENTE", turno_a_reservar.Id_Paciente);
                datos.setParametro("@IDHORA", turno_a_reservar.Id_Horario);
                datos.setParametro("@FECHA", turno_a_reservar.Fecha);
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
    }
}