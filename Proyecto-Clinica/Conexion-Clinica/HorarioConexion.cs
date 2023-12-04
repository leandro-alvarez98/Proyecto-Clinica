using Dominio;
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
    public class HorarioConexion
    {
        public int GetIdHorario(TimeSpan horaSeleccionada)
        {
            int IdHorario = 0;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID_HORARIO FROM HORARIOS WHERE HORA = @HORASELECCIONADA");
                datos.setParametro("@HORASELECCIONADA", horaSeleccionada);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    IdHorario = (int)datos.Lector["ID_HORARIO"];
                    return IdHorario;
                }
                return 0;
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

        public List<Horario> Listar()
        {
            List<Horario> lista = new List<Horario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID_HORARIO, HORA, DISPONIBILIDAD FROM HORARIOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Horario Horario = new Horario
                    {
                        Id_Horario = (int)datos.Lector["ID_HORARIO"],
                        Hora = (TimeSpan)datos.Lector["HORA"],
                        Disponibilidad = (bool)datos.Lector["DISPONIBILIDAD"]
                    };
                    lista.Add(Horario);
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
    }
}
