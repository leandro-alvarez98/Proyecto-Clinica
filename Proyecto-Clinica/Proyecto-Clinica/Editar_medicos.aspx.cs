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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

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

            cargarDatosMedicos();

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
            //---- evalua las expresiones de enlace de datos
            Page.DataBind();

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
            try
            {
                if (rbl_Jornada.SelectedValue != null)
                {
                    if (int.TryParse(rbl_Jornada.SelectedValue, out int indiceSeleccionado))
                    {
                        if (indiceSeleccionado > 0 && indiceSeleccionado <= Clinica.Jornadas.Count)
                        {
                            int jornadaSeleccionada = Clinica.Jornadas[indiceSeleccionado - 1].Id;
                            AsignarJornadaEnBaseDeDatos(Medico_actual.Id, jornadaSeleccionada);
                            Response.Redirect("Editar_medicos.aspx");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones si es necesario.
                throw ex;
            }


        }
        private void AsignarJornadaEnBaseDeDatos(int idMedico, int idJornada)
        {
            JornadaConexion jornadaConexion = new JornadaConexion();
            jornadaConexion.Insertar_Jornada(idMedico, idJornada);
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
            try
            {
                if (rbl_Especialidades.SelectedValue != null && int.TryParse(rbl_Especialidades.SelectedValue, out int indiceSeleccionado))
                {
                    if (indiceSeleccionado > 0 && indiceSeleccionado <= Clinica.Especialidades.Count)
                    {
                        int especialidadSeleccionada = Clinica.Especialidades[indiceSeleccionado - 1].Id;

                        if (especialidadSeleccionada > 0)
                        {
                            AsignarEspecialidadEnBaseDeDatos(Medico_actual.Id, especialidadSeleccionada);
                            Response.Redirect("Editar_medicos.aspx");
                            string mensaje = "La acción se ha completado con éxito.";

                            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMensajeModal", $"mostrarMensajeModal('{mensaje}');", true);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones si es necesario.
                throw ex;
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
            try
            {
                if (rbl_Elimina_Especialidad.SelectedValue != null && int.TryParse(rbl_Elimina_Especialidad.SelectedValue, out int indiceSeleccionado))
                {
                    if (indiceSeleccionado > 0 && indiceSeleccionado <= Clinica.Especialidades.Count)
                    {
                        int especialidadSeleccionada = Clinica.Especialidades[indiceSeleccionado - 1].Id;

                        if (especialidadSeleccionada > 0)
                        {
                            EliminarMedicoxEspecialidad(Medico_actual.Id, especialidadSeleccionada);
                            Response.Redirect("Editar_medicos.aspx");
                        }
                        else
                        {
                            // Manejar el caso en que especialidadSeleccionada no es mayor que 0.
                            // Puedes mostrar un mensaje de error o realizar otras acciones.
                            //    lbl_sin_datos.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones si es necesario.
                throw ex;
            }
        }


        private void EliminarMedicoxEspecialidad(int idMedico, int idEspecialidad)
        {
            EspecialidadesConexion especialidadesConexion = new EspecialidadesConexion();
            especialidadesConexion.EliminarEspecialidadxMedico(idMedico, idEspecialidad);
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
            try
            {
                if (rbl_Eliminar_Jornada.SelectedValue != null && int.TryParse(rbl_Eliminar_Jornada.SelectedValue, out int indiceSeleccionado))
                {
                    if (indiceSeleccionado > 0 && indiceSeleccionado <= Clinica.Jornadas.Count)
                    {
                        int jornadaSeleccionada = Clinica.Jornadas[indiceSeleccionado - 1].Id;

                        if (jornadaSeleccionada >= 0)
                        {
                            EliminarMedicoxJornada(Medico_actual.Id, jornadaSeleccionada);
                            Response.Redirect("Editar_medicos.aspx");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones si es necesario.
                throw ex;
            }
        }


        private void EliminarMedicoxJornada(int idMedico, int idJornada)
        {
            JornadaConexion jornadaConexion = new JornadaConexion();
            jornadaConexion.Eliminar_Jornada(idMedico, idJornada);
        }

        protected void bntEditarMedico_Click(object sender, EventArgs e)
        {
            
            ScriptManager.RegisterStartupScript(this, GetType(), "OcultarDropdown", "ocultarDropdown();", true);


            txtNombreEdit.Visible = true;
            txtApellidoEdit.Visible = true;
            txtDniEdit.Visible = true;
            txtMailEdit.Visible = true;
            txtTelefonoEdit.Visible = true;
            txtDireccionEdit.Visible = true;
            txtFechaNacimientoEdit.Visible = true;

            // Asigna los valores actuales a los controles de edición
            txtNombreEdit.Text = Medico_actual.Nombre;
            txtApellidoEdit.Text =  Medico_actual.Apellido;
            txtDniEdit.Text =  Medico_actual.Dni;
            txtMailEdit.Text =  Medico_actual.Mail;
            txtTelefonoEdit.Text =  Medico_actual.Telefono;
            txtDireccionEdit.Text =  Medico_actual.Direccion;
            txtFechaNacimientoEdit.Text =  Medico_actual.Fecha_Nacimiento.ToString("yyyy-MM-dd");

            // Oculta los controles de visualización
            nombrelbl.Visible = false;
            apellidoLbl.Visible = false;
            dniLbl.Visible = false;
            emailLbl.Visible = false;
            telefonoLbl.Visible = false;
            direccionLbl.Visible = false;
            fechaNacimientoLbl.Visible = false;

            // Muestra los botones de Guardar y Cancelar
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;

            // Oculta el botón de Editar
            btnEditarMedico.Visible = false;

        }
        public void cargarDatosMedicos()
        {
            if (Medico_actual != null)
            {
                nombrelbl.Text = Medico_actual.Nombre;
                apellidoLbl.Text = Medico_actual.Apellido;
                dniLbl.Text = Medico_actual.Dni.ToString();
                emailLbl.Text = Medico_actual.Mail;
                telefonoLbl.Text = Medico_actual.Telefono;
                direccionLbl.Text = Medico_actual.Direccion;
                fechaNacimientoLbl.Text = Medico_actual.Fecha_Nacimiento.ToString("yyyy-MM-dd");
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool nombreValido = true, apellidoValido = true, telefonoValido = true, emailValido = true, direccionValido = true, fechaNacimientoValido = true, dniValido = true;
            

            if (!Validaciones.EsNumero(txtDniEdit.Text))
            {
                lblErrorDni.Visible = true;
                dniValido = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "OcultarDropdown", "ocultarDropdown();", true);
            }
            if (!Validaciones.EsNumero(txtTelefonoEdit.Text))
            {
                lblErrorTelefono.Visible = true;
                telefonoValido = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "OcultarDropdown", "ocultarDropdown();", true);

            }
            if (Validaciones.ContieneNumeros(txtNombreEdit.Text))
            {
                lblErrorNombre.Visible = true;
                nombreValido = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "OcultarDropdown", "ocultarDropdown();", true);
            }
            if (Validaciones.ContieneNumeros(txtApellidoEdit.Text))
            {
                lblErrorApellido.Visible = true;
                apellidoValido = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "OcultarDropdown", "ocultarDropdown();", true);
            }

            if (!Validaciones.EsFormatoCorreoElectronico(txtMailEdit.Text))
            {
                lblErrorMail.Visible = true;
                emailValido = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "OcultarDropdown", "ocultarDropdown();", true);
            }
           

            if (nombreValido && apellidoValido && telefonoValido && emailValido && direccionValido && fechaNacimientoValido && dniValido)
            {
                Ocultar_labels_Error();

                if (Medico_actual.Nombre == null)
                {
                    InsertarDatosEnBBDD();
                }
                else
                {


                    ActualizarDatosEnBBDD();
                }
            }
            
        }
        public void Ocultar_labels_Error()
        {
            lblErrorDni.Visible = false;

            lblErrorTelefono.Visible = false;

            lblErrorNombre.Visible = false;

            lblErrorApellido.Visible = false;

            lblErrorMail.Visible = false;

        }
        private void ActualizarDatosEnBBDD()
        {

            // guardamos los valores editados de los TextBox
            string nuevoNombre = txtNombreEdit.Text;
            string nuevoApellido = txtApellidoEdit.Text;
            string nuevoDni = txtDniEdit.Text;
            string nuevoMail = txtMailEdit.Text;
            string nuevoTelefono = txtTelefonoEdit.Text;
            string nuevaDireccion = txtDireccionEdit.Text;
            DateTime nuevaFechaNacimiento = DateTime.Parse(txtFechaNacimientoEdit.Text);


            // Actualizar los datos del paciente

            if (Medico_actual != null)
            {
                Medico medicoActualizado = new Medico 
                {
                    Id_Usuario = Medico_actual.Id_Usuario,
                    Dni = nuevoDni,
                    Nombre = nuevoNombre,
                    Apellido = nuevoApellido,
                    Mail = nuevoMail,
                    Telefono = nuevoTelefono,
                    Direccion = nuevaDireccion,
                    Fecha_Nacimiento = nuevaFechaNacimiento
                };

                UsuarioConexion conexionMedico = new UsuarioConexion();
                conexionMedico.ActualizarMedico(medicoActualizado);

                // Oculta el TextBox y botón de guardar
                OcultarControlesEdicion();
                // Redirecciona a la misma página para refrescar los datos
                Response.Redirect(Request.RawUrl);
            }

        }
        private void InsertarDatosEnBBDD()
        {
            string nuevoDni = txtDniEdit.Text;
            string nuevoNombre = txtNombreEdit.Text;
            string nuevoApellido = txtApellidoEdit.Text;
            string nuevoMail = txtMailEdit.Text;
            string nuevoTelefono = txtTelefonoEdit.Text;
            string nuevaDireccion = txtDireccionEdit.Text;
            DateTime nuevaFechaNacimiento = DateTime.Parse(txtFechaNacimientoEdit.Text);

            UsuarioConexion usuarioConexion = new UsuarioConexion();
            Medico_actual.Dni = nuevoDni;
            Medico_actual.Nombre = nuevoNombre;
            Medico_actual.Apellido = nuevoApellido;
            Medico_actual.Mail = nuevoMail;
            Medico_actual.Direccion = nuevaDireccion;
            Medico_actual.Fecha_Nacimiento = nuevaFechaNacimiento;
            usuarioConexion.ActualizarMedico(Medico_actual);
        }
        private void OcultarControlesEdicion()
        {
            //ocultar TextBox y boton de guardar
            Visibilidad_Texbox(false);

            //Ocultar botón de guardar
            btnGuardar.Visible = false;
            btnEditarMedico.Visible = true;
        }
        public void Visibilidad_Texbox(bool valor)
        {
            txtDniEdit.Visible = valor;
            txtNombreEdit.Visible = valor;
            txtApellidoEdit.Visible = valor;
            txtMailEdit.Visible = valor;
            txtTelefonoEdit.Visible = valor;
            txtDireccionEdit.Visible = valor;
            txtFechaNacimientoEdit.Visible = valor;
        }

        public void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancelar.Visible = false;
            OcultarControlesEdicion();
            Visibilidad_labels(true);
            Cargar_labels();
            Ocultar_labels_Error();




        }
        public void Cargar_labels()
        {
            dniLbl.Text = Medico_actual.Dni.ToString();
            apellidoLbl.Text = Medico_actual.Apellido;
            nombrelbl.Text = Medico_actual.Nombre;
            emailLbl.Text = Medico_actual.Mail;
            telefonoLbl.Text = Medico_actual.Telefono;
            direccionLbl.Text = Medico_actual.Direccion;
            fechaNacimientoLbl.Text = Medico_actual.Fecha_Nacimiento.ToString("d/M/yyyy");
        }
        public void Visibilidad_labels(bool valor)
        {
            dniLbl.Visible = valor;
            nombrelbl.Visible = valor;
            apellidoLbl.Visible = valor;
            emailLbl.Visible = valor;
            telefonoLbl.Visible = valor;
            direccionLbl.Visible = valor;
            fechaNacimientoLbl.Visible = valor;
        }
        
    }

}