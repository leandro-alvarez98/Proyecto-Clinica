using Conexion_Clinica;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class Detalle_turno : System.Web.UI.Page
    {
        Usuario usuario_actual;
        Turno turno_actual;
        Clinica clinica;
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_componentes();
        }
        public void Cargar_componentes()
        {       
            clinica = new Clinica();
            turno_actual = new Turno();
            turno_actual = (Turno)Session["Turno"];

            Lbl_nombre_paciente.Text = turno_actual.Nombre_Paciente;
            Lbl_nombre_medico.Text = turno_actual.Nombre_Medico;
            Lbl_Fecha.Text = turno_actual.Fecha.ToString();
            Lbl_Horario.Text = turno_actual.Horario.ToString();
            Lbl_Id_Turno.Text = turno_actual.Id.ToString();
            Lbl_motivo_consulta.Text = turno_actual.Obs_paciente;
            observacion.InnerText = turno_actual.Obs_medico;
            
        }
        protected void Btn_agregar_obs_Click(object sender, EventArgs e)
        {
            //oculta los botones
            Btn_agregar_obs.Visible = false;
            Btn_aceptar.Visible = true;

            //oculta las la observacion actual 
            observacion.Visible = false;
            Txt_Observacion.Visible = true;
        }
        protected void Btn_aceptar_Click(object sender, EventArgs e)
        {
            
            string Observacion = Txt_Observacion.Value.ToString();
            insertar_Observacion_BBDD(Observacion);

            //Recarga  el Turno actual al cual se le agrego la observacion 
            turno_actual = Recargar_turno(turno_actual.Id);

            //actualiza el texto de la observacion
            observacion.InnerText = turno_actual.Obs_medico;
           
            //muestra los campos por defecto
            Btn_agregar_obs.Visible = true;
            observacion.Visible = true;

            //oculta lo que ya no se usa
            Btn_aceptar.Visible = false;
            Txt_Observacion.Visible = false;
        }     
        public void insertar_Observacion_BBDD(string Observacion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                  datos.setConsulta("UPDATE  TURNOS SET OBS_MEDICO = @OBSERVACION WHERE ID_TURNO = @ID_TURNO");
                  datos.setParametro("@OBSERVACION", Observacion);
                  datos.setParametro("@ID_TURNO", turno_actual.Id);
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
        public Turno Recargar_turno(int ID)
        {
            ClinicaConexion conexion = new ClinicaConexion();
            clinica = conexion.Listar();
            foreach (Turno turno in clinica.Turnos)
            {
                if (ID == turno.Id)
                {
                    return turno;
                }
            }
            return new Turno();
        }
    }
}