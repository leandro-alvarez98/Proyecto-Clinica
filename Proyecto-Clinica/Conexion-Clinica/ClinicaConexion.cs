using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexion_Clinica
{
    internal class ClinicaConexion
    {
        public Clinica listar()
        {
            Clinica objetoClinica = new Clinica();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    objetoClinica.usuarios = new List<Usuario>();
                    objetoClinica.pacientes = new List<Paciente>();
                    objetoClinica.turnos = new List<Turno>();
                    objetoClinica.medicos = new List<Medico>();

                    // Primero hay que hacer los Listar() de todos los demás
                    //Despues llenar las listas de Clinica con esas funciones

                }
                return objetoClinica;
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
