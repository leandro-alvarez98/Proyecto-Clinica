using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexion_Clinica
{
    internal class TurnoConexion
    {
        public List<Turno> listar()
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID_TURNO, M.NOMBRE AS MNOMBRE, P.NOMBRE AS PNOMBRE, FECHA, HORA_INICIO, HORA_FIN, T.ESTADO AS ESTADO FROM TURNOS T INNER JOIN MEDICOS M ON M.ID_MEDICO = T.ID_MEDICO INNER JOIN PACIENTES P ON P.ID_PACIENTE = T.ID_PACIENTE");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno turno = new Turno();
                    turno.Id = (int)datos.Lector["ID_TURNO"];
                    turno.Paciente = (String)datos.Lector["PNOMBRE"];
                    turno.Medico = (String)datos.Lector["MNOMBRE"];
                    turno.Fecha = (DateTime)datos.Lector["FECHA"];
                    turno.HoraInicio = (TimeSpan)datos.Lector["HORA_INICIO"];
                    turno.HoraFin = (TimeSpan)datos.Lector["HORA_FIN"];
                    turno.Estado = (bool)datos.Lector["ESTADO"];

                    lista.Add(turno);
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
