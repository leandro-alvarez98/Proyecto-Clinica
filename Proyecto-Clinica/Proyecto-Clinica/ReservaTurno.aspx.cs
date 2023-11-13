using Conexion_Clinica;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Clinica
{
    public partial class ReservaTurno : System.Web.UI.Page
    {
        List<Medico> medicos_disponibles ;
        Clinica clinica ;
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_componentes();
        }
        public void Cargar_componentes()
        {
            clinica = new Clinica();
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            clinica = clinicaConexion.Listar();
            medicos_disponibles = new List<Medico>();
           
            //DROP_DOWN_LIST ESPECIALIDADES
            List<Especialidad> especialidades = new List<Especialidad>();
            especialidades = clinica.Especialidades;
            DDL_especialidades.DataTextField = "TIPO";
            DDL_especialidades.DataValueField = "Id";
            DDL_especialidades.DataSource = especialidades;
            DDL_especialidades.DataBind();


            //Grilla turnos disponibles
            //Dia,hora,doctor,especialidad
            
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Medicos_segun_Especialidad();

        
           Grilla_turnos_disponibles.DataSource = medicos_disponibles;
           Grilla_turnos_disponibles.DataBind();


        }

        public void Medicos_segun_Especialidad()
        {
            foreach (Medico medico in clinica.Medicos)
            {
                foreach (Especialidad especialidad in medico.Especialidades)
                {
                    if (especialidad.Id.ToString() == DDL_especialidades.SelectedValue)
                    {
                        medicos_disponibles.Add(medico);
                    }
                }
            }
           
        }

        public void Turnos_disponibles()
        {

        }


    }
}