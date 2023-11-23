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

        Turno turno_actual;
        Clinica clinica;
        TurnoConexion turnoConexion;
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_componentes();
        }
        public void Cargar_componentes()
        {       
            clinica = new Clinica();
            turno_actual = new Turno();
            turno_actual = (Turno)Session["Turno"];

            Cargar_labels();

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
    }
}