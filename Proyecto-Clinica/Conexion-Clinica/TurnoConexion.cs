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
    public class TurnoConexion
    {
        public List<Turno> Listar()
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT \r\n\t\tT.ID_TURNO AS IDTURNO,\r\n\t\tT.ID_MEDICO AS IDMEDICO,\r\n\t\tT.ID_PACIENTE AS IDPACIENTE,\r\n\t\tT.ID_HORARIO AS IDHORARIO,\r\n\t\tT.ID_ESPECIALIDAD AS IDESPECIALIDAD, \r\n\t\tT.FECHA AS FECHA,\r\n\t\tH.HORA AS HORA,\r\n\t\tP.DNI AS DNIPACIENTE,\r\n\t\tT.ESTADO AS ESTADO,\r\n\t\tM.NOMBRE AS MNOMBRE,\r\n\t\tM.APELLIDO AS MAPELLIDO,\r\n\t\tP.NOMBRE AS PNOMBRE,\r\n\t\tP.APELLIDO AS PAPELLIDO,\r\n\t\tT.OBS_PACIENTE AS OBSERVACION_PACIENTE,\r\n\t\tT.OBS_MEDICO AS OBSERVACION_MEDICO \r\n\tFROM TURNOS T \r\n\tINNER JOIN MEDICOS M ON M.ID_MEDICO = T.ID_MEDICO \r\n\tINNER JOIN PACIENTES P ON P.ID_PACIENTE = T.ID_PACIENTE \r\n\tINNER JOIN HORARIOS H ON H.ID_HORARIO = T.ID_HORARIO");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno turno = new Turno
                    {
                        Id = (int)datos.Lector["IDTURNO"],
                        Id_Medico = (int)datos.Lector["IDMEDICO"],
                        Id_Paciente = (int)datos.Lector["IDPACIENTE"],
                        Id_Horario = (int)datos.Lector["IDHORARIO"],
                        Id_Especialidad = (int)datos.Lector["IDESPECIALIDAD"],
                        Horario = (TimeSpan)datos.Lector["HORA"],
                        Dni_paciente = (String)datos.Lector["DNIPACIENTE"],
                        Fecha = (DateTime)datos.Lector["FECHA"],
                        Estado = (String)datos.Lector["ESTADO"],
                        Nombre_Medico = (String)datos.Lector["MNOMBRE"],
                        Apellido_Medico = (String)datos.Lector["MAPELLIDO"],
                        Nombre_Paciente = (String)datos.Lector["PNOMBRE"],
                        Apellido_Paciente = (String)datos.Lector["PAPELLIDO"],
                        Obs_paciente = (String)datos.Lector["OBSERVACION_PACIENTE"],
                        Obs_medico = (String)datos.Lector["OBSERVACION_MEDICO"],
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

        public List<Turno> Listar_Turnos_cancelados()
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT \r\n\t\tT.ID_TURNO AS IDTURNO,\r\n\t\tT.ID_MEDICO AS IDMEDICO,\r\n\t\tT.ID_PACIENTE AS IDPACIENTE,\r\n\t\tT.ID_HORARIO AS IDHORARIO,\r\n\t\tT.ID_ESPECIALIDAD AS IDESPECIALIDAD, \r\n\t\tT.FECHA AS FECHA,\r\n\t\tH.HORA AS HORA,\r\n\t\tP.DNI AS DNIPACIENTE,\r\n\t\tT.ESTADO AS ESTADO,\r\n\t\tM.NOMBRE AS MNOMBRE,\r\n\t\tM.APELLIDO AS MAPELLIDO,\r\n\t\tP.NOMBRE AS PNOMBRE,\r\n\t\tP.APELLIDO AS PAPELLIDO,\r\n\t\tT.OBS_PACIENTE AS OBSERVACION_PACIENTE FROM TURNOS_CANCELADOS T \r\n\tINNER JOIN MEDICOS M ON M.ID_MEDICO = T.ID_MEDICO \r\n\tINNER JOIN PACIENTES P ON P.ID_PACIENTE = T.ID_PACIENTE \r\n\tINNER JOIN HORARIOS H ON H.ID_HORARIO = T.ID_HORARIO");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno turno = new Turno
                    {
                        Id = (int)datos.Lector["IDTURNO"],
                        Id_Medico = (int)datos.Lector["IDMEDICO"],
                        Id_Paciente = (int)datos.Lector["IDPACIENTE"],
                        Id_Horario = (int)datos.Lector["IDHORARIO"],
                        Id_Especialidad = (int)datos.Lector["IDESPECIALIDAD"],
                        Horario = (TimeSpan)datos.Lector["HORA"],
                        Dni_paciente = (String)datos.Lector["DNIPACIENTE"],
                        Fecha = (DateTime)datos.Lector["FECHA"],
                        Estado = (String)datos.Lector["ESTADO"],
                        Nombre_Medico = (String)datos.Lector["MNOMBRE"],
                        Apellido_Medico = (String)datos.Lector["MAPELLIDO"],
                        Nombre_Paciente = (String)datos.Lector["PNOMBRE"],
                        Apellido_Paciente = (String)datos.Lector["PAPELLIDO"],
                        Obs_paciente = (String)datos.Lector["OBSERVACION_PACIENTE"],
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

        public string Listar_Observacion_x_ID(int ID)
        {
            AccesoDatos datos = new AccesoDatos();
            string observacion_medico="";
            try
            {
                datos.setConsulta("SELECT T.OBS_MEDICO AS OBSERVACION_MEDICO FROM TURNOS T WHERE T.ID_TURNO = @ID_TURNO ");
                datos.setParametro("@ID_TURNO", ID);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    observacion_medico = (string)datos.Lector["OBSERVACION_MEDICO"];
                }
                return observacion_medico;
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
        public void Actualizar_Observacion_x_ID(string Observacion, int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE  TURNOS SET OBS_MEDICO = @OBSERVACION WHERE ID_TURNO = @ID_TURNO");
                datos.setParametro("@OBSERVACION", Observacion);
                datos.setParametro("@ID_TURNO", id);
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
        public void Insertar_Turno(Turno turno)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO TURNOS (ID_MEDICO, ID_PACIENTE, ID_HORARIO, ID_ESPECIALIDAD, FECHA, OBS_PACIENTE, OBS_MEDICO, ESTADO) VALUES (@IDMEDICO, @IDPACIENTE, @IDHORA, @IDESPECIALIDAD, @FECHA, @OBS_PACIENTE, @OBS_MEDICO, @ESTADO)");

                datos.setParametro("@IDMEDICO", turno.Id_Medico);
                datos.setParametro("@IDPACIENTE", turno.Id_Paciente);
                datos.setParametro("@IDHORA", turno.Id_Horario);
                datos.setParametro("@IDESPECIALIDAD", turno.Id_Especialidad);
                datos.setParametro("@FECHA", turno.Fecha.Year + "-" + turno.Fecha.Month + "-" + turno.Fecha.Day);
                datos.setParametro("@OBS_PACIENTE", turno.Obs_paciente);
                datos.setParametro("@OBS_MEDICO", turno.Obs_medico);
                datos.setParametro("@ESTADO", "Reservado");
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
        public bool Modificar_Turno(Turno turno)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE TURNOS SET FECHA = @FECHA ,ID_HORARIO = @ID_HORARIO,ID_MEDICO = @ID_MEDICO WHERE ID_TURNO = @ID_TURNO ");
                datos.setParametro("@FECHA", turno.Fecha.Year + "-" + turno.Fecha.Month + "-" + turno.Fecha.Day);
                datos.setParametro("@ID_HORARIO", turno.Id_Horario);
                datos.setParametro("@ID_MEDICO", turno.Id_Medico);
                datos.setParametro("@ID_TURNO", turno.Id);

                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
                throw ex;
                
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void Reprogramar_Turno(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE TURNOS SET ESTADO = 'Reprogramado' WHERE ID_TURNO = @ID_TURNO");
                datos.setParametro("@ID_TURNO", id);
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
        public void Finalizar_Turno(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE TURNOS SET ESTADO = 'Finalizado' WHERE ID_TURNO = @ID_TURNO");
                datos.setParametro("@ID_TURNO", id);
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
        public int GetMaxID()
        {
            AccesoDatos datos = new AccesoDatos();
            int MaxId = 0;
            try
            {
                datos.setConsulta("SELECT MAX(ID_TURNO) AS MAXID FROM TURNOS");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    MaxId = (int)datos.Lector["MAXID"];
                }
                return MaxId;
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
        public void EliminarTurno(int iD_Turno)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("DELETE FROM TURNOS WHERE ID_TURNO = @IDTURNO");
                datos.setParametro("@IDTURNO", iD_Turno);
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

        public void Insertar_Turno_Cancelado(Turno turno_Seleccionado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO TURNOS_CANCELADOS (ID_TURNO, ID_MEDICO, ID_PACIENTE, ID_HORARIO, ID_ESPECIALIDAD, FECHA, ESTADO, OBS_PACIENTE) VALUES(@IDTURNO, @IDMEDICO, @IDPACIENTE, @IDHORARIO, @IDESPECIALIDAD, @FECHA, 'Cancelado', @OBSPACIENTE)");
                datos.setParametro("@IDTURNO", turno_Seleccionado.Id);
                datos.setParametro("@IDMEDICO", turno_Seleccionado.Id_Medico);
                datos.setParametro("@IDPACIENTE", turno_Seleccionado.Id_Paciente);
                datos.setParametro("@IDHORARIO", turno_Seleccionado.Id_Horario);
                datos.setParametro("@IDESPECIALIDAD", turno_Seleccionado.Id_Especialidad);
                datos.setParametro("@FECHA", turno_Seleccionado.Fecha.Year + "-" + turno_Seleccionado.Fecha.Month + "-" + turno_Seleccionado.Fecha.Day);
                datos.setParametro("@OBSPACIENTE", turno_Seleccionado.Obs_paciente);
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

        public void Insertar_Turno_Reagendado(Turno turno, int IDMedicoNuevo, DateTime FechaNueva, int IdHorarioNuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO TURNOS_Reagendados\r\n\t(ID_TURNO, \r\n\tID_PACIENTE,\r\n\tID_ESPECIALIDAD, \r\n\tOBS_PACIENTE,\r\n\tID_MEDICO_ANTERIOR , \r\n\tID_HORARIO_ANTERIOR, \r\n\tFECHA_ANTERIOR, \r\n\tID_MEDICO_NUEVO,\r\n\tID_HORARIO_NUEVO, \r\n\tFECHA_NUEVA ,\r\n\tESTADO)\r\n\r\nVALUES(\r\n\t@IDTURNO, \r\n\t@IDPACIENTE, \r\n\t@IDESPECIALIDAD, \r\n\t@OBSPACIENTE,\r\n\t@IDMEDICOANTERIOR, \r\n\t@IDHORARIOANTERIOR, \r\n\t@FECHAANTERIOR,\r\n\t@IDMEDICONUEVO,\r\n\t@IDHORARIONUEVO, \r\n\t@FECHANUEVA ,\r\n\t'Reasignado') ");
               
                datos.setParametro("@IDTURNO", turno.Id);
                datos.setParametro("@IDPACIENTE", turno.Id_Paciente);
                datos.setParametro("@IDESPECIALIDAD", turno.Id_Especialidad);
                datos.setParametro("@OBSPACIENTE", turno.Obs_paciente);
                datos.setParametro("@IDMEDICOANTERIOR", turno.Id_Medico);
                datos.setParametro("@IDHORARIOANTERIOR", turno.Id_Horario);
                datos.setParametro("@FECHAANTERIOR", turno.Fecha.Year + "-" + turno.Fecha.Month + "-" + turno.Fecha.Day);

                datos.setParametro("@IDMEDICONUEVO", IDMedicoNuevo);
                datos.setParametro("@IDHORARIONUEVO", IdHorarioNuevo);
                datos.setParametro("@FECHANUEVA", FechaNueva.Year + "-" + FechaNueva.Month + "-" + FechaNueva.Day);
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
