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
                datos.setConsulta("SELECT P.ID_PACIENTE AS PCIENTE, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO, O.OBSERVACION AS OBS, o.ID_MEDICO as MEDICO, o.FECHA as FECHA FROM PACIENTES P LEFT JOIN OBSERVACIONES O ON P.ID_PACIENTE = O.ID_PACIENTE");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente paciente = new Paciente();

                    paciente.Id = (int)datos.Lector["PCIENTE"];

                    paciente.nombre = (string)datos.Lector["NOMBRE"];

                    paciente.apellido = (string)datos.Lector["APELLIDO"];

                    paciente.telefono = (string)datos.Lector["TELEFONO"];

                    paciente.direccion = (string)datos.Lector["DIRECCION"];

                    paciente.fecha_nacimiento = (DateTime)datos.Lector["FECHA_NACIMIENTO"];

                    paciente.mail = (string)datos.Lector["MAIL"];

                    paciente.estado = (bool)datos.Lector["ESTADO"];

                    paciente.Observaciones = new List<Observacion>();
                    Observacion obs = new Observacion();
                    obs.Descripcion = (string)datos.Lector["OBS"];
                    obs.id_Medico = (int)datos.Lector["MEDICO"];
                    obs.id_Paciente = (int)datos.Lector["PCIENTE"];
                    obs.Fecha = (DateTime)datos.Lector["FECHA"];
                    paciente.Observaciones.Add(obs);


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
