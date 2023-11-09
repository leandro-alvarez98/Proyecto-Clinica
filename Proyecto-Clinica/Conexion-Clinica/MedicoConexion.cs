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
        public List<Medico> Listar()
        {
            List<Medico> lista = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT M.ID_MEDICO AS ID, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO,E.ID_ESPECIALIDAD AS IDESPECIALIDAD, E.TIPO AS ESPECIALIDAD FROM MEDICOS M INNER JOIN MEDICOSXESPECIALIDAD ME ON ME.ID_MEDICO = M.ID_MEDICO INNER JOIN ESPECIALIDADES E ON E.ID_ESPECIALIDAD = ME.ID_ESPECIALIDAD");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medico medico = new Medico
                    {
                        Id = (int)datos.Lector["ID"],

                        Nombre = (String)datos.Lector["NOMBRE"],

                        Apellido = (String)datos.Lector["APELLIDO"],

                        Telefono = (String)datos.Lector["TELEFONO"],

                        Direccion = (String)datos.Lector["DIRECCION"],

                        Fecha_Nacimiento = (DateTime)datos.Lector["FECHA_NACIMIENTO"],

                        Mail = (String)datos.Lector["MAIL"],

                        Estado = (bool)datos.Lector["ESTADO"],

                        Especialidades = new List<Especialidad>()
                    };
                    Especialidad nueva = new Especialidad
                    {
                        Id = (byte)datos.Lector["IDESPECIALIDAD"],
                        Tipo = (String)datos.Lector["ESPECIALIDAD"]
                    };
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
