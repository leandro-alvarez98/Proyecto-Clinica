using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using Proyecto_Clinica.Dominio;
using Dominio;

namespace Conexion_Clinica
{
    public class MedicoConexion
    {
        public List<Medico> Listar()
        {
            List<Medico> lista = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT \r\n        M.ID_MEDICO AS ID, \r\n        U.ID_USUARIO AS IDUSUARIO,\r\n        M.DNI AS DNI,\r\n        M.NOMBRE AS NOMBRE, \r\n        M.APELLIDO AS APELLIDO, \r\n        M.TELEFONO AS TELEFONO, \r\n        M.DIRECCION AS DIRECCION, \r\n        M.FECHA_NACIMIENTO AS FECHANACIMIENTO, \r\n        MAIL, M.ESTADO AS ESTADO,\r\n        E.ID_ESPECIALIDAD AS IDESPECIALIDAD, \r\n        E.TIPO AS ESPECIALIDAD,\r\n\t\tMJ.ID_JORNADA AS IDJORNADA,\r\n        J.TIPO_JORNADA AS JORNADA,\r\n        I.URL_IMAGEN AS URL_IMAGEN\r\n    FROM MEDICOS M \r\n    LEFT JOIN MEDICOSXESPECIALIDAD ME ON ME.ID_MEDICO = M.ID_MEDICO \r\n    LEFT JOIN ESPECIALIDADES E ON E.ID_ESPECIALIDAD = ME.ID_ESPECIALIDAD\r\n    LEFT JOIN MEDICOXJORNADA MJ ON MJ.ID_MEDICO = M.ID_MEDICO\r\n\tINNER JOIN JORNADAS J ON J.ID_JORNADA = MJ.ID_JORNADA\r\n    INNER JOIN USUARIOS U ON U.ID_USUARIO = M.ID_USUARIO \r\n    LEFT JOIN IMAGENES I ON I.ID_IMAGEN = U.ID_IMAGEN");
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

                        Jornadas = new List<Jornada>()
                    };

                    Especialidad especiliadad = new Especialidad();

                    if (!(datos.Lector["IDESPECIALIDAD"] is DBNull))
                    {
                        especiliadad.Id = (int)datos.Lector["IDESPECIALIDAD"];
                        especiliadad.Tipo = (String)datos.Lector["ESPECIALIDAD"];
                    }

                    medico.Especialidades.Add(especiliadad);

                    Jornada jornada = new Jornada();

                    if (!(datos.Lector["JORNADA"] is DBNull))
                    {
                        jornada.Id = (int)datos.Lector["IDJORNADA"];
                        jornada.Tipo = (String)datos.Lector["JORNADA"];
                    }

                    medico.Jornadas.Add(jornada);

                    if (!(datos.Lector["URL_IMAGEN"] is DBNull))
                    {
                        medico.Imagen = "~/img/" + (String)datos.Lector["URL_IMAGEN"];
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

        public void Alta_Medico (int ID )
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE MEDICOS SET ESTADO = 1 WHERE ID_MEDICO = @ID_MEDICO");
                datos.setParametro("@ID_MEDICO", ID);
                datos.ejecutarAccion();

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
        public void Baja_Medico(int ID)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE MEDICOS SET ESTADO = 0 WHERE ID_MEDICO = @ID_MEDICO");
                datos.setParametro("@ID_MEDICO", ID);
                datos.ejecutarAccion();

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
        

        public void Modificar_Especialidades(int ID)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE MEDICOSXESPECIALIDAD SET ESTADO = 1 WHERE ID_MEDICO = @ID_MEDICO");
                datos.setParametro("@ID_MEDICO", ID);
                datos.ejecutarAccion();

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

        public void InsertarMedico(Usuario usuario_actual)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO MEDICOS (ID_USUARIO, DNI, NOMBRE,APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO) VALUES(@IDUSUARIO, @DNI, @NOMBRE, @APELLIDO, @TELEFONO, @DIRECCION, @FECHANACIMIENTO, @MAIL, 1)");
                datos.setParametro("@IDUSUARIO", usuario_actual.Id);
                datos.setParametro("@DNI", usuario_actual.Dni);
                datos.setParametro("@NOMBRE", usuario_actual.Nombre);
                datos.setParametro("@APELLIDO", usuario_actual.Apellido);
                datos.setParametro("@TELEFONO", usuario_actual.Telefono);
                datos.setParametro("@DIRECCION", usuario_actual.Direccion);
                datos.setParametro("@FECHANACIMIENTO", usuario_actual.Fecha_Nacimiento);
                datos.setParametro("@MAIL", usuario_actual.Mail);
                datos.ejecutarAccion();
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
