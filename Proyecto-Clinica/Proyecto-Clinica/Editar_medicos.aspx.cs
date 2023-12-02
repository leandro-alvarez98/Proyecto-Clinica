using Conexion_Clinica;
using Dominio;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Clinica
{
    public partial class Editar_medicos : System.Web.UI.Page
    {
        public Medico Medico_actual;
        public Clinica Clinica;
        List<Especialidad> lista_Especialidades_Faltantes;
        List<Jornada> lista_Jornadas_Faltantes;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            Clinica = clinicaConexion.Listar();
            EspecialidadesConexion especialidadesConexion = new EspecialidadesConexion();
            Clinica.Especialidades = especialidadesConexion.Listar_2();

            int Id_Medico_Seleccionado = ((Medico)Session["Medico"]).Id;
            Medico_actual = Cargar_Médico_Clinica(Id_Medico_Seleccionado);


            lista_Especialidades_Faltantes = new List<Especialidad>();
            CargarEspecialidadesFaltantes();

            lista_Jornadas_Faltantes = new List<Jornada>();
            CargarJornadaFaltante();

            // Especialidades de la Card
            repeaterEspecialidades.DataSource = Medico_actual.Especialidades;
            repeaterEspecialidades.DataBind();

            // Jornadas de la Card
            repeaterJornadas.DataSource = Medico_actual.Jornadas;
            repeaterJornadas.DataBind();
        }
        private Medico Cargar_Médico_Clinica(int medico_id)
        {
            foreach (Medico medico in Clinica.Medicos)
            {
                if (medico.Id == medico_id)
                {
                    return medico;
                }
            }
            return new Medico();
        }
        private void CargarJornadaFaltante()
        {

            foreach (Jornada jornada in Clinica.Jornadas)
            {
                bool jornadaAsignada = false;

                foreach (Jornada jor in Medico_actual.Jornadas)
                {
                    if (jornada.Id == jor.Id)
                    {
                        jornadaAsignada = true;
                        break; // La especialidad ya está asignada, no es necesario verificar más
                    }
                }

                if (!jornadaAsignada)
                {
                    // La especialidad no está asignada al médico actual
                    lista_Jornadas_Faltantes.Add(jornada);
                }
            }
        }
        private void CargarEspecialidadesFaltantes()
        {
            foreach (Especialidad especialidad in Clinica.Especialidades)
            {
                bool especialidadAsignada = false;

                foreach (Especialidad esp in Medico_actual.Especialidades)
                {
                    if (especialidad.Id == esp.Id)
                    {
                        especialidadAsignada = true;
                        break; // La especialidad ya está asignada, no es necesario verificar más
                    }
                }

                if (!especialidadAsignada)
                {
                    // La especialidad no está asignada al médico actual
                    lista_Especialidades_Faltantes.Add(especialidad);
                }
            }
        }

        // ------------------ MODAL AGREGAR JORNADA ------------------
        // Abre el modal
        protected void btn_SeleccionarMedicoJornada_Click(object sender, EventArgs e)
        {
            rbl_Jornada.DataSource = lista_Jornadas_Faltantes;
            rbl_Jornada.DataTextField = "Tipo";
            rbl_Jornada.DataValueField = "Id";
            rbl_Jornada.DataBind();

            string script = @"
                $(document).ready(function () {
                    $('#mod_ElegirJornada').modal('show');
                });
            ";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
        }
        // Toma la Jornada elegida y la Agrega
        protected void btn_ActualizarJornada_Click(object sender, EventArgs e)
        {

        }


        // ------------------ MODAL AGREGAR ESPECIALIDAD ------------------
        // Abre el modal
        protected void btn_SeleccionarMedicoEspecialidad_Click(object sender, EventArgs e)
        {

            rbl_Especialidades.DataSource = lista_Especialidades_Faltantes;
            rbl_Especialidades.DataTextField = "Tipo";
            rbl_Especialidades.DataValueField = "Id";
            rbl_Especialidades.DataBind();

            string script = @"
                $(document).ready(function () {
                    $('#mod_ElegirEspecialidad').modal('show');
                });
            ";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
        }
        // Toma la Especialidad elegida y la Agrega
        protected void btn_ActualizarEspecialidad_Click(object sender, EventArgs e)
        {
            int indiceSeleccionado = int.Parse(rbl_Especialidades.SelectedValue);
            int especialidadSeleccionada = Clinica.Especialidades[indiceSeleccionado - 1].Id;
           
            if (especialidadSeleccionada > 0)
            {
                AsignarEspecialidadEnBaseDeDatos(Medico_actual.Id, especialidadSeleccionada);
                Response.Redirect("Editar_medicos.aspx");
            }
        }
        private void AsignarEspecialidadEnBaseDeDatos(int idMedico, int idEspecialidad)
        {
            try
            {
                EspecialidadesConexion especialidadesConexion = new EspecialidadesConexion();
                especialidadesConexion.AsignarEspecialidadAMedico(idMedico, idEspecialidad);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        // ------------------ MODAL ELIMINAR ESPECIALIDAD ------------------
        // Abre el modal
        protected void btn_EliminarEspecialidad_Click(object sender, EventArgs e)
        {
            rbl_Elimina_Especialidad.DataSource = Medico_actual.Especialidades;
            rbl_Elimina_Especialidad.DataTextField = "Tipo";
            rbl_Elimina_Especialidad.DataValueField = "Id";
            rbl_Elimina_Especialidad.DataBind();
            // Abre el modal correspondiente
            string script = @"
        $(document).ready(function () {
            $('#mod_eliminarEspecialidad').modal('show');
        });
    ";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
        }
        // Toma la especialidad a eliminar y la elimina.
        protected void btn_Seleccionar_Especialidad_a_Eliminar_Click(object sender, EventArgs e)
        {

        }


        // ------------------ MODAL ELIMINAR JORNADA ------------------
        // Abre el modal
        protected void btn_EliminarJornada_Click(object sender, EventArgs e)
        {
            rbl_Eliminar_Jornada.DataSource = Medico_actual.Jornadas;
            rbl_Eliminar_Jornada.DataTextField = "Tipo";
            rbl_Eliminar_Jornada.DataValueField = "Id";
            rbl_Eliminar_Jornada.DataBind();

            // Abre el modal correspondiente (desde el lado del cliente)
            string script = @"
        $(document).ready(function () {
            $('#mod_eliminarJornada').modal('show');
        });
    ";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "MostrarModal", script, true);
        }
        // Toma la jornada elegida y la elimina.
        protected void btn_Eliminar_Jornada_Click(object sender, EventArgs e)
        {

        }

    }
}