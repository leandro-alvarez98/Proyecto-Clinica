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
        public Usuario Comprobar_Usuario()
        {
            return usuario_actual;
        }
        public void cargar_componentes()
        {
            Master_page master = (Master_page)this.Master;


            ClinicaConexion clinicaConexion = new ClinicaConexion();
            clinica = clinicaConexion.listar();

            if (Session["Usuario"] == null)
            {
                Session["Usuario"] = new Usuario();
            }
            else
            {
                master.Mostrar_Icono();
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
                if (usuario_actual.Tipo == "Médico")
                {
                    CargarTurnos();
                }
                Session["Usuario"] = usuario_actual;

                Response.Redirect("Home.aspx");
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña inválidos. Intente otra vez");
                Response.Redirect("Default.aspx");
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
        private void CargarTurnos()
        {
            
        }
    }
}