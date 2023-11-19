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
        public List<Observacion> Listar(int tipo)
        {
            List<Observacion> lista = new List<Observacion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (tipo == 1)
                {
                        datos.setConsulta("SELECT ID_OBSERVACION, ID_TURNO, OBSERVACION FROM OBSERVACIONES_MEDICOS");
                        datos.ejecutarLectura();

                        while (datos.Lector.Read())
                        {
                            Observacion observacion = new Observacion
                            {
                                Id = (int)datos.Lector["ID_OBSERVACION"],
                                Id_Turno = (int)datos.Lector["ID_TURNO"],
                                Descripción = (String)datos.Lector["OBSERVACION"]
                            };

                            lista.Add(observacion);
                        }
                        return lista;
                }
                else if (tipo == 2)
                {
                    datos.setConsulta("SELECT ID_OBSERVACION, ID_TURNO, OBSERVACION FROM OBSERVACIONES_PACIENTES");
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Observacion observacion = new Observacion
                        {
                            Id = (int)datos.Lector["ID_OBSERVACION"],
                            Id_Turno = (int)datos.Lector["ID_TURNO"],
                            Descripción = (String)datos.Lector["OBSERVACION"]
                        };

                        lista.Add(observacion);
                    }
                    return lista;
                }
                else { return lista; }
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
