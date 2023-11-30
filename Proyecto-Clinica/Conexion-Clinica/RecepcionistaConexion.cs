using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexion_Clinica
{
    public class RecepcionistaConexion
    {
        public void InsertarRecepcionista(Usuario usuario_actual)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO RECEPCIONISTA (ID_USUARIO, DNI, NOMBRE,APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO) VALUES(@IDUSUARIO, @DNI, @NOMBRE, @APELLIDO, @TELEFONO, @DIRECCION, @FECHANACIMIENTO, @MAIL, 1)");
                datos.setParametro("@IDUSUARIO", usuario_actual.Id);
                datos.setParametro("@DNI", usuario_actual.Dni);
                datos.setParametro("@NOMBRE", usuario_actual.Nombre);
                datos.setParametro("@APELLIDO", usuario_actual.Apellido);
                datos.setParametro("@TELEFONO", usuario_actual.Telefono);
                datos.setParametro("@DIRECCION", usuario_actual.Direccion);
                datos.setParametro("@FECHANACIMIENTO", usuario_actual.Fecha_Nacimiento);
                datos.setParametro("@MAIL", usuario_actual.Mail);
                datos.ejecutarAccion();
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

        public List<Recepcionista> Listar()
        {
            List<Recepcionista> lista = new List<Recepcionista>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID_RECEPCIONISTA, ID_USUARIO, DNI, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO FROM RECEPCIONISTA");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Recepcionista recepcionista = new Recepcionista
                    {
                        Id = (int)datos.Lector["ID_RECEPCIONISTA"],

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

                    lista.Add(recepcionista);
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
