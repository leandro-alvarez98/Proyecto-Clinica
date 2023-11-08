using Conexion_Clinica;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class Perfil_Usuario : System.Web.UI.Page
    {
        public Usuario Usuario_Actual = null;
        Paciente paciente_actual = null;
        Medico Medico_actual = null;   

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cargar_Componentes();
            }
        }
        private void Cargar_Componentes()
        {
            Master_page master = (Master_page)this.Master;
            master.Mostrar_menu_lateral();

            if (Usuario_Actual == null)
            {
                Usuario_Actual = new Usuario();

                Usuario_Actual = (Usuario)Session["Usuario"];

                Cargar_usuario();
              
            }

        }
        private void Cargar_usuario()
        {
            int id = Usuario_Actual.Id;
            string tipo = Usuario_Actual.Tipo;
            if (tipo == "Paciente")
            {
                paciente_actual = Datos_Paciente(id);
                Cargar_label_Paciente();
            }else if (tipo == "Médico")
            {
                Medico_actual = Datos_medico(id);
                Cargar_label_Medico();
            }

        }
        public Medico Datos_medico(int id_usuario)
        {
            Medico Medico = new Medico();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("Select ID_MEDICO, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO FROM MEDICOS WHERE ID_USUARIO = @IDUSUARIO");
                datos.setParametro("@IDUSUARIO", id_usuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medico.Id = (int)datos.Lector["ID_MEDICO"];

                    Medico.Nombre = (String)datos.Lector["NOMBRE"];

                    Medico.Apellido = (String)datos.Lector["APELLIDO"];

                    Medico.Telefono = (String)datos.Lector["TELEFONO"];

                    Medico.Direccion = (String)datos.Lector["DIRECCION"];

                    Medico.Fecha_Nacimiento = (DateTime)datos.Lector["FECHA_NACIMIENTO"];

                    Medico.Mail = (String)datos.Lector["MAIL"];

                    Medico.Estado = (bool)datos.Lector["ESTADO"];
                }
                return Medico;
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
        private Paciente Datos_Paciente(int id_usuario)
        {
            Paciente paciente = new Paciente();

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID_PACIENTE, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO FROM PACIENTES WHERE ID_USUARIO = @IDUSUARIO");
                datos.setParametro("@IDUSUARIO", id_usuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    paciente.Id = (int)datos.Lector["ID_PACIENTE"];

                    paciente.Nombre = (String)datos.Lector["NOMBRE"];

                    paciente.Apellido = (String)datos.Lector["APELLIDO"];

                    paciente.Telefono = (String)datos.Lector["TELEFONO"];

                    paciente.Direccion = (String)datos.Lector["DIRECCION"];

                    paciente.Fecha_Nacimiento = (DateTime)datos.Lector["FECHA_NACIMIENTO"];

                    paciente.Mail = (String)datos.Lector["MAIL"];

                    paciente.Estado = (bool)datos.Lector["ESTADO"];

                }
                    return paciente;
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
        public void Cargar_label_Paciente()
        {
            string apellido = paciente_actual.Apellido;
            string nombre = paciente_actual.Nombre;
            string mail = paciente_actual.Mail;
            string telefono = paciente_actual.Telefono;
            string direccion = paciente_actual.Direccion;
            DateTime fecha_nacimiento = paciente_actual.Fecha_Nacimiento;

            apellidoLbl.Text = "Apellido : " + apellido;
            nombrelbl.Text = "Nombre : " + nombre;
            emailLbl.Text = "Mail : " + mail;
            telefonoLbl.Text = "Telefono : " + telefono;
            direccionLbl.Text = "Dirrecion :" + direccion;
            fechaNacimientoLbl.Text = "Fecha de nacimiento : " + fecha_nacimiento;
        }
        public void Cargar_label_Medico()
        {
            string apellido = Medico_actual.Apellido;
            string nombre = Medico_actual.Nombre;
            string mail = Medico_actual.Mail;
            string telefono = Medico_actual.Telefono;
            string direccion = Medico_actual.Direccion;
            DateTime fecha_nacimiento = Medico_actual.Fecha_Nacimiento;

            apellidoLbl.Text = "Apellido : " + apellido;
            nombrelbl.Text = "Nombre : " + nombre;
            emailLbl.Text = "Mail : " + mail;
            telefonoLbl.Text = "Telefono : " + telefono;
            direccionLbl.Text = "Dirrecion :" + direccion;
            fechaNacimientoLbl.Text = "Fecha de nacimiento : " + fecha_nacimiento;
        }
     
    }
}