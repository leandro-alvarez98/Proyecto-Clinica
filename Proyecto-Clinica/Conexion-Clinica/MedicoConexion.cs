using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using Proyecto_Clinica.Dominio;

namespace Conexion_Clinica
{
    internal class MedicoConexion
    {
        public List<Medico> listar()
        {
            List<Medico> lista = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID_MEDICO, NOMBRE, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO, M.ID_ESPECIALIDAD as ESPECIALIDAD, E.TIPO as TIPO FROM MEDICOS M INNER JOIN ESPECIALIDADES E ON M.ID_ESPECIALIDAD = E.ID_ESPECIALIDAD");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medico medico = new Medico();

                    medico.Id = (int)datos.Lector["ID_MEDICO"];

                    medico.nombre = (string)datos.Lector["NOMBRE"];

                    medico.telefono = (string)datos.Lector["TELEFONO"];

                    medico.direccion = (string)datos.Lector["DIRECCION"];

                    medico.fechaNacimiento = (DateTime)datos.Lector["FECHA_NACIMIENTO"];

                    medico.mail = (string)datos.Lector["MAIL"];

                    medico.estado = (bool)datos.Lector["ESTADO"];

                    medico.Especialidades = new List<Especialidad>();
                    Especialidad nueva = new Especialidad();
                    nueva.Id = (byte)datos.Lector["ESPECIALIDAD"];
                    nueva.Tipo = (String)datos.Lector["TIPO"];
                    
                    medico.Especialidades.Add(nueva);

                    lista.Add(medico);
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
    }
}
