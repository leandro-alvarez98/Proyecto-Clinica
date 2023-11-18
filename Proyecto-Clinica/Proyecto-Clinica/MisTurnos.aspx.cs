﻿using Conexion_Clinica;
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
        public  Usuario usuarioActual;
        Medico medicoActual;
        Paciente pacienteActual;
        List<Turno> misTurnos;
        Turno Turno_Seleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_Componentes();
        }
        private void Cargar_Componentes()
        {
            clinica = new Clinica();
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            clinica = clinicaConexion.Listar();

            usuarioActual = new Usuario();
            usuarioActual = (Proyecto_Clinica.Dominio.Usuario)Session["Usuario"];

            Turno_Seleccionado = new Turno();

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

            if(usuarioActual.Tipo == "Recepcionista" || usuarioActual.Tipo == "Administrador")
            {
                DGV_Turnos_totales.DataSource = misTurnos;
                DGV_Turnos_totales.DataBind();
            }
            else if (usuarioActual.Tipo == "Médico")
            {
                dgv_Turnos_Medicos.DataSource = misTurnos;
                dgv_Turnos_Medicos.DataBind();
            }
            else
            {
                Dgv_Turnos_Paciente.DataSource = misTurnos; 
                Dgv_Turnos_Paciente.DataBind();
            }
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
            }else if (usuarioActual.Tipo == "Recepcionista" || usuarioActual.Tipo == "Administrador")
            {
                foreach (Turno turno in clinica.Turnos)
                {     
                    misTurnos.Add(turno);   
                }
            }
        }
        private Turno Get_Turno(int ID)
        {
            foreach (Turno turno in clinica.Turnos)
            {
                if (ID == turno.Id)
                {
                    return turno;
                }
            }
            return new Turno();
        }
        protected void dgv_Turnos_Pacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ID_Turno = Dgv_Turnos_Paciente.SelectedRow.Cells[0].Text;
            int ID_Turno = int.Parse(str_ID_Turno);
            Turno_Seleccionado = Get_Turno(ID_Turno);
            Baja_Logica_Turno(Turno_Seleccionado);
        }
        protected void DGV_Turnos_totales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DGV_Turnos_totales.SelectedIndex >= 0)
            {
                string str_ID_Turno = DGV_Turnos_totales.SelectedRow.Cells[0].Text;
                int ID_Turno = int.Parse(str_ID_Turno);
                Turno_Seleccionado = Get_Turno(ID_Turno);
            }
        }
        protected void DGV_Turnos_totales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Esta funcion no se esta usando, no se como usarla.
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = DGV_Turnos_totales.Rows[index];

                string idTurno = selectedRow.Cells[0].Text;
                int ID_Turno = int.Parse(idTurno);
                Turno_Seleccionado = Get_Turno(ID_Turno);

                if (e.CommandName == "Modificar")
                {
                    MessageBox.Show("Funciona Cancelar");
                    // Baja_Logica_Turno(Turno_Seleccionado);
                }
                else if (e.CommandName == "Cancelar")
                {
                    MessageBox.Show("Funciona Modificar");
                }
            }
        }

        private void Baja_Logica_Turno(Turno turno_Seleccionado)
        {

        }

        protected void dgv_Turnos_Medicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ID_Turno = Dgv_Turnos_Paciente.SelectedRow.Cells[0].Text;
            int ID_Turno = int.Parse(str_ID_Turno);
            Turno_Seleccionado = Get_Turno(ID_Turno);
            //mostrar en otra pagina los detalles del turno y el hecho de poder agregarle la observacion
        }
    }
}