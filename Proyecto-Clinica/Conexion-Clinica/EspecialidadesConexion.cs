
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexion_Clinica
{
    internal class EspecialidadesConexion
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
                        Id = (byte)datos.Lector["ID_ESPECIALIDAD"],
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
