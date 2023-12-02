
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
                datos.setConsulta("UPDATE MEDICOSXESPECIALIDAD SET ESTADO = 0 WHERE ID_MEDICO = @IDMEDICO");
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
        
        
        public void AsignarEspecialidadAMedico(int idMedico, string especialidad)
        {
            AccesoDatos datos = new AccesoDatos();

            if (!string.IsNullOrEmpty(especialidad))
            {
                int idEspecialidad = ObtenerIdEspecialidadPorTipo(especialidad);

                if (idEspecialidad > 0)
                {
                    try
                    {
                        // Asegúrate de tener la lógica adecuada para asociar la especialidad al médico
                        datos.setConsulta("INSERT INTO MEDICOSXESPECIALIDAD (ID_MEDICO, ID_ESPECIALIDAD, ESTADO) VALUES (@ID_MEDICO, @ID_ESPECIALIDAD, 1)");
                        datos.setParametro("@ID_MEDICO", idMedico);
                        datos.setParametro("@ID_ESPECIALIDAD", idEspecialidad); // Utiliza el idEspecialidad directamente
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
                else
                {
                    // Manejar el caso donde ObtenerIdEspecialidadPorTipo no devuelve un valor válido
                    // Puedes lanzar una excepción, mostrar un mensaje de error, etc.
                    Console.WriteLine("El ID de especialidad no es válido.");
                }
            }
            else
            {
                // Manejar el caso donde especialidad es null o una cadena vacía
                Console.WriteLine("La especialidad no es válida.");
            }
        }

        public int ObtenerIdEspecialidadPorTipo(string tipoEspecialidad)
        {
            AccesoDatos datos = new AccesoDatos();
            int idEspecialidad = 0;  // El valor predeterminado si no se encuentra la especialidad

            try
            {
                datos.setConsulta("SELECT ID_ESPECIALIDAD FROM ESPECIALIDADES WHERE TIPO = @TIPO");
                datos.setParametro("@TIPO", tipoEspecialidad);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    idEspecialidad = (int)datos.Lector["ID_ESPECIALIDAD"];
                }
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

            return idEspecialidad;
        }



    }
}
