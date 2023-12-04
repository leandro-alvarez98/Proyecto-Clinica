using Proyecto_Clinica.Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexion_Clinica
{
    public class UsuarioConexion
    {
        public List<Usuario> Listar_todos()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("\tSELECT \r\n\t\tID_USUARIO, \r\n\t\tNOMBRE_USUARIO, \r\n\t\tCONTRASENA, TIPO, \r\n\t\tURL_IMAGEN, \r\n\t\tESTADO\r\n\tFROM USUARIOS U \r\n\tLEFT JOIN IMAGENES I ON I.ID_IMAGEN = U.ID_IMAGEN");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    if (!(datos.Lector["URL_IMAGEN"] is DBNull))
                    {
                        Usuario usuario = new Usuario
                        {
                            Id = (int)datos.Lector["ID_USUARIO"],
                            Username = (String)datos.Lector["NOMBRE_USUARIO"],
                            Contraseña = (String)datos.Lector["CONTRASENA"],
                            Tipo = (String)datos.Lector["TIPO"],
                            Imagen = (String)datos.Lector["URL_IMAGEN"],
                            Estado = (bool)datos.Lector["ESTADO"]

                        };
                        lista.Add(usuario);
                    }
                    else
                    {
                        Usuario usuario = new Usuario
                        {
                            Id = (int)datos.Lector["ID_USUARIO"],
                            Username = (String)datos.Lector["NOMBRE_USUARIO"],
                            Contraseña = (String)datos.Lector["CONTRASENA"],
                            Tipo = (String)datos.Lector["TIPO"],
                            Estado = (bool)datos.Lector["ESTADO"]
                        };
                        lista.Add(usuario);
                    }

                }
                return lista;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Usuario> Listar_Activos()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("\tSELECT \r\n\t\tID_USUARIO, \r\n\t\tNOMBRE_USUARIO, \r\n\t\tCONTRASENA, TIPO, \r\n\t\tURL_IMAGEN, \r\n\t\tESTADO\r\n\tFROM USUARIOS U \r\n\tLEFT JOIN IMAGENES I ON I.ID_IMAGEN = U.ID_IMAGEN\r\n\tWHERE ESTADO = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    if (!(datos.Lector["URL_IMAGEN"] is DBNull))
                    {
                        Usuario usuario = new Usuario
                        {
                            Id = (int)datos.Lector["ID_USUARIO"],
                            Username = (String)datos.Lector["NOMBRE_USUARIO"],
                            Contraseña = (String)datos.Lector["CONTRASENA"],
                            Tipo = (String)datos.Lector["TIPO"],
                            Imagen = (String)datos.Lector["URL_IMAGEN"],
                            Estado = (bool)datos.Lector["ESTADO"]

                        };
                        lista.Add(usuario);
                    }
                    else
                    {
                        Usuario usuario = new Usuario
                        {
                            Id = (int)datos.Lector["ID_USUARIO"],
                            Username = (String)datos.Lector["NOMBRE_USUARIO"],
                            Contraseña = (String)datos.Lector["CONTRASENA"],
                            Tipo = (String)datos.Lector["TIPO"],
                            Estado = (bool)datos.Lector["ESTADO"]
                        };
                        lista.Add(usuario);
                    }

                }
                return lista;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
               throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Usuario> Listar_Inactivos()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT \r\n\t\tID_USUARIO, \r\n\t\tNOMBRE_USUARIO, \r\n\t\tCONTRASENA, TIPO, \r\n\t\tURL_IMAGEN, \r\n\t\tESTADO\r\n\tFROM USUARIOS U \r\n\tLEFT JOIN IMAGENES I ON I.ID_IMAGEN = U.ID_IMAGEN\r\n\tWHERE ESTADO = 0");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    if (!(datos.Lector["URL_IMAGEN"] is DBNull))
                    {
                        Usuario usuario = new Usuario
                        {
                            Id = (int)datos.Lector["ID_USUARIO"],
                            Username = (String)datos.Lector["NOMBRE_USUARIO"],
                            Contraseña = (String)datos.Lector["CONTRASENA"],
                            Tipo = (String)datos.Lector["TIPO"],
                            Imagen = (String)datos.Lector["URL_IMAGEN"],
                            Estado = (bool)datos.Lector["ESTADO"]

                        };
                        lista.Add(usuario);
                    }
                    else
                    {
                        Usuario usuario = new Usuario
                        {
                            Id = (int)datos.Lector["ID_USUARIO"],
                            Username = (String)datos.Lector["NOMBRE_USUARIO"],
                            Contraseña = (String)datos.Lector["CONTRASENA"],
                            Tipo = (String)datos.Lector["TIPO"],
                            Estado = (bool)datos.Lector["ESTADO"]
                        };
                        lista.Add(usuario);
                    }

                }
                return lista;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public int Get_ID_Usuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            int id = 0;
            try
            {
                datos.setConsulta("SELECT ID_USUARIO FROM USUARIOS WHERE NOMBRE_USUARIO = @USERNAME");
                datos.setParametro("@USERNAME", usuario.Username);
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    id = (int)datos.Lector["ID_USUARIO"];
                    return id;
                }
                return id;

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void InsertarUsuarioEnBBDD(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO USUARIOS (NOMBRE_USUARIO, CONTRASENA, TIPO) VALUES(@Nombre, @Contrasena, @Tipo)");
                datos.setParametro("@Nombre", usuario.Username);
                datos.setParametro("@Contrasena", usuario.Contraseña);
                datos.setParametro("@Tipo", usuario.Tipo);
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
        public void Actualizar_Usuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE USUARIOS SET NOMBRE_USUARIO = @USERNAME, CONTRASENA = @CONTRASENA, TIPO = @TIPO WHERE ID_USUARIO = @IDUSUARIO");
                datos.setParametro("@USERNAME", usuario.Username);
                datos.setParametro("@CONTRASENA", usuario.Contraseña);
                datos.setParametro("@TIPO", usuario.Tipo);
                datos.setParametro("@IDUSUARIO", usuario.Id);
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
        public void ActualizarPaciente(Paciente paciente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                
                // Actualiza los datos en la tabla de los PACIENTES
                string queryPaciente = "UPDATE PACIENTES SET DNI = @Dni, NOMBRE = @Nombre, APELLIDO = @Apellido, TELEFONO = @Telefono, DIRECCION = @Direccion, FECHA_NACIMIENTO = @FechaNacimiento, MAIL = @Mail WHERE ID_USUARIO = @Id";
                datos.setConsulta(queryPaciente);
                datos.setParametro("@Dni", paciente.Dni);
                datos.setParametro("@Nombre", paciente.Nombre);
                datos.setParametro("@Apellido", paciente.Apellido);
                datos.setParametro("@Telefono", paciente.Telefono);
                datos.setParametro("@Direccion", paciente.Direccion);
                datos.setParametro("@FechaNacimiento", paciente.Fecha_Nacimiento);
                datos.setParametro("@Mail", paciente.Mail);
                datos.setParametro("@Id", paciente.Id_Usuario);
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
        public void ActualizarMedico(Medico medico)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Actualiza los datos en la tabla de los MEDICOS
                string queryMedico = "UPDATE MEDICOS SET DNI = @Dni, NOMBRE = @Nombre, APELLIDO = @Apellido, TELEFONO = @Telefono, DIRECCION = @Direccion, FECHA_NACIMIENTO = @FechaNacimiento, MAIL = @Mail WHERE ID_USUARIO = @Id";
                datos.setConsulta(queryMedico);
                datos.setParametro("@Dni", medico.Dni);
                datos.setParametro("@Nombre", medico.Nombre);
                datos.setParametro("@Apellido", medico.Apellido);
                datos.setParametro("@Telefono", medico.Telefono);
                datos.setParametro("@Direccion", medico.Direccion);
                datos.setParametro("@FechaNacimiento", medico.Fecha_Nacimiento);
                datos.setParametro("@Mail", medico.Mail);
                datos.setParametro("@Id", medico.Id_Usuario);
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
        public void ActualizarRecepcionista(Recepcionista recepcionista)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Actualiza los datos en la tabla de los RECEPCIONISTA
                string queryMedico = "UPDATE RECEPCIONISTA SET DNI = @Dni, NOMBRE = @Nombre, APELLIDO = @Apellido, TELEFONO = @Telefono, DIRECCION = @Direccion, FECHA_NACIMIENTO = @FechaNacimiento, MAIL = @Mail WHERE ID_USUARIO = @Id";
                datos.setConsulta(queryMedico);
                datos.setParametro("@Dni", recepcionista.Dni);
                datos.setParametro("@Nombre", recepcionista.Nombre);
                datos.setParametro("@Apellido", recepcionista.Apellido);
                datos.setParametro("@Telefono", recepcionista.Telefono);
                datos.setParametro("@Direccion", recepcionista.Direccion);
                datos.setParametro("@FechaNacimiento", recepcionista.Fecha_Nacimiento);
                datos.setParametro("@Mail", recepcionista.Mail);
                datos.setParametro("@Id", recepcionista.Id_Usuario);
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
        public void ActualizarAdministracion(Administrador administrador)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Actualiza los datos en la tabla de los ADMINISTRACION
                string queryMedico = "UPDATE ADMINISTRADOR SET DNI = @Dni, NOMBRE = @Nombre, APELLIDO = @Apellido, TELEFONO = @Telefono, DIRECCION = @Direccion, FECHA_NACIMIENTO = @FechaNacimiento, MAIL = @Mail WHERE ID_USUARIO = @Id";
                datos.setConsulta(queryMedico);
                datos.setParametro("@Dni", administrador.Dni);
                datos.setParametro("@Nombre", administrador.Nombre);
                datos.setParametro("@Apellido", administrador.Apellido);
                datos.setParametro("@Telefono", administrador.Telefono);
                datos.setParametro("@Direccion", administrador.Direccion);
                datos.setParametro("@FechaNacimiento", administrador.Fecha_Nacimiento);
                datos.setParametro("@Mail", administrador.Mail);
                datos.setParametro("@Id", administrador.Id_Usuario);
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
        public void EliminarDatos(Usuario usuario_actual)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                switch (usuario_actual.Tipo)
                {
                    case "Administrador":
                        datos.setConsulta("UPDATE ADMINISTRADOR SET ESTADO = 0 WHERE ID_USUARIO = @IDUSUARIO");
                        break;
                    case "Recepcionista":
                        datos.setConsulta("UPDATE RECEPCIONISTA SET ESTADO = 0 WHERE ID_USUARIO = @IDUSUARIO");
                        break;
                    case "Médico":
                        datos.setConsulta("UPDATE MEDICOS SET ESTADO = 0 WHERE ID_USUARIO = @IDUSUARIO");
                        break;
                    case "Paciente":
                        datos.setConsulta("UPDATE PACIENTES SET ESTADO = 0 WHERE ID_USUARIO = @IDUSUARIO");
                        break;

                }
                datos.setParametro("@IDUSUARIO", usuario_actual.Id);
                datos.ejecutarAccion();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            
        }

        public void Alta_logica_usuario(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE USUARIOS SET ESTADO = 1 WHERE ID_USUARIO = @IDUSUARIO");
                datos.setParametro("@IDUSUARIO", id);
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
        public void Baja_logica_usuario (int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE USUARIOS SET ESTADO = 0 WHERE ID_USUARIO = @IDUSUARIO");
                datos.setParametro("@IDUSUARIO", id);
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

        public void actualizarImagen(Usuario usuario_Actual)
        {
            Insertar_Imagen(usuario_Actual.Imagen);
            ActualizarImagenUsuario(usuario_Actual.Id);
        }
        private void ActualizarImagenUsuario(int ID)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE USUARIOS SET ID_IMAGEN = (SELECT MAX(ID_IMAGEN) FROM IMAGENES) WHERE ID_USUARIO = @IDUSUARIO");
                datos.setParametro("@IDUSUARIO", ID);
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
        private void Insertar_Imagen(String URL)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO IMAGENES(URL_IMAGEN) VALUES (@URL)");
                datos.setParametro("@URL", URL);
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
        public void EliminarImagen(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("delete from IMAGENES where ID_IMAGEN = (select ID_IMAGEN from USUARIOS WHERE ID_USUARIO = @IDUSUARIO)");
                datos.setParametro("@IDUSUARIO", Id);
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