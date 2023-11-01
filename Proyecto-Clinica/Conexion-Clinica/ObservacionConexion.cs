using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexion_Clinica
{
    public class ObservacionConexion
    {
        public List<Observacion> Listar()
        {
            List<Observacion> lista = new List<Observacion>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID_OBSERVACION, ID_TURNO, OBSERVACION FROM OBSERVACIONES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Observacion observacion = new Observacion();
                    observacion.Id = (int)datos.Lector["ID_OBSERVACION"];
                    observacion.Id_Turno = (int)datos.Lector["ID_TURNO"];
                    observacion.Descripción = (String)datos.Lector["OBSERVACION"];

                    lista.Add(observacion);
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
