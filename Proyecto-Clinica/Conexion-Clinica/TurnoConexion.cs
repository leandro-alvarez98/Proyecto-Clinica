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
                datos.setConsulta("SELECT \r\n\t\tT.ID_TURNO AS IDTURNO, \r\n\t\tT.ID_MEDICO AS IDMEDICO, \r\n\t\tT.ID_PACIENTE AS IDPACIENTE, \r\n\t\tT.ID_HORARIO, \r\n\t\tT.FECHA AS FECHA, \r\n\t\tT.ID_HORARIO AS IDHORARIO,\r\n\t\tH.HORA AS HORA,\r\n\t\tP.DNI AS DNIPACIENTE, \r\n\t\tT.ESTADO AS ESTADO, \r\n\t\tM.NOMBRE AS MNOMBRE, \r\n\t\tM.APELLIDO AS MAPELLIDO, \r\n\t\tP.NOMBRE AS PNOMBRE, \r\n\t\tP.APELLIDO AS PAPELLIDO \r\n\tFROM TURNOS T \r\n\tINNER JOIN \r\n\tMEDICOS M ON M.ID_MEDICO = T.ID_MEDICO \r\n\tINNER JOIN \r\n\tPACIENTES P ON P.ID_PACIENTE = T.ID_PACIENTE\r\n\tINNER JOIN\r\n\tHORARIOS H ON H.ID_HORARIO = T.ID_HORARIO");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno turno = new Turno
                    {
                        Id = (int)datos.Lector["IDTURNO"],
                        Id_Medico = (int)datos.Lector["IDMEDICO"],
                        Id_Paciente = (int)datos.Lector["IDPACIENTE"],
                        Id_Horario = (int)datos.Lector["IDHORARIO"],
                        Horario = (TimeSpan)datos.Lector["HORA"],
                        Dni_paciente = (String)datos.Lector["DNIPACIENTE"],
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
