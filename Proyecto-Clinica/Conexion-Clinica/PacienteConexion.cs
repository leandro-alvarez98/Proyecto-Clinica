using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexion_Clinica
{
    public class PacienteConexion
    {
        public void InsertarPaciente(Usuario usuario_actual)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO PACIENTES (ID_USUARIO, DNI, NOMBRE,APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO) VALUES(@IDUSUARIO, @DNI, @NOMBRE, @APELLIDO, @TELEFONO, @DIRECCION, @FECHANACIMIENTO, @MAIL, 1)");
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

        public List<Paciente> Listar()
        {
            List<Paciente> lista = new List<Paciente>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID_PACIENTE, ID_USUARIO, DNI, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO FROM PACIENTES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente paciente = new Paciente
                    {
                        Id = (int)datos.Lector["ID_PACIENTE"],

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

                    lista.Add(paciente);
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
