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
                datos.setConsulta("\tSELECT T.ID_TURNO AS IDTURNO,T.ID_MEDICO AS IDMEDICO,T.ID_PACIENTE AS IDPACIENTE,T.ID_HORARIO,T.FECHA AS FECHA,T.ID_HORARIO AS IDHORARIO,H.HORA AS HORA,P.DNI AS DNIPACIENTE,T.ESTADO AS ESTADO,M.NOMBRE AS MNOMBRE,M.APELLIDO AS MAPELLIDO,P.NOMBRE AS PNOMBRE,P.APELLIDO AS PAPELLIDO ,T.OBS_PACIENTE AS OBSERVACION_PACIENTE,T.OBS_MEDICO AS OBSERVACION_MEDICO FROM TURNOS T INNER JOIN MEDICOS M ON M.ID_MEDICO = T.ID_MEDICO INNER JOIN PACIENTES P ON P.ID_PACIENTE = T.ID_PACIENTE INNER JOIN HORARIOS H ON H.ID_HORARIO = T.ID_HORARIO");
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
                        Apellido_Paciente = (String)datos.Lector["PAPELLIDO"],
                        Obs_paciente = (string)datos.Lector["OBSERVACION_PACIENTE"],
                        Obs_medico = (string)datos.Lector["OBSERVACION_MEDICO"],
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
        public void Cancelar_Turno(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE TURNOS SET ESTADO = 'Cancelado' WHERE ID_TURNO = @ID_TURNO");
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
        public void Activar_Turno(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE TURNOS SET ESTADO = 'Activo' WHERE ID_TURNO = @ID_TURNO");
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
        public void Modificar_Turno(Turno turno)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE TURNOS SET FECHA = @FECHA ,ID_HORARIO = @ID_HORARIO,ID_MEDICO = @ID_MEDICO WHERE ID_TURNO = @ID_TURNO ");
                datos.setParametro("@FECHA", turno.Fecha);
                datos.setParametro("@ID_MEDICO", turno.Id_Medico);
                datos.setParametro("@ID_TURNO", turno.Id);
                datos.setParametro("@ID_HORARIO", turno.Id_Horario);
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
        public void No_asistio_Turno(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE TURNOS SET ESTADO = 'No asistió' WHERE ID_TURNO = @ID_TURNO");
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
        public int Get_Especialidad_Turno(Turno turno)
        {
            AccesoDatos datos = new AccesoDatos();
            int Id_Especialidad = -1;
            try
            {
                datos.setConsulta("SELECT E.ID_ESPECIALIDAD AS ID FROM ESPECIALIDADES E\r\n\tINNER JOIN MEDICOSXESPECIALIDAD ME ON ME.ID_ESPECIALIDAD = E.ID_ESPECIALIDAD\r\n\tINNER JOIN TURNOS T ON T.ID_MEDICO = ME.ID_MEDICO\r\n\tWHERE ME.ID_MEDICO = @ID_MEDICO");
                datos.setParametro("@ID_MEDICO", turno.Id_Medico);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Id_Especialidad = (int)datos.Lector["ID"];
                }
                return Id_Especialidad;

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
