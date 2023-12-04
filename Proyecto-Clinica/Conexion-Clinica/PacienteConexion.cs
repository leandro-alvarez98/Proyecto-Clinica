using Proyecto_Clinica.Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexion_Clinica
{
    public class PacienteConexion
    {
        public Paciente getPaciente(int id_Paciente)
        {
            AccesoDatos datos = new AccesoDatos();
            Paciente paciente = new Paciente();

            try
            {
                datos.setConsulta("SELECT ID_PACIENTE, ID_USUARIO, DNI, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO FROM PACIENTES WHERE ESTADO != 0 AND ID_PACIENTE = @IDPACIENTE");
                datos.setParametro("@IDPACIENTE", id_Paciente);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    paciente.Id = (int)datos.Lector["ID_PACIENTE"];

                    paciente.Id_Usuario = (int)datos.Lector["ID_USUARIO"];

                    paciente.Dni = (string)datos.Lector["DNI"];

                    paciente.Nombre = (string)datos.Lector["NOMBRE"];

                    paciente.Apellido = (string)datos.Lector["APELLIDO"];

                    paciente.Telefono = (string)datos.Lector["TELEFONO"];

                    paciente.Direccion = (string)datos.Lector["DIRECCION"];

                    paciente.Fecha_Nacimiento = (DateTime)datos.Lector["FECHA_NACIMIENTO"];

                    paciente.Mail = (string)datos.Lector["MAIL"];

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
        public void InsertarPaciente(Paciente paciente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO PACIENTES (ID_USUARIO, DNI, NOMBRE,APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO) VALUES(@IDUSUARIO, @DNI, @NOMBRE, @APELLIDO, @TELEFONO, @DIRECCION, @FECHANACIMIENTO, @MAIL, 1)");
                datos.setParametro("@IDUSUARIO", paciente.Id_Usuario);
                datos.setParametro("@DNI", paciente.Dni);
                datos.setParametro("@NOMBRE", paciente.Nombre);
                datos.setParametro("@APELLIDO", paciente.Apellido);
                datos.setParametro("@TELEFONO", paciente.Telefono);
                datos.setParametro("@DIRECCION", paciente.Direccion);
                datos.setParametro("@FECHANACIMIENTO", paciente.Fecha_Nacimiento);
                datos.setParametro("@MAIL", paciente.Mail);
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
                datos.setConsulta("SELECT ID_PACIENTE, ID_USUARIO, DNI, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO FROM PACIENTES WHERE ESTADO != 0");
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
