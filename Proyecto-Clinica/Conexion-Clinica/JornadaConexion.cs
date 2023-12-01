using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexion_Clinica
{
    internal class JornadaConexion
    {
        public List<Jornada> Listar()
        {
            List<Jornada> lista = new List<Jornada>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID_JORNADA,TIPO FROM JORNADAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Jornada especialidad = new Jornada
                    {
                        Id = (int)datos.Lector["ID_JORNADA"],
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
    }
}
