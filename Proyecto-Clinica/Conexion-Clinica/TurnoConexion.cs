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
        public List<Turno> Listar()
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT T.ID_TURNO AS IDTURNO, T.ID_MEDICO AS IDMEDICO, T.ID_PACIENTE AS IDPACIENTE, T.ID_HORARIO AS IDHORARIO, T.FECHA AS FECHA ,T.ESTADO AS ESTADO, M.NOMBRE AS MNOMBRE, M.APELLIDO AS MAPELLIDO, P.NOMBRE AS PNOMBRE, P.APELLIDO AS PAPELLIDO FROM TURNOS T INNER JOIN MEDICOS M ON M.ID_MEDICO = T.ID_MEDICO INNER JOIN PACIENTES P ON P.ID_PACIENTE = T.ID_PACIENTE");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno turno = new Turno
                    {
                        Id = (int)datos.Lector["IDTURNO"],
                        Id_Medico = (int)datos.Lector["IDMEDICO"],
                        Id_Paciente = (int)datos.Lector["IDPACIENTE"],
                        Id_Horario = (int)datos.Lector["IDHORARIO"],
                        Fecha = (DateTime)datos.Lector["FECHA"],
                        Estado = (String)datos.Lector["ESTADO"],
                        Nombre_Medico = (String)datos.Lector["MNOMBRE"],
                        Apellido_Medico = (String)datos.Lector["MAPELLIDO"],
                        Nombre_Paciente = (String)datos.Lector["PNOMBRE"],
                        Apellido_Paciente = (String)datos.Lector["PAPELLIDO"]
                    };

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
