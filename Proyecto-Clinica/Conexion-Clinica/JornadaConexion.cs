using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexion_Clinica
{
    public class JornadaConexion
    {
        public List<Jornada> Listar()
        {
            List<Jornada> lista = new List<Jornada>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID_JORNADA,TIPO_JORNADA FROM JORNADAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Jornada especialidad = new Jornada
                    {
                        Id = (int)datos.Lector["ID_JORNADA"],
                        Tipo = (string)datos.Lector["TIPO_JORNADA"]
                    };
                    lista.Add(especialidad);

                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void Insertar_Jornada(int Id_Medico, int Id_Jornada)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO MEDICOXJORNADA (ID_JORNADA, ID_MEDICO, ESTADO) VALUES (@IDJORNADA, @ID_MEDICO, 1)");
                datos.setParametro("@ID_MEDICO", Id_Medico);
                datos.setParametro("@IDJORNADA", Id_Jornada);
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
        public void Eliminar_Jornada(int idMedico, int idJornada)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("DELETE FROM MEDICOXJORNADA WHERE ID_JORNADA = @ID_JORNADA AND ID_MEDICO = @ID_MEDICO");
                datos.setParametro("@ID_MEDICO", idMedico);
                datos.setParametro("@ID_JORNADA", idJornada);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void Insertar_Especialidad(int Id_Especialidad, int Id_Medico)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO MEDICOSXESPECIALIDAD (ID_ESPECIALIDAD, ID_MEDICO) VALUES (@IDESPECIALIDAD, @ID_MEDICO)");
                datos.setParametro("@IDESPECIALIDAD", Id_Especialidad);
                datos.setParametro("@ID_MEDICO", Id_Medico);
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
        
        public void Eliminar_Especialidades(int id_especialidades, int id_medico)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("DELETE FROM MEDICOSXESPECIALIDAD WHERE ID_ESPECIALIDAD = @ID_ESPECIALIDAD AND ID_MEDICO = @ID_MEDICO");
                datos.setParametro("@ID_ESPECIALIDAD", id_especialidades);
                datos.setParametro("@IDMEDICO", id_medico);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
