using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexion_Clinica
{
    internal class AdministradorConexion
    {
        public List<Administrador> Listar()
        {
            List<Administrador> lista = new List<Administrador>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID_ADMINISTRADOR, ID_USUARIO, DNI, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO FROM ADMINISTRADOR");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Administrador administrador = new Administrador
                    {
                        Id = (int)datos.Lector["ID_ADMINISTRADOR"],

                        Id_Usuario = (int)datos.Lector["ID_USUARIO"],

                        Dni = (string)datos.Lector["DNI"],

                        Nombre = (string)datos.Lector["NOMBRE"],

                        Apellido = (string)datos.Lector["APELLIDO"],

                        Telefono = (string)datos.Lector["TELEFONO"],

                        Direccion = (string)datos.Lector["DIRECCION"],

                        Fecha_Nacimiento = (DateTime)datos.Lector["FECHA_NACIMIENTO"],

                        Mail = (string)datos.Lector["MAIL"],

                        Estado = (bool)datos.Lector["ESTADO"]
                    };

                    lista.Add(administrador);
                }
                return lista;
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
