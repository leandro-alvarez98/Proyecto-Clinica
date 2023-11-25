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
                datos.setConsulta("SELECT M.ID_MEDICO AS ID, U.ID_USUARIO AS IDUSUARIO, M.DNI AS DNI ,M.NOMBRE AS NOMBRE, M.APELLIDO AS APELLIDO, M.TELEFONO AS TELEFONO, M.DIRECCION AS DIRECCION, M.FECHA_NACIMIENTO AS FECHANACIMIENTO, MAIL, M.ESTADO AS ESTADO, E.ID_ESPECIALIDAD AS IDESPECIALIDAD, E.TIPO AS ESPECIALIDAD FROM MEDICOS M INNER JOIN USUARIOS U ON U.ID_USUARIO = M.ID_USUARIO INNER JOIN MEDICOSXESPECIALIDAD ME ON ME.ID_MEDICO = M.ID_MEDICO INNER JOIN ESPECIALIDADES E ON E.ID_ESPECIALIDAD = ME.ID_ESPECIALIDAD");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medico medico = new Medico
                    {
                        Id = (int)datos.Lector["ID"],

                        Id_Usuario = (int)datos.Lector["IDUSUARIO"],

                        Dni = (string)datos.Lector["DNI"],

                        Nombre = (String)datos.Lector["NOMBRE"],

                        Apellido = (String)datos.Lector["APELLIDO"],

                        Telefono = (String)datos.Lector["TELEFONO"],

                        Direccion = (String)datos.Lector["DIRECCION"],

                        Fecha_Nacimiento = (DateTime)datos.Lector["FECHANACIMIENTO"],

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
