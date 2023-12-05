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
        Turno Turno_Seleccionado;
        public  Usuario usuarioActual;
        Medico medicoActual;
        Paciente pacienteActual;

        List<Turno> misTurnos_totales;
        List<Turno> TurnosCancelados;
        List<Turno> turnos_x_dni;
        List<Turno> Turnos_del_dia;
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
            usuarioActual = (Usuario)Session["Usuario"];

            Turno_Seleccionado = new Turno();
            misTurnos_totales = new List<Turno>();
            

            if (usuarioActual.Tipo == "Médico")
            {
                medicoActual = new Medico();
                medicoActual = Cargar_Médico_Clinica();
            }
            else if (usuarioActual.Tipo == "Paciente")
            {
                pacienteActual = new Paciente();
                pacienteActual = Cargar_Paciente_Clinica();
                TurnosCancelados = CargarTurnosCancelados(pacienteActual.Id);
            }

            Cargar_Turnos();
            

            if(usuarioActual.Tipo == "Recepcionista" || usuarioActual.Tipo == "Administrador")
            {
                TurnosCancelados = CargarTurnosCancelados();
                DGV_Turnos_totales.DataSource = misTurnos_totales;
                DGV_Turnos_totales.DataBind();
            }
            else if (usuarioActual.Tipo == "Médico")
            {
                dgv_Turnos_Medicos.DataSource = misTurnos_totales;
                dgv_Turnos_Medicos.DataBind();
            }
            else
            {
                Dgv_Turnos_Paciente.DataSource = misTurnos_totales; 
                Dgv_Turnos_Paciente.DataBind();
            }
        }

        private void Cargar_Turnos()
        {
            if (usuarioActual.Tipo == "Médico")
            {
                foreach (Turno turno in clinica.Turnos)
                {
                    if (medicoActual.Id == turno.Id_Medico)
                    {
                        misTurnos_totales.Add(turno);
                    }
                }
            }
            else if (usuarioActual.Tipo == "Paciente")
            {
                foreach (Turno turno in clinica.Turnos)
                {
                    if (pacienteActual.Id == turno.Id_Paciente)
                    {
                        misTurnos_totales.Add(turno);
                    }
                }
            }else if (usuarioActual.Tipo == "Recepcionista" || usuarioActual.Tipo == "Administrador")
            {
                foreach (Turno turno in clinica.Turnos)
                {
                    misTurnos_totales.Add(turno);   
                }
            }
        }
        private List<Turno> CargarTurnosCancelados()
        {
            TurnoConexion turnoConexion = new TurnoConexion();

            List<Turno> turnosCancelados = new List<Turno>();

            foreach (Turno turno in turnoConexion.Listar_Turnos_cancelados())
            {
                turnosCancelados.Add(turno);
            }
            return turnosCancelados;
        }
        private List<Turno> CargarTurnosCancelados(int IdPaciente)
        {
            TurnoConexion turnoConexion = new TurnoConexion();
            List<Turno> turnosCancelados = new List<Turno>();
            foreach (Turno turno in turnoConexion.Listar_Turnos_cancelados())
            {
                if(IdPaciente == turno.Id_Paciente)
                {
                    turnosCancelados.Add(turno);
                }
            }
            return turnosCancelados;
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
        public void Cargar_turnos_x_Dni(string dni,int id_medico)
        {
            foreach (Turno turno in clinica.Turnos)
            {
                foreach (Paciente paciente in clinica.Pacientes)
                {
                    if (paciente.Dni == dni && paciente.Id == turno.Id_Paciente && id_medico == turno.Id_Medico)
                    {
                        turnos_x_dni.Add(turno);
                    }
                }
            }
        }
        public void Cargar_turnos_del_dia()
        {
            Turnos_del_dia = new List<Turno>();
            foreach (Turno turno in misTurnos_totales)
            {
                if(turno.Fecha == DateTime.Today)
                {
                    Turnos_del_dia.Add(turno);
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
        protected void Btn_aceptar_cancelar_turno_Click(object sender, EventArgs e)
        {
            string str_ID_Turno = Dgv_Turnos_Paciente.SelectedRow.Cells[0].Text;
            int ID_Turno = int.Parse(str_ID_Turno);
            Turno_Seleccionado = Get_Turno(ID_Turno);
            TurnoConexion turno_conexion = new TurnoConexion();
            turno_conexion.Insertar_Turno_Cancelado(Turno_Seleccionado);
            turno_conexion.EliminarTurno(ID_Turno);
            Response.Redirect("MisTurnos.aspx");
        }
        protected void Btn_VerTurnosCanceladosPaciente_Click(object sender, EventArgs e)
        {
            Dgv_Turnos_Paciente.DataSource = null;
            Dgv_Turnos_Paciente.DataBind();

            //cargar la nueva grilla de datos 
            Dgv_Turnos_Paciente.DataSource = TurnosCancelados;
            Dgv_Turnos_Paciente.DataBind();
            DGV_Turnos_totales.Columns[10].Visible = false;



            if (TurnosCancelados.Count() != 0)
            {
                LblPacienteSinTurnosCancelados.Visible = false;
            }
            else
            {
                LblPacienteSinTurnosCancelados.Visible = true;
            }
        }
        protected void Btn_LimpiarGrillaPacientes_Click(object sender, EventArgs e)
        {
            Dgv_Turnos_Paciente.DataSource = null;
            Dgv_Turnos_Paciente.DataBind();
            //cargar la nueva grilla de datos 
            Dgv_Turnos_Paciente.DataSource = misTurnos_totales;
            Dgv_Turnos_Paciente.DataBind();

            if (misTurnos_totales.Count() != 0)
            {
                Lbl_sin_turnos.Visible = false;
            }
            else
            {
                Lbl_sin_turnos_hoy.Visible = false;
            }
        }

                             //EVENTOS DE BUSQUEDA COMO ADMIN Y RECEP
        //GRILLA PARA RECEPCIONISTA Y ADMIN, PUEDEN CANCELAR Y MODIFICAR EL TURNO 
        protected void DGV_Turnos_totales_Cancelar_Modificar(object sender, EventArgs e)
        {

            string str_ID_Turno = DGV_Turnos_totales.SelectedRow.Cells[0].Text;
            int ID_Turno = int.Parse(str_ID_Turno);
            Turno_Seleccionado = Get_Turno(ID_Turno);

            Session["Turno"] = Turno_Seleccionado;

            Response.Redirect("Detalle_turno.aspx");

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
                Lbl_sin_turnos_hoy.Visible = false;
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
            DGV_Turnos_totales.DataSource = misTurnos_totales;
            DGV_Turnos_totales.DataBind();
            if(misTurnos_totales.Count() != 0)
            {
                Lbl_sin_turnos.Visible=false;
            }
            else
            {
                Lbl_sin_turnos_hoy.Visible = false;
            }
        }
        protected void Ver_turnos_del_dia_RA_Click(object sender, EventArgs e)
        {
            Cargar_turnos_del_dia();
            //limpia la grilla actual
            DGV_Turnos_totales.DataSource = null;
            DGV_Turnos_totales.DataBind();
            //cargar la nueva grilla de datos 
            DGV_Turnos_totales.DataSource = Turnos_del_dia;
            DGV_Turnos_totales.DataBind();
            if (Turnos_del_dia.Count() != 0)
            {
                Lbl_sin_turnos_hoy.Visible = false;
            }
            else
            {
                Lbl_sin_turnos_hoy.Visible = true;
            }
        }
        protected void Btn_VerTurnosCancelados_Click(object sender, EventArgs e)
        {
            CargarTurnosCancelados();
            DGV_Turnos_totales.DataSource = null;
            DGV_Turnos_totales.DataBind();
            //cargar la nueva grilla de datos 
            DGV_Turnos_totales.DataSource = TurnosCancelados;
            DGV_Turnos_totales.DataBind();
            DGV_Turnos_totales.Columns[10].Visible = false;

            if (TurnosCancelados.Count() != 0)
            {
                lbl_SinTurnosCancelados.Visible = false;
            }
            else
            {
                lbl_SinTurnosCancelados.Visible = true;
            }

        }

                                //EVENTOS DE BUSQUEDA COMO MEDICO
        //GRILLA PARA MEDICO
        protected void dgv_Turnos_Medicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID_Turno = int.Parse(dgv_Turnos_Medicos.SelectedRow.Cells[0].Text);
            Turno_Seleccionado = Get_Turno(ID_Turno);

            if (Turno_Seleccionado.Estado == "Finalizado")
            {
                Session["Turno"] = Turno_Seleccionado;
                Response.Redirect("Detalle_turno.aspx");
            }
            else
            {
                lblTurnoNoFinalizado.Visible = true;
            }
        }
        protected void Limpiar_turno_Click(object sender, EventArgs e)
        {
            //limpia la grilla actual
            dgv_Turnos_Medicos.DataSource = null;
            dgv_Turnos_Medicos.DataBind();
            //cargar la nueva grilla de datos 
            dgv_Turnos_Medicos.DataSource = misTurnos_totales;
            dgv_Turnos_Medicos.DataBind();
            if (misTurnos_totales.Count() != 0)
            {
                Lbl_sin_turnos_dni.Visible = false;
            }
            Lbl_sin_turnos_hoy_m.Visible = false;
        }
        protected void Buscar_turno_Click(object sender, EventArgs e)
        {
            try
            {
                turnos_x_dni = new List<Turno>();
                string dni_paciente = Txt_buscar_turno.Text;
                Cargar_turnos_x_Dni(dni_paciente,medicoActual.Id);

                //limpia la grilla actual
                dgv_Turnos_Medicos.DataSource = null;
                dgv_Turnos_Medicos.DataBind();
                //cargar la nueva grilla de datos 
                dgv_Turnos_Medicos.DataSource = turnos_x_dni;
                dgv_Turnos_Medicos.DataBind();
                if (turnos_x_dni.Count() == 0)
                {
                    Lbl_sin_turnos_dni.Visible = true;
                }
                else
                {
                    Lbl_sin_turnos_dni.Visible = false;
                }
                Lbl_sin_turnos_hoy_m.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
        protected void Ver_turnos_del_dia_Click(object sender, EventArgs e)
        {
            Cargar_turnos_del_dia();
            //limpia la grilla actual
            dgv_Turnos_Medicos.DataSource = null;
            dgv_Turnos_Medicos.DataBind();
            //cargar la nueva grilla de datos 
            dgv_Turnos_Medicos.DataSource = Turnos_del_dia;
            dgv_Turnos_Medicos.DataBind();
            if (Turnos_del_dia.Count() != 0)
            {
                Lbl_sin_turnos_hoy_m.Visible = false;
            }
            else
            {
                Lbl_sin_turnos_hoy_m.Visible = true;
            }
        }

    }
}