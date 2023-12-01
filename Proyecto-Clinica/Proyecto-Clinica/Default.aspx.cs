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
        Usuario usuario_actual = null;
      
        public void Cargar_Componentes()
        {
            Session["Usuario"] = new Usuario();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_Componentes();
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContraseña.Text;

            usuario_actual = Buscar_Usuario_En_BBDD(usuario, contrasena);
            

            if(usuario_actual.Id != -1)
            {
                Session["Usuario"] = usuario_actual;
                Response.Redirect("Home.aspx");
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña inválidos. Intente otra vez");
                Response.Redirect("Default.aspx");
            }
        }

        private Usuario Buscar_Usuario_En_BBDD(string nombre, string contrasena)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setConsulta("SELECT ID_USUARIO, NOMBRE_USUARIO, CONTRASENA, TIPO, URL_IMAGEN FROM USUARIOS U LEFT JOIN IMAGENES I ON I.ID_IMAGEN = U.ID_IMAGEN WHERE @nombre = NOMBRE_USUARIO AND @contrasena = CONTRASENA");
                datos.setParametro("@nombre", nombre);
                datos.setParametro("@contrasena", contrasena);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("ID_USUARIO")))
                    {
                        if (!(datos.Lector["URL_IMAGEN"] is DBNull))
                        {
                            Usuario usuario = new Usuario
                            {
                                Id = (int)datos.Lector["ID_USUARIO"],
                                Username = (String)datos.Lector["NOMBRE_USUARIO"],
                                Contraseña = (String)datos.Lector["CONTRASENA"],
                                Tipo = (String)datos.Lector["TIPO"],
                                Imagen = (String)datos.Lector["URL_IMAGEN"]
                            };
                            return usuario;
                        }
                        else
                        {
                            Usuario usuario = new Usuario
                            {
                                Id = (int)datos.Lector["ID_USUARIO"],
                                Username = (String)datos.Lector["NOMBRE_USUARIO"],
                                Contraseña = (String)datos.Lector["CONTRASENA"],
                                Tipo = (String)datos.Lector["TIPO"]
                            };
                            return usuario;
                        }
                    }
                }
                return new Usuario();
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
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaUsuario.aspx");
        }
    }
}