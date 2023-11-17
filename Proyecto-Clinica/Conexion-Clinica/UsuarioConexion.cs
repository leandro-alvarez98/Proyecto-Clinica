﻿using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexion_Clinica
{
    public class UsuarioConexion
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID_USUARIO, NOMBRE_USUARIO, CONTRASENA, TIPO FROM USUARIOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        Id = (int)datos.Lector["ID_USUARIO"],
                        Nombre = (String)datos.Lector["NOMBRE_USUARIO"],
                        Contraseña = (String)datos.Lector["CONTRASENA"],
                        Tipo = (String)datos.Lector["TIPO"]
                    };

                    lista.Add(usuario);
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
                datos.setParametro("@Id", paciente.Id);
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
                datos.setParametro("@Id", medico.Id);
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
                datos.setParametro("@Id", recepcionista.Id);
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
                datos.setParametro("@Id", administrador.Id);
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

