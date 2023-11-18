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
            //oculta lo que ya no se usa
            Btn_aceptar.Visible=false;
            Txt_Observacion.Visible=false;

            string Observacion = Txt_Observacion.Value.ToString();
            insertar_Observacion_BBDD(Observacion);

            // Redirecciona a la misma página para refrescar los datos
            Response.Redirect(Request.RawUrl);

            //muestra los campos por defecto
            Btn_agregar_obs.Visible = true;
            observacion.Visible = true;
        }
      
        public void insertar_Observacion_BBDD(string Observacion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
               
                //como vamos a cambiar la base de datos no se bien como puede ser esto pero algo dejo hecho               
                //if (turno_actual.!!OBSERVACION!!.LENTH == 0){
                //    datos.setConsulta("INSER INTO TURNOS (OBSERVACION) VALUES  = (@OBSERVACION) WHERE ID_TURNO = @ID_TURNO");
                //    datos.setParametro("@OBSERVACION", Observacion);
                //    datos.setParametro("@ID_TURNO", turno_actual.Id);
                //    datos.ejecutarAccion();
                //}
                //else{

                //}
                //datos.setConsulta("UPDATE  TURNOS SET OBSERVACION = @OBSERVACION WHERE ID_TURNO = @ID_TURNO");
                //datos.setParametro("@OBSERVACION",Observacion);
                //datos.setParametro("@ID_TURNO", turno_actual.Id);
                //datos.ejecutarAccion();

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