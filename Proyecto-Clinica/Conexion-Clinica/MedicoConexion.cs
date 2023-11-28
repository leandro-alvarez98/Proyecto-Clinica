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
                datos.setConsulta("SELECT \r\n\t\tM.ID_MEDICO AS ID, \r\n\t\tU.ID_USUARIO AS IDUSUARIO,\r\n\t\tM.DNI AS DNI,\r\n\t\tM.NOMBRE AS NOMBRE, \r\n\t\tM.APELLIDO AS APELLIDO, \r\n\t\tM.TELEFONO AS TELEFONO, \r\n\t\tM.DIRECCION AS DIRECCION, \r\n\t\tM.FECHA_NACIMIENTO AS FECHANACIMIENTO, \r\n\t\tMAIL, M.ESTADO AS ESTADO,\r\n\t\tE.ID_ESPECIALIDAD AS IDESPECIALIDAD, \r\n\t\tE.TIPO AS ESPECIALIDAD,\r\n\t\tMJ.ID_JORNADA AS JORNADA,\r\n\t\tI.URL_IMAGEN AS URL\r\n\tFROM MEDICOS M \r\n\tINNER JOIN USUARIOS U ON U.ID_USUARIO = M.ID_USUARIO \r\n\tINNER JOIN MEDICOSXESPECIALIDAD ME ON ME.ID_MEDICO = M.ID_MEDICO \r\n\tINNER JOIN ESPECIALIDADES E ON E.ID_ESPECIALIDAD = ME.ID_ESPECIALIDAD\r\n\tINNER JOIN MEDICOXJORNADA MJ ON MJ.ID_MEDICO = M.ID_MEDICO\r\n\tLEFT JOIN IMAGENES I ON I.ID_IMAGEN = U.ID_USUARIO");
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

                        Especialidades = new List<Especialidad>(),

                        Jornadas = new List<int>()
                    };

                    Especialidad nueva = new Especialidad
                    {
                        Id = (byte)datos.Lector["IDESPECIALIDAD"],
                        Tipo = (String)datos.Lector["ESPECIALIDAD"]
                    };
                    medico.Especialidades.Add(nueva);

                    medico.Jornadas.Add((int)datos.Lector["JORNADA"]);

                    if (!(datos.Lector["URL"] is DBNull))
                    {
                        medico.Imagen = (String)datos.Lector["URL"];
                    }

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
