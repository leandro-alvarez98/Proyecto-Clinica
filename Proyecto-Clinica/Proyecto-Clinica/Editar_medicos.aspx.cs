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
            Medico_actual = (Medico)Session["Medico"];
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            Clinica = clinicaConexion.Listar();
            EspecialidadesConexion especialidadesConexion = new EspecialidadesConexion();
            Clinica.Especialidades = especialidadesConexion.Listar_2();
            lista_Especialidades_Faltantes = new List<Especialidad>();
            lista_Jornadas_Faltantes = new List<Jornada>();


            //Busca las especialidades que no tiene el medico 
            CargarEspecialidadesFaltantes();

            //Busca las jornadas que no tiene el medico 
            CargarJornadaFaltante();


            if (!IsPostBack)
            {
                repeaterJornadas.DataSource = Medico_actual.Jornadas;
                repeaterJornadas.DataBind();
                repeaterEspecialidades.DataSource = Medico_actual.Especialidades;
                repeaterEspecialidades.DataBind();
            }
        }

        //MODAL JORNADA
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
        //MODAL ESPECIALIDADES

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
        //BTN DEL MODAL/EVENTO PARA GUARDAR LO SELECCIONADO
        protected void btn_ActualizarJornada_Click(object sender, EventArgs e)
        {

        }

        //SELECCION DEL RADIO BUTTON
        protected void rbl_Especialidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_ActualizarEspecialidad_Click(object sender, EventArgs e)
        {
            int indiceSeleccionado = int.Parse(rbl_Especialidades.SelectedValue);
            string especialidadSeleccionada = lista_Especialidades_Faltantes[indiceSeleccionado - 1].Tipo;
           
            if (!string.IsNullOrEmpty(especialidadSeleccionada))
            {
                GuardarEspecialidadEnBaseDeDatos(Medico_actual.Id, especialidadSeleccionada);

        //        string script = @"
        //    $(document).ready(function () {
        //        $('#mod_ElegirEspecialidad').modal('show');
        //    });
        //";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
            }

        }
        // MEtodo para guardar la especialidad en la base de datos, no esta guardando bien los datos
        private void GuardarEspecialidadEnBaseDeDatos(int idMedico, string especialidad)
        {
            try
            {
                EspecialidadesConexion especialidadesConexion = new EspecialidadesConexion();
                especialidadesConexion.Insertar_Especialidad_En_BBDD(especialidad);

                especialidadesConexion.AsignarEspecialidadAMedico(idMedico, especialidad);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private Medico GetMedico(int id)
        {
            foreach (Medico medico in Clinica.Medicos)
            {
                if (medico.Id == id)
                    return medico;
            }
            return new Medico();
        }
        //MODAL ELIMINAR ESPECIALIDAD
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


        //MODAL ELIMINAR JORNADA

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





        protected void btn_Eliminar_Jornada_Click(object sender, EventArgs e)
        {

        }

        protected void btn_Eliminar_Especialidad_Click1(object sender, EventArgs e)
        {

        }
    }
}