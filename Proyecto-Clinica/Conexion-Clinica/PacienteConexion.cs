using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexion_Clinica
{
    internal class PacienteConexion
    {
        public List<Paciente> listar()
        {
            List<Paciente> lista = new List<Paciente>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID_PACIENTE, ID_USUARIO, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO FROM PACIENTES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente paciente = new Paciente();

                    paciente.Id = (int)datos.Lector["ID_PACIENTE"];

                    paciente.Id_Usuario = (int)datos.Lector["ID_USUARIO"];

                    paciente.Nombre = (string)datos.Lector["NOMBRE"];

                    paciente.Apellido = (string)datos.Lector["APELLIDO"];

                    paciente.Telefono = (string)datos.Lector["TELEFONO"];

                    paciente.Direccion = (string)datos.Lector["DIRECCION"];

                    paciente.Fecha_Nacimiento = (DateTime)datos.Lector["FECHA_NACIMIENTO"];

                    paciente.Mail = (string)datos.Lector["MAIL"];

                    paciente.Estado = (bool)datos.Lector["ESTADO"];

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
