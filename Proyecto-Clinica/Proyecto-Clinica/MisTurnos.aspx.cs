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
        Clinica clinica;
        Usuario usuarioActual;
        Medico medicoActual;
        Paciente pacienteActual;
        List<Turno> misTurnos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cargar_Componentes();
            }
        }
        private void Cargar_Componentes()
        {
            clinica = new Clinica();
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            clinica = clinicaConexion.Listar();

            usuarioActual = new Usuario();
            usuarioActual = (Proyecto_Clinica.Dominio.Usuario)Session["Usuario"];

            if (usuarioActual.Tipo == "Médico")
            {
                medicoActual = new Medico();
                medicoActual = Cargar_Médico_Clinica();
            }
            else if (usuarioActual.Tipo == "Paciente")
            {
                pacienteActual = new Paciente();
                pacienteActual = Cargar_Paciente_Clinica();
            }

            misTurnos = new List<Turno>();
            Cargar_Turnos();

            dgv_Turnos.DataSource = misTurnos;
            dgv_Turnos.DataBind();
        }
        private Medico Cargar_Médico_Clinica()
        {
            foreach (Medico medico in clinica.Medicos)
            {
                if (medico.Id_Usuario == usuarioActual.Id)
                {
                    return medico;
                }
            }
            return new Medico();
        }
        private Paciente Cargar_Paciente_Clinica()
        {
            foreach(Paciente paciente in clinica.Pacientes)
            {
                if(paciente.Id_Usuario == usuarioActual.Id)
                {
                    return paciente;
                }
            }
            return new Paciente();
        }
        private void Cargar_Turnos()
        {
            if (usuarioActual.Tipo == "Médico")
            {
                foreach (Turno turno in clinica.Turnos)
                {
                    if (medicoActual.Id == turno.Id_Medico)
                    {
                        misTurnos.Add(turno);
                    }
                }
            }
            else if (usuarioActual.Tipo == "Paciente")
            {
                foreach (Turno turno in clinica.Turnos)
                {
                    if (pacienteActual.Id == turno.Id_Paciente)
                    {
                        misTurnos.Add(turno);
                    }
                }
            }
        }
    }
}