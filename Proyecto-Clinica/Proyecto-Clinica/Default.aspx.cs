using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto_Clinica.Dominio;
using Conexion_Clinica;
using System.Collections;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class Default : System.Web.UI.Page
    {
        Clinica clinica = new Clinica();

        Usuario usuario_actual = null;
        public void cargar_componentes()
        {
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            clinica = clinicaConexion.listar();
            dgv_Pacientes = new GridView();
            dgv_Medicos = new GridView();
            dgv_Turnos = new GridView();
            dgv_Usuarios = new GridView();

            //Se cargan las grillas
            dgv_Pacientes.DataSource = clinica.pacientes;
            dgv_Medicos.DataSource = clinica.medicos;
            dgv_Turnos.DataSource = clinica.turnos;
            dgv_Usuarios.DataSource = clinica.usuarios;
            //Se muestran
            dgv_Pacientes.DataBind();
            dgv_Medicos.DataBind();
            dgv_Turnos.DataBind();
            dgv_Usuarios.DataBind();

            if (Session["Usuario"] == null)
            {
                Session["Usuario"] = new Usuario();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_componentes();
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContraseña.Text;

            usuario_actual = buscar_usuario_en_BBDD(usuario, contrasena);

            if(usuario_actual.Id != -1)
            {
                Session["Usuario"] = usuario_actual;

                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");
                //Debería salir un mensaje diciendo que el ingreso no fue exitoso y no deberia permitir 
                //que se salga de la página de Login :)
            }
        }

        private Usuario buscar_usuario_en_BBDD(string nombre, string contrasena)
        {
            Usuario usuario1 = new Usuario();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setConsulta("SELECT ID_USUARIO, NOMBRE_USUARIO, CONTRASENA, TIPO FROM USUARIOS WHERE @nombre = NOMBRE_USUARIO AND @contrasena = CONTRASENA");
                datos.setParametro("@nombre", nombre);
                datos.setParametro("@contrasena", contrasena);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("ID_USUARIO")))
                    {
                        usuario1.Id = (int)datos.Lector["ID_USUARIO"];
                        usuario1.Nombre = (String)datos.Lector["NOMBRE_USUARIO"];
                        usuario1.Contraseña = (String)datos.Lector["CONTRASENA"];
                        usuario1.Tipo = (String)datos.Lector["TIPO"];
                    }
                }
                return usuario1;
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

       
    }
}