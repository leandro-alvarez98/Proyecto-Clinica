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
        public  Usuario usuarioActual;
        Medico medicoActual;
        Paciente pacienteActual;
        List<Turno> misTurnos;
        List<Turno> turnos_x_dni;
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
        public void Cargar_turnos_x_Dni(string dni)
        {
            foreach (Turno turno in clinica.Turnos)
            {
                foreach (Paciente paciente in clinica.Pacientes)
                {
                    if(paciente.Dni == dni && paciente.Id == turno.Id_Paciente)
                    {
                        turnos_x_dni.Add(turno);
                    }
                }
            }
        }

        //GRILLA PARA PACIENTES, SOLO PUEDE CANCELAR EL TURNO 
        protected void DGV_Turnos_Pacientes_Cancelar(object sender, EventArgs e)
        {

            string script = @"
                $(document).ready(function () {
                    $('#Modal_cancelar_turno').modal('show');
                });
            ";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);          
;           
        }
        //GRILLA PARA RECEPCIONISTA Y ADMIN, PUEDEN CANCELAR Y MODIFICAR EL TURNO 
        protected void DGV_Turnos_totales_Cancelar_Modificar(object sender, EventArgs e)
        {
         
                string str_ID_Turno = DGV_Turnos_totales.SelectedRow.Cells[0].Text;
                int ID_Turno = int.Parse(str_ID_Turno);
                Turno_Seleccionado = Get_Turno(ID_Turno);

                Session["Turno"] = Turno_Seleccionado;
            
                Response.Redirect("Detalle_turno.aspx");
            
        }
        //GRILLA PARA MEDICO
        protected void dgv_Turnos_Medicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID_Turno = int.Parse(dgv_Turnos_Medicos.SelectedRow.Cells[0].Text);
            Turno_Seleccionado = Get_Turno(ID_Turno);

            if(Turno_Seleccionado.Estado == "Finalizado")
            {
                Session["Turno"] = Turno_Seleccionado;
                Response.Redirect("Detalle_turno.aspx");
            }
            else
            {
                lblTurnoNoFinalizado.Visible = true;
            }
        }
        protected void Btn_busqueda_Click(object sender, EventArgs e)
        {
            try
            {
                turnos_x_dni = new List<Turno>();
                string dni_paciente = Txt_Busqueda.Text;
                Cargar_turnos_x_Dni(dni_paciente);

                //limpia la grilla actual
                DGV_Turnos_totales.DataSource = null;
                DGV_Turnos_totales.DataBind();
                //cargar la nueva grilla de datos 
                DGV_Turnos_totales.DataSource = turnos_x_dni;
                DGV_Turnos_totales.DataBind();
                if (turnos_x_dni.Count() == 0)
                {
                    Lbl_sin_turnos.Visible = true;
                }
                else
                {
                    Lbl_sin_turnos.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
           
        }
        protected void Btn_limpiar_busqueda_Click(object sender, EventArgs e)
        {
            //limpia la grilla actual
            DGV_Turnos_totales.DataSource = null;
            DGV_Turnos_totales.DataBind();
            //cargar la nueva grilla de datos 
            DGV_Turnos_totales.DataSource = misTurnos;
            DGV_Turnos_totales.DataBind();
            if(misTurnos.Count() != 0)
            {
                Lbl_sin_turnos.Visible=false;
            }
        }

        protected void Btn_aceptar_cancelar_turno_Click(object sender, EventArgs e)
        {
            string str_ID_Turno = Dgv_Turnos_Paciente.SelectedRow.Cells[0].Text;
            int ID_Turno = int.Parse(str_ID_Turno);
            Turno_Seleccionado = Get_Turno(ID_Turno);

            TurnoConexion turno_conexion = new TurnoConexion();

            // si la fecha en la que esta cancelando el turno es mayor a la fecha del turno en si 
            // tiene que activarse de nuevo sino queda como cancelado
            if(DateTime.Today > Turno_Seleccionado.Fecha)
            {
                turno_conexion.Activar_Turno(Turno_Seleccionado.Id);
            }
            else
            {
                turno_conexion.Cancelar_Turno(Turno_Seleccionado.Id);
            }

            Response.Redirect("MisTurnos.aspx");
        }
    }
}