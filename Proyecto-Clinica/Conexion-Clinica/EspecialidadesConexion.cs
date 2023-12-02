
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
    public class EspecialidadesConexion
    {
        public List<Especialidad> Listar()
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID_ESPECIALIDAD,TIPO FROM ESPECIALIDADES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad especialidad = new Especialidad
                    {
                        Id = (int)datos.Lector["ID_ESPECIALIDAD"],
                        Tipo = (string)datos.Lector["TIPO"]
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

        public List<Especialidad> Listar_2()
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID_ESPECIALIDAD,TIPO FROM ESPECIALIDADES WHERE ID_ESPECIALIDAD > 0");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad especialidad = new Especialidad
                    {
                        Id = (int)datos.Lector["ID_ESPECIALIDAD"],
                        Tipo = (string)datos.Lector["TIPO"]
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

        public void Insertar_Especialidad_En_BBDD(string nueva_Especialidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO ESPECIALIDADES (TIPO) VALUES (@TIPO)");
                datos.setParametro("@TIPO", nueva_Especialidad);
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
        
        public void EliminarEspecialidadxMedico(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("delete from MEDICOSXESPECIALIDAD WHERE ID_MEDICO = @IDMEDICO");
                datos.setParametro("@IDMEDICO", id);
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
        public void EliminarEspecialidadxMedico(int idMedico, int idEspecialidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("delete from MEDICOSXESPECIALIDAD WHERE ID_MEDICO = @IDMEDICO AND ID_ESPECIALIDAD = @IDESPECIALIDAD");
                datos.setParametro("@IDMEDICO", idMedico);
                datos.setParametro("@IDESPECIALIDAD", idEspecialidad);
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
        public void AsignarEspecialidadAMedico(int idMedico, int idEspecialidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO MEDICOSXESPECIALIDAD (ID_MEDICO, ID_ESPECIALIDAD, ESTADO) VALUES (@ID_MEDICO, @ID_ESPECIALIDAD, 1)");
                datos.setParametro("@ID_MEDICO", idMedico);
                datos.setParametro("@ID_ESPECIALIDAD", idEspecialidad);
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
